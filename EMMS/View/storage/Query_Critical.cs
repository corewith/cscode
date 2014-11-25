using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.storage
{
    public partial class Query_Critical : Form
    {
        private EMMS.BLL.Storage_Order bll = new BLL.Storage_Order();
        public Query_Critical()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            dgvCritical.DataSource = bll.GetListBelowCritical();
            dgvCritical.Columns[0].HeaderText = "库存编码";
            dgvCritical.Columns[1].HeaderText = "仓库";
            dgvCritical.Columns[2].HeaderText = "物品名称";
            dgvCritical.Columns[3].HeaderText = "库存量";
            dgvCritical.Columns[4].HeaderText = "警戒线";
            dgvCritical.Columns[5].HeaderText = "备注";
            dgvCritical.Columns[6].HeaderText = "物品编码";
            dgvCritical.Columns[6].Visible = false;
        }
        private void Query_Critical_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvCritical);
        }
    }
}
