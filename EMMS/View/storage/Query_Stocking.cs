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
    public partial class Query_Stocking : EMMS.Common.View
    {
        private EMMS.BLL.Stocking_Order bll=new BLL.Stocking_Order();
        private string flag;
        public Query_Stocking()
        {
            InitializeComponent();
            flag = "";
        }
        private void BindData()
        {
            dgvStocking.DataSource = bll.GetModelListView(flag);
            dgvStocking.Columns[0].HeaderText = "入库单编码";
            dgvStocking.Columns[1].HeaderText = "目标仓库";
            dgvStocking.Columns[2].HeaderText = "成品入库";
            dgvStocking.Columns[3].HeaderText = "经手人";
            dgvStocking.Columns[4].HeaderText = "经手时间";
            dgvStocking.Columns[5].HeaderText = "制表人";
            dgvStocking.Columns[6].HeaderText = "制表时间";
            dgvStocking.Columns[7].HeaderText = "备注";
            dgvStocking.Columns[8].HeaderText = "与之对应的进购单";
        }
        private void Query_Stocking_Load(object sender, EventArgs e)
        {
            rbAll.Checked = true;
            BindData();
        }
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new Stocking_Order();
            view.Show();
        }

        private void tsbDetail_Click(object sender, EventArgs e)
        {
            if (dgvStocking.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvStocking.SelectedRows)
            {
                EMMS.Model.Stocking_OrderView stockingView = new Model.Stocking_OrderView();
                stockingView.No = row.Cells["no"].Value.ToString();
                stockingView.WarehouseName = row.Cells["warehousename"].Value.ToString();
                stockingView.Type = bool.Parse(row.Cells["type"].Value.ToString());
                stockingView.FoundName = row.Cells["foundname"].Value.ToString();
                stockingView.FoundTime = row.Cells["foundtime"].Value.ToString();
                stockingView.MakeName = row.Cells["makename"].Value.ToString();
                stockingView.MakeTime = row.Cells["maketime"].Value.ToString();
                stockingView.Remarks = row.Cells["remarks"].Value.ToString();
                stockingView.Entry = row.Cells["entry"].Value.ToString();

                List<EMMS.Model.Stocking_MaterialView> stockingViewList = bll.GetModelListView1(stockingView.No);

                base.StockingFlag = 1;
                base.StockingOrderView = stockingView;
                base.StockingViewList = stockingViewList;

                EMMS.View.storage.Stocking_Order stocking = new Stocking_Order();
                stocking.flag = 1;
                stocking.GetParent(this);
                stocking.ShowDialog();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            rbAll.Checked = true;
            BindData();
        }

        private void Type()
        {
            if (rbAll.Checked == true)
            {
                flag = "";
            }
            else if (rbProd.Checked == true)
            {
                flag = "1";
            }
            else if (rbMaterial.Checked == true)
            {
                flag = "0";
            }
        }
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            Type();
        }

        private void rbProd_CheckedChanged(object sender, EventArgs e)
        {
            Type();
        }

        private void rbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            Type();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvStocking);
        }
    }
}
