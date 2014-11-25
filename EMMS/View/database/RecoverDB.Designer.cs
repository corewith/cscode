namespace EMMS.View.database
{
    partial class RecoverDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoverDB));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_broswer = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.ofdialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_broswer);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "还原数据库";
            // 
            // btn_broswer
            // 
            this.btn_broswer.Location = new System.Drawing.Point(335, 38);
            this.btn_broswer.Name = "btn_broswer";
            this.btn_broswer.Size = new System.Drawing.Size(54, 23);
            this.btn_broswer.TabIndex = 2;
            this.btn_broswer.Text = "...";
            this.btn_broswer.UseVisualStyleBackColor = true;
            this.btn_broswer.Click += new System.EventHandler(this.btn_broswer_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(95, 40);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(234, 21);
            this.txt_path.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "备份文件：";
            // 
            // btn_restore
            // 
            this.btn_restore.Location = new System.Drawing.Point(229, 127);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(75, 23);
            this.btn_restore.TabIndex = 1;
            this.btn_restore.Text = "还原数据库";
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(310, 127);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "取消";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // ofdialog
            // 
            this.ofdialog.FileName = "openFileDialog1";
            // 
            // RecoverDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 171);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecoverDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "还原数据库";
            this.Load += new System.EventHandler(this.RecoverDB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_broswer;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.OpenFileDialog ofdialog;
    }
}