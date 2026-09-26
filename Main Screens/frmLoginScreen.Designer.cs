namespace Atlantis_Bank
{
    partial class frmLoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginScreen));
            this.ctrlDonLogin = new DonControls.DonLoginControl();
            this.SuspendLayout();
            // 
            // ctrlDonLogin
            // 
            this.ctrlDonLogin.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ctrlDonLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDonLogin.FeaturesText = "Powerful.  Secure.  Simple.";
            this.ctrlDonLogin.FeaturesTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.ctrlDonLogin.FeaturesTextFontSize = 9.75F;
            this.ctrlDonLogin.ForgotPasswordColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.ctrlDonLogin.ForgotPasswordFontSize = 9.75F;
            this.ctrlDonLogin.ForgotPasswordText = "Forgot Password?";
            this.ctrlDonLogin.LeftPanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(31)))), ((int)(((byte)(51)))));
            this.ctrlDonLogin.Location = new System.Drawing.Point(0, 0);
            this.ctrlDonLogin.LoginButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.ctrlDonLogin.LoginButtonFontSize = 12F;
            this.ctrlDonLogin.LoginButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ctrlDonLogin.LoginButtonText = "";
            this.ctrlDonLogin.Logo = ((System.Drawing.Image)(resources.GetObject("ctrlDonLogin.Logo")));
            this.ctrlDonLogin.MainTextColor = System.Drawing.Color.White;
            this.ctrlDonLogin.MainTextFontSize = 18F;
            this.ctrlDonLogin.Name = "ctrlDonLogin";
            this.ctrlDonLogin.Password = "";
            this.ctrlDonLogin.ProjectName = "Atlantis Bank";
            this.ctrlDonLogin.ProjectNameColor = System.Drawing.Color.White;
            this.ctrlDonLogin.ProjectNameFontSize = 21.75F;
            this.ctrlDonLogin.RememberMe = false;
            this.ctrlDonLogin.RightPanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ctrlDonLogin.Size = new System.Drawing.Size(984, 561);
            this.ctrlDonLogin.TabIndex = 0;
            this.ctrlDonLogin.Tagline = "Sign in to your account";
            this.ctrlDonLogin.TaglineColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.ctrlDonLogin.TaglineFontSize = 9.75F;
            this.ctrlDonLogin.Username = "";
            this.ctrlDonLogin.OnLoginClicked += new System.EventHandler(this.ctrlDonLogin_OnLoginClicked);
            this.ctrlDonLogin.OnForgotPasswordClicked += new System.EventHandler(this.ctrlDonLogin_OnForgotPasswordClicked);
            this.ctrlDonLogin.OnRememberMeChanged += new System.EventHandler(this.ctrlDonLogin_OnRememberMeChanged);
            // 
            // frmLoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.ctrlDonLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLoginScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DonControls.DonLoginControl ctrlDonLogin;
    }
}

