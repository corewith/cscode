namespace EMMS.View.storage
{
    partial class Storage_Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Storage_Order));
            this.tbStorage = new System.Windows.Forms.ToolStrip();
            this.tsbMStocking = new System.Windows.Forms.ToolStripButton();
            this.tsbPStocking = new System.Windows.Forms.ToolStripButton();
            this.tsbOut = new System.Windows.Forms.ToolStripButton();
            this.tsbInventory = new System.Windows.Forms.ToolStripButton();
            this.tsbCritical = new System.Windows.Forms.ToolStripButton();
            this.tsbPicking = new System.Windows.Forms.ToolStripButton();
            this.tsbQueryCritical = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tbGoods = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStorage = new System.Windows.Forms.DataGridView();
            this.msStorage = new System.Windows.Forms.MenuStrip();
            this.入库操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物料入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.成品入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出库操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询出库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.盘点操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.盘点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询盘点单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.警戒操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置警戒值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询警戒库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.请购操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.请购ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.请购单查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGoods = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.tvStorage = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lPageAll = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPage = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lCounts = new System.Windows.Forms.Label();
            this.tbStorage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorage)).BeginInit();
            this.msStorage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbStorage
            // 
            this.tbStorage.Dock = System.Windows.Forms.DockStyle.None;
            this.tbStorage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMStocking,
            this.tsbPStocking,
            this.tsbOut,
            this.tsbInventory,
            this.tsbCritical,
            this.tsbPicking,
            this.tsbQueryCritical,
            this.tsbRefresh,
            this.toolStripButton1,
            this.tsbClose});
            this.tbStorage.Location = new System.Drawing.Point(9, 26);
            this.tbStorage.Name = "tbStorage";
            this.tbStorage.Size = new System.Drawing.Size(668, 56);
            this.tbStorage.TabIndex = 0;
            this.tbStorage.Text = "toolStrip1";
            // 
            // tsbMStocking
            // 
            this.tsbMStocking.Image = global::EMMS.View.Properties.Resources.material_stocking;
            this.tsbMStocking.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMStocking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMStocking.Name = "tsbMStocking";
            this.tsbMStocking.Size = new System.Drawing.Size(60, 53);
            this.tsbMStocking.Text = "物料入库";
            this.tsbMStocking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMStocking.Click += new System.EventHandler(this.tsbIn_Click);
            // 
            // tsbPStocking
            // 
            this.tsbPStocking.Image = global::EMMS.View.Properties.Resources.material_stocking;
            this.tsbPStocking.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPStocking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPStocking.Name = "tsbPStocking";
            this.tsbPStocking.Size = new System.Drawing.Size(60, 53);
            this.tsbPStocking.Text = "成品入库";
            this.tsbPStocking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPStocking.Click += new System.EventHandler(this.tsbPStocking_Click);
            // 
            // tsbOut
            // 
            this.tsbOut.Image = global::EMMS.View.Properties.Resources.retireval_info;
            this.tsbOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOut.Name = "tsbOut";
            this.tsbOut.Size = new System.Drawing.Size(40, 53);
            this.tsbOut.Text = "出库";
            this.tsbOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOut.Click += new System.EventHandler(this.tsbOut_Click);
            // 
            // tsbInventory
            // 
            this.tsbInventory.Image = global::EMMS.View.Properties.Resources.check1;
            this.tsbInventory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInventory.Name = "tsbInventory";
            this.tsbInventory.Size = new System.Drawing.Size(63, 53);
            this.tsbInventory.Text = "盘点";
            this.tsbInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbInventory.Click += new System.EventHandler(this.tsbInventory_Click);
            // 
            // tsbCritical
            // 
            this.tsbCritical.Image = global::EMMS.View.Properties.Resources.set;
            this.tsbCritical.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCritical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCritical.Name = "tsbCritical";
            this.tsbCritical.Size = new System.Drawing.Size(72, 53);
            this.tsbCritical.Text = "设置警戒值";
            this.tsbCritical.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCritical.Click += new System.EventHandler(this.tsbCritical_Click);
            // 
            // tsbPicking
            // 
            this.tsbPicking.Image = global::EMMS.View.Properties.Resources.query1;
            this.tsbPicking.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPicking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPicking.Name = "tsbPicking";
            this.tsbPicking.Size = new System.Drawing.Size(72, 53);
            this.tsbPicking.Text = "查询领料单";
            this.tsbPicking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPicking.Click += new System.EventHandler(this.tsbPicking_Click);
            // 
            // tsbQueryCritical
            // 
            this.tsbQueryCritical.Image = global::EMMS.View.Properties.Resources.query;
            this.tsbQueryCritical.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbQueryCritical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueryCritical.Name = "tsbQueryCritical";
            this.tsbQueryCritical.Size = new System.Drawing.Size(84, 53);
            this.tsbQueryCritical.Text = "查询警戒库存";
            this.tsbQueryCritical.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbQueryCritical.Click += new System.EventHandler(this.tsbQueryCritical_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = global::EMMS.View.Properties.Resources.refresh;
            this.tsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(63, 53);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::EMMS.View.Properties.Resources.output;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 53);
            this.toolStripButton1.Text = "导出到Excel";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::EMMS.View.Properties.Resources.close;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(65, 53);
            this.tsbClose.Text = "关闭";
            this.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tbGoods
            // 
            this.tbGoods.Location = new System.Drawing.Point(284, 16);
            this.tbGoods.Name = "tbGoods";
            this.tbGoods.ReadOnly = true;
            this.tbGoods.Size = new System.Drawing.Size(100, 21);
            this.tbGoods.TabIndex = 4;
            this.tbGoods.TextChanged += new System.EventHandler(this.tbGoods_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "选择物品";
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.Location = new System.Drawing.Point(68, 17);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.ReadOnly = true;
            this.tbWarehouse.Size = new System.Drawing.Size(100, 21);
            this.tbWarehouse.TabIndex = 1;
            this.tbWarehouse.TextChanged += new System.EventHandler(this.tbWarehouse_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择仓库";
            // 
            // dgvStorage
            // 
            this.dgvStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStorage.Location = new System.Drawing.Point(157, 132);
            this.dgvStorage.Name = "dgvStorage";
            this.dgvStorage.ReadOnly = true;
            this.dgvStorage.RowTemplate.Height = 23;
            this.dgvStorage.Size = new System.Drawing.Size(650, 341);
            this.dgvStorage.TabIndex = 2;
            this.dgvStorage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStorage_CellContentClick);
            this.dgvStorage.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStorage_CellEndEdit);
            this.dgvStorage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStorage_CellValueChanged);
            // 
            // msStorage
            // 
            this.msStorage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入库操作ToolStripMenuItem,
            this.出库操作ToolStripMenuItem,
            this.盘点操作ToolStripMenuItem,
            this.警戒操作ToolStripMenuItem,
            this.请购操作ToolStripMenuItem});
            this.msStorage.Location = new System.Drawing.Point(0, 0);
            this.msStorage.Name = "msStorage";
            this.msStorage.Size = new System.Drawing.Size(819, 25);
            this.msStorage.TabIndex = 3;
            this.msStorage.Text = "menuStrip1";
            // 
            // 入库操作ToolStripMenuItem
            // 
            this.入库操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.物料入库ToolStripMenuItem,
            this.成品入库ToolStripMenuItem,
            this.查询入库ToolStripMenuItem});
            this.入库操作ToolStripMenuItem.Name = "入库操作ToolStripMenuItem";
            this.入库操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.入库操作ToolStripMenuItem.Text = "入库操作";
            // 
            // 物料入库ToolStripMenuItem
            // 
            this.物料入库ToolStripMenuItem.Name = "物料入库ToolStripMenuItem";
            this.物料入库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.物料入库ToolStripMenuItem.Text = "物料入库";
            this.物料入库ToolStripMenuItem.Click += new System.EventHandler(this.物料入库ToolStripMenuItem_Click);
            // 
            // 成品入库ToolStripMenuItem
            // 
            this.成品入库ToolStripMenuItem.Name = "成品入库ToolStripMenuItem";
            this.成品入库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.成品入库ToolStripMenuItem.Text = "成品入库";
            this.成品入库ToolStripMenuItem.Click += new System.EventHandler(this.成品入库ToolStripMenuItem_Click);
            // 
            // 查询入库ToolStripMenuItem
            // 
            this.查询入库ToolStripMenuItem.Name = "查询入库ToolStripMenuItem";
            this.查询入库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.查询入库ToolStripMenuItem.Text = "查询入库单";
            // 
            // 出库操作ToolStripMenuItem
            // 
            this.出库操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.出库ToolStripMenuItem,
            this.查询出库ToolStripMenuItem});
            this.出库操作ToolStripMenuItem.Name = "出库操作ToolStripMenuItem";
            this.出库操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.出库操作ToolStripMenuItem.Text = "出库操作";
            // 
            // 出库ToolStripMenuItem
            // 
            this.出库ToolStripMenuItem.Name = "出库ToolStripMenuItem";
            this.出库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.出库ToolStripMenuItem.Text = "出库";
            this.出库ToolStripMenuItem.Click += new System.EventHandler(this.出库ToolStripMenuItem_Click);
            // 
            // 查询出库ToolStripMenuItem
            // 
            this.查询出库ToolStripMenuItem.Name = "查询出库ToolStripMenuItem";
            this.查询出库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.查询出库ToolStripMenuItem.Text = "查询出库单";
            this.查询出库ToolStripMenuItem.Click += new System.EventHandler(this.查询出库ToolStripMenuItem_Click);
            // 
            // 盘点操作ToolStripMenuItem
            // 
            this.盘点操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.盘点ToolStripMenuItem,
            this.查询盘点单ToolStripMenuItem});
            this.盘点操作ToolStripMenuItem.Name = "盘点操作ToolStripMenuItem";
            this.盘点操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.盘点操作ToolStripMenuItem.Text = "盘点操作";
            // 
            // 盘点ToolStripMenuItem
            // 
            this.盘点ToolStripMenuItem.Name = "盘点ToolStripMenuItem";
            this.盘点ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.盘点ToolStripMenuItem.Text = "盘点";
            this.盘点ToolStripMenuItem.Click += new System.EventHandler(this.盘点ToolStripMenuItem_Click);
            // 
            // 查询盘点单ToolStripMenuItem
            // 
            this.查询盘点单ToolStripMenuItem.Name = "查询盘点单ToolStripMenuItem";
            this.查询盘点单ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.查询盘点单ToolStripMenuItem.Text = "查询盘点单";
            this.查询盘点单ToolStripMenuItem.Click += new System.EventHandler(this.查询盘点单ToolStripMenuItem_Click);
            // 
            // 警戒操作ToolStripMenuItem
            // 
            this.警戒操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置警戒值ToolStripMenuItem,
            this.查询警戒库存ToolStripMenuItem});
            this.警戒操作ToolStripMenuItem.Name = "警戒操作ToolStripMenuItem";
            this.警戒操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.警戒操作ToolStripMenuItem.Text = "警戒操作";
            // 
            // 设置警戒值ToolStripMenuItem
            // 
            this.设置警戒值ToolStripMenuItem.Name = "设置警戒值ToolStripMenuItem";
            this.设置警戒值ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.设置警戒值ToolStripMenuItem.Text = "设置警戒值";
            this.设置警戒值ToolStripMenuItem.Click += new System.EventHandler(this.设置警戒值ToolStripMenuItem_Click);
            // 
            // 查询警戒库存ToolStripMenuItem
            // 
            this.查询警戒库存ToolStripMenuItem.Name = "查询警戒库存ToolStripMenuItem";
            this.查询警戒库存ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查询警戒库存ToolStripMenuItem.Text = "查询警戒库存";
            this.查询警戒库存ToolStripMenuItem.Click += new System.EventHandler(this.查询警戒库存ToolStripMenuItem_Click);
            // 
            // 请购操作ToolStripMenuItem
            // 
            this.请购操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.请购ToolStripMenuItem,
            this.请购单查询ToolStripMenuItem});
            this.请购操作ToolStripMenuItem.Name = "请购操作ToolStripMenuItem";
            this.请购操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.请购操作ToolStripMenuItem.Text = "请购操作";
            // 
            // 请购ToolStripMenuItem
            // 
            this.请购ToolStripMenuItem.Name = "请购ToolStripMenuItem";
            this.请购ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.请购ToolStripMenuItem.Text = "请购";
            this.请购ToolStripMenuItem.Click += new System.EventHandler(this.请购ToolStripMenuItem_Click);
            // 
            // 请购单查询ToolStripMenuItem
            // 
            this.请购单查询ToolStripMenuItem.Name = "请购单查询ToolStripMenuItem";
            this.请购单查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.请购单查询ToolStripMenuItem.Text = "请购单查询";
            this.请购单查询ToolStripMenuItem.Click += new System.EventHandler(this.请购单查询ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnGoods);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbWarehouse);
            this.groupBox1.Controls.Add(this.tbGoods);
            this.groupBox1.Controls.Add(this.btnWarehouse);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 41);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择";
            // 
            // btnGoods
            // 
            this.btnGoods.FlatAppearance.BorderSize = 0;
            this.btnGoods.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGoods.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoods.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnGoods.Location = new System.Drawing.Point(380, 14);
            this.btnGoods.Name = "btnGoods";
            this.btnGoods.Size = new System.Drawing.Size(26, 23);
            this.btnGoods.TabIndex = 5;
            this.btnGoods.UseVisualStyleBackColor = true;
            this.btnGoods.Click += new System.EventHandler(this.btnGoods_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.FlatAppearance.BorderSize = 0;
            this.btnWarehouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWarehouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouse.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnWarehouse.Location = new System.Drawing.Point(163, 16);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(30, 23);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // tvStorage
            // 
            this.tvStorage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvStorage.Location = new System.Drawing.Point(9, 132);
            this.tvStorage.Name = "tvStorage";
            this.tvStorage.Size = new System.Drawing.Size(142, 341);
            this.tvStorage.TabIndex = 7;
            this.tvStorage.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStorage_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Controls.Add(this.lPageAll);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbPage);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Location = new System.Drawing.Point(431, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 36);
            this.panel1.TabIndex = 8;
            // 
            // btnLast
            // 
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Location = new System.Drawing.Point(300, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 6;
            this.btnLast.Text = "最后一页";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Location = new System.Drawing.Point(43, 7);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(59, 23);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "第一页";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lPageAll
            // 
            this.lPageAll.AutoSize = true;
            this.lPageAll.Location = new System.Drawing.Point(236, 12);
            this.lPageAll.Name = "lPageAll";
            this.lPageAll.Size = new System.Drawing.Size(11, 12);
            this.lPageAll.TabIndex = 4;
            this.lPageAll.Text = "l";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "/ ";
            // 
            // tbPage
            // 
            this.tbPage.Location = new System.Drawing.Point(154, 10);
            this.tbPage.Name = "tbPage";
            this.tbPage.Size = new System.Drawing.Size(53, 21);
            this.tbPage.TabIndex = 2;
            this.tbPage.TextChanged += new System.EventHandler(this.tbPage_TextChanged);
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(253, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(58, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Location = new System.Drawing.Point(91, 7);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(57, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "上一页";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lCounts
            // 
            this.lCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lCounts.AutoSize = true;
            this.lCounts.Location = new System.Drawing.Point(157, 480);
            this.lCounts.Name = "lCounts";
            this.lCounts.Size = new System.Drawing.Size(41, 12);
            this.lCounts.TabIndex = 9;
            this.lCounts.Text = "label4";
            // 
            // Storage_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 505);
            this.Controls.Add(this.lCounts);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tvStorage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvStorage);
            this.Controls.Add(this.tbStorage);
            this.Controls.Add(this.msStorage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msStorage;
            this.Name = "Storage_Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库存信息";
            this.Activated += new System.EventHandler(this.Storage_Order_Activated);
            this.Load += new System.EventHandler(this.Storage_Order_Load);
            this.tbStorage.ResumeLayout(false);
            this.tbStorage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorage)).EndInit();
            this.msStorage.ResumeLayout(false);
            this.msStorage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbStorage;
        private System.Windows.Forms.ToolStripButton tsbMStocking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnGoods;
        private System.Windows.Forms.DataGridView dgvStorage;
        private System.Windows.Forms.ToolStripButton tsbOut;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbClose;
        public System.Windows.Forms.TextBox tbWarehouse;
        public System.Windows.Forms.TextBox tbGoods;
        private System.Windows.Forms.ToolStripButton tsbInventory;
        private System.Windows.Forms.MenuStrip msStorage;
        private System.Windows.Forms.ToolStripMenuItem 入库操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出库操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询出库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 盘点操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 盘点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询盘点单ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvStorage;
        private System.Windows.Forms.ToolStripButton tsbCritical;
        private System.Windows.Forms.ToolStripButton tsbQueryCritical;
        private System.Windows.Forms.ToolStripMenuItem 警戒操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置警戒值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询警戒库存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 请购操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 请购ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 请购单查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbPicking;
        private System.Windows.Forms.ToolStripButton tsbPStocking;
        private System.Windows.Forms.ToolStripMenuItem 成品入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物料入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lPageAll;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lCounts;
    }
}