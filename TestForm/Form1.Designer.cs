using Lync;
namespace TestForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tsStatus = new System.Windows.Forms.ToolStrip();
            this.tsbStatus = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAvailable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBusy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAway = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lstUsers = new Lync.ctlUserList();
            this.tsStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(12, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(255, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "User URI";
            // 
            // tsStatus
            // 
            this.tsStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.tsStatus.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStatus});
            this.tsStatus.Location = new System.Drawing.Point(270, 70);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Padding = new System.Windows.Forms.Padding(0);
            this.tsStatus.Size = new System.Drawing.Size(34, 25);
            this.tsStatus.TabIndex = 7;
            // 
            // tsbStatus
            // 
            this.tsbStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.mnuAvailable,
            this.mnuBusy,
            this.mnuAway,
            this.mnuDisconnect});
            this.tsbStatus.Image = global::TestForm.Properties.Resources.SignIn;
            this.tsbStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStatus.Name = "tsbStatus";
            this.tsbStatus.Size = new System.Drawing.Size(32, 22);
            this.tsbStatus.Text = "toolStripSplitButton1";
            // 
            // mnuConnect
            // 
            this.mnuConnect.Image = global::TestForm.Properties.Resources.SignIn;
            this.mnuConnect.Name = "mnuConnect";
            this.mnuConnect.Size = new System.Drawing.Size(133, 22);
            this.mnuConnect.Text = "Connect";
            this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
            // 
            // mnuAvailable
            // 
            this.mnuAvailable.Image = global::TestForm.Properties.Resources.StatusOnline;
            this.mnuAvailable.Name = "mnuAvailable";
            this.mnuAvailable.Size = new System.Drawing.Size(133, 22);
            this.mnuAvailable.Text = "Available";
            this.mnuAvailable.Visible = false;
            this.mnuAvailable.Click += new System.EventHandler(this.mnuAvailable_Click);
            // 
            // mnuBusy
            // 
            this.mnuBusy.Image = global::TestForm.Properties.Resources.StatusBusy;
            this.mnuBusy.Name = "mnuBusy";
            this.mnuBusy.Size = new System.Drawing.Size(133, 22);
            this.mnuBusy.Text = "Busy";
            this.mnuBusy.Visible = false;
            this.mnuBusy.Click += new System.EventHandler(this.mnuBusy_Click);
            // 
            // mnuAway
            // 
            this.mnuAway.Image = global::TestForm.Properties.Resources.StatusAway;
            this.mnuAway.Name = "mnuAway";
            this.mnuAway.Size = new System.Drawing.Size(133, 22);
            this.mnuAway.Text = "Away";
            this.mnuAway.Visible = false;
            this.mnuAway.Click += new System.EventHandler(this.mnuAway_Click);
            // 
            // mnuDisconnect
            // 
            this.mnuDisconnect.Image = global::TestForm.Properties.Resources.StatusOffline;
            this.mnuDisconnect.Name = "mnuDisconnect";
            this.mnuDisconnect.Size = new System.Drawing.Size(133, 22);
            this.mnuDisconnect.Text = "Disconnect";
            this.mnuDisconnect.Visible = false;
            this.mnuDisconnect.Click += new System.EventHandler(this.mnuDisconnect_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.Location = new System.Drawing.Point(12, 417);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(291, 25);
            this.lblMsg.TabIndex = 8;
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstUsers.AutoScroll = true;
            this.lstUsers.BackColor = System.Drawing.Color.White;
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstUsers.Location = new System.Drawing.Point(12, 98);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(291, 316);
            this.lstUsers.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 450);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.tsStatus);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Lync Test";
            this.tsStatus.ResumeLayout(false);
            this.tsStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ctlUserList lstUsers;
        private System.Windows.Forms.ToolStrip tsStatus;
        private System.Windows.Forms.ToolStripSplitButton tsbStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuConnect;
        private System.Windows.Forms.ToolStripMenuItem mnuAvailable;
        private System.Windows.Forms.ToolStripMenuItem mnuBusy;
        private System.Windows.Forms.ToolStripMenuItem mnuAway;
        private System.Windows.Forms.ToolStripMenuItem mnuDisconnect;
        private System.Windows.Forms.Label lblMsg;

    }
}

