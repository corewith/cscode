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
    public partial class RecoverDB : Form
    {
        public RecoverDB()
        {
            InitializeComponent();
        }

        private void RecoverDB_Load(object sender, EventArgs e)
        {
            ofdialog.DefaultExt = "备份文件(*.bak)|*.bak";
            ofdialog.Filter = "备份文件(*.bak)|*.bak|所有文件(*.*)|*.*";
        }

        private void btn_broswer_Click(object sender, EventArgs e)
        {
            if (ofdialog.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = ofdialog.FileName;
            }
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            EMMS.Common.DatabaseOperator dbOperator = new Common.DatabaseOperator();
            if (dbOperator.RecoverDatabase(txt_path.Text))
            {
                MessageBox.Show("还原成功！");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
