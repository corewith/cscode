namespace EMMS.View.warehouse
{
    partial class Warehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warehouse));
            this.tsWarehouse = new System.Windows.Forms.ToolStrip();
            this.tsbWarehouseAttri = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbAlter = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbOutput = new System.Windows.Forms.ToolStripButton();
            this.tbsClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvWarehouseAttri = new System.Windows.Forms.TreeView();
            this.dgvWarehouse = new System.Windows.Forms.DataGridView();
            this.tsWarehouse.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // tsWarehouse
            // 
            this.tsWarehouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbWarehouseAttri,
            this.tsbAdd,
            this.tsbDelete,
            this.tsbAlter,
            this.tsbRefresh,
            this.tsbOutput,
            this.tbsClose});
            this.tsWarehouse.Location = new System.Drawing.Point(0, 0);
            this.tsWarehouse.Name = "tsWarehouse";
            this.tsWarehouse.Size = new System.Drawing.Size(725, 56);
            this.tsWarehouse.TabIndex = 0;
            // 
            // tsbWarehouseAttri
            // 
            this.tsbWarehouseAttri.Image = global::EMMS.View.Properties.Resources.attri;
            this.tsbWarehouseAttri.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbWarehouseAttri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWarehouseAttri.Name = "tsbWarehouseAttri";
            this.tsbWarehouseAttri.Size = new System.Drawing.Size(74, 53);
            this.tsbWarehouseAttri.Text = "仓库类别";
            this.tsbWarehouseAttri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbWarehouseAttri.Click += new System.EventHandler(this.tsbWarehouseAttri_Click);
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::EMMS.View.Properties.Resources.add;
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(67, 53);
            this.tsbAdd.Text = "增加";
            this.tsbAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::EMMS.View.Properties.Resources.delete;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(74, 53);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbAlter
            // 
            this.tsbAlter.Image = global::EMMS.View.Properties.Resources.alter;
            this.tsbAlter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAlter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlter.Name = "tsbAlter";
            this.tsbAlter.Size = new System.Drawing.Size(73, 53);
            this.tsbAlter.Text = "修改";
            this.tsbAlter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAlter.Click += new System.EventHandler(this.tsbAlter_Click);
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
            // tsbOutput
            // 
            this.tsbOutput.Image = global::EMMS.View.Properties.Resources.output;
            this.tsbOutput.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOutput.Name = "tsbOutput";
            this.tsbOutput.Size = new System.Drawing.Size(77, 53);
            this.tsbOutput.Text = "导出到Excel";
            this.tsbOutput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOutput.Click += new System.EventHandler(this.tsbOutput_Click);
            // 
            // tbsClose
            // 
            this.tbsClose.Image = global::EMMS.View.Properties.Resources.close;
            this.tbsClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsClose.Name = "tbsClose";
            this.tbsClose.Size = new System.Drawing.Size(65, 53);
            this.tbsClose.Text = "关闭";
            this.tbsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbsClose.Click += new System.EventHandler(this.tbsClose_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 38);
            this.panel1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(588, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(470, 8);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 21);
            this.tbSearch.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入仓库名称\\编码查找：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库类别";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 109);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvWarehouseAttri);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvWarehouse);
            this.splitContainer1.Size = new System.Drawing.Size(701, 309);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvWarehouseAttri
            // 
            this.tvWarehouseAttri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvWarehouseAttri.Location = new System.Drawing.Point(3, 3);
            this.tvWarehouseAttri.Name = "tvWarehouseAttri";
            this.tvWarehouseAttri.Size = new System.Drawing.Size(120, 293);
            this.tvWarehouseAttri.TabIndex = 0;
            this.tvWarehouseAttri.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvWarehouseAttri_AfterSelect);
            this.tvWarehouseAttri.Click += new System.EventHandler(this.tvWarehouseAttri_Click);
            this.tvWarehouseAttri.Enter += new System.EventHandler(this.tvWarehouseAttri_Enter);
            // 
            // dgvWarehouse
            // 
            this.dgvWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouse.Location = new System.Drawing.Point(0, 3);
            this.dgvWarehouse.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.dgvWarehouse.Name = "dgvWarehouse";
            this.dgvWarehouse.RowTemplate.Height = 23;
            this.dgvWarehouse.Size = new System.Drawing.Size(550, 293);
            this.dgvWarehouse.TabIndex = 0;
            this.dgvWarehouse.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouse_CellEndEdit);
            this.dgvWarehouse.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouse_CellValueChanged);
            this.dgvWarehouse.Enter += new System.EventHandler(this.dgvWarehouse_Enter);
            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 430);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsWarehouse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Warehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库信息";
            this.Activated += new System.EventHandler(this.Warehouse_Activated);
            this.Load += new System.EventHandler(this.Warehouse_Load);
            this.Enter += new System.EventHandler(this.Warehouse_Enter);
            this.tsWarehouse.ResumeLayout(false);
            this.tsWarehouse.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsWarehouse;
        internal System.Windows.Forms.ToolStripButton tsbWarehouseAttri;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbAlter;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tbsClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvWarehouseAttri;
        private System.Windows.Forms.DataGridView dgvWarehouse;
        private System.Windows.Forms.ToolStripButton tsbOutput;
    }
}