namespace Atlantis_Bank
{
    partial class frmUserManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnChangePassword = new ReaLTaiizor.Controls.CyberButton();
            this.btnDelete = new ReaLTaiizor.Controls.CyberButton();
            this.btnUpdate = new ReaLTaiizor.Controls.CyberButton();
            this.btnShowInfo = new ReaLTaiizor.Controls.CyberButton();
            this.btnAdd = new ReaLTaiizor.Controls.CyberButton();
            this.lblRecords = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new DonControls.Custom_Controls.DonTextbox();
            this.btnClear = new ReaLTaiizor.Controls.CyberButton();
            this.btnSearch = new ReaLTaiizor.Controls.CyberButton();
            this.cmbFilter = new ReaLTaiizor.Controls.CyberComboBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlAccent = new ReaLTaiizor.Controls.Panel();
            this.lblSubtitle = new ReaLTaiizor.Controls.SmallLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(124)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsers.ColumnHeadersHeight = 40;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(90)))));
            this.dgvUsers.Location = new System.Drawing.Point(0, 165);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 35;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1422, 357);
            this.dgvUsers.TabIndex = 12;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.pnlActions.Controls.Add(this.btnChangePassword);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnUpdate);
            this.pnlActions.Controls.Add(this.btnShowInfo);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Controls.Add(this.lblRecords);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 522);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1422, 65);
            this.pnlActions.TabIndex = 11;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Alpha = 20;
            this.btnChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.Background = true;
            this.btnChangePassword.Background_WidthPen = 4F;
            this.btnChangePassword.BackgroundPen = true;
            this.btnChangePassword.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnChangePassword.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnChangePassword.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnChangePassword.ColorBackground_Pen = System.Drawing.Color.Transparent;
            this.btnChangePassword.ColorLighting = System.Drawing.Color.Transparent;
            this.btnChangePassword.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnChangePassword.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnChangePassword.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnChangePassword.Effect_1 = true;
            this.btnChangePassword.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnChangePassword.Effect_1_Transparency = 25;
            this.btnChangePassword.Effect_2 = true;
            this.btnChangePassword.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnChangePassword.Effect_2_Transparency = 20;
            this.btnChangePassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnChangePassword.Lighting = false;
            this.btnChangePassword.LinearGradient_Background = false;
            this.btnChangePassword.LinearGradientPen = false;
            this.btnChangePassword.Location = new System.Drawing.Point(337, 12);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.PenWidth = 15;
            this.btnChangePassword.Rounding = true;
            this.btnChangePassword.RoundingInt = 70;
            this.btnChangePassword.Size = new System.Drawing.Size(140, 40);
            this.btnChangePassword.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnChangePassword.TabIndex = 44;
            this.btnChangePassword.Tag = "Cyber";
            this.btnChangePassword.TextButton = "Change Password";
            this.btnChangePassword.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnChangePassword.Timer_Effect_1 = 5;
            this.btnChangePassword.Timer_RGB = 300;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Alpha = 20;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Background = true;
            this.btnDelete.Background_WidthPen = 4F;
            this.btnDelete.BackgroundPen = true;
            this.btnDelete.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnDelete.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnDelete.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnDelete.ColorBackground_Pen = System.Drawing.Color.Transparent;
            this.btnDelete.ColorLighting = System.Drawing.Color.Transparent;
            this.btnDelete.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnDelete.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnDelete.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnDelete.Effect_1 = true;
            this.btnDelete.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDelete.Effect_1_Transparency = 25;
            this.btnDelete.Effect_2 = true;
            this.btnDelete.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnDelete.Effect_2_Transparency = 20;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnDelete.Lighting = false;
            this.btnDelete.LinearGradient_Background = false;
            this.btnDelete.LinearGradientPen = false;
            this.btnDelete.Location = new System.Drawing.Point(650, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PenWidth = 15;
            this.btnDelete.Rounding = true;
            this.btnDelete.RoundingInt = 70;
            this.btnDelete.Size = new System.Drawing.Size(140, 40);
            this.btnDelete.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Tag = "Cyber";
            this.btnDelete.TextButton = "Delete";
            this.btnDelete.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnDelete.Timer_Effect_1 = 5;
            this.btnDelete.Timer_RGB = 300;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Alpha = 20;
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Background = true;
            this.btnUpdate.Background_WidthPen = 4F;
            this.btnUpdate.BackgroundPen = true;
            this.btnUpdate.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnUpdate.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnUpdate.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnUpdate.ColorBackground_Pen = System.Drawing.Color.Transparent;
            this.btnUpdate.ColorLighting = System.Drawing.Color.Transparent;
            this.btnUpdate.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnUpdate.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnUpdate.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnUpdate.Effect_1 = true;
            this.btnUpdate.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnUpdate.Effect_1_Transparency = 25;
            this.btnUpdate.Effect_2 = true;
            this.btnUpdate.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnUpdate.Effect_2_Transparency = 20;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnUpdate.Lighting = false;
            this.btnUpdate.LinearGradient_Background = false;
            this.btnUpdate.LinearGradientPen = false;
            this.btnUpdate.Location = new System.Drawing.Point(180, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.PenWidth = 15;
            this.btnUpdate.Rounding = true;
            this.btnUpdate.RoundingInt = 70;
            this.btnUpdate.Size = new System.Drawing.Size(140, 40);
            this.btnUpdate.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Tag = "Cyber";
            this.btnUpdate.TextButton = "Update";
            this.btnUpdate.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnUpdate.Timer_Effect_1 = 5;
            this.btnUpdate.Timer_RGB = 300;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.Alpha = 20;
            this.btnShowInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnShowInfo.Background = true;
            this.btnShowInfo.Background_WidthPen = 4F;
            this.btnShowInfo.BackgroundPen = true;
            this.btnShowInfo.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnShowInfo.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnShowInfo.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnShowInfo.ColorBackground_Pen = System.Drawing.Color.Transparent;
            this.btnShowInfo.ColorLighting = System.Drawing.Color.Transparent;
            this.btnShowInfo.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnShowInfo.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnShowInfo.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnShowInfo.Effect_1 = true;
            this.btnShowInfo.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnShowInfo.Effect_1_Transparency = 25;
            this.btnShowInfo.Effect_2 = true;
            this.btnShowInfo.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnShowInfo.Effect_2_Transparency = 20;
            this.btnShowInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnShowInfo.Lighting = false;
            this.btnShowInfo.LinearGradient_Background = false;
            this.btnShowInfo.LinearGradientPen = false;
            this.btnShowInfo.Location = new System.Drawing.Point(495, 12);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.PenWidth = 15;
            this.btnShowInfo.Rounding = true;
            this.btnShowInfo.RoundingInt = 70;
            this.btnShowInfo.Size = new System.Drawing.Size(140, 40);
            this.btnShowInfo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnShowInfo.TabIndex = 41;
            this.btnShowInfo.Tag = "Cyber";
            this.btnShowInfo.TextButton = "Show Info";
            this.btnShowInfo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnShowInfo.Timer_Effect_1 = 5;
            this.btnShowInfo.Timer_RGB = 300;
            this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Alpha = 20;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Background = true;
            this.btnAdd.Background_WidthPen = 4F;
            this.btnAdd.BackgroundPen = true;
            this.btnAdd.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAdd.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAdd.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAdd.ColorBackground_Pen = System.Drawing.Color.Transparent;
            this.btnAdd.ColorLighting = System.Drawing.Color.Transparent;
            this.btnAdd.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAdd.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAdd.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnAdd.Effect_1 = true;
            this.btnAdd.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnAdd.Effect_1_Transparency = 25;
            this.btnAdd.Effect_2 = true;
            this.btnAdd.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnAdd.Effect_2_Transparency = 20;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnAdd.Lighting = false;
            this.btnAdd.LinearGradient_Background = false;
            this.btnAdd.LinearGradientPen = false;
            this.btnAdd.Location = new System.Drawing.Point(25, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PenWidth = 15;
            this.btnAdd.Rounding = true;
            this.btnAdd.RoundingInt = 70;
            this.btnAdd.Size = new System.Drawing.Size(140, 40);
            this.btnAdd.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Tag = "Cyber";
            this.btnAdd.TextButton = "Add";
            this.btnAdd.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnAdd.Timer_Effect_1 = 5;
            this.btnAdd.Timer_RGB = 300;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecords.AutoSize = true;
            this.lblRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblRecords.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.LightGray;
            this.lblRecords.Location = new System.Drawing.Point(1267, 25);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(96, 16);
            this.lblRecords.TabIndex = 40;
            this.lblRecords.Text = "Total Users: 0";
            this.lblRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnClear);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.cmbFilter);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 90);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1422, 75);
            this.pnlSearch.TabIndex = 10;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.InputType = DonControls.Custom_Controls.DonTextbox.InputTypeEnum.TextInput;
            this.txtSearch.IsRequired = false;
            this.txtSearch.Location = new System.Drawing.Point(165, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(360, 27);
            this.txtSearch.TabIndex = 39;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClear
            // 
            this.btnClear.Alpha = 20;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Background = true;
            this.btnClear.Background_WidthPen = 4F;
            this.btnClear.BackgroundPen = true;
            this.btnClear.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnClear.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnClear.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnClear.ColorBackground_Pen = System.Drawing.Color.Transparent;
            this.btnClear.ColorLighting = System.Drawing.Color.Transparent;
            this.btnClear.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnClear.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.btnClear.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnClear.Effect_1 = true;
            this.btnClear.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnClear.Effect_1_Transparency = 25;
            this.btnClear.Effect_2 = true;
            this.btnClear.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnClear.Effect_2_Transparency = 20;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnClear.Lighting = false;
            this.btnClear.LinearGradient_Background = false;
            this.btnClear.LinearGradientPen = false;
            this.btnClear.Location = new System.Drawing.Point(660, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.PenWidth = 15;
            this.btnClear.Rounding = true;
            this.btnClear.RoundingInt = 70;
            this.btnClear.Size = new System.Drawing.Size(110, 36);
            this.btnClear.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnClear.TabIndex = 38;
            this.btnClear.Tag = "Cyber";
            this.btnClear.TextButton = "Clear";
            this.btnClear.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnClear.Timer_Effect_1 = 5;
            this.btnClear.Timer_RGB = 300;
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
            this.btnSearch.ColorBackground_Pen = System.Drawing.Color.Transparent;
            this.btnSearch.ColorLighting = System.Drawing.Color.Transparent;
            this.btnSearch.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearch.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
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
            this.btnSearch.Location = new System.Drawing.Point(540, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PenWidth = 15;
            this.btnSearch.Rounding = true;
            this.btnSearch.RoundingInt = 70;
            this.btnSearch.Size = new System.Drawing.Size(110, 36);
            this.btnSearch.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Tag = "Cyber";
            this.btnSearch.TextButton = "Search";
            this.btnSearch.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnSearch.Timer_Effect_1 = 5;
            this.btnSearch.Timer_RGB = 300;
            // 
            // cmbFilter
            // 
            this.cmbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbFilter.ColorArrow = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbFilter.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.cmbFilter.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbFilter.ColorItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.cmbFilter.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cmbFilter.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cmbFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFilter.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cmbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.ItemHeight = 28;
            this.cmbFilter.Items.AddRange(new object[] {
            "All Users",
            "User ID",
            "Employee ID",
            "Username",
            "Branch",
            "Position",
            "Role"});
            this.cmbFilter.Location = new System.Drawing.Point(20, 19);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.RGB = false;
            this.cmbFilter.Size = new System.Drawing.Size(130, 34);
            this.cmbFilter.TabIndex = 36;
            this.cmbFilter.Timer_RGB = 300;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.pnlHeader.Controls.Add(this.pnlAccent);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1422, 90);
            this.pnlHeader.TabIndex = 9;
            // 
            // pnlAccent
            // 
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.pnlAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Padding = new System.Windows.Forms.Padding(5);
            this.pnlAccent.Size = new System.Drawing.Size(5, 90);
            this.pnlAccent.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.pnlAccent.TabIndex = 41;
            this.pnlAccent.Text = "panel1";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubtitle.Location = new System.Drawing.Point(63, 44);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(181, 14);
            this.lblSubtitle.TabIndex = 40;
            this.lblSubtitle.Text = "Manage and monitor bank users";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 33);
            this.lblTitle.TabIndex = 39;
            this.lblTitle.Text = "Users Management";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1422, 587);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUserManagement_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel pnlActions;
        private ReaLTaiizor.Controls.CyberButton btnChangePassword;
        private ReaLTaiizor.Controls.CyberButton btnDelete;
        private ReaLTaiizor.Controls.CyberButton btnUpdate;
        private ReaLTaiizor.Controls.CyberButton btnShowInfo;
        private ReaLTaiizor.Controls.CyberButton btnAdd;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Panel pnlSearch;
        private DonControls.Custom_Controls.DonTextbox txtSearch;
        private ReaLTaiizor.Controls.CyberButton btnClear;
        private ReaLTaiizor.Controls.CyberButton btnSearch;
        private ReaLTaiizor.Controls.CyberComboBox cmbFilter;
        private System.Windows.Forms.Panel pnlHeader;
        private ReaLTaiizor.Controls.Panel pnlAccent;
        private ReaLTaiizor.Controls.SmallLabel lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
    }
}