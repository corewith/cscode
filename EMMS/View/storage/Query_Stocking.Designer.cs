namespace EMMS.View.storage
{
    partial class Query_Stocking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Query_Stocking));
            this.tsStocking = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDetail = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbOutput = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMaterial = new System.Windows.Forms.RadioButton();
            this.rbProd = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvStocking = new System.Windows.Forms.DataGridView();
            this.tsStocking.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocking)).BeginInit();
            this.SuspendLayout();
            // 
            // tsStocking
            // 
            this.tsStocking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDetail,
            this.tsbRefresh,
            this.tsbOutput,
            this.tsbClose});
            this.tsStocking.Location = new System.Drawing.Point(0, 0);
            this.tsStocking.Name = "tsStocking";
            this.tsStocking.Size = new System.Drawing.Size(704, 56);
            this.tsStocking.TabIndex = 0;
            this.tsStocking.Text = "toolStrip1";
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
            // tsbDetail
            // 
            this.tsbDetail.Image = global::EMMS.View.Properties.Resources.detail;
            this.tsbDetail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDetail.Name = "tsbDetail";
            this.tsbDetail.Size = new System.Drawing.Size(69, 53);
            this.tsbDetail.Text = "查看详情";
            this.tsbDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDetail.Click += new System.EventHandler(this.tsbDetail_Click);
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
            this.groupBox1.Controls.Add(this.rbMaterial);
            this.groupBox1.Controls.Add(this.rbProd);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Location = new System.Drawing.Point(63, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找";
            // 
            // rbMaterial
            // 
            this.rbMaterial.AutoSize = true;
            this.rbMaterial.Location = new System.Drawing.Point(163, 20);
            this.rbMaterial.Name = "rbMaterial";
            this.rbMaterial.Size = new System.Drawing.Size(71, 16);
            this.rbMaterial.TabIndex = 2;
            this.rbMaterial.TabStop = true;
            this.rbMaterial.Text = "物料入库";
            this.rbMaterial.UseVisualStyleBackColor = true;
            this.rbMaterial.CheckedChanged += new System.EventHandler(this.rbMaterial_CheckedChanged);
            // 
            // rbProd
            // 
            this.rbProd.AutoSize = true;
            this.rbProd.Location = new System.Drawing.Point(86, 20);
            this.rbProd.Name = "rbProd";
            this.rbProd.Size = new System.Drawing.Size(71, 16);
            this.rbProd.TabIndex = 1;
            this.rbProd.TabStop = true;
            this.rbProd.Text = "成品入库";
            this.rbProd.UseVisualStyleBackColor = true;
            this.rbProd.CheckedChanged += new System.EventHandler(this.rbProd_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(33, 21);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(47, 16);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "所有";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvStocking);
            this.groupBox2.Location = new System.Drawing.Point(28, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(644, 287);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入库信息";
            // 
            // dgvStocking
            // 
            this.dgvStocking.AllowUserToDeleteRows = false;
            this.dgvStocking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStocking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStocking.Location = new System.Drawing.Point(20, 21);
            this.dgvStocking.Name = "dgvStocking";
            this.dgvStocking.ReadOnly = true;
            this.dgvStocking.RowTemplate.Height = 23;
            this.dgvStocking.Size = new System.Drawing.Size(603, 260);
            this.dgvStocking.TabIndex = 0;
            // 
            // Query_Stocking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 428);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsStocking);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Query_Stocking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入库单查询";
            this.Load += new System.EventHandler(this.Query_Stocking_Load);
            this.tsStocking.ResumeLayout(false);
            this.tsStocking.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsStocking;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDetail;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMaterial;
        private System.Windows.Forms.RadioButton rbProd;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvStocking;
        private System.Windows.Forms.ToolStripButton tsbOutput;
    }
}