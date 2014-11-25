namespace EMMS.View.database
{
    partial class BackupDB
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupDB));
            this.btn_bak = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_broswer = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.savefiledlg = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_bak
            // 
            this.btn_bak.Location = new System.Drawing.Point(185, 109);
            this.btn_bak.Name = "btn_bak";
            this.btn_bak.Size = new System.Drawing.Size(75, 23);
            this.btn_bak.TabIndex = 3;
            this.btn_bak.Text = "备份";
            this.btn_bak.UseVisualStyleBackColor = true;
            this.btn_bak.Click += new System.EventHandler(this.btn_bak_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(272, 109);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(76, 23);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "取消";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_broswer);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 79);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "备份数据库";
            // 
            // btn_broswer
            // 
            this.btn_broswer.Location = new System.Drawing.Point(274, 31);
            this.btn_broswer.Name = "btn_broswer";
            this.btn_broswer.Size = new System.Drawing.Size(44, 23);
            this.btn_broswer.TabIndex = 5;
            this.btn_broswer.Text = "...";
            this.btn_broswer.UseVisualStyleBackColor = true;
            this.btn_broswer.Click += new System.EventHandler(this.btn_broswer_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(76, 33);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(192, 21);
            this.txt_path.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "备份路径：";
            // 
            // BackupDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 144);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_bak);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "备份数据库";
            this.Load += new System.EventHandler(this.BackupDB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_bak;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_broswer;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog savefiledlg;
    }
}