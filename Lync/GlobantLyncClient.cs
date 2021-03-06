﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Lync;
using Microsoft.Lync.Utilities;
using Microsoft.Lync.Utilities.Logging;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model.Device;
using Microsoft.Lync.Model.Group;
using Microsoft.Lync.Model.Room;
using UserFramework;

namespace Lync
{
    public class GlobantLyncClient : ICommunicator
    {
        private GlobantLyncClient() { }

        private static GlobantLyncClient _Instance;
        public static GlobantLyncClient GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new GlobantLyncClient();

                if (!_Instance.CreateInstance())
                    _Instance = null;
            }

            return _Instance;
        }

        private LyncClient _Client;
        public event EventHandler<UserAddedEventArgs> UserAdded;
        public event EventHandler SignIn;
        public event EventHandler SignOut;

        private bool CreateInstance()
        {
            try
            {
                _Client = LyncClient.GetClient();
                _Client.ConversationManager.ConversationAdded += new EventHandler<ConversationManagerEventArgs>(ConversationManager_ConversationAdded);
            }
            catch (Exception e)
            {
                NotificationHelper.Notify(Notifier, "Lync Client", "Unable to create Lync instance: " + e.Message, Severity.Error);
                return false;
            }

            return true;
        }

        void ConversationManager_ConversationAdded(object sender, ConversationManagerEventArgs e)
        {
            e.Conversation.ContextDataReceived += new EventHandler<ContextEventArgs>(Conversation_ContextDataReceived);
        }

        void Conversation_ContextDataReceived(object sender, ContextEventArgs e)
        {
            string s = e.ContextData;
        }

        private bool IsClientAvailable()
        {
            if (_Client == null)
            {
                NotificationHelper.Notify(Notifier, "Lync Client", "Lync client is null.", Severity.Error);
                return false;
            }

            return true;
        }

        public void Login(string userUri, string password)
        {
            if (!IsClientAvailable()) return;

            if (_Client.InSuppressedMode)
            {
                try
                {
                    _Client.BeginInitialize(InitializeCallback, new string[] { userUri, password });
                }
                catch (AlreadyInitializedException)
                {
                    BeginSignIn(userUri, password);
                }
                catch (Exception ex)
                {
                    NotificationHelper.Notify(Notifier, "Lync Client", "Lync client sign in error: " + ex.Message, Severity.Error);
                }
            }
            else
                BeginSignIn(userUri, password);
        }

        private void InitializeCallback(IAsyncResult ar)
        {
            if (!ar.IsCompleted)
                return;

            _Client.EndInitialize(ar);

            string[] login = ar.AsyncState as string[];
            BeginSignIn(login[0], login[1]);
        }

        private void BeginSignIn(string userUri, string password)
        {
            if (_Client.State == ClientState.SignedIn)
            {
                OnSignIn();
                return;
            }

            try
            {
                _Client.BeginSignIn(userUri, string.Empty, password, SignInCallback, null);
            }
            catch (Exception ex)
            {
                NotificationHelper.Notify(Notifier, "Lync Client", "Lync client sign in error: " + ex.Message, Severity.Error);
            }
        }

        private void SignInCallback(IAsyncResult ar)
        {
            if (!ar.IsCompleted)
                return;

            _Client.EndSignIn(ar);
            OnSignIn();
        }

        protected void OnSignIn()
        {
            if (SignIn != null)
                SignIn(this, EventArgs.Empty);
        }

        public void Disconnect()
        {
            if (!IsClientAvailable()) return;

            if (_Client.State == ClientState.SignedOut)
                OnSignOut();
            else
                _Client.BeginSignOut(SignOutCallback, null);
        }

        private void SignOutCallback(IAsyncResult ar)
        {
            if (!ar.IsCompleted)
                return;

            _Client.EndSignOut(ar);

            if (_Self != null)
                lock (_SelfLock) { _Self = null; }

            if (_Client.InSuppressedMode)
                _Client.BeginShutdown((ar2) => { _Client.EndShutdown(ar2); }, null);

            this._Self = null;
            this._Client = null;
            _Instance = null;

            OnSignOut();
        }

        protected void OnSignOut()
        {
            if (SignOut != null)
                SignOut(this, EventArgs.Empty);
        }

        private IUserInfo CreateUserInfo(Contact contact)
        {
            IUserInfo userinfo = new UserInfo(contact);
            userinfo.Notifier = Notifier;

            return userinfo;
        }

        public void LoadUsers()
        {
            if (!IsClientAvailable()) return;

            _Client.ContactManager.GroupAdded += new EventHandler<GroupCollectionChangedEventArgs>(ContactManager_GroupAdded);

            foreach (Group g in _Client.ContactManager.Groups)
            {
                g.ContactAdded += new EventHandler<GroupMemberChangedEventArgs>(g_ContactAdded);

                foreach (Contact c in g)
                    OnUserAdded(new UserAddedEventArgs(CreateUserInfo(c)));
            }
        }

        void g_ContactAdded(object sender, GroupMemberChangedEventArgs e)
        {
            OnUserAdded(new UserAddedEventArgs(CreateUserInfo(e.Contact)));
        }

        void ContactManager_GroupAdded(object sender, GroupCollectionChangedEventArgs e)
        {
            foreach (Contact c in e.Group)
                OnUserAdded(new UserAddedEventArgs(CreateUserInfo(c)));
        }

        protected virtual void OnUserAdded(UserAddedEventArgs args)
        {
            if (UserAdded != null)
                UserAdded(this, args);
        }

        SelfUserInfo _Self;
        readonly object _SelfLock = new object();

        public ISelfUserInfo Self
        {
            get
            {
                if (!IsClientAvailable())
                    return null;

                if (_Self == null)
                {
                    lock (_SelfLock)
                    {
                        _Self = new SelfUserInfo(_Client.Self);
                        _Self.Notifier = Notifier;
                    }
                }

                return _Self;
            }
        }

        public static INotification Notifier { get; set; }
    }
}
