namespace Lync
{
    partial class ctlUserItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.toolIcon = new System.Windows.Forms.ToolTip(this.components);
            this.toolStatus = new System.Windows.Forms.ToolTip(this.components);
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.picShowContactCard = new System.Windows.Forms.PictureBox();
            this.picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShowContactCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.Location = new System.Drawing.Point(41, 12);
            this.lblDisplayName.Margin = new System.Windows.Forms.Padding(3);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(96, 15);
            this.lblDisplayName.TabIndex = 0;
            this.lblDisplayName.Text = "Display Name";
            // 
            // picStatus
            // 
            this.picStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picStatus.Location = new System.Drawing.Point(280, 11);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(16, 16);
            this.picStatus.TabIndex = 3;
            this.picStatus.TabStop = false;
            this.picStatus.MouseLeave += new System.EventHandler(this.picStatus_MouseLeave);
            this.picStatus.MouseHover += new System.EventHandler(this.picStatus_MouseHover);
            // 
            // picShowContactCard
            // 
            this.picShowContactCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picShowContactCard.Image = global::Lync.Properties.Resources.ArrowUserCard;
            this.picShowContactCard.Location = new System.Drawing.Point(302, 11);
            this.picShowContactCard.Name = "picShowContactCard";
            this.picShowContactCard.Size = new System.Drawing.Size(16, 16);
            this.picShowContactCard.TabIndex = 2;
            this.picShowContactCard.TabStop = false;
            this.picShowContactCard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picShowContactCard_MouseUp);
            // 
            // picIcon
            // 
            this.picIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picIcon.Image = global::Lync.Properties.Resources.icon_user_32px;
            this.picIcon.Location = new System.Drawing.Point(3, 3);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(32, 32);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            this.picIcon.MouseLeave += new System.EventHandler(this.picIcon_MouseLeave);
            this.picIcon.MouseHover += new System.EventHandler(this.picIcon_MouseHover);
            // 
            // ctlUserItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.picShowContactCard);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblDisplayName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ctlUserItem";
            this.Size = new System.Drawing.Size(321, 38);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShowContactCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.PictureBox picShowContactCard;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.ToolTip toolIcon;
        private System.Windows.Forms.ToolTip toolStatus;
    }
}
