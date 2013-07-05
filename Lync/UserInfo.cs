using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Microsoft.Lync.Model;
using System.IO;
using UserFramework;

namespace Lync
{
    class UserInfo : IUserInfo
    {
        readonly object PropertyChangedLock = new object();
        EventHandler<UserInfoPropertyChangeEventArgs> PropertyChangedEvent;

        public event EventHandler<UserInfoPropertyChangeEventArgs> PropertyChanged
        {
            add
            {
                lock (PropertyChangedLock) { PropertyChangedEvent += value; }
            }
            remove
            {
                lock (PropertyChangedLock) { PropertyChangedEvent -= value; }
            }
        }

        public UserInfo(Contact contact)
        {
            _contact = contact;
            _contact.ContactInformationChanged += new EventHandler<ContactInformationChangedEventArgs>(_contact_ContactInformationChanged);
        }

        void _contact_ContactInformationChanged(object sender, ContactInformationChangedEventArgs e)
        {
            IEnumerable<UserPorpertyInfo> props = e.ChangedContactInformation.Select(ci =>
                                                                            {
                                                                                switch (ci)
                                                                                {
                                                                                    case ContactInformationType.Availability:
                                                                                        return UserPorpertyInfo.UserStatus;
                                                                                    case ContactInformationType.DisplayName:
                                                                                        return UserPorpertyInfo.DisplayName;
                                                                                    case ContactInformationType.FirstName:
                                                                                        return UserPorpertyInfo.FisrtName;
                                                                                    case ContactInformationType.IconStream:
                                                                                        return UserPorpertyInfo.Icon;
                                                                                    case ContactInformationType.LastName:
                                                                                        return UserPorpertyInfo.LastName;
                                                                                    case ContactInformationType.Photo:
                                                                                        return UserPorpertyInfo.Photo;
                                                                                }

                                                                                return UserPorpertyInfo.None;
                                                                            });

            OnPropertyChanged(new UserInfoPropertyChangeEventArgs(props));
        }

        protected virtual void OnPropertyChanged(UserInfoPropertyChangeEventArgs args)
        {
            EventHandler<UserInfoPropertyChangeEventArgs> handler;
            lock (PropertyChangedLock)
                handler = PropertyChangedEvent;

            if (handler != null)
                handler(this, args);
        }

        private Contact _contact;
        private Contact Contact { get { return _contact; } }

        public string Id
        {
            get { return _contact.Uri; }
        }

        public string DisplayName
        {
            get { return GetInfo<string>(ContactInformationType.DisplayName); }
        }

        public string FisrtName
        {
            get { return GetInfo<string>(ContactInformationType.FirstName); }
        }

        public string LastName
        {
            get { return GetInfo<string>(ContactInformationType.LastName); }
        }

        private T GetInfo<T>(ContactInformationType cit)
        {
            try
            {
                return (_contact == null) ? default(T) : (T)_contact.GetContactInformation(cit);
            }
            catch (NotSignedInException)
            {
                return default(T);
            }
            catch (Exception ex)
            {
                NotificationHelper.Notify(this.Notifier, "User Info", "The following user information could not be obtained: " + cit + ". " + ex.Message, Severity.Warning);
                return default(T);
            }
        }

        public Image Icon
        {
            get { return GetImageInfo(ContactInformationType.IconStream); }
        }

        public Image Photo
        {
            get { return GetImageInfo(ContactInformationType.Photo); }
        }

        private Image GetImageInfo(ContactInformationType cit)
        {
            Bitmap bmp = null;

            try
            {
                Stream stream = _contact.GetContactInformation(cit) as Stream;
                bmp = new Bitmap(stream);
            }
            catch (NotSignedInException)
            {
                
            }
            catch (Exception ex)
            {
                NotificationHelper.Notify(this.Notifier, "User Info", "The user image could not be obtained: " + ex.Message, Severity.Warning);
            }

            return bmp;
        }

        public UserStatus Status
        {
            get
            {
                ContactAvailability avai = GetInfo<ContactAvailability>(ContactInformationType.Availability);

                switch (avai)
                {
                    case ContactAvailability.Away:
                    case ContactAvailability.TemporarilyAway:
                        return UserStatus.Away;

                    case ContactAvailability.DoNotDisturb:
                    case ContactAvailability.Busy:
                    case ContactAvailability.BusyIdle:
                        return UserStatus.Busy;

                    case ContactAvailability.Free:
                    case ContactAvailability.FreeIdle:
                        return UserStatus.Available;

                    case ContactAvailability.Invalid:
                    case ContactAvailability.None:
                    case ContactAvailability.Offline:
                    default:
                        return UserStatus.Offline;
                }
            }
        }

        public INotification Notifier { get; set; }
    }
}
