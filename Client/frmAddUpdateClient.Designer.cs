namespace Atlantis_Bank
{
    partial class frmAddUpdateClient
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
            this.llImage = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new ReaLTaiizor.Controls.SmallLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlAccent = new ReaLTaiizor.Controls.Panel();
            this.btnPrevious = new ReaLTaiizor.Controls.CyberButton();
            this.btnNextSave = new ReaLTaiizor.Controls.CyberButton();
            this.tpInfo = new ReaLTaiizor.Controls.AirTabPage();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.rbFemale = new ReaLTaiizor.Controls.CyberRadioButton();
            this.rbMale = new ReaLTaiizor.Controls.CyberRadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new ReaLTaiizor.Controls.PoisonDateTime();
            this.txtNationalNo = new DonControls.DonCyberTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new DonControls.DonCyberTextbox();
            this.txtLastName = new DonControls.DonCyberTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSecondName = new DonControls.DonCyberTextbox();
            this.tpContactInfo = new System.Windows.Forms.TabPage();
            this.txtAddress = new DonControls.DonCyberTextbox();
            this.cmbCountry = new ReaLTaiizor.Controls.CyberComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPhone = new DonControls.DonCyberTextbox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEmail = new DonControls.DonCyberTextbox();
            this.tpEmployeeInfo = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.cmbBranch = new ReaLTaiizor.Controls.CyberComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.tpInfo.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpContactInfo.SuspendLayout();
            this.tpEmployeeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // llImage
            // 
            this.llImage.ActiveLinkColor = System.Drawing.Color.Navy;
            this.llImage.AutoSize = true;
            this.llImage.BackColor = System.Drawing.Color.Gainsboro;
            this.llImage.DisabledLinkColor = System.Drawing.Color.Navy;
            this.llImage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llImage.ForeColor = System.Drawing.Color.Navy;
            this.llImage.LinkColor = System.Drawing.Color.Navy;
            this.llImage.Location = new System.Drawing.Point(799, 358);
            this.llImage.Name = "llImage";
            this.llImage.Size = new System.Drawing.Size(91, 19);
            this.llImage.TabIndex = 27;
            this.llImage.TabStop = true;
            this.llImage.Text = "Set image";
            this.llImage.VisitedLinkColor = System.Drawing.Color.Navy;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(37, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(222, 33);
            this.lblTitle.TabIndex = 44;
            this.lblTitle.Text = "Add New Client";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubtitle.Location = new System.Drawing.Point(64, 45);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(194, 14);
            this.lblSubtitle.TabIndex = 57;
            this.lblSubtitle.Text = "Add and update client information";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblSubtitle);
            this.panel4.Controls.Add(this.pnlAccent);
            this.panel4.Controls.Add(this.lblTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(911, 75);
            this.panel4.TabIndex = 74;
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
            this.btnPrevious.Location = new System.Drawing.Point(655, 463);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.PenWidth = 15;
            this.btnPrevious.Rounding = true;
            this.btnPrevious.RoundingInt = 70;
            this.btnPrevious.Size = new System.Drawing.Size(114, 50);
            this.btnPrevious.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnPrevious.TabIndex = 77;
            this.btnPrevious.Tag = "Cyber";
            this.btnPrevious.TextButton = "← Previous";
            this.btnPrevious.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnPrevious.Timer_Effect_1 = 5;
            this.btnPrevious.Timer_RGB = 300;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
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
            this.btnNextSave.Location = new System.Drawing.Point(775, 463);
            this.btnNextSave.Name = "btnNextSave";
            this.btnNextSave.PenWidth = 15;
            this.btnNextSave.Rounding = true;
            this.btnNextSave.RoundingInt = 70;
            this.btnNextSave.Size = new System.Drawing.Size(114, 50);
            this.btnNextSave.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnNextSave.TabIndex = 76;
            this.btnNextSave.Tag = "Cyber";
            this.btnNextSave.TextButton = "Next  →";
            this.btnNextSave.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnNextSave.Timer_Effect_1 = 5;
            this.btnNextSave.Timer_RGB = 300;
            this.btnNextSave.Click += new System.EventHandler(this.btnNextSave_Click);
            // 
            // tpInfo
            // 
            this.tpInfo.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tpInfo.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpInfo.Controls.Add(this.tpPersonalInfo);
            this.tpInfo.Controls.Add(this.tpContactInfo);
            this.tpInfo.Controls.Add(this.tpEmployeeInfo);
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
            this.tpInfo.Size = new System.Drawing.Size(620, 381);
            this.tpInfo.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tpInfo.SquareColor = System.Drawing.Color.White;
            this.tpInfo.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tpInfo.TabIndex = 75;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpPersonalInfo.Controls.Add(this.rbFemale);
            this.tpPersonalInfo.Controls.Add(this.rbMale);
            this.tpPersonalInfo.Controls.Add(this.label4);
            this.tpPersonalInfo.Controls.Add(this.label7);
            this.tpPersonalInfo.Controls.Add(this.dtpDateOfBirth);
            this.tpPersonalInfo.Controls.Add(this.txtNationalNo);
            this.tpPersonalInfo.Controls.Add(this.label5);
            this.tpPersonalInfo.Controls.Add(this.label1);
            this.tpPersonalInfo.Controls.Add(this.txtFirstName);
            this.tpPersonalInfo.Controls.Add(this.txtLastName);
            this.tpPersonalInfo.Controls.Add(this.label2);
            this.tpPersonalInfo.Controls.Add(this.label3);
            this.tpPersonalInfo.Controls.Add(this.txtSecondName);
            this.tpPersonalInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpPersonalInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPersonalInfo.Location = new System.Drawing.Point(119, 4);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(497, 373);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            // 
            // rbFemale
            // 
            this.rbFemale.BackColor = System.Drawing.Color.Transparent;
            this.rbFemale.Background = true;
            this.rbFemale.Background_WidthPen = 2F;
            this.rbFemale.BackgroundPen = true;
            this.rbFemale.Checked = false;
            this.rbFemale.Color_1_Background_value = System.Drawing.Color.Empty;
            this.rbFemale.Color_2_Background_value = System.Drawing.Color.Empty;
            this.rbFemale.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.rbFemale.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.rbFemale.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.rbFemale.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.rbFemale.ColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.rbFemale.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.rbFemale.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.rbFemale.CyberRadioButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.rbFemale.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.rbFemale.Effect_1_Transparency = 25;
            this.rbFemale.Effect_2 = true;
            this.rbFemale.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.rbFemale.Effect_2_Transparency = 15;
            this.rbFemale.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.rbFemale.LinearGradient_Background = false;
            this.rbFemale.LinearGradient_Value = false;
            this.rbFemale.LinearGradientPen = false;
            this.rbFemale.Location = new System.Drawing.Point(296, 244);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.RGB = false;
            this.rbFemale.Rounding = true;
            this.rbFemale.RoundingInt = 100;
            this.rbFemale.Size = new System.Drawing.Size(103, 45);
            this.rbFemale.SizeChecked = 8;
            this.rbFemale.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.rbFemale.TabIndex = 62;
            this.rbFemale.Tag = "Cyber";
            this.rbFemale.TextButton = "Female";
            this.rbFemale.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.rbFemale.Timer_Effect_1 = 1;
            this.rbFemale.Timer_RGB = 300;
            this.rbFemale.Click += new System.EventHandler(this.rbFemale_Click_1);
            // 
            // rbMale
            // 
            this.rbMale.BackColor = System.Drawing.Color.Transparent;
            this.rbMale.Background = true;
            this.rbMale.Background_WidthPen = 2F;
            this.rbMale.BackgroundPen = true;
            this.rbMale.Checked = true;
            this.rbMale.Color_1_Background_value = System.Drawing.Color.Empty;
            this.rbMale.Color_2_Background_value = System.Drawing.Color.Empty;
            this.rbMale.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.rbMale.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.rbMale.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.rbMale.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.rbMale.ColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.rbMale.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.rbMale.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.rbMale.CyberRadioButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.rbMale.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.rbMale.Effect_1_Transparency = 25;
            this.rbMale.Effect_2 = true;
            this.rbMale.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.rbMale.Effect_2_Transparency = 15;
            this.rbMale.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.rbMale.LinearGradient_Background = false;
            this.rbMale.LinearGradient_Value = false;
            this.rbMale.LinearGradientPen = false;
            this.rbMale.Location = new System.Drawing.Point(194, 244);
            this.rbMale.Name = "rbMale";
            this.rbMale.RGB = false;
            this.rbMale.Rounding = true;
            this.rbMale.RoundingInt = 100;
            this.rbMale.Size = new System.Drawing.Size(103, 45);
            this.rbMale.SizeChecked = 8;
            this.rbMale.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.rbMale.TabIndex = 60;
            this.rbMale.Tag = "Cyber";
            this.rbMale.TextButton = "Male";
            this.rbMale.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.rbMale.Timer_Effect_1 = 1;
            this.rbMale.Timer_RGB = 300;
            this.rbMale.Click += new System.EventHandler(this.rbMale_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(121, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 64;
            this.label4.Text = "Gender:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(80, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 18);
            this.label7.TabIndex = 63;
            this.label7.Text = "Date of Birth:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CalendarFont = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpDateOfBirth.CalendarForeColor = System.Drawing.Color.White;
            this.dtpDateOfBirth.CalendarTitleBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.dtpDateOfBirth.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.dtpDateOfBirth.CustomFormat = "yyyy/mm/dd";
            this.dtpDateOfBirth.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(190, 295);
            this.dtpDateOfBirth.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(224, 29);
            this.dtpDateOfBirth.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            this.dtpDateOfBirth.TabIndex = 61;
            this.dtpDateOfBirth.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.Alpha = 20;
            this.txtNationalNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtNationalNo.Background_WidthPen = 3F;
            this.txtNationalNo.BackgroundPen = true;
            this.txtNationalNo.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtNationalNo.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtNationalNo.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtNationalNo.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtNationalNo.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtNationalNo.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtNationalNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtNationalNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtNationalNo.InputType = DonControls.DonCyberTextbox.InputTypeEnum.TextInput;
            this.txtNationalNo.IsRequired = true;
            this.txtNationalNo.Lighting = false;
            this.txtNationalNo.LinearGradientPen = false;
            this.txtNationalNo.Location = new System.Drawing.Point(190, 200);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.PenWidth = 15;
            this.txtNationalNo.RGB = false;
            this.txtNationalNo.Rounding = true;
            this.txtNationalNo.RoundingInt = 60;
            this.txtNationalNo.Size = new System.Drawing.Size(220, 32);
            this.txtNationalNo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtNationalNo.TabIndex = 59;
            this.txtNationalNo.Tag = "Cyber";
            this.txtNationalNo.TextButton = "";
            this.txtNationalNo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtNationalNo.Timer_RGB = 300;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(86, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 58;
            this.label5.Text = "National No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 52;
            this.label1.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Alpha = 20;
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtFirstName.Background_WidthPen = 3F;
            this.txtFirstName.BackgroundPen = true;
            this.txtFirstName.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtFirstName.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtFirstName.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtFirstName.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtFirstName.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtFirstName.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtFirstName.InputType = DonControls.DonCyberTextbox.InputTypeEnum.TextInput;
            this.txtFirstName.IsRequired = true;
            this.txtFirstName.Lighting = false;
            this.txtFirstName.LinearGradientPen = false;
            this.txtFirstName.Location = new System.Drawing.Point(190, 50);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PenWidth = 15;
            this.txtFirstName.RGB = false;
            this.txtFirstName.Rounding = true;
            this.txtFirstName.RoundingInt = 60;
            this.txtFirstName.Size = new System.Drawing.Size(220, 32);
            this.txtFirstName.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtFirstName.TabIndex = 53;
            this.txtFirstName.Tag = "Cyber";
            this.txtFirstName.TextButton = "";
            this.txtFirstName.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtFirstName.Timer_RGB = 300;
            // 
            // txtLastName
            // 
            this.txtLastName.Alpha = 20;
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtLastName.Background_WidthPen = 3F;
            this.txtLastName.BackgroundPen = true;
            this.txtLastName.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtLastName.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtLastName.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtLastName.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtLastName.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtLastName.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtLastName.InputType = DonControls.DonCyberTextbox.InputTypeEnum.TextInput;
            this.txtLastName.IsRequired = true;
            this.txtLastName.Lighting = false;
            this.txtLastName.LinearGradientPen = false;
            this.txtLastName.Location = new System.Drawing.Point(190, 150);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PenWidth = 15;
            this.txtLastName.RGB = false;
            this.txtLastName.Rounding = true;
            this.txtLastName.RoundingInt = 60;
            this.txtLastName.Size = new System.Drawing.Size(220, 32);
            this.txtLastName.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtLastName.TabIndex = 57;
            this.txtLastName.Tag = "Cyber";
            this.txtLastName.TextButton = "";
            this.txtLastName.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtLastName.Timer_RGB = 300;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(74, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 54;
            this.label2.Text = "Second Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(96, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 56;
            this.label3.Text = "Last Name:";
            // 
            // txtSecondName
            // 
            this.txtSecondName.Alpha = 20;
            this.txtSecondName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtSecondName.Background_WidthPen = 3F;
            this.txtSecondName.BackgroundPen = true;
            this.txtSecondName.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtSecondName.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtSecondName.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtSecondName.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtSecondName.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtSecondName.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtSecondName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtSecondName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtSecondName.InputType = DonControls.DonCyberTextbox.InputTypeEnum.TextInput;
            this.txtSecondName.IsRequired = true;
            this.txtSecondName.Lighting = false;
            this.txtSecondName.LinearGradientPen = false;
            this.txtSecondName.Location = new System.Drawing.Point(190, 100);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.PenWidth = 15;
            this.txtSecondName.RGB = false;
            this.txtSecondName.Rounding = true;
            this.txtSecondName.RoundingInt = 60;
            this.txtSecondName.Size = new System.Drawing.Size(220, 32);
            this.txtSecondName.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtSecondName.TabIndex = 55;
            this.txtSecondName.Tag = "Cyber";
            this.txtSecondName.TextButton = "";
            this.txtSecondName.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtSecondName.Timer_RGB = 300;
            // 
            // tpContactInfo
            // 
            this.tpContactInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpContactInfo.Controls.Add(this.txtAddress);
            this.tpContactInfo.Controls.Add(this.cmbCountry);
            this.tpContactInfo.Controls.Add(this.label9);
            this.tpContactInfo.Controls.Add(this.label14);
            this.tpContactInfo.Controls.Add(this.txtPhone);
            this.tpContactInfo.Controls.Add(this.label15);
            this.tpContactInfo.Controls.Add(this.label16);
            this.tpContactInfo.Controls.Add(this.txtEmail);
            this.tpContactInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpContactInfo.Location = new System.Drawing.Point(119, 4);
            this.tpContactInfo.Name = "tpContactInfo";
            this.tpContactInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpContactInfo.Size = new System.Drawing.Size(497, 373);
            this.tpContactInfo.TabIndex = 1;
            this.tpContactInfo.Text = "Contact Info";
            // 
            // txtAddress
            // 
            this.txtAddress.Alpha = 20;
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtAddress.Background_WidthPen = 3F;
            this.txtAddress.BackgroundPen = true;
            this.txtAddress.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtAddress.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtAddress.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtAddress.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtAddress.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtAddress.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtAddress.InputType = DonControls.DonCyberTextbox.InputTypeEnum.TextInput;
            this.txtAddress.IsRequired = true;
            this.txtAddress.Lighting = false;
            this.txtAddress.LinearGradientPen = false;
            this.txtAddress.Location = new System.Drawing.Point(157, 244);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PenWidth = 15;
            this.txtAddress.RGB = false;
            this.txtAddress.Rounding = true;
            this.txtAddress.RoundingInt = 60;
            this.txtAddress.Size = new System.Drawing.Size(220, 32);
            this.txtAddress.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtAddress.TabIndex = 62;
            this.txtAddress.Tag = "Cyber";
            this.txtAddress.TextButton = "";
            this.txtAddress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtAddress.Timer_RGB = 300;
            // 
            // cmbCountry
            // 
            this.cmbCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbCountry.ColorArrow = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbCountry.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbCountry.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbCountry.ColorItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.cmbCountry.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbCountry.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cmbCountry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCountry.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cmbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCountry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.ItemHeight = 28;
            this.cmbCountry.Location = new System.Drawing.Point(157, 190);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.RGB = false;
            this.cmbCountry.Size = new System.Drawing.Size(219, 34);
            this.cmbCountry.TabIndex = 61;
            this.cmbCountry.Timer_RGB = 300;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(79, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 18);
            this.label9.TabIndex = 59;
            this.label9.Text = "Address:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(93, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 18);
            this.label14.TabIndex = 53;
            this.label14.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Alpha = 20;
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtPhone.Background_WidthPen = 3F;
            this.txtPhone.BackgroundPen = true;
            this.txtPhone.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtPhone.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtPhone.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtPhone.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtPhone.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtPhone.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtPhone.InputType = DonControls.DonCyberTextbox.InputTypeEnum.NumberInput;
            this.txtPhone.IsRequired = true;
            this.txtPhone.Lighting = false;
            this.txtPhone.LinearGradientPen = false;
            this.txtPhone.Location = new System.Drawing.Point(156, 90);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PenWidth = 15;
            this.txtPhone.RGB = false;
            this.txtPhone.Rounding = true;
            this.txtPhone.RoundingInt = 60;
            this.txtPhone.Size = new System.Drawing.Size(220, 32);
            this.txtPhone.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtPhone.TabIndex = 54;
            this.txtPhone.Tag = "Cyber";
            this.txtPhone.TextButton = "";
            this.txtPhone.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtPhone.Timer_RGB = 300;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(98, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 18);
            this.label15.TabIndex = 55;
            this.label15.Text = "Email:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(80, 195);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 18);
            this.label16.TabIndex = 57;
            this.label16.Text = "Country:";
            // 
            // txtEmail
            // 
            this.txtEmail.Alpha = 20;
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtEmail.Background_WidthPen = 3F;
            this.txtEmail.BackgroundPen = true;
            this.txtEmail.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtEmail.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtEmail.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtEmail.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtEmail.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtEmail.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtEmail.InputType = DonControls.DonCyberTextbox.InputTypeEnum.TextInput;
            this.txtEmail.IsRequired = true;
            this.txtEmail.Lighting = false;
            this.txtEmail.LinearGradientPen = false;
            this.txtEmail.Location = new System.Drawing.Point(156, 140);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PenWidth = 15;
            this.txtEmail.RGB = false;
            this.txtEmail.Rounding = true;
            this.txtEmail.RoundingInt = 60;
            this.txtEmail.Size = new System.Drawing.Size(220, 32);
            this.txtEmail.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtEmail.TabIndex = 56;
            this.txtEmail.Tag = "Cyber";
            this.txtEmail.TextButton = "";
            this.txtEmail.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtEmail.Timer_RGB = 300;
            // 
            // tpEmployeeInfo
            // 
            this.tpEmployeeInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.tpEmployeeInfo.Controls.Add(this.label11);
            this.tpEmployeeInfo.Controls.Add(this.lblID);
            this.tpEmployeeInfo.Controls.Add(this.cmbBranch);
            this.tpEmployeeInfo.Controls.Add(this.label6);
            this.tpEmployeeInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpEmployeeInfo.Location = new System.Drawing.Point(119, 4);
            this.tpEmployeeInfo.Name = "tpEmployeeInfo";
            this.tpEmployeeInfo.Size = new System.Drawing.Size(497, 373);
            this.tpEmployeeInfo.TabIndex = 3;
            this.tpEmployeeInfo.Text = "Client Info";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(107, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 18);
            this.label11.TabIndex = 68;
            this.label11.Text = "Branch:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblID.Location = new System.Drawing.Point(179, 136);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(38, 18);
            this.lblID.TabIndex = 59;
            this.lblID.Text = "[-1]";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cmbBranch.Location = new System.Drawing.Point(179, 181);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.RGB = false;
            this.cmbBranch.Size = new System.Drawing.Size(224, 34);
            this.cmbBranch.TabIndex = 67;
            this.cmbBranch.Timer_RGB = 300;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(93, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 58;
            this.label6.Text = "Client ID:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.ActiveLinkColor = System.Drawing.Color.Cyan;
            this.llRemoveImage.AutoSize = true;
            this.llRemoveImage.BackColor = System.Drawing.Color.Transparent;
            this.llRemoveImage.DisabledLinkColor = System.Drawing.Color.Cyan;
            this.llRemoveImage.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llRemoveImage.ForeColor = System.Drawing.Color.Cyan;
            this.llRemoveImage.LinkColor = System.Drawing.Color.Cyan;
            this.llRemoveImage.Location = new System.Drawing.Point(786, 363);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(68, 18);
            this.llRemoveImage.TabIndex = 69;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Remove";
            this.llRemoveImage.VisitedLinkColor = System.Drawing.Color.Navy;
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked_1);
            // 
            // llSetImage
            // 
            this.llSetImage.ActiveLinkColor = System.Drawing.Color.Cyan;
            this.llSetImage.AutoSize = true;
            this.llSetImage.BackColor = System.Drawing.Color.Transparent;
            this.llSetImage.DisabledLinkColor = System.Drawing.Color.Cyan;
            this.llSetImage.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llSetImage.ForeColor = System.Drawing.Color.Cyan;
            this.llSetImage.LinkColor = System.Drawing.Color.Cyan;
            this.llSetImage.Location = new System.Drawing.Point(689, 363);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(84, 18);
            this.llSetImage.TabIndex = 68;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Set Image";
            this.llSetImage.VisitedLinkColor = System.Drawing.Color.Navy;
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked_1);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pbImage.Image = global::Atlantis_Bank.Properties.Resources.Male_Employee1;
            this.pbImage.Location = new System.Drawing.Point(646, 97);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(247, 256);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 67;
            this.pbImage.TabStop = false;
            // 
            // frmAddUpdateClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(911, 530);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.llRemoveImage);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.llSetImage);
            this.Controls.Add(this.btnNextSave);
            this.Controls.Add(this.tpInfo);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddNewEmployeeClient_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tpInfo.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpPersonalInfo.PerformLayout();
            this.tpContactInfo.ResumeLayout(false);
            this.tpContactInfo.PerformLayout();
            this.tpEmployeeInfo.ResumeLayout(false);
            this.tpEmployeeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel llImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblTitle;
        private ReaLTaiizor.Controls.SmallLabel lblSubtitle;
        private System.Windows.Forms.Panel panel4;
        private ReaLTaiizor.Controls.Panel pnlAccent;
        private ReaLTaiizor.Controls.CyberButton btnPrevious;
        private ReaLTaiizor.Controls.CyberButton btnNextSave;
        private ReaLTaiizor.Controls.AirTabPage tpInfo;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.PictureBox pbImage;
        private ReaLTaiizor.Controls.CyberRadioButton rbFemale;
        private ReaLTaiizor.Controls.CyberRadioButton rbMale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private ReaLTaiizor.Controls.PoisonDateTime dtpDateOfBirth;
        private DonControls.DonCyberTextbox txtNationalNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private DonControls.DonCyberTextbox txtFirstName;
        private DonControls.DonCyberTextbox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DonControls.DonCyberTextbox txtSecondName;
        private System.Windows.Forms.TabPage tpContactInfo;
        private ReaLTaiizor.Controls.CyberComboBox cmbCountry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private DonControls.DonCyberTextbox txtPhone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private DonControls.DonCyberTextbox txtEmail;
        private System.Windows.Forms.TabPage tpEmployeeInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblID;
        private ReaLTaiizor.Controls.CyberComboBox cmbBranch;
        private System.Windows.Forms.Label label6;
        private DonControls.DonCyberTextbox txtAddress;
    }
}