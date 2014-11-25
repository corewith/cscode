namespace EMMS.View.picking
{
    partial class Query_Picking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Query_Picking));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbEnded = new System.Windows.Forms.RadioButton();
            this.rbUnended = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPicking = new System.Windows.Forms.DataGridView();
            this.tsPicking = new System.Windows.Forms.ToolStrip();
            this.tsbDetail = new System.Windows.Forms.ToolStripButton();
            this.tsbInventory = new System.Windows.Forms.ToolStripButton();
            this.tsbDelivery = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbOutput = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPicking)).BeginInit();
            this.tsPicking.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(23, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbEnded);
            this.panel1.Controls.Add(this.rbUnended);
            this.panel1.Controls.Add(this.rbAll);
            this.panel1.Location = new System.Drawing.Point(27, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 27);
            this.panel1.TabIndex = 0;
            // 
            // rbEnded
            // 
            this.rbEnded.AutoSize = true;
            this.rbEnded.Location = new System.Drawing.Point(121, 4);
            this.rbEnded.Name = "rbEnded";
            this.rbEnded.Size = new System.Drawing.Size(59, 16);
            this.rbEnded.TabIndex = 2;
            this.rbEnded.TabStop = true;
            this.rbEnded.Text = "已结束";
            this.rbEnded.UseVisualStyleBackColor = true;
            this.rbEnded.CheckedChanged += new System.EventHandler(this.rbEnded_CheckedChanged);
            // 
            // rbUnended
            // 
            this.rbUnended.AutoSize = true;
            this.rbUnended.Location = new System.Drawing.Point(57, 4);
            this.rbUnended.Name = "rbUnended";
            this.rbUnended.Size = new System.Drawing.Size(59, 16);
            this.rbUnended.TabIndex = 1;
            this.rbUnended.TabStop = true;
            this.rbUnended.Text = "未结束";
            this.rbUnended.UseVisualStyleBackColor = true;
            this.rbUnended.CheckedChanged += new System.EventHandler(this.rbUnended_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(4, 4);
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
            this.groupBox2.Controls.Add(this.dgvPicking);
            this.groupBox2.Location = new System.Drawing.Point(23, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 204);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "领料单信息";
            // 
            // dgvPicking
            // 
            this.dgvPicking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPicking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPicking.Location = new System.Drawing.Point(16, 29);
            this.dgvPicking.Name = "dgvPicking";
            this.dgvPicking.ReadOnly = true;
            this.dgvPicking.RowTemplate.Height = 23;
            this.dgvPicking.Size = new System.Drawing.Size(579, 159);
            this.dgvPicking.TabIndex = 0;
            this.dgvPicking.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPicking_RowHeaderMouseDoubleClick);
            // 
            // tsPicking
            // 
            this.tsPicking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDetail,
            this.tsbInventory,
            this.tsbDelivery,
            this.tsbRefresh,
            this.tsbOutput,
            this.tsbClose});
            this.tsPicking.Location = new System.Drawing.Point(0, 0);
            this.tsPicking.Name = "tsPicking";
            this.tsPicking.Size = new System.Drawing.Size(659, 56);
            this.tsPicking.TabIndex = 2;
            this.tsPicking.Text = "toolStrip1";
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
            // tsbInventory
            // 
            this.tsbInventory.Image = global::EMMS.View.Properties.Resources.preview;
            this.tsbInventory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInventory.Name = "tsbInventory";
            this.tsbInventory.Size = new System.Drawing.Size(120, 53);
            this.tsbInventory.Text = "根据领料单作盘点单";
            this.tsbInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbInventory.Click += new System.EventHandler(this.tsbInventory_Click);
            // 
            // tsbDelivery
            // 
            this.tsbDelivery.Image = global::EMMS.View.Properties.Resources.next;
            this.tsbDelivery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelivery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelivery.Name = "tsbDelivery";
            this.tsbDelivery.Size = new System.Drawing.Size(72, 53);
            this.tsbDelivery.Text = "生成出库单";
            this.tsbDelivery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelivery.Click += new System.EventHandler(this.tsbDelivery_Click);
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
            // Query_Picking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 342);
            this.Controls.Add(this.tsPicking);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Query_Picking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "领料单查询";
            this.Load += new System.EventHandler(this.Query_Picking_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPicking)).EndInit();
            this.tsPicking.ResumeLayout(false);
            this.tsPicking.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPicking;
        private System.Windows.Forms.ToolStrip tsPicking;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbEnded;
        private System.Windows.Forms.RadioButton rbUnended;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.ToolStripButton tsbDetail;
        private System.Windows.Forms.ToolStripButton tsbDelivery;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbInventory;
        private System.Windows.Forms.ToolStripButton tsbOutput;
    }
}