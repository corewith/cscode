namespace EMMS.View.paying
{
    partial class Query
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Query));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbEnded = new System.Windows.Forms.RadioButton();
            this.rbUnended = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPaying = new System.Windows.Forms.DataGridView();
            this.tsPicking = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDetail = new System.Windows.Forms.ToolStripButton();
            this.tsbPayed = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaying)).BeginInit();
            this.tsPicking.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(23, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 53);
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
            this.groupBox2.Controls.Add(this.dgvPaying);
            this.groupBox2.Location = new System.Drawing.Point(23, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 245);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "物料信息";
            // 
            // dgvPaying
            // 
            this.dgvPaying.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaying.Location = new System.Drawing.Point(16, 20);
            this.dgvPaying.Name = "dgvPaying";
            this.dgvPaying.ReadOnly = true;
            this.dgvPaying.RowTemplate.Height = 23;
            this.dgvPaying.Size = new System.Drawing.Size(571, 219);
            this.dgvPaying.TabIndex = 0;
            this.dgvPaying.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPaying_RowHeaderMouseDoubleClick);
            // 
            // tsPicking
            // 
            this.tsPicking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDetail,
            this.tsbPayed,
            this.tsbRefresh,
            this.toolStripButton1,
            this.tsbClose});
            this.tsPicking.Location = new System.Drawing.Point(0, 0);
            this.tsPicking.Name = "tsPicking";
            this.tsPicking.Size = new System.Drawing.Size(659, 56);
            this.tsPicking.TabIndex = 2;
            this.tsPicking.Text = "toolStrip1";
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
            // tsbPayed
            // 
            this.tsbPayed.Image = global::EMMS.View.Properties.Resources.next;
            this.tsbPayed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPayed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPayed.Name = "tsbPayed";
            this.tsbPayed.Size = new System.Drawing.Size(96, 53);
            this.tsbPayed.Text = "生成付款结算单";
            this.tsbPayed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPayed.Click += new System.EventHandler(this.tsbPayed_Click);
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
            // Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 386);
            this.Controls.Add(this.tsPicking);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Query";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应付款项单查询";
            this.Activated += new System.EventHandler(this.Query_Activated);
            this.Load += new System.EventHandler(this.Query_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaying)).EndInit();
            this.tsPicking.ResumeLayout(false);
            this.tsPicking.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPaying;
        private System.Windows.Forms.ToolStrip tsPicking;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbEnded;
        private System.Windows.Forms.RadioButton rbUnended;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.ToolStripButton tsbDetail;
        private System.Windows.Forms.ToolStripButton tsbPayed;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}