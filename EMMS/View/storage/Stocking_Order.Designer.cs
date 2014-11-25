namespace EMMS.View.storage
{
    partial class Stocking_Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stocking_Order));
            this.tsStocking = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEntry = new System.Windows.Forms.Button();
            this.tbEntry = new System.Windows.Forms.TextBox();
            this.labType = new System.Windows.Forms.Label();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStaff = new System.Windows.Forms.Button();
            this.tbStaff = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStocking = new System.Windows.Forms.DataGridView();
            this.gbGoods = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbMakeTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMakeName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tsStocking.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocking)).BeginInit();
            this.gbGoods.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsStocking
            // 
            this.tsStocking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbCopy,
            this.tsbClose});
            this.tsStocking.Location = new System.Drawing.Point(0, 0);
            this.tsStocking.Name = "tsStocking";
            this.tsStocking.Size = new System.Drawing.Size(662, 56);
            this.tsStocking.TabIndex = 0;
            this.tsStocking.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::EMMS.View.Properties.Resources.save;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(71, 53);
            this.tsbSave.Text = "保存";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Image = global::EMMS.View.Properties.Resources.preview;
            this.tsbCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(84, 53);
            this.tsbCopy.Text = "复制前置单据";
            this.tsbCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnEntry);
            this.groupBox1.Controls.Add(this.tbEntry);
            this.groupBox1.Controls.Add(this.labType);
            this.groupBox1.Controls.Add(this.tbRemarks);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnStaff);
            this.groupBox1.Controls.Add(this.tbStaff);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnWarehouse);
            this.groupBox1.Controls.Add(this.tbWarehouse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 198);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // btnEntry
            // 
            this.btnEntry.FlatAppearance.BorderSize = 0;
            this.btnEntry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEntry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntry.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnEntry.Location = new System.Drawing.Point(232, 133);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(24, 23);
            this.btnEntry.TabIndex = 14;
            this.btnEntry.UseVisualStyleBackColor = true;
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
            // 
            // tbEntry
            // 
            this.tbEntry.Location = new System.Drawing.Point(136, 134);
            this.tbEntry.Name = "tbEntry";
            this.tbEntry.ReadOnly = true;
            this.tbEntry.Size = new System.Drawing.Size(100, 21);
            this.tbEntry.TabIndex = 13;
            this.tbEntry.TextChanged += new System.EventHandler(this.tbEntry_TextChanged);
            // 
            // labType
            // 
            this.labType.AutoSize = true;
            this.labType.Location = new System.Drawing.Point(40, 134);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(65, 12);
            this.labType.TabIndex = 12;
            this.labType.Text = "进  购  单";
            // 
            // tbRemarks
            // 
            this.tbRemarks.Location = new System.Drawing.Point(399, 129);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(206, 53);
            this.tbRemarks.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "备注";
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(399, 69);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(165, 21);
            this.dtpTime.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "入库日期";
            // 
            // btnStaff
            // 
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStaff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnStaff.Location = new System.Drawing.Point(232, 72);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(24, 23);
            this.btnStaff.TabIndex = 7;
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // tbStaff
            // 
            this.tbStaff.Location = new System.Drawing.Point(136, 74);
            this.tbStaff.Name = "tbStaff";
            this.tbStaff.ReadOnly = true;
            this.tbStaff.Size = new System.Drawing.Size(100, 21);
            this.tbStaff.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "经  手  人";
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.FlatAppearance.BorderSize = 0;
            this.btnWarehouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWarehouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouse.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnWarehouse.Location = new System.Drawing.Point(496, 18);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(22, 23);
            this.btnWarehouse.TabIndex = 4;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.Location = new System.Drawing.Point(399, 19);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.ReadOnly = true;
            this.tbWarehouse.Size = new System.Drawing.Size(100, 21);
            this.tbWarehouse.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "入货仓库";
            // 
            // tbNo
            // 
            this.tbNo.Location = new System.Drawing.Point(136, 25);
            this.tbNo.Name = "tbNo";
            this.tbNo.ReadOnly = true;
            this.tbNo.Size = new System.Drawing.Size(100, 21);
            this.tbNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "入库单编码";
            // 
            // dgvStocking
            // 
            this.dgvStocking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStocking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStocking.Location = new System.Drawing.Point(6, 20);
            this.dgvStocking.Name = "dgvStocking";
            this.dgvStocking.RowTemplate.Height = 23;
            this.dgvStocking.Size = new System.Drawing.Size(621, 245);
            this.dgvStocking.TabIndex = 2;
            this.dgvStocking.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStocking_CellClick);
            this.dgvStocking.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStocking_CellContentClick);
            this.dgvStocking.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStocking_CellEndEdit);
            // 
            // gbGoods
            // 
            this.gbGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGoods.Controls.Add(this.dgvStocking);
            this.gbGoods.Location = new System.Drawing.Point(17, 282);
            this.gbGoods.Name = "gbGoods";
            this.gbGoods.Size = new System.Drawing.Size(633, 271);
            this.gbGoods.TabIndex = 3;
            this.gbGoods.TabStop = false;
            this.gbGoods.Text = "物品信息";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbMakeTime);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbMakeName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 567);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 30);
            this.panel1.TabIndex = 4;
            // 
            // tbMakeTime
            // 
            this.tbMakeTime.Location = new System.Drawing.Point(453, 3);
            this.tbMakeTime.Name = "tbMakeTime";
            this.tbMakeTime.ReadOnly = true;
            this.tbMakeTime.Size = new System.Drawing.Size(118, 21);
            this.tbMakeTime.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "制表时间";
            // 
            // tbMakeName
            // 
            this.tbMakeName.Location = new System.Drawing.Point(88, 3);
            this.tbMakeName.Name = "tbMakeName";
            this.tbMakeName.ReadOnly = true;
            this.tbMakeName.Size = new System.Drawing.Size(114, 21);
            this.tbMakeName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "制表人";
            // 
            // Stocking_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 597);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbGoods);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsStocking);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Stocking_Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入库单信息";
            this.Activated += new System.EventHandler(this.Stocking_Order_Activated);
            this.Load += new System.EventHandler(this.Stocking_Order_Load);
            this.tsStocking.ResumeLayout(false);
            this.tsStocking.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocking)).EndInit();
            this.gbGoods.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsStocking;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.TextBox tbWarehouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.TextBox tbStaff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.DataGridView dgvStocking;
        private System.Windows.Forms.GroupBox gbGoods;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbMakeTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMakeName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labType;
        private System.Windows.Forms.Button btnEntry;
        private System.Windows.Forms.TextBox tbEntry;
    }
}