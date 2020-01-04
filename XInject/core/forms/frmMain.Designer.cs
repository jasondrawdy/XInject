namespace XInject
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblAssembly = new System.Windows.Forms.Label();
            this.txtAssemblyPath = new System.Windows.Forms.TextBox();
            this.lblIcons = new System.Windows.Forms.Label();
            this.colLength = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imgStatus = new System.Windows.Forms.ImageList(this.components);
            this.txtCertificatePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkResign = new System.Windows.Forms.CheckBox();
            this.btnClose = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnInject = new MaterialSkin.Controls.MaterialFlatButton();
            this.lvIcons = new BrightIdeasSoftware.ObjectListView();
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colExtension = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.conMain = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.conAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.conRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.conSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.conSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.lvIcons)).BeginInit();
            this.conMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAssembly
            // 
            this.lblAssembly.AutoSize = true;
            this.lblAssembly.Location = new System.Drawing.Point(12, 9);
            this.lblAssembly.Name = "lblAssembly";
            this.lblAssembly.Size = new System.Drawing.Size(54, 13);
            this.lblAssembly.TabIndex = 0;
            this.lblAssembly.Text = "Assembly:";
            // 
            // txtAssemblyPath
            // 
            this.txtAssemblyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssemblyPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAssemblyPath.Location = new System.Drawing.Point(15, 25);
            this.txtAssemblyPath.Name = "txtAssemblyPath";
            this.txtAssemblyPath.ReadOnly = true;
            this.txtAssemblyPath.Size = new System.Drawing.Size(616, 20);
            this.txtAssemblyPath.TabIndex = 1;
            this.txtAssemblyPath.Text = "Click to browse...";
            this.txtAssemblyPath.Click += new System.EventHandler(this.txtAssemblyPath_Click);
            // 
            // lblIcons
            // 
            this.lblIcons.AutoSize = true;
            this.lblIcons.Location = new System.Drawing.Point(12, 87);
            this.lblIcons.Name = "lblIcons";
            this.lblIcons.Size = new System.Drawing.Size(36, 13);
            this.lblIcons.TabIndex = 3;
            this.lblIcons.Text = "Icons:";
            // 
            // colLength
            // 
            this.colLength.IsVisible = false;
            this.colLength.MaximumWidth = 0;
            this.colLength.MinimumWidth = 0;
            this.colLength.Text = "Length";
            this.colLength.Width = 0;
            // 
            // imgStatus
            // 
            this.imgStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgStatus.ImageStream")));
            this.imgStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imgStatus.Images.SetKeyName(0, "Injected.png");
            this.imgStatus.Images.SetKeyName(1, "Idle.png");
            this.imgStatus.Images.SetKeyName(2, "Warning.png");
            this.imgStatus.Images.SetKeyName(3, "Error.png");
            // 
            // txtCertificatePath
            // 
            this.txtCertificatePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertificatePath.Enabled = false;
            this.txtCertificatePath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCertificatePath.Location = new System.Drawing.Point(15, 64);
            this.txtCertificatePath.Name = "txtCertificatePath";
            this.txtCertificatePath.ReadOnly = true;
            this.txtCertificatePath.Size = new System.Drawing.Size(616, 20);
            this.txtCertificatePath.TabIndex = 2;
            this.txtCertificatePath.Text = "Click to browse...";
            this.txtCertificatePath.Click += new System.EventHandler(this.txtCertificatePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Certificate:";
            // 
            // chkResign
            // 
            this.chkResign.AutoSize = true;
            this.chkResign.Location = new System.Drawing.Point(15, 324);
            this.chkResign.Name = "chkResign";
            this.chkResign.Size = new System.Drawing.Size(144, 17);
            this.chkResign.TabIndex = 0;
            this.chkResign.Text = "Re-sign file after injection";
            this.chkResign.UseVisualStyleBackColor = true;
            this.chkResign.CheckedChanged += new System.EventHandler(this.chkResign_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Depth = 0;
            this.btnClose.Location = new System.Drawing.Point(377, 320);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = false;
            this.btnClose.Size = new System.Drawing.Size(123, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInject
            // 
            this.btnInject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInject.Depth = 0;
            this.btnInject.Enabled = false;
            this.btnInject.Location = new System.Drawing.Point(508, 320);
            this.btnInject.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnInject.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInject.Name = "btnInject";
            this.btnInject.Primary = false;
            this.btnInject.Size = new System.Drawing.Size(123, 23);
            this.btnInject.TabIndex = 3;
            this.btnInject.Text = "Inject Icons";
            this.btnInject.UseVisualStyleBackColor = true;
            this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
            // 
            // lvIcons
            // 
            this.lvIcons.AllColumns.Add(this.colName);
            this.lvIcons.AllColumns.Add(this.colExtension);
            this.lvIcons.AllColumns.Add(this.colPath);
            this.lvIcons.AllColumns.Add(this.colSize);
            this.lvIcons.AllColumns.Add(this.colLength);
            this.lvIcons.AllColumns.Add(this.colStatus);
            this.lvIcons.AllowDrop = true;
            this.lvIcons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvIcons.CellEditUseWholeCell = false;
            this.lvIcons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colExtension,
            this.colPath,
            this.colSize,
            this.colStatus});
            this.lvIcons.ContextMenuStrip = this.conMain;
            this.lvIcons.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvIcons.EmptyListMsg = "No Icons";
            this.lvIcons.FullRowSelect = true;
            this.lvIcons.IsSimpleDropSink = true;
            this.lvIcons.LargeImageList = this.imgStatus;
            this.lvIcons.Location = new System.Drawing.Point(15, 103);
            this.lvIcons.Name = "lvIcons";
            this.lvIcons.SelectColumnsOnRightClick = false;
            this.lvIcons.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.lvIcons.ShowGroups = false;
            this.lvIcons.ShowHeaderInAllViews = false;
            this.lvIcons.Size = new System.Drawing.Size(616, 208);
            this.lvIcons.SmallImageList = this.imgStatus;
            this.lvIcons.TabIndex = 2;
            this.lvIcons.UseCompatibleStateImageBehavior = false;
            this.lvIcons.UseHotItem = true;
            this.lvIcons.View = System.Windows.Forms.View.Details;
            this.lvIcons.CanDrop += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.lvIcons_CanDrop);
            this.lvIcons.Dropped += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.lvIcons_Dropped);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 111;
            // 
            // colExtension
            // 
            this.colExtension.Text = "Extension";
            this.colExtension.Width = 77;
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 238;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 98;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 72;
            // 
            // conMain
            // 
            this.conMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conMain.Depth = 0;
            this.conMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conAdd,
            this.conRemove,
            this.conSep1,
            this.conSelectAll});
            this.conMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.conMain.Name = "materialContextMenuStrip1";
            this.conMain.Size = new System.Drawing.Size(123, 76);
            this.conMain.Opening += new System.ComponentModel.CancelEventHandler(this.conMain_Opening);
            // 
            // conAdd
            // 
            this.conAdd.Name = "conAdd";
            this.conAdd.Size = new System.Drawing.Size(122, 22);
            this.conAdd.Text = "Add";
            this.conAdd.Click += new System.EventHandler(this.conAdd_Click);
            // 
            // conRemove
            // 
            this.conRemove.Name = "conRemove";
            this.conRemove.Size = new System.Drawing.Size(122, 22);
            this.conRemove.Text = "Remove";
            this.conRemove.Click += new System.EventHandler(this.conRemove_Click);
            // 
            // conSep1
            // 
            this.conSep1.Name = "conSep1";
            this.conSep1.Size = new System.Drawing.Size(119, 6);
            // 
            // conSelectAll
            // 
            this.conSelectAll.Name = "conSelectAll";
            this.conSelectAll.Size = new System.Drawing.Size(122, 22);
            this.conSelectAll.Text = "Select All";
            this.conSelectAll.Click += new System.EventHandler(this.conSelectAll_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 358);
            this.Controls.Add(this.chkResign);
            this.Controls.Add(this.txtCertificatePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInject);
            this.Controls.Add(this.lvIcons);
            this.Controls.Add(this.lblIcons);
            this.Controls.Add(this.txtAssemblyPath);
            this.Controls.Add(this.lblAssembly);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(659, 361);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XInject";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvIcons)).EndInit();
            this.conMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAssembly;
        private System.Windows.Forms.TextBox txtAssemblyPath;
        private System.Windows.Forms.Label lblIcons;
        private BrightIdeasSoftware.ObjectListView lvIcons;
        private BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn colExtension;
        private BrightIdeasSoftware.OLVColumn colPath;
        private BrightIdeasSoftware.OLVColumn colSize;
        private BrightIdeasSoftware.OLVColumn colLength;
        private BrightIdeasSoftware.OLVColumn colStatus;
        private MaterialSkin.Controls.MaterialContextMenuStrip conMain;
        private System.Windows.Forms.ToolStripMenuItem conAdd;
        private System.Windows.Forms.ToolStripMenuItem conRemove;
        private System.Windows.Forms.ToolStripSeparator conSep1;
        private System.Windows.Forms.ToolStripMenuItem conSelectAll;
        private MaterialSkin.Controls.MaterialFlatButton btnInject;
        private MaterialSkin.Controls.MaterialFlatButton btnClose;
        private System.Windows.Forms.ImageList imgStatus;
        private System.Windows.Forms.TextBox txtCertificatePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkResign;
    }
}

