using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.warehouse
{
    public partial class List : Form
    {
        public EMMS.BLL.Warehouse bll = new BLL.Warehouse();
        //public EMMS.View.storage.Storage_Order view;
        public EMMS.Common.View view;
        public List()
        {
            InitializeComponent();
        }
        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        private void BindData()
        {
            List<EMMS.Model.WarehouseView> modelListView = new List<Model.WarehouseView>();
            modelListView = bll.GetModelListViewByNumber("1");
            dgvWarehouse.DataSource = modelListView;

            dgvWarehouse.AllowUserToAddRows = false;
            //dgvWarehouse.ReadOnly = true;
            //dgvWarehouse.Columns["no"].ReadOnly = true;
            //dgvWarehouse.Columns["name"].ReadOnly = true;
            //dgvWarehouse.Columns["typename"].ReadOnly = true;
            //dgvWarehouse.Columns["disabled"].ReadOnly = false;
            //dgvWarehouse.Columns["remarks"].ReadOnly = true;

            //for (int i = 0; i < dgvWarehouse.Columns.Count; i++)
            //{
            //    if (i == 3)
            //        dgvWarehouse.Columns[i].ReadOnly = false;
            //    else
            //        dgvWarehouse.Columns[i].ReadOnly = true;
            //}
            dgvWarehouse.ReadOnly = true;
            dgvWarehouse.Columns[0].HeaderText = "仓库编码";
            dgvWarehouse.Columns[1].HeaderText = "仓库名称";
            dgvWarehouse.Columns[2].HeaderText = "仓库类别";
            dgvWarehouse.Columns[3].HeaderText = "不可用";
            dgvWarehouse.Columns[4].HeaderText = "备注";
            dgvWarehouse.Columns[3].Visible = false;
            dgvWarehouse.Columns[4].Visible = false;
        }
        private void List_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvWarehouse_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EMMS.Model.WarehouseSet model = new Model.WarehouseSet();
            string no = dgvWarehouse.Rows[e.RowIndex].Cells[0].Value.ToString();
            string name = dgvWarehouse.Rows[e.RowIndex].Cells[1].Value.ToString();
            string type = dgvWarehouse.Rows[e.RowIndex].Cells[2].Value.ToString();
            int useable = (Convert.ToBoolean(dgvWarehouse.Rows[e.RowIndex].Cells[3].Value.ToString())) ? 0 : 1;
            string remarks = dgvWarehouse.Rows[e.RowIndex].Cells[4].Value.ToString();
            model.No = no;
            model.Name = name;
            model.Type = type;
            model.Useable = useable;
            model.Remarks = remarks;
            view.WarehouseModel = model;
            view.WarehouseFlag = 1;
            //view.tbWarehouse.Text = name;//赋值填充tbGoods
            this.Dispose();
        }
    }
}
