﻿namespace EMMS.View.warehouse
{
    partial class Add
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
            this.tsAdd = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveClose = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAttri = new System.Windows.Forms.Button();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbDisabled = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ttNo = new System.Windows.Forms.ToolTip(this.components);
            this.ttName = new System.Windows.Forms.ToolTip(this.components);
            this.tsAdd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsAdd
            // 
            this.tsAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbSaveAdd,
            this.tsbSaveClose,
            this.tsbClose});
            this.tsAdd.Location = new System.Drawing.Point(0, 0);
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(432, 56);
            this.tsAdd.TabIndex = 0;
            this.tsAdd.Text = "toolStrip1";
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
            // tsbSaveAdd
            // 
            this.tsbSaveAdd.Image = global::EMMS.View.Properties.Resources.saveadd;
            this.tsbSaveAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSaveAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAdd.Name = "tsbSaveAdd";
            this.tsbSaveAdd.Size = new System.Drawing.Size(72, 53);
            this.tsbSaveAdd.Text = "保存并新增";
            this.tsbSaveAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSaveAdd.Click += new System.EventHandler(this.tsbSaveAdd_Click);
            // 
            // tsbSaveClose
            // 
            this.tsbSaveClose.Image = global::EMMS.View.Properties.Resources.saveclose;
            this.tsbSaveClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveClose.Name = "tsbSaveClose";
            this.tsbSaveClose.Size = new System.Drawing.Size(73, 53);
            this.tsbSaveClose.Text = "保存并关闭";
            this.tsbSaveClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSaveClose.Click += new System.EventHandler(this.tsbSaveClose_Click);
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
            this.groupBox1.Controls.Add(this.btnAttri);
            this.groupBox1.Controls.Add(this.tbRemarks);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ckbDisabled);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // btnAttri
            // 
            this.btnAttri.FlatAppearance.BorderSize = 0;
            this.btnAttri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAttri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAttri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttri.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnAttri.Location = new System.Drawing.Point(180, 72);
            this.btnAttri.Name = "btnAttri";
            this.btnAttri.Size = new System.Drawing.Size(21, 23);
            this.btnAttri.TabIndex = 10;
            this.btnAttri.UseVisualStyleBackColor = true;
            this.btnAttri.Click += new System.EventHandler(this.btnAttri_Click);
            // 
            // tbRemarks
            // 
            this.tbRemarks.Location = new System.Drawing.Point(83, 116);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(213, 88);
            this.tbRemarks.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "备注";
            // 
            // ckbDisabled
            // 
            this.ckbDisabled.AutoSize = true;
            this.ckbDisabled.Location = new System.Drawing.Point(281, 75);
            this.ckbDisabled.Name = "ckbDisabled";
            this.ckbDisabled.Size = new System.Drawing.Size(15, 14);
            this.ckbDisabled.TabIndex = 7;
            this.ckbDisabled.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "是否停用";
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(83, 72);
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(100, 21);
            this.tbType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "仓库类别";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(279, 30);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 21);
            this.tbName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "仓库名称";
            // 
            // tbNo
            // 
            this.tbNo.Location = new System.Drawing.Point(83, 30);
            this.tbNo.Name = "tbNo";
            this.tbNo.Size = new System.Drawing.Size(100, 21);
            this.tbNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库编码*";
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 324);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库信息";
            this.Load += new System.EventHandler(this.Add_Load);
            this.tsAdd.ResumeLayout(false);
            this.tsAdd.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsAdd;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbSaveAdd;
        private System.Windows.Forms.ToolStripButton tsbSaveClose;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.GroupBox groupBox1;
        public  System.Windows.Forms.CheckBox ckbDisabled;
        private System.Windows.Forms.Label label4;
        public  System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label label3;
        public  System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        public  System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.Label label1;
        public  System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAttri;
        private System.Windows.Forms.ToolTip ttNo;
        private System.Windows.Forms.ToolTip ttName;
    }
}