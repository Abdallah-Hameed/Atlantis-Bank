namespace Atlantis_Bank
{
    partial class frmClientManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlAccent = new ReaLTaiizor.Controls.Panel();
            this.lblSubtitle = new ReaLTaiizor.Controls.SmallLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnDelete = new ReaLTaiizor.Controls.CyberButton();
            this.btnUpdate = new ReaLTaiizor.Controls.CyberButton();
            this.btnShowInfo = new ReaLTaiizor.Controls.CyberButton();
            this.btnAdd = new ReaLTaiizor.Controls.CyberButton();
            this.lblRecords = new System.Windows.Forms.Label();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.cmbFilter = new ReaLTaiizor.Controls.CyberComboBox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new DonControls.Custom_Controls.DonTextbox();
            this.btnClear = new ReaLTaiizor.Controls.CyberButton();
            this.btnSearch = new ReaLTaiizor.Controls.CyberButton();
            this.pnlHeader.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(1236, 90);
            this.pnlHeader.TabIndex = 1;
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
            this.lblSubtitle.Location = new System.Drawing.Point(39, 46);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(187, 14);
            this.lblSubtitle.TabIndex = 40;
            this.lblSubtitle.Text = "Manage and monitor bank clients";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 33);
            this.lblTitle.TabIndex = 39;
            this.lblTitle.Text = "Clients Management";
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnUpdate);
            this.pnlActions.Controls.Add(this.btnShowInfo);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Controls.Add(this.lblRecords);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 505);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1236, 65);
            this.pnlActions.TabIndex = 4;
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
            this.btnDelete.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
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
            this.btnDelete.Location = new System.Drawing.Point(490, 12);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
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
            this.btnUpdate.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
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
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
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
            this.btnShowInfo.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
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
            this.btnShowInfo.Location = new System.Drawing.Point(335, 12);
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
            this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click_1);
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
            this.btnAdd.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
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
            this.lblRecords.Location = new System.Drawing.Point(1100, 25);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(103, 16);
            this.lblRecords.TabIndex = 40;
            this.lblRecords.Text = "Total Clients: 0";
            this.lblRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvClients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            this.dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(124)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClients.ColumnHeadersHeight = 40;
            this.dgvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClients.EnableHeadersVisualStyles = false;
            this.dgvClients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(90)))));
            this.dgvClients.Location = new System.Drawing.Point(0, 165);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(40)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowTemplate.Height = 35;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(1236, 405);
            this.dgvClients.TabIndex = 3;
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
            "All Clients",
            "Client ID",
            "National No",
            "First Name",
            "Second Name",
            "Last Name",
            "Email",
            "Phone",
            "Gender",
            "Country",
            "Branch"});
            this.cmbFilter.Location = new System.Drawing.Point(20, 19);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.RGB = false;
            this.cmbFilter.Size = new System.Drawing.Size(130, 34);
            this.cmbFilter.TabIndex = 36;
            this.cmbFilter.Timer_RGB = 300;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
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
            this.pnlSearch.Size = new System.Drawing.Size(1236, 75);
            this.pnlSearch.TabIndex = 2;
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
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            this.btnClear.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
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
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
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
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmClientManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 570);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmClientManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frmClientManagement_Activated);
            this.Load += new System.EventHandler(this.frmClientManagement_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private ReaLTaiizor.Controls.SmallLabel lblSubtitle;
        private System.Windows.Forms.Panel pnlActions;
        private ReaLTaiizor.Controls.Panel pnlAccent;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.DataGridView dgvClients;
        private ReaLTaiizor.Controls.CyberComboBox cmbFilter;
        private System.Windows.Forms.Panel pnlSearch;
        private ReaLTaiizor.Controls.CyberButton btnClear;
        private ReaLTaiizor.Controls.CyberButton btnSearch;
        private ReaLTaiizor.Controls.CyberButton btnDelete;
        private ReaLTaiizor.Controls.CyberButton btnUpdate;
        private ReaLTaiizor.Controls.CyberButton btnShowInfo;
        private ReaLTaiizor.Controls.CyberButton btnAdd;
        private DonControls.Custom_Controls.DonTextbox txtSearch;
    }
}