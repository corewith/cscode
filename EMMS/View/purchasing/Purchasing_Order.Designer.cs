﻿namespace EMMS.View.purchasing
{
    partial class Purchasing_Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchasing_Order));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRequisition = new System.Windows.Forms.Button();
            this.tbRequisition = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnStaff = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStaff = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.tbSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsPurchasing = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbMakeTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMakeName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPurchasing = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tsPurchasing.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchasing)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRequisition);
            this.groupBox1.Controls.Add(this.tbRequisition);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbRemarks);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpTime);
            this.groupBox1.Controls.Add(this.btnStaff);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbStaff);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSupplier);
            this.groupBox1.Controls.Add(this.tbSupplier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // btnRequisition
            // 
            this.btnRequisition.FlatAppearance.BorderSize = 0;
            this.btnRequisition.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRequisition.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRequisition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequisition.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnRequisition.Location = new System.Drawing.Point(228, 129);
            this.btnRequisition.Name = "btnRequisition";
            this.btnRequisition.Size = new System.Drawing.Size(21, 23);
            this.btnRequisition.TabIndex = 14;
            this.btnRequisition.UseVisualStyleBackColor = true;
            this.btnRequisition.Click += new System.EventHandler(this.btnRequisition_Click);
            // 
            // tbRequisition
            // 
            this.tbRequisition.Location = new System.Drawing.Point(132, 129);
            this.tbRequisition.Name = "tbRequisition";
            this.tbRequisition.ReadOnly = true;
            this.tbRequisition.Size = new System.Drawing.Size(100, 21);
            this.tbRequisition.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "请  购  单";
            // 
            // tbRemarks
            // 
            this.tbRemarks.Location = new System.Drawing.Point(385, 129);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(309, 46);
            this.tbRemarks.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "备注";
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(385, 74);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(171, 21);
            this.dtpTime.TabIndex = 9;
            // 
            // btnStaff
            // 
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStaff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnStaff.Location = new System.Drawing.Point(228, 72);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(21, 23);
            this.btnStaff.TabIndex = 8;
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "经手时间";
            // 
            // tbStaff
            // 
            this.tbStaff.Location = new System.Drawing.Point(132, 74);
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
            // btnSupplier
            // 
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnSupplier.Location = new System.Drawing.Point(482, 26);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(20, 23);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // tbSupplier
            // 
            this.tbSupplier.Location = new System.Drawing.Point(385, 26);
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.ReadOnly = true;
            this.tbSupplier.Size = new System.Drawing.Size(100, 21);
            this.tbSupplier.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "供 应 商";
            // 
            // tbNo
            // 
            this.tbNo.Location = new System.Drawing.Point(132, 23);
            this.tbNo.Name = "tbNo";
            this.tbNo.ReadOnly = true;
            this.tbNo.Size = new System.Drawing.Size(100, 21);
            this.tbNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "采购单编码";
            // 
            // tsPurchasing
            // 
            this.tsPurchasing.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbCopy,
            this.tsbClose});
            this.tsPurchasing.Location = new System.Drawing.Point(0, 0);
            this.tsPurchasing.Name = "tsPurchasing";
            this.tsPurchasing.Size = new System.Drawing.Size(784, 56);
            this.tsPurchasing.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.tbMakeTime);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbMakeName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 562);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 31);
            this.panel1.TabIndex = 2;
            // 
            // tbMakeTime
            // 
            this.tbMakeTime.Location = new System.Drawing.Point(506, 3);
            this.tbMakeTime.Name = "tbMakeTime";
            this.tbMakeTime.ReadOnly = true;
            this.tbMakeTime.Size = new System.Drawing.Size(100, 21);
            this.tbMakeTime.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(431, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "制表时间";
            // 
            // tbMakeName
            // 
            this.tbMakeName.Location = new System.Drawing.Point(132, 6);
            this.tbMakeName.Name = "tbMakeName";
            this.tbMakeName.ReadOnly = true;
            this.tbMakeName.Size = new System.Drawing.Size(100, 21);
            this.tbMakeName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "制表人";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.dgvPurchasing);
            this.groupBox2.Location = new System.Drawing.Point(13, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 282);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "物料信息";
            // 
            // dgvPurchasing
            // 
            this.dgvPurchasing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchasing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchasing.Location = new System.Drawing.Point(7, 21);
            this.dgvPurchasing.Name = "dgvPurchasing";
            this.dgvPurchasing.RowTemplate.Height = 23;
            this.dgvPurchasing.Size = new System.Drawing.Size(734, 255);
            this.dgvPurchasing.TabIndex = 0;
            this.dgvPurchasing.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStocking_CellClick);
            this.dgvPurchasing.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStocking_CellContentClick);
            this.dgvPurchasing.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStocking_CellEndEdit);
            this.dgvPurchasing.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDelivery_CellValueChanged);
            // 
            // Purchasing_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 593);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsPurchasing);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Purchasing_Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采购单信息";
            this.Activated += new System.EventHandler(this.Stocking_Order_Activated);
            this.Load += new System.EventHandler(this.Purchasing_Order_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tsPurchasing.ResumeLayout(false);
            this.tsPurchasing.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchasing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip tsPurchasing;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvPurchasing;
        public System.Windows.Forms.TextBox tbNo;
        public System.Windows.Forms.TextBox tbStaff;
        public System.Windows.Forms.TextBox tbSupplier;
        public System.Windows.Forms.DateTimePicker dtpTime;
        public System.Windows.Forms.TextBox tbRemarks;
        public System.Windows.Forms.TextBox tbMakeName;
        public System.Windows.Forms.TextBox tbMakeTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRequisition;
        public System.Windows.Forms.TextBox tbRequisition;
    }
}