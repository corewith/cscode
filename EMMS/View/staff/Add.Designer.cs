namespace EMMS.View.staff
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
            this.panelUser = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.labPwd = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ckbLogin = new System.Windows.Forms.CheckBox();
            this.cbAge = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbGirl = new System.Windows.Forms.RadioButton();
            this.rbBoy = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.tbDepartment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnJob = new System.Windows.Forms.Button();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbResign = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbJob = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ttNo = new System.Windows.Forms.ToolTip(this.components);
            this.ttName = new System.Windows.Forms.ToolTip(this.components);
            this.ttUser = new System.Windows.Forms.ToolTip(this.components);
            this.ttPassword = new System.Windows.Forms.ToolTip(this.components);
            this.tsAdd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelUser.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tsAdd.Size = new System.Drawing.Size(449, 56);
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
            this.groupBox1.Controls.Add(this.panelUser);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ckbLogin);
            this.groupBox1.Controls.Add(this.cbAge);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnDepartment);
            this.groupBox1.Controls.Add(this.tbDepartment);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnJob);
            this.groupBox1.Controls.Add(this.tbRemarks);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ckbResign);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbJob);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 372);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.btnReset);
            this.panelUser.Controls.Add(this.cbRole);
            this.panelUser.Controls.Add(this.label12);
            this.panelUser.Controls.Add(this.tbPassword);
            this.panelUser.Controls.Add(this.labPwd);
            this.panelUser.Controls.Add(this.tbUserName);
            this.panelUser.Controls.Add(this.label10);
            this.panelUser.Location = new System.Drawing.Point(20, 195);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(371, 69);
            this.panelUser.TabIndex = 21;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(255, 40);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "重置密码";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(59, 42);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(76, 20);
            this.cbRole.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "角色";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(255, 14);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 21);
            this.tbPassword.TabIndex = 3;
            // 
            // labPwd
            // 
            this.labPwd.AutoSize = true;
            this.labPwd.Location = new System.Drawing.Point(194, 17);
            this.labPwd.Name = "labPwd";
            this.labPwd.Size = new System.Drawing.Size(53, 12);
            this.labPwd.TabIndex = 2;
            this.labPwd.Text = "初始密码";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(57, 14);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "用户名";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "允许登录";
            // 
            // ckbLogin
            // 
            this.ckbLogin.AutoSize = true;
            this.ckbLogin.Location = new System.Drawing.Point(83, 175);
            this.ckbLogin.Name = "ckbLogin";
            this.ckbLogin.Size = new System.Drawing.Size(15, 14);
            this.ckbLogin.TabIndex = 19;
            this.ckbLogin.UseVisualStyleBackColor = true;
            this.ckbLogin.CheckedChanged += new System.EventHandler(this.ckbLogin_CheckedChanged);
            // 
            // cbAge
            // 
            this.cbAge.FormattingEnabled = true;
            this.cbAge.Location = new System.Drawing.Point(279, 75);
            this.cbAge.Name = "cbAge";
            this.cbAge.Size = new System.Drawing.Size(77, 20);
            this.cbAge.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbGirl);
            this.panel1.Controls.Add(this.rbBoy);
            this.panel1.Location = new System.Drawing.Point(83, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 20);
            this.panel1.TabIndex = 17;
            // 
            // rbGirl
            // 
            this.rbGirl.AutoSize = true;
            this.rbGirl.Location = new System.Drawing.Point(60, 3);
            this.rbGirl.Name = "rbGirl";
            this.rbGirl.Size = new System.Drawing.Size(35, 16);
            this.rbGirl.TabIndex = 1;
            this.rbGirl.TabStop = true;
            this.rbGirl.Text = "女";
            this.rbGirl.UseVisualStyleBackColor = true;
            // 
            // rbBoy
            // 
            this.rbBoy.AutoSize = true;
            this.rbBoy.Location = new System.Drawing.Point(4, 3);
            this.rbBoy.Name = "rbBoy";
            this.rbBoy.Size = new System.Drawing.Size(35, 16);
            this.rbBoy.TabIndex = 0;
            this.rbBoy.TabStop = true;
            this.rbBoy.Text = "男";
            this.rbBoy.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "年    龄";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "性    别";
            // 
            // btnDepartment
            // 
            this.btnDepartment.FlatAppearance.BorderSize = 0;
            this.btnDepartment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDepartment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartment.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnDepartment.Location = new System.Drawing.Point(373, 118);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(23, 23);
            this.btnDepartment.TabIndex = 13;
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // tbDepartment
            // 
            this.tbDepartment.Location = new System.Drawing.Point(277, 120);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.ReadOnly = true;
            this.tbDepartment.Size = new System.Drawing.Size(100, 21);
            this.tbDepartment.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "部    门";
            // 
            // btnJob
            // 
            this.btnJob.FlatAppearance.BorderSize = 0;
            this.btnJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob.Image = global::EMMS.View.Properties.Resources.a1;
            this.btnJob.Location = new System.Drawing.Point(178, 121);
            this.btnJob.Name = "btnJob";
            this.btnJob.Size = new System.Drawing.Size(22, 23);
            this.btnJob.TabIndex = 10;
            this.btnJob.UseVisualStyleBackColor = true;
            this.btnJob.Click += new System.EventHandler(this.btnAttri_Click);
            // 
            // tbRemarks
            // 
            this.tbRemarks.Location = new System.Drawing.Point(83, 270);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(294, 88);
            this.tbRemarks.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "备注";
            // 
            // ckbResign
            // 
            this.ckbResign.AutoSize = true;
            this.ckbResign.Location = new System.Drawing.Point(279, 174);
            this.ckbResign.Name = "ckbResign";
            this.ckbResign.Size = new System.Drawing.Size(15, 14);
            this.ckbResign.TabIndex = 7;
            this.ckbResign.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "已 离 职";
            // 
            // tbJob
            // 
            this.tbJob.Location = new System.Drawing.Point(81, 123);
            this.tbJob.Name = "tbJob";
            this.tbJob.ReadOnly = true;
            this.tbJob.Size = new System.Drawing.Size(100, 21);
            this.tbJob.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "职    务";
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
            this.label2.Text = "人员名称";
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
            this.label1.Text = "人员编码*";
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 443);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员信息";
            this.Activated += new System.EventHandler(this.Add_Activated);
            this.Load += new System.EventHandler(this.Add_Load);
            this.tsAdd.ResumeLayout(false);
            this.tsAdd.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        public System.Windows.Forms.CheckBox ckbResign;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbJob;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnJob;
        private System.Windows.Forms.ToolTip ttNo;
        private System.Windows.Forms.ToolTip ttName;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tbDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.CheckBox ckbLogin;
        public System.Windows.Forms.ComboBox cbAge;
        public System.Windows.Forms.RadioButton rbGirl;
        public System.Windows.Forms.RadioButton rbBoy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip ttUser;
        private System.Windows.Forms.ToolTip ttPassword;
        public System.Windows.Forms.Panel panelUser;
        public System.Windows.Forms.TextBox tbUserName;
        public System.Windows.Forms.TextBox tbPassword;
        public System.Windows.Forms.ComboBox cbRole;
        public System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Label labPwd;
    }
}