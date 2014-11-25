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
    public partial class List : Form
    {
        private EMMS.BLL.Storage_Order bll = new BLL.Storage_Order();
        public EMMS.Common.View view;
        public List()
        {
            InitializeComponent();
        }

        public void GetParent(EMMS.Common.View view)
        {
            this.view=view;
        }
        private void BindData()
        {
            List<EMMS.Model.Storage_OrderView> modelList = new List<Model.Storage_OrderView>();
            if ( this.view == null )
            {
                modelList = bll.GetModelListView("", "");
                
            }
            else
            {
                modelList=bll.GetModelListView(view.StorageModelView.WarehouseName,"");
            }
            dgvStorage.DataSource = modelList;
            dgvStorage.Columns[0].HeaderText = "库存编码";
            dgvStorage.Columns[1].HeaderText = "仓库名称";
            dgvStorage.Columns[2].HeaderText = "物品名称";
            dgvStorage.Columns[3].HeaderText = "库存量";
            dgvStorage.Columns[4].HeaderText = "警戒线";
            dgvStorage.Columns[5].HeaderText = "备注";
            dgvStorage.Columns[6].HeaderText = "物品编码";
            dgvStorage.Columns[6].Visible = false;
        }
        private void List_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvStorage_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EMMS.Model.Storage_OrderSet model = new Model.Storage_OrderSet();
            EMMS.Model.Storage_OrderView modelview = new Model.Storage_OrderView();
            string no = dgvStorage.Rows[e.RowIndex].Cells[0].Value.ToString(); //库存编码
            string warehousename = dgvStorage.Rows[e.RowIndex].Cells[1].Value.ToString();
            string goodsname = dgvStorage.Rows[e.RowIndex].Cells[2].Value.ToString();
            int counts=int.Parse(dgvStorage.Rows[e.RowIndex].Cells[3].Value.ToString());
            int critical=int.Parse(dgvStorage.Rows[e.RowIndex].Cells[4].Value.ToString());
            string  remarks = dgvStorage.Rows[e.RowIndex].Cells[5].Value.ToString();
            string goodsno = dgvStorage.Rows[e.RowIndex].Cells[6].Value.ToString();

            modelview.No = no;
            modelview.WarehouseName = warehousename;
            modelview.GoodsName = goodsname;
            modelview.Counts = counts;
            modelview.Critical = critical;
            modelview.Remarks = remarks;
            modelview.GoodsNo = goodsno;
  
            model = bll.GetModel(no);         

            view.StorageModelSet = model;
            view.StorageModelView = modelview;
            view.StorageSetFlag = 1;
            view.StorageViewFlag = 1;
            this.Dispose();
        }
    }
}
