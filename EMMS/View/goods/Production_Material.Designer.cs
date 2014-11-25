namespace EMMS.View.goods
{
    partial class Production_Material
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production_Material));
            this.label1 = new System.Windows.Forms.Label();
            this.cbProduction = new System.Windows.Forms.ComboBox();
            this.dgvBOM = new System.Windows.Forms.DataGridView();
            this.tsProdMate = new System.Windows.Forms.ToolStrip();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.tvBOM = new System.Windows.Forms.TreeView();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbAlter = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).BeginInit();
            this.tsProdMate.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择产品";
            // 
            // cbProduction
            // 
            this.cbProduction.FormattingEnabled = true;
            this.cbProduction.Location = new System.Drawing.Point(95, 20);
            this.cbProduction.Name = "cbProduction";
            this.cbProduction.Size = new System.Drawing.Size(121, 20);
            this.cbProduction.TabIndex = 1;
            this.cbProduction.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgvBOM
            // 
            this.dgvBOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOM.Location = new System.Drawing.Point(132, 132);
            this.dgvBOM.Name = "dgvBOM";
            this.dgvBOM.RowTemplate.Height = 23;
            this.dgvBOM.Size = new System.Drawing.Size(296, 252);
            this.dgvBOM.TabIndex = 2;
            this.dgvBOM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOM_CellContentClick);
            // 
            // tsProdMate
            // 
            this.tsProdMate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDelete,
            this.tsbAlter,
            this.tsbRefresh,
            this.tsbClose});
            this.tsProdMate.Location = new System.Drawing.Point(0, 0);
            this.tsProdMate.Name = "tsProdMate";
            this.tsProdMate.Size = new System.Drawing.Size(443, 55);
            this.tsProdMate.TabIndex = 3;
            this.tsProdMate.Text = "toolStrip1";
            // 
            // group1
            // 
            this.group1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group1.Controls.Add(this.label1);
            this.group1.Controls.Add(this.cbProduction);
            this.group1.Location = new System.Drawing.Point(12, 63);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(264, 63);
            this.group1.TabIndex = 7;
            this.group1.TabStop = false;
            this.group1.Text = "查找";
            // 
            // tvBOM
            // 
            this.tvBOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvBOM.Location = new System.Drawing.Point(12, 132);
            this.tvBOM.Name = "tvBOM";
            this.tvBOM.Size = new System.Drawing.Size(114, 252);
            this.tvBOM.TabIndex = 8;
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::EMMS.View.Properties.Resources.add;
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(67, 52);
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
            this.tsbDelete.Size = new System.Drawing.Size(74, 52);
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
            this.tsbAlter.Size = new System.Drawing.Size(73, 52);
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
            this.tsbRefresh.Size = new System.Drawing.Size(63, 52);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::EMMS.View.Properties.Resources.close;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(65, 52);
            this.tsbClose.Text = "关闭";
            this.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // Production_Material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 396);
            this.Controls.Add(this.tvBOM);
            this.Controls.Add(this.group1);
            this.Controls.Add(this.tsProdMate);
            this.Controls.Add(this.dgvBOM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Production_Material";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品BOM";
            this.Load += new System.EventHandler(this.Production_Material_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).EndInit();
            this.tsProdMate.ResumeLayout(false);
            this.tsProdMate.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProduction;
        private System.Windows.Forms.DataGridView dgvBOM;
        private System.Windows.Forms.ToolStrip tsProdMate;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.TreeView tvBOM;
        private System.Windows.Forms.ToolStripButton tsbAlter;

    }
}