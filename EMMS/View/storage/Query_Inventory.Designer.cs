namespace EMMS.View.storage
{
    partial class Query_Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Query_Inventory));
            this.tsInventory = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDetail = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tsbOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.tsInventory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // tsInventory
            // 
            this.tsInventory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDetail,
            this.toolStripButton3,
            this.tsbOutput,
            this.toolStripButton1});
            this.tsInventory.Location = new System.Drawing.Point(0, 0);
            this.tsInventory.Name = "tsInventory";
            this.tsInventory.Size = new System.Drawing.Size(927, 56);
            this.tsInventory.TabIndex = 0;
            this.tsInventory.Text = "toolStrip1";
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
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::EMMS.View.Properties.Resources.refresh;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(63, 53);
            this.toolStripButton3.Text = "刷新";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::EMMS.View.Properties.Resources.close;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 53);
            this.toolStripButton1.Text = "关闭";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvInventory);
            this.groupBox1.Location = new System.Drawing.Point(24, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(879, 283);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘点单据";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(18, 30);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowTemplate.Height = 23;
            this.dgvInventory.Size = new System.Drawing.Size(841, 236);
            this.dgvInventory.TabIndex = 0;
            // 
            // Query_Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsInventory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Query_Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询盘点单";
            this.Load += new System.EventHandler(this.Query_Inventory_Load);
            this.tsInventory.ResumeLayout(false);
            this.tsInventory.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsInventory;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDetail;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.ToolStripButton tsbOutput;
    }
}