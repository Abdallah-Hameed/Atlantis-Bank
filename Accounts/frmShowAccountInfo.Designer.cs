namespace Atlantis_Bank.Accounts
{
    partial class frmShowAccountInfo
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlAccent = new ReaLTaiizor.Controls.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new ReaLTaiizor.Controls.SmallLabel();
            this.ctrlAccountInfo1 = new Atlantis_Bank.Accounts.ctrlAccountInfo();
            this.lblStatus = new ReaLTaiizor.Controls.SmallLabel();
            this.lblBranchName = new ReaLTaiizor.Controls.SmallLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new ReaLTaiizor.Controls.CyberButton();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnlAccent);
            this.panel5.Controls.Add(this.lblTitle);
            this.panel5.Controls.Add(this.lblSubtitle);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(666, 75);
            this.panel5.TabIndex = 75;
            // 
            // pnlAccent
            // 
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.pnlAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Padding = new System.Windows.Forms.Padding(5);
            this.pnlAccent.Size = new System.Drawing.Size(5, 75);
            this.pnlAccent.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.pnlAccent.TabIndex = 70;
            this.pnlAccent.Text = "panel1";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(23, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(295, 33);
            this.lblTitle.TabIndex = 55;
            this.lblTitle.Text = "Account Information";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubtitle.Location = new System.Drawing.Point(42, 44);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(189, 14);
            this.lblSubtitle.TabIndex = 56;
            this.lblSubtitle.Text = "View system account information";
            // 
            // ctrlAccountInfo1
            // 
            this.ctrlAccountInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.ctrlAccountInfo1.Location = new System.Drawing.Point(168, 81);
            this.ctrlAccountInfo1.Name = "ctrlAccountInfo1";
            this.ctrlAccountInfo1.Size = new System.Drawing.Size(391, 266);
            this.ctrlAccountInfo1.TabIndex = 76;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.LightGray;
            this.lblStatus.Location = new System.Drawing.Point(326, 395);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(220, 18);
            this.lblStatus.TabIndex = 139;
            this.lblStatus.Text = "$ 0";
            // 
            // lblBranchName
            // 
            this.lblBranchName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBranchName.BackColor = System.Drawing.Color.Transparent;
            this.lblBranchName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchName.ForeColor = System.Drawing.Color.LightGray;
            this.lblBranchName.Location = new System.Drawing.Point(326, 353);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(220, 18);
            this.lblBranchName.TabIndex = 138;
            this.lblBranchName.Text = "Unknown";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label4.Location = new System.Drawing.Point(244, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 137;
            this.label4.Text = "Branch:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label3.Location = new System.Drawing.Point(248, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 136;
            this.label3.Text = "Status:";
            // 
            // btnClose
            // 
            this.btnClose.Alpha = 20;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Background = true;
            this.btnClose.Background_WidthPen = 4F;
            this.btnClose.BackgroundPen = true;
            this.btnClose.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnClose.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnClose.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnClose.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnClose.ColorLighting = System.Drawing.Color.Transparent;
            this.btnClose.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnClose.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnClose.Effect_1 = true;
            this.btnClose.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnClose.Effect_1_Transparency = 25;
            this.btnClose.Effect_2 = true;
            this.btnClose.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnClose.Effect_2_Transparency = 20;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnClose.Lighting = false;
            this.btnClose.LinearGradient_Background = false;
            this.btnClose.LinearGradientPen = false;
            this.btnClose.Location = new System.Drawing.Point(576, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.PenWidth = 15;
            this.btnClose.Rounding = true;
            this.btnClose.RoundingInt = 70;
            this.btnClose.Size = new System.Drawing.Size(73, 45);
            this.btnClose.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnClose.TabIndex = 140;
            this.btnClose.Tag = "Cyber";
            this.btnClose.TextButton = "Close";
            this.btnClose.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnClose.Timer_Effect_1 = 5;
            this.btnClose.Timer_RGB = 300;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowAccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(666, 455);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlAccountInfo1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowAccountInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fmrShowAccountInfo_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private ReaLTaiizor.Controls.Panel pnlAccent;
        private System.Windows.Forms.Label lblTitle;
        private ReaLTaiizor.Controls.SmallLabel lblSubtitle;
        private ctrlAccountInfo ctrlAccountInfo1;
        private ReaLTaiizor.Controls.SmallLabel lblStatus;
        private ReaLTaiizor.Controls.SmallLabel lblBranchName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.CyberButton btnClose;
    }
}