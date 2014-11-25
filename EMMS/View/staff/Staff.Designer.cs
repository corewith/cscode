namespace EMMS.View.staff
{
    partial class Staff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staff));
            this.tsStaff = new System.Windows.Forms.ToolStrip();
            this.tsbDepartment = new System.Windows.Forms.ToolStripButton();
            this.tsbJob = new System.Windows.Forms.ToolStripButton();
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
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.tvDepJob = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tsStaff.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsStaff
            // 
            this.tsStaff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDepartment,
            this.tsbJob,
            this.tsbAdd,
            this.tsbDelete,
            this.tsbAlter,
            this.tsbRefresh,
            this.tsbOutput,
            this.tbsClose});
            this.tsStaff.Location = new System.Drawing.Point(0, 0);
            this.tsStaff.Name = "tsStaff";
            this.tsStaff.Size = new System.Drawing.Size(928, 56);
            this.tsStaff.TabIndex = 0;
            // 
            // tsbDepartment
            // 
            this.tsbDepartment.Image = global::EMMS.View.Properties.Resources.attri;
            this.tsbDepartment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDepartment.Name = "tsbDepartment";
            this.tsbDepartment.Size = new System.Drawing.Size(74, 53);
            this.tsbDepartment.Text = "部门";
            this.tsbDepartment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDepartment.Click += new System.EventHandler(this.tsbDepartment_Click);
            // 
            // tsbJob
            // 
            this.tsbJob.Image = global::EMMS.View.Properties.Resources.storage_info;
            this.tsbJob.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJob.Name = "tsbJob";
            this.tsbJob.Size = new System.Drawing.Size(40, 53);
            this.tsbJob.Text = "职务";
            this.tsbJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbJob.Click += new System.EventHandler(this.tsbWarehouseAttri_Click);
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
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 38);
            this.panel1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(661, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(543, 8);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 21);
            this.tbSearch.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入人员名称\\编码\\部门\\职务查找：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门与职务";
            // 
            // dgvStaff
            // 
            this.dgvStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Location = new System.Drawing.Point(0, 0);
            this.dgvStaff.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowTemplate.Height = 23;
            this.dgvStaff.Size = new System.Drawing.Size(738, 346);
            this.dgvStaff.TabIndex = 0;
            this.dgvStaff.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouse_CellEndEdit);
            this.dgvStaff.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouse_CellValueChanged);
            this.dgvStaff.Enter += new System.EventHandler(this.dgvWarehouse_Enter);
            // 
            // tvDepJob
            // 
            this.tvDepJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDepJob.Location = new System.Drawing.Point(0, 3);
            this.tvDepJob.Name = "tvDepJob";
            this.tvDepJob.Size = new System.Drawing.Size(171, 343);
            this.tvDepJob.TabIndex = 0;
            this.tvDepJob.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvWarehouseAttri_AfterSelect);
            this.tvDepJob.Click += new System.EventHandler(this.tvWarehouseAttri_Click);
            this.tvDepJob.Enter += new System.EventHandler(this.tvWarehouseAttri_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 125);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDepJob);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvStaff);
            this.splitContainer1.Size = new System.Drawing.Size(913, 346);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 2;
            // 
            // Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 497);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsStaff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Staff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员信息";
            this.Activated += new System.EventHandler(this.Warehouse_Activated);
            this.Load += new System.EventHandler(this.Warehouse_Load);
            this.Enter += new System.EventHandler(this.Warehouse_Enter);
            this.tsStaff.ResumeLayout(false);
            this.tsStaff.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsStaff;
        internal System.Windows.Forms.ToolStripButton tsbJob;
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
        private System.Windows.Forms.ToolStripButton tsbDepartment;
        private System.Windows.Forms.ToolStripButton tsbOutput;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.TreeView tvDepJob;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}