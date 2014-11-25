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
    public partial class Query_Inventory : EMMS.Common.View
    {
        private EMMS.BLL.Inventory_Order bll = new BLL.Inventory_Order();
        public Query_Inventory()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            dgvInventory.DataSource = bll.GetModelListView("");
            dgvInventory.Columns[0].HeaderText = "盘点单编码";
            dgvInventory.Columns[1].HeaderText = "仓库名称";
            dgvInventory.Columns[2].HeaderText = "经手人";
            dgvInventory.Columns[3].HeaderText = "经手时间";
            dgvInventory.Columns[4].HeaderText = "制表人";
            dgvInventory.Columns[5].HeaderText = "制表时间";
            dgvInventory.Columns[6].HeaderText = "备注";
            dgvInventory.Columns[7].HeaderText = "对应的领料单";
        }
        private void Query_Inventory_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Inventory_Order view = new Inventory_Order();
            view.Show();
        }

        private void tsbDetail_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvInventory.SelectedRows)
            {
                List<EMMS.Model.Inventory_MaterialView> viewList = bll.GetModelListView1(row.Cells["no"].Value.ToString());
                base.InventoryViewList = viewList;

                EMMS.View.storage.Inventory_Order view = new Inventory_Order();
                view.tbNo.Text = row.Cells["no"].Value.ToString();
                view.tbWarehouse.Text = row.Cells["warehousename"].Value.ToString();
                view.tbRemarks.Text = row.Cells["remarks"].Value.ToString();
                view.tbFoundName.Text = row.Cells["foundname"].Value.ToString();
                view.dtpTime.Value = DateTime.Parse(row.Cells["foundtime"].Value.ToString());
                view.tbMakeName.Text = row.Cells["makename"].Value.ToString();
                view.tbMakeTime.Text = row.Cells["maketime"].Value.ToString();
                view.GetParent(this);
                view.flag = 2;
                view.Show();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvInventory);
        }
    }
}
