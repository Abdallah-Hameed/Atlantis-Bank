namespace Atlantis_Bank.Accounts
{
    partial class frmAddAccount
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOwnerID = new System.Windows.Forms.Label();
            this.txtOwnerID = new DonControls.DonCyberTextbox();
            this.btnSearch = new ReaLTaiizor.Controls.CyberButton();
            this.lblAccountNumber = new ReaLTaiizor.Controls.SmallLabel();
            this.lblOwnerName = new System.Windows.Forms.Label();
            this.llOwnerName = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAccountType = new ReaLTaiizor.Controls.CyberComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new ReaLTaiizor.Controls.CyberComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOpenDate = new ReaLTaiizor.Controls.SmallLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBranch = new ReaLTaiizor.Controls.CyberComboBox();
            this.tpInfo = new ReaLTaiizor.Controls.AirTabPage();
            this.tpOwnerInfo = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbOwnerType = new ReaLTaiizor.Controls.CyberComboBox();
            this.tpAccountInfo = new System.Windows.Forms.TabPage();
            this.lblAccountID = new ReaLTaiizor.Controls.SmallLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrevious = new ReaLTaiizor.Controls.CyberButton();
            this.btnNextSave = new ReaLTaiizor.Controls.CyberButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSubtitle = new ReaLTaiizor.Controls.SmallLabel();
            this.pnlAccent = new ReaLTaiizor.Controls.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tpInfo.SuspendLayout();
            this.tpOwnerInfo.SuspendLayout();
            this.tpAccountInfo.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label1.Location = new System.Drawing.Point(45, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 87;
            this.label1.Text = "Account Number:";
            // 
            // lblOwnerID
            // 
            this.lblOwnerID.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerID.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblOwnerID.Location = new System.Drawing.Point(6, 153);
            this.lblOwnerID.Name = "lblOwnerID";
            this.lblOwnerID.Size = new System.Drawing.Size(173, 18);
            this.lblOwnerID.TabIndex = 89;
            this.lblOwnerID.Text = "Owner ID:";
            this.lblOwnerID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtOwnerID
            // 
            this.txtOwnerID.Alpha = 20;
            this.txtOwnerID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtOwnerID.Background_WidthPen = 3F;
            this.txtOwnerID.BackgroundPen = true;
            this.txtOwnerID.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtOwnerID.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtOwnerID.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtOwnerID.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtOwnerID.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtOwnerID.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtOwnerID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtOwnerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtOwnerID.InputType = DonControls.DonCyberTextbox.InputTypeEnum.NumberInput;
            this.txtOwnerID.IsRequired = true;
            this.txtOwnerID.Lighting = false;
            this.txtOwnerID.LinearGradientPen = false;
            this.txtOwnerID.Location = new System.Drawing.Point(183, 146);
            this.txtOwnerID.Name = "txtOwnerID";
            this.txtOwnerID.PenWidth = 15;
            this.txtOwnerID.RGB = false;
            this.txtOwnerID.Rounding = true;
            this.txtOwnerID.RoundingInt = 60;
            this.txtOwnerID.Size = new System.Drawing.Size(143, 32);
            this.txtOwnerID.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtOwnerID.TabIndex = 90;
            this.txtOwnerID.Tag = "Cyber";
            this.txtOwnerID.TextButton = "";
            this.txtOwnerID.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtOwnerID.Timer_RGB = 300;
            // 
            // btnSearch
            // 
            this.btnSearch.Alpha = 20;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Background = true;
            this.btnSearch.Background_WidthPen = 4F;
            this.btnSearch.BackgroundPen = true;
            this.btnSearch.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearch.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearch.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearch.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnSearch.ColorLighting = System.Drawing.Color.Transparent;
            this.btnSearch.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearch.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnSearch.Effect_1 = true;
            this.btnSearch.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnSearch.Effect_1_Transparency = 25;
            this.btnSearch.Effect_2 = true;
            this.btnSearch.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnSearch.Effect_2_Transparency = 20;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnSearch.Lighting = false;
            this.btnSearch.LinearGradient_Background = false;
            this.btnSearch.LinearGradientPen = false;
            this.btnSearch.Location = new System.Drawing.Point(332, 142);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PenWidth = 15;
            this.btnSearch.Rounding = true;
            this.btnSearch.RoundingInt = 70;
            this.btnSearch.Size = new System.Drawing.Size(82, 38);
            this.btnSearch.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnSearch.TabIndex = 91;
            this.btnSearch.Tag = "Cyber";
            this.btnSearch.TextButton = "Search";
            this.btnSearch.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnSearch.Timer_Effect_1 = 5;
            this.btnSearch.Timer_RGB = 300;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNumber.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.ForeColor = System.Drawing.Color.LightGray;
            this.lblAccountNumber.Location = new System.Drawing.Point(181, 81);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(220, 18);
            this.lblAccountNumber.TabIndex = 92;
            this.lblAccountNumber.Text = "00000000";
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblOwnerName.Location = new System.Drawing.Point(9, 220);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(170, 18);
            this.lblOwnerName.TabIndex = 93;
            this.lblOwnerName.Text = "Owner Name:";
            this.lblOwnerName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // llOwnerName
            // 
            this.llOwnerName.ActiveLinkColor = System.Drawing.Color.White;
            this.llOwnerName.BackColor = System.Drawing.Color.Transparent;
            this.llOwnerName.DisabledLinkColor = System.Drawing.Color.White;
            this.llOwnerName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llOwnerName.ForeColor = System.Drawing.Color.White;
            this.llOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llOwnerName.LinkColor = System.Drawing.Color.White;
            this.llOwnerName.Location = new System.Drawing.Point(185, 220);
            this.llOwnerName.Name = "llOwnerName";
            this.llOwnerName.Size = new System.Drawing.Size(218, 41);
            this.llOwnerName.TabIndex = 94;
            this.llOwnerName.TabStop = true;
            this.llOwnerName.Text = "● Unknown";
            this.llOwnerName.VisitedLinkColor = System.Drawing.Color.White;
            this.llOwnerName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOwnerName_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label8.Location = new System.Drawing.Point(68, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 18);
            this.label8.TabIndex = 96;
            this.label8.Text = "Account Type:";
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbAccountType.ColorArrow = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbAccountType.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbAccountType.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbAccountType.ColorItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.cmbAccountType.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbAccountType.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cmbAccountType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAccountType.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cmbAccountType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAccountType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccountType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.ItemHeight = 28;
            this.cmbAccountType.Items.AddRange(new object[] {
            "Current",
            "Saving"});
            this.cmbAccountType.Location = new System.Drawing.Point(180, 123);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.RGB = false;
            this.cmbAccountType.Size = new System.Drawing.Size(224, 34);
            this.cmbAccountType.TabIndex = 95;
            this.cmbAccountType.Timer_RGB = 300;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.CausesValidation = false;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label4.Location = new System.Drawing.Point(119, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 98;
            this.label4.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbStatus.ColorArrow = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbStatus.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbStatus.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbStatus.ColorItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.cmbStatus.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbStatus.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStatus.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.ItemHeight = 28;
            this.cmbStatus.Items.AddRange(new object[] {
            "Inactive",
            "Active"});
            this.cmbStatus.Location = new System.Drawing.Point(180, 182);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.RGB = false;
            this.cmbStatus.Size = new System.Drawing.Size(224, 34);
            this.cmbStatus.TabIndex = 97;
            this.cmbStatus.Timer_RGB = 300;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.CausesValidation = false;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label5.Location = new System.Drawing.Point(88, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 18);
            this.label5.TabIndex = 99;
            this.label5.Text = "Open Date:";
            // 
            // lblOpenDate
            // 
            this.lblOpenDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOpenDate.BackColor = System.Drawing.Color.Transparent;
            this.lblOpenDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenDate.ForeColor = System.Drawing.Color.White;
            this.lblOpenDate.Location = new System.Drawing.Point(178, 311);
            this.lblOpenDate.Name = "lblOpenDate";
            this.lblOpenDate.Size = new System.Drawing.Size(220, 18);
            this.lblOpenDate.TabIndex = 100;
            this.lblOpenDate.Text = "2026/09/08";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.CausesValidation = false;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label9.Location = new System.Drawing.Point(115, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 104;
            this.label9.Text = "Branch:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbBranch.ColorArrow = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbBranch.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbBranch.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbBranch.ColorItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.cmbBranch.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbBranch.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cmbBranch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBranch.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cmbBranch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.ItemHeight = 28;
            this.cmbBranch.Location = new System.Drawing.Point(179, 243);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.RGB = false;
            this.cmbBranch.Size = new System.Drawing.Size(224, 34);
            this.cmbBranch.TabIndex = 103;
            this.cmbBranch.Timer_RGB = 300;
            // 
            // tpInfo
            // 
            this.tpInfo.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tpInfo.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpInfo.Controls.Add(this.tpOwnerInfo);
            this.tpInfo.Controls.Add(this.tpAccountInfo);
            this.tpInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tpInfo.ItemSize = new System.Drawing.Size(30, 115);
            this.tpInfo.Location = new System.Drawing.Point(3, 76);
            this.tpInfo.Multiline = true;
            this.tpInfo.Name = "tpInfo";
            this.tpInfo.NormalTextColor = System.Drawing.Color.Silver;
            this.tpInfo.SelectedIndex = 0;
            this.tpInfo.SelectedTabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpInfo.SelectedTextColor = System.Drawing.Color.White;
            this.tpInfo.ShowOuterBorders = false;
            this.tpInfo.Size = new System.Drawing.Size(620, 353);
            this.tpInfo.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tpInfo.SquareColor = System.Drawing.Color.White;
            this.tpInfo.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tpInfo.TabIndex = 106;
            // 
            // tpOwnerInfo
            // 
            this.tpOwnerInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpOwnerInfo.Controls.Add(this.label11);
            this.tpOwnerInfo.Controls.Add(this.cmbOwnerType);
            this.tpOwnerInfo.Controls.Add(this.lblOwnerID);
            this.tpOwnerInfo.Controls.Add(this.btnSearch);
            this.tpOwnerInfo.Controls.Add(this.lblOwnerName);
            this.tpOwnerInfo.Controls.Add(this.llOwnerName);
            this.tpOwnerInfo.Controls.Add(this.txtOwnerID);
            this.tpOwnerInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpOwnerInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpOwnerInfo.Location = new System.Drawing.Point(119, 4);
            this.tpOwnerInfo.Name = "tpOwnerInfo";
            this.tpOwnerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpOwnerInfo.Size = new System.Drawing.Size(497, 345);
            this.tpOwnerInfo.TabIndex = 0;
            this.tpOwnerInfo.Text = "Owner Info";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label11.Location = new System.Drawing.Point(12, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 18);
            this.label11.TabIndex = 106;
            this.label11.Text = "Owner Type:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbOwnerType
            // 
            this.cmbOwnerType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbOwnerType.ColorArrow = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbOwnerType.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbOwnerType.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbOwnerType.ColorItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.cmbOwnerType.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbOwnerType.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cmbOwnerType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbOwnerType.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cmbOwnerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOwnerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOwnerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOwnerType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOwnerType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cmbOwnerType.FormattingEnabled = true;
            this.cmbOwnerType.ItemHeight = 28;
            this.cmbOwnerType.Items.AddRange(new object[] {
            "Client",
            "Employee"});
            this.cmbOwnerType.Location = new System.Drawing.Point(183, 77);
            this.cmbOwnerType.Name = "cmbOwnerType";
            this.cmbOwnerType.RGB = false;
            this.cmbOwnerType.Size = new System.Drawing.Size(224, 34);
            this.cmbOwnerType.TabIndex = 105;
            this.cmbOwnerType.Timer_RGB = 300;
            this.cmbOwnerType.SelectedIndexChanged += new System.EventHandler(this.cmbOwnerType_SelectedIndexChanged);
            // 
            // tpAccountInfo
            // 
            this.tpAccountInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpAccountInfo.Controls.Add(this.lblAccountID);
            this.tpAccountInfo.Controls.Add(this.label2);
            this.tpAccountInfo.Controls.Add(this.label9);
            this.tpAccountInfo.Controls.Add(this.label1);
            this.tpAccountInfo.Controls.Add(this.cmbBranch);
            this.tpAccountInfo.Controls.Add(this.cmbAccountType);
            this.tpAccountInfo.Controls.Add(this.label8);
            this.tpAccountInfo.Controls.Add(this.cmbStatus);
            this.tpAccountInfo.Controls.Add(this.lblOpenDate);
            this.tpAccountInfo.Controls.Add(this.lblAccountNumber);
            this.tpAccountInfo.Controls.Add(this.label5);
            this.tpAccountInfo.Controls.Add(this.label4);
            this.tpAccountInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpAccountInfo.Location = new System.Drawing.Point(119, 4);
            this.tpAccountInfo.Name = "tpAccountInfo";
            this.tpAccountInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccountInfo.Size = new System.Drawing.Size(497, 345);
            this.tpAccountInfo.TabIndex = 1;
            this.tpAccountInfo.Text = "Account Info";
            // 
            // lblAccountID
            // 
            this.lblAccountID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAccountID.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountID.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.ForeColor = System.Drawing.Color.LightGray;
            this.lblAccountID.Location = new System.Drawing.Point(181, 37);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(220, 18);
            this.lblAccountID.TabIndex = 106;
            this.lblAccountID.Text = "-1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.label2.Location = new System.Drawing.Point(86, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 105;
            this.label2.Text = "Account ID:";
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
            this.btnPrevious.Location = new System.Drawing.Point(415, 439);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.PenWidth = 15;
            this.btnPrevious.Rounding = true;
            this.btnPrevious.RoundingInt = 70;
            this.btnPrevious.Size = new System.Drawing.Size(114, 50);
            this.btnPrevious.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnPrevious.TabIndex = 107;
            this.btnPrevious.Tag = "Cyber";
            this.btnPrevious.TextButton = "← Previous";
            this.btnPrevious.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnPrevious.Timer_Effect_1 = 5;
            this.btnPrevious.Timer_RGB = 300;
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
            this.btnNextSave.Location = new System.Drawing.Point(550, 439);
            this.btnNextSave.Name = "btnNextSave";
            this.btnNextSave.PenWidth = 15;
            this.btnNextSave.Rounding = true;
            this.btnNextSave.RoundingInt = 70;
            this.btnNextSave.Size = new System.Drawing.Size(114, 50);
            this.btnNextSave.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnNextSave.TabIndex = 108;
            this.btnNextSave.Tag = "Cyber";
            this.btnNextSave.TextButton = "Next  →";
            this.btnNextSave.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnNextSave.Timer_Effect_1 = 5;
            this.btnNextSave.Timer_RGB = 300;
            this.btnNextSave.Click += new System.EventHandler(this.btnNextSave_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblSubtitle);
            this.panel4.Controls.Add(this.pnlAccent);
            this.panel4.Controls.Add(this.lblTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(687, 75);
            this.panel4.TabIndex = 109;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubtitle.Location = new System.Drawing.Point(59, 45);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(157, 14);
            this.lblSubtitle.TabIndex = 57;
            this.lblSubtitle.Text = "Add a new system account";
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
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(37, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 33);
            this.lblTitle.TabIndex = 44;
            this.lblTitle.Text = "Add New Account";
            // 
            // frmAddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(687, 501);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnNextSave);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.tpInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddUpdateAccount_Load);
            this.tpInfo.ResumeLayout(false);
            this.tpOwnerInfo.ResumeLayout(false);
            this.tpAccountInfo.ResumeLayout(false);
            this.tpAccountInfo.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOwnerID;
        private DonControls.DonCyberTextbox txtOwnerID;
        private ReaLTaiizor.Controls.CyberButton btnSearch;
        private ReaLTaiizor.Controls.SmallLabel lblAccountNumber;
        private System.Windows.Forms.Label lblOwnerName;
        private System.Windows.Forms.LinkLabel llOwnerName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label8;
        private ReaLTaiizor.Controls.CyberComboBox cmbAccountType;
        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.CyberComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private ReaLTaiizor.Controls.SmallLabel lblOpenDate;
        private System.Windows.Forms.Label label9;
        private ReaLTaiizor.Controls.CyberComboBox cmbBranch;
        private ReaLTaiizor.Controls.AirTabPage tpInfo;
        private System.Windows.Forms.TabPage tpOwnerInfo;
        private System.Windows.Forms.TabPage tpAccountInfo;
        private System.Windows.Forms.Label label11;
        private ReaLTaiizor.Controls.CyberComboBox cmbOwnerType;
        private ReaLTaiizor.Controls.SmallLabel lblAccountID;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.CyberButton btnPrevious;
        private ReaLTaiizor.Controls.CyberButton btnNextSave;
        private System.Windows.Forms.Panel panel4;
        private ReaLTaiizor.Controls.SmallLabel lblSubtitle;
        private ReaLTaiizor.Controls.Panel pnlAccent;
        private System.Windows.Forms.Label lblTitle;
    }
}