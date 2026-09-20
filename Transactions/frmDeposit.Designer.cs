namespace Atlantis_Bank.Transactions
{
    partial class frmDeposit
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
            this.tpInfo = new ReaLTaiizor.Controls.AirTabPage();
            this.tpAccountInfo = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new ReaLTaiizor.Controls.CyberButton();
            this.txtAccountID = new DonControls.DonCyberTextbox();
            this.ctrlAccountInfo1 = new Atlantis_Bank.Accounts.ctrlAccountInfo();
            this.tpDepositDetails = new System.Windows.Forms.TabPage();
            this.lblBalanceAfterDeposit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeposit = new ReaLTaiizor.Controls.CyberButton();
            this.txtDepositAmount = new DonControls.DonCyberTextbox();
            this.btnPrevious = new ReaLTaiizor.Controls.CyberButton();
            this.btnNextSave = new ReaLTaiizor.Controls.CyberButton();
            this.panel5.SuspendLayout();
            this.tpInfo.SuspendLayout();
            this.tpAccountInfo.SuspendLayout();
            this.tpDepositDetails.SuspendLayout();
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
            this.panel5.Size = new System.Drawing.Size(753, 75);
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
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(21, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 33);
            this.lblTitle.TabIndex = 55;
            this.lblTitle.Text = "Deposit";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubtitle.Location = new System.Drawing.Point(43, 42);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(144, 14);
            this.lblSubtitle.TabIndex = 56;
            this.lblSubtitle.Text = "Add funds to an account";
            // 
            // tpInfo
            // 
            this.tpInfo.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tpInfo.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpInfo.Controls.Add(this.tpAccountInfo);
            this.tpInfo.Controls.Add(this.tpDepositDetails);
            this.tpInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tpInfo.ItemSize = new System.Drawing.Size(30, 115);
            this.tpInfo.Location = new System.Drawing.Point(2, 81);
            this.tpInfo.Multiline = true;
            this.tpInfo.Name = "tpInfo";
            this.tpInfo.NormalTextColor = System.Drawing.Color.Silver;
            this.tpInfo.SelectedIndex = 0;
            this.tpInfo.SelectedTabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpInfo.SelectedTextColor = System.Drawing.Color.White;
            this.tpInfo.ShowOuterBorders = false;
            this.tpInfo.Size = new System.Drawing.Size(709, 336);
            this.tpInfo.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tpInfo.SquareColor = System.Drawing.Color.White;
            this.tpInfo.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tpInfo.TabIndex = 81;
            // 
            // tpAccountInfo
            // 
            this.tpAccountInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpAccountInfo.Controls.Add(this.lblStatus);
            this.tpAccountInfo.Controls.Add(this.label1);
            this.tpAccountInfo.Controls.Add(this.btnFind);
            this.tpAccountInfo.Controls.Add(this.txtAccountID);
            this.tpAccountInfo.Controls.Add(this.ctrlAccountInfo1);
            this.tpAccountInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpAccountInfo.Location = new System.Drawing.Point(119, 4);
            this.tpAccountInfo.Name = "tpAccountInfo";
            this.tpAccountInfo.Size = new System.Drawing.Size(586, 328);
            this.tpAccountInfo.TabIndex = 3;
            this.tpAccountInfo.Text = "Account Info";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(265, 297);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(109, 18);
            this.lblStatus.TabIndex = 98;
            this.lblStatus.Text = "Not Specified";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(184, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 97;
            this.label1.Text = "Status:";
            // 
            // btnFind
            // 
            this.btnFind.Alpha = 20;
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.Background = true;
            this.btnFind.Background_WidthPen = 4F;
            this.btnFind.BackgroundPen = true;
            this.btnFind.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnFind.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnFind.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnFind.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnFind.ColorLighting = System.Drawing.Color.Transparent;
            this.btnFind.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnFind.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnFind.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnFind.Effect_1 = true;
            this.btnFind.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnFind.Effect_1_Transparency = 25;
            this.btnFind.Effect_2 = true;
            this.btnFind.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnFind.Effect_2_Transparency = 20;
            this.btnFind.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnFind.Lighting = false;
            this.btnFind.LinearGradient_Background = false;
            this.btnFind.LinearGradientPen = false;
            this.btnFind.Location = new System.Drawing.Point(426, 27);
            this.btnFind.Name = "btnFind";
            this.btnFind.PenWidth = 15;
            this.btnFind.Rounding = true;
            this.btnFind.RoundingInt = 70;
            this.btnFind.Size = new System.Drawing.Size(79, 40);
            this.btnFind.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnFind.TabIndex = 95;
            this.btnFind.Tag = "Cyber";
            this.btnFind.TextButton = "Find";
            this.btnFind.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnFind.Timer_Effect_1 = 5;
            this.btnFind.Timer_RGB = 300;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtAccountID
            // 
            this.txtAccountID.Alpha = 20;
            this.txtAccountID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtAccountID.Background_WidthPen = 3F;
            this.txtAccountID.BackgroundPen = true;
            this.txtAccountID.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtAccountID.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtAccountID.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtAccountID.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtAccountID.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtAccountID.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtAccountID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtAccountID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtAccountID.InputType = DonControls.DonCyberTextbox.InputTypeEnum.NumberInput;
            this.txtAccountID.IsRequired = true;
            this.txtAccountID.Lighting = false;
            this.txtAccountID.LinearGradientPen = false;
            this.txtAccountID.Location = new System.Drawing.Point(269, 30);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.PenWidth = 15;
            this.txtAccountID.RGB = false;
            this.txtAccountID.Rounding = true;
            this.txtAccountID.RoundingInt = 60;
            this.txtAccountID.Size = new System.Drawing.Size(146, 32);
            this.txtAccountID.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtAccountID.TabIndex = 94;
            this.txtAccountID.Tag = "Cyber";
            this.txtAccountID.TextButton = "";
            this.txtAccountID.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtAccountID.Timer_RGB = 300;
            // 
            // ctrlAccountInfo1
            // 
            this.ctrlAccountInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.ctrlAccountInfo1.Location = new System.Drawing.Point(104, 26);
            this.ctrlAccountInfo1.Name = "ctrlAccountInfo1";
            this.ctrlAccountInfo1.Size = new System.Drawing.Size(391, 259);
            this.ctrlAccountInfo1.TabIndex = 96;
            // 
            // tpDepositDetails
            // 
            this.tpDepositDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpDepositDetails.Controls.Add(this.lblBalanceAfterDeposit);
            this.tpDepositDetails.Controls.Add(this.label5);
            this.tpDepositDetails.Controls.Add(this.label2);
            this.tpDepositDetails.Controls.Add(this.btnDeposit);
            this.tpDepositDetails.Controls.Add(this.txtDepositAmount);
            this.tpDepositDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpDepositDetails.Location = new System.Drawing.Point(119, 4);
            this.tpDepositDetails.Name = "tpDepositDetails";
            this.tpDepositDetails.Size = new System.Drawing.Size(586, 328);
            this.tpDepositDetails.TabIndex = 2;
            this.tpDepositDetails.Text = "Deposit Details";
            // 
            // lblBalanceAfterDeposit
            // 
            this.lblBalanceAfterDeposit.AutoSize = true;
            this.lblBalanceAfterDeposit.BackColor = System.Drawing.Color.Transparent;
            this.lblBalanceAfterDeposit.Enabled = false;
            this.lblBalanceAfterDeposit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceAfterDeposit.ForeColor = System.Drawing.Color.White;
            this.lblBalanceAfterDeposit.Location = new System.Drawing.Point(268, 152);
            this.lblBalanceAfterDeposit.Name = "lblBalanceAfterDeposit";
            this.lblBalanceAfterDeposit.Size = new System.Drawing.Size(32, 18);
            this.lblBalanceAfterDeposit.TabIndex = 104;
            this.lblBalanceAfterDeposit.Text = "$ 0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(73, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 18);
            this.label5.TabIndex = 103;
            this.label5.Text = "Balance After Deposit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(118, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 100;
            this.label2.Text = "Deposit Amount:";
            // 
            // btnDeposit
            // 
            this.btnDeposit.Alpha = 20;
            this.btnDeposit.BackColor = System.Drawing.Color.Transparent;
            this.btnDeposit.Background = true;
            this.btnDeposit.Background_WidthPen = 4F;
            this.btnDeposit.BackgroundPen = true;
            this.btnDeposit.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnDeposit.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnDeposit.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnDeposit.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnDeposit.ColorLighting = System.Drawing.Color.Transparent;
            this.btnDeposit.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnDeposit.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnDeposit.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnDeposit.Effect_1 = true;
            this.btnDeposit.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDeposit.Effect_1_Transparency = 25;
            this.btnDeposit.Effect_2 = true;
            this.btnDeposit.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnDeposit.Effect_2_Transparency = 20;
            this.btnDeposit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnDeposit.Lighting = false;
            this.btnDeposit.LinearGradient_Background = false;
            this.btnDeposit.LinearGradientPen = false;
            this.btnDeposit.Location = new System.Drawing.Point(237, 248);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.PenWidth = 15;
            this.btnDeposit.Rounding = true;
            this.btnDeposit.RoundingInt = 70;
            this.btnDeposit.Size = new System.Drawing.Size(98, 40);
            this.btnDeposit.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnDeposit.TabIndex = 99;
            this.btnDeposit.Tag = "Cyber";
            this.btnDeposit.TextButton = "Deposit";
            this.btnDeposit.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnDeposit.Timer_Effect_1 = 5;
            this.btnDeposit.Timer_RGB = 300;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // txtDepositAmount
            // 
            this.txtDepositAmount.Alpha = 20;
            this.txtDepositAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtDepositAmount.Background_WidthPen = 3F;
            this.txtDepositAmount.BackgroundPen = true;
            this.txtDepositAmount.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtDepositAmount.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtDepositAmount.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtDepositAmount.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtDepositAmount.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtDepositAmount.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtDepositAmount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtDepositAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtDepositAmount.InputType = DonControls.DonCyberTextbox.InputTypeEnum.NumberInput;
            this.txtDepositAmount.IsRequired = true;
            this.txtDepositAmount.Lighting = false;
            this.txtDepositAmount.LinearGradientPen = false;
            this.txtDepositAmount.Location = new System.Drawing.Point(264, 80);
            this.txtDepositAmount.Name = "txtDepositAmount";
            this.txtDepositAmount.PenWidth = 15;
            this.txtDepositAmount.RGB = false;
            this.txtDepositAmount.Rounding = true;
            this.txtDepositAmount.RoundingInt = 60;
            this.txtDepositAmount.Size = new System.Drawing.Size(146, 32);
            this.txtDepositAmount.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtDepositAmount.TabIndex = 98;
            this.txtDepositAmount.Tag = "Cyber";
            this.txtDepositAmount.TextButton = "";
            this.txtDepositAmount.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtDepositAmount.Timer_RGB = 300;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Alpha = 20;
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Background = true;
            this.btnPrevious.Background_WidthPen = 4F;
            this.btnPrevious.BackgroundPen = true;
            this.btnPrevious.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnPrevious.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnPrevious.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnPrevious.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnPrevious.ColorLighting = System.Drawing.Color.Transparent;
            this.btnPrevious.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnPrevious.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnPrevious.Effect_1 = true;
            this.btnPrevious.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnPrevious.Effect_1_Transparency = 25;
            this.btnPrevious.Effect_2 = true;
            this.btnPrevious.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnPrevious.Effect_2_Transparency = 20;
            this.btnPrevious.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnPrevious.Lighting = false;
            this.btnPrevious.LinearGradient_Background = false;
            this.btnPrevious.LinearGradientPen = false;
            this.btnPrevious.Location = new System.Drawing.Point(487, 426);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.PenWidth = 15;
            this.btnPrevious.Rounding = true;
            this.btnPrevious.RoundingInt = 70;
            this.btnPrevious.Size = new System.Drawing.Size(114, 50);
            this.btnPrevious.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnPrevious.TabIndex = 83;
            this.btnPrevious.Tag = "Cyber";
            this.btnPrevious.TextButton = "← Previous";
            this.btnPrevious.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnPrevious.Timer_Effect_1 = 5;
            this.btnPrevious.Timer_RGB = 300;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click_1);
            // 
            // btnNextSave
            // 
            this.btnNextSave.Alpha = 20;
            this.btnNextSave.BackColor = System.Drawing.Color.Transparent;
            this.btnNextSave.Background = true;
            this.btnNextSave.Background_WidthPen = 4F;
            this.btnNextSave.BackgroundPen = true;
            this.btnNextSave.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnNextSave.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnNextSave.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnNextSave.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnNextSave.ColorLighting = System.Drawing.Color.Transparent;
            this.btnNextSave.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnNextSave.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnNextSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextSave.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnNextSave.Effect_1 = true;
            this.btnNextSave.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnNextSave.Effect_1_Transparency = 25;
            this.btnNextSave.Effect_2 = true;
            this.btnNextSave.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnNextSave.Effect_2_Transparency = 20;
            this.btnNextSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnNextSave.Lighting = false;
            this.btnNextSave.LinearGradient_Background = false;
            this.btnNextSave.LinearGradientPen = false;
            this.btnNextSave.Location = new System.Drawing.Point(614, 426);
            this.btnNextSave.Name = "btnNextSave";
            this.btnNextSave.PenWidth = 15;
            this.btnNextSave.Rounding = true;
            this.btnNextSave.RoundingInt = 70;
            this.btnNextSave.Size = new System.Drawing.Size(114, 50);
            this.btnNextSave.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnNextSave.TabIndex = 82;
            this.btnNextSave.Tag = "Cyber";
            this.btnNextSave.TextButton = "Next  →";
            this.btnNextSave.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnNextSave.Timer_Effect_1 = 5;
            this.btnNextSave.Timer_RGB = 300;
            this.btnNextSave.Click += new System.EventHandler(this.btnNextSave_Click_1);
            // 
            // frmDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(753, 488);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNextSave);
            this.Controls.Add(this.tpInfo);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDeposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDeposit_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tpInfo.ResumeLayout(false);
            this.tpAccountInfo.ResumeLayout(false);
            this.tpAccountInfo.PerformLayout();
            this.tpDepositDetails.ResumeLayout(false);
            this.tpDepositDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private ReaLTaiizor.Controls.Panel pnlAccent;
        private System.Windows.Forms.Label lblTitle;
        private ReaLTaiizor.Controls.SmallLabel lblSubtitle;
        private ReaLTaiizor.Controls.AirTabPage tpInfo;
        private System.Windows.Forms.TabPage tpAccountInfo;
        private ReaLTaiizor.Controls.CyberButton btnFind;
        private DonControls.DonCyberTextbox txtAccountID;
        private Accounts.ctrlAccountInfo ctrlAccountInfo1;
        private System.Windows.Forms.TabPage tpDepositDetails;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.CyberButton btnPrevious;
        private ReaLTaiizor.Controls.CyberButton btnNextSave;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.CyberButton btnDeposit;
        private DonControls.DonCyberTextbox txtDepositAmount;
        private System.Windows.Forms.Label lblBalanceAfterDeposit;
        private System.Windows.Forms.Label label5;
    }
}