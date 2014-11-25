using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.goods
{
    public partial class List : EMMS.Common.View
    {
        public EMMS.BLL.Goods bll = new BLL.Goods();
        public string typename;
        //public EMMS.View.storage.Storage_Order view;
        private EMMS.Common.View view;
        public bool all;
        public List()
        {
            InitializeComponent();
            typename = "物料";
            all = false;
        }
        public void GetParent(EMMS.Common.View view)//EMMS.View.storage.Storage_Order view)
        {
            //this.view = view;
            this.view = view;

        }
        private void BindData()
        {
            //绑定到转换后的集合
            List<EMMS.Model.GoodsView> modelListView = new List<Model.GoodsView>();
            if (all == true)
            {
                modelListView = bll.GetModelListViewByNumber("0");
            }
            else
            {
                modelListView = bll.GetModelListViewByNumber1("0", typename);
            }
            dgvGoods.DataSource = modelListView;

            dgvGoods.AllowUserToAddRows = false;
          
            dgvGoods.ReadOnly = true;
            dgvGoods.Columns[0].HeaderText = "物品编码";
            dgvGoods.Columns[1].HeaderText = "物品名称";
            dgvGoods.Columns[2].HeaderText = "物品类别";
            dgvGoods.Columns[3].HeaderText = "单位";
            dgvGoods.Columns[4].HeaderText = "单价";
            dgvGoods.Columns[5].HeaderText = "货币单位";
            dgvGoods.Columns[6].HeaderText = "停用";
            dgvGoods.Columns[7].HeaderText = "备注";
            dgvGoods.Columns[6].Visible = false;
            dgvGoods.Columns[7].Visible = false;
        }
        private void List_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvGoods_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dgvGoods.Rows[e.RowIndex].Cells[0].ToString();
            EMMS.Model.GoodsSet model = new Model.GoodsSet();
            string no = dgvGoods.Rows[e.RowIndex].Cells[0].Value.ToString();
            string name = dgvGoods.Rows[e.RowIndex].Cells[1].Value.ToString();
            string type = dgvGoods.Rows[e.RowIndex].Cells[2].Value.ToString();
            string unit = dgvGoods.Rows[e.RowIndex].Cells[3].Value.ToString();
            float price = float.Parse(dgvGoods.Rows[e.RowIndex].Cells[4].Value.ToString());
            string priceunit = dgvGoods.Rows[e.RowIndex].Cells[5].Value.ToString();
            int disable = (Convert.ToBoolean(dgvGoods.Rows[e.RowIndex].Cells[6].Value.ToString()))?1:0;
            string remarks = dgvGoods.Rows[e.RowIndex].Cells[7].Value.ToString();
            model.No = no;
            model.Name = name;
            model.Type = type;
            model.Unit = unit;
            model.Price = price;
            model.PriceUnit = priceunit;
            model.Disable = disable;
            model.Remarks = remarks;
            view.GoodsModel = model;
            view.GoodsFlag = 1;
            //view.tbGoods.Text= name;//赋值填充tbGoods
            this.Dispose();
        }
    }
}
