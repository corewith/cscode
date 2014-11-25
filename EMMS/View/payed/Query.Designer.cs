namespace EMMS.View.payed
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbUnended = new System.Windows.Forms.RadioButton();
            this.rbEnded = new System.Windows.Forms.RadioButton();
            this.rbAll1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbUnaudited = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbAudited = new System.Windows.Forms.RadioButton();
            this.tsQuery = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDetail = new System.Windows.Forms.ToolStripButton();
            this.tsbCheck = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbOutput = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.dgvQuery = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(22, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.rbUnended);
            this.panel2.Controls.Add(this.rbEnded);
            this.panel2.Controls.Add(this.rbAll1);
            this.panel2.Location = new System.Drawing.Point(236, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 35);
            this.panel2.TabIndex = 4;
            // 
            // rbUnended
            // 
            this.rbUnended.AutoSize = true;
            this.rbUnended.Location = new System.Drawing.Point(129, 10);
            this.rbUnended.Name = "rbUnended";
            this.rbUnended.Size = new System.Drawing.Size(59, 16);
            this.rbUnended.TabIndex = 2;
            this.rbUnended.TabStop = true;
            this.rbUnended.Text = "未结束";
            this.rbUnended.UseVisualStyleBackColor = true;
            this.rbUnended.CheckedChanged += new System.EventHandler(this.rbUnended_CheckedChanged);
            // 
            // rbEnded
            // 
            this.rbEnded.AutoSize = true;
            this.rbEnded.Location = new System.Drawing.Point(64, 10);
            this.rbEnded.Name = "rbEnded";
            this.rbEnded.Size = new System.Drawing.Size(59, 16);
            this.rbEnded.TabIndex = 1;
            this.rbEnded.TabStop = true;
            this.rbEnded.Text = "已结束";
            this.rbEnded.UseVisualStyleBackColor = true;
            this.rbEnded.CheckedChanged += new System.EventHandler(this.rbEnded_CheckedChanged);
            // 
            // rbAll1
            // 
            this.rbAll1.AutoSize = true;
            this.rbAll1.Location = new System.Drawing.Point(4, 10);
            this.rbAll1.Name = "rbAll1";
            this.rbAll1.Size = new System.Drawing.Size(53, 16);
            this.rbAll1.TabIndex = 0;
            this.rbAll1.TabStop = true;
            this.rbAll1.Text = " 所有";
            this.rbAll1.UseVisualStyleBackColor = true;
            this.rbAll1.CheckedChanged += new System.EventHandler(this.rbAll1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.rbUnaudited);
            this.panel1.Controls.Add(this.rbAll);
            this.panel1.Controls.Add(this.rbAudited);
            this.panel1.Location = new System.Drawing.Point(22, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 35);
            this.panel1.TabIndex = 3;
            // 
            // rbUnaudited
            // 
            this.rbUnaudited.AutoSize = true;
            this.rbUnaudited.Location = new System.Drawing.Point(122, 8);
            this.rbUnaudited.Name = "rbUnaudited";
            this.rbUnaudited.Size = new System.Drawing.Size(59, 16);
            this.rbUnaudited.TabIndex = 1;
            this.rbUnaudited.TabStop = true;
            this.rbUnaudited.Text = "未审核";
            this.rbUnaudited.UseVisualStyleBackColor = true;
            this.rbUnaudited.CheckedChanged += new System.EventHandler(this.rbUnaudited_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(13, 8);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(47, 16);
            this.rbAll.TabIndex = 2;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "所有";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbAudited
            // 
            this.rbAudited.AutoSize = true;
            this.rbAudited.Location = new System.Drawing.Point(66, 8);
            this.rbAudited.Name = "rbAudited";
            this.rbAudited.Size = new System.Drawing.Size(59, 16);
            this.rbAudited.TabIndex = 0;
            this.rbAudited.TabStop = true;
            this.rbAudited.Text = "已审核";
            this.rbAudited.UseVisualStyleBackColor = true;
            this.rbAudited.CheckedChanged += new System.EventHandler(this.rbAudited_CheckedChanged);
            // 
            // tsQuery
            // 
            this.tsQuery.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDetail,
            this.tsbCheck,
            this.tsbRefresh,
            this.tsbOutput,
            this.tsbClose});
            this.tsQuery.Location = new System.Drawing.Point(0, 0);
            this.tsQuery.Name = "tsQuery";
            this.tsQuery.Size = new System.Drawing.Size(695, 56);
            this.tsQuery.TabIndex = 1;
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
            // tsbCheck
            // 
            this.tsbCheck.Image = global::EMMS.View.Properties.Resources.save;
            this.tsbCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheck.Name = "tsbCheck";
            this.tsbCheck.Size = new System.Drawing.Size(71, 53);
            this.tsbCheck.Text = "审核单据";
            this.tsbCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCheck.Click += new System.EventHandler(this.tsbCheck_Click);
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
            // dgvQuery
            // 
            this.dgvQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuery.Location = new System.Drawing.Point(22, 131);
            this.dgvQuery.Name = "dgvQuery";
            this.dgvQuery.ReadOnly = true;
            this.dgvQuery.RowTemplate.Height = 23;
            this.dgvQuery.Size = new System.Drawing.Size(648, 245);
            this.dgvQuery.TabIndex = 2;
            // 
            // Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 388);
            this.Controls.Add(this.dgvQuery);
            this.Controls.Add(this.tsQuery);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Query";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询付款结算单";
            this.Activated += new System.EventHandler(this.Query_Activated);
            this.Load += new System.EventHandler(this.Query_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsQuery.ResumeLayout(false);
            this.tsQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip tsQuery;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbCheck;
        private System.Windows.Forms.RadioButton rbAudited;
        private System.Windows.Forms.RadioButton rbUnaudited;
        private System.Windows.Forms.DataGridView dgvQuery;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbAll1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbUnended;
        private System.Windows.Forms.RadioButton rbEnded;
        private System.Windows.Forms.ToolStripButton tsbDetail;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbOutput;
    }
}