using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.database
{
    public partial class BackupDB : Form
    {
        public BackupDB()
        {
            InitializeComponent();
        }

        private void BackupDB_Load(object sender, EventArgs e)
        {
            savefiledlg.InitialDirectory = Application.StartupPath + @"\BACKUP";
            savefiledlg.DefaultExt = "备份文件(*.bak)|*.bak";
            savefiledlg.Filter = "备份文件(*.bak)|*.bak|所有文件(*.*)|*.*";
        }

        private void btn_bak_Click(object sender, EventArgs e)
        {
            EMMS.Common.DatabaseOperator dbOperator = new Common.DatabaseOperator();
            if (dbOperator.BackupDatabase(txt_path.Text))
            {
                MessageBox.Show("备份成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_broswer_Click(object sender, EventArgs e)
        {
            if (savefiledlg.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = savefiledlg.FileName;
            }
        
        }
    }
}
