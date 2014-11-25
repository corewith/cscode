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
    public partial class Goods : Form
    {
        public EMMS.BLL.Goods bll = new BLL.Goods();

        public Goods()
        {
            InitializeComponent();
        }
        //tvWarehouseAttri初始化
        private void InitTreeView()
        {
            if (tvGoodsAttri != null)
            {
                tvGoodsAttri.Nodes.Clear();
            }
            //根节点
            TreeNode tnRoot = new TreeNode();
            tnRoot.Text = "物品类别";
            tvGoodsAttri.Nodes.Add(tnRoot);
            //得到名称
            List<TreeNode> nodeList = new List<TreeNode>();
            nodeList = bll.GetNodeList();
            foreach (TreeNode node in nodeList)
                tnRoot.Nodes.Add(node);
            //默认展开所有节点
            tnRoot.ExpandAll();
        }
        //dgvWarehouse绑定数据
        private void BindData()
        {
            //绑定到转换后的集合
            List<EMMS.Model.GoodsView> modelListView = new List<Model.GoodsView>();
            modelListView = bll.GetModelListView(tbSearch.Text.ToString());
            dgvGoods.DataSource = modelListView;

            dgvGoods.AllowUserToAddRows = false;
            //dgvWarehouse.ReadOnly = true;
            //dgvWarehouse.Columns["no"].ReadOnly = true;
            //dgvWarehouse.Columns["name"].ReadOnly = true;
            //dgvWarehouse.Columns["typename"].ReadOnly = true;
            //dgvWarehouse.Columns["disabled"].ReadOnly = false;
            //dgvWarehouse.Columns["remarks"].ReadOnly = true;

            //for (int i = 0; i < dgvGoods.Columns.Count; i++)
            //{
            //    if (i == 3)
            //        dgvGoods.Columns[i].ReadOnly = false;
            //    else
            //        dgvGoods.Columns[i].ReadOnly = true;
            //}
            dgvGoods.ReadOnly = true;
            dgvGoods.Columns[0].HeaderText = "物品编码";
            dgvGoods.Columns[1].HeaderText = "物品名称";
            dgvGoods.Columns[2].HeaderText = "物品类别";
            dgvGoods.Columns[3].HeaderText = "单位";
            dgvGoods.Columns[4].HeaderText = "单价";
            dgvGoods.Columns[5].HeaderText = "货币单位";
            dgvGoods.Columns[6].HeaderText = "停用";
            dgvGoods.Columns[7].HeaderText = "备注";
           
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            InitTreeView();
            BindData();
        }

        private void tvWarehouseAttri_Click(object sender, EventArgs e)
        {
           
        }

        private void tvWarehouseAttri_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            TreeNode node = new TreeNode();
            if (tv.SelectedNode != null)
            {
                node = tv.SelectedNode;
                if (node.Parent != null)
                {
                    List<EMMS.Model.GoodsView> modelListView = new List<Model.GoodsView>();
                    modelListView = bll.GetModelListView(node.Text.ToString());
                    dgvGoods.DataSource = modelListView;
                }
            }
        }
        //查找按钮
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        //更新(还不够完美)
        private void dgvWarehouse_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > 0 && e.RowIndex < dgvGoods.Rows.Count)
            //{
            //    //让其失去焦点
            //    //dgvWarehouse.EndEdit();

            //    string no = dgvGoods.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    Model.GoodsSet model = new Model.GoodsSet();
            //    model = bll.GetModel(no);
            //    model.Useable = ((Convert.ToBoolean(dgvGoods.Rows[e.RowIndex].Cells[3].Value.ToString())) == true) ? 0 : 1;
            //    bll.Update(model);
            //}
        }

        private void dgvWarehouse_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        //刷新
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            //InitTreeView();
            tbSearch.Text = "";
            BindData();
        }
        //物品类别
        private void tsbWarehouseAttri_Click(object sender, EventArgs e)
        {
            GoodsAttri goodsAttri = new GoodsAttri();
            goodsAttri.ShowDialog();
        }
        //增加
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.flag = 0;
            add.ShowDialog();
        }
        //删除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvGoods.SelectedRows.Count > 0))
            {
                MessageBox.Show("请至少选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvGoods.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (MessageBox.Show("确定要删除该行吗？", "确定删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                    try
                    {
                        string no = row.Cells[0].Value.ToString();
                        if (bll.Delete(no))
                        {
                            MessageBox.Show("删除成功！");
                            BindData();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("由于某些原因，删除失败！");
                    }

                }
            }
        }
        //关闭
        private void tbsClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //修改
        private void tsbAlter_Click(object sender, EventArgs e)
        {
            if (dgvGoods.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvGoods.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string no = row.Cells[0].Value.ToString();
                    string name = row.Cells[1].Value.ToString();
                    string typename = row.Cells[2].Value.ToString();
                    string unit = row.Cells[3].Value.ToString();
                    string price = row.Cells[4].Value.ToString();
                    string priceunit = row.Cells[5].Value.ToString();
                    bool disabled = Convert.ToBoolean(row.Cells[6].Value.ToString());
                    string remarks = row.Cells[7].Value.ToString();
                    Add add = new Add();
                    add.flag = 1;
                    add.goodsAttrimodel.Name = typename;
                    add.goodsAttrimodel.No = (bll.GetModel(no)).Type;
                    add.tbNo.Text = no;
                    add.tbName.Text = name;
                    add.tbType.Text = typename;
                    add.tbUnit.Text = unit;
                    add.tbPrice.Text = price;
                    add.cbPriceUnit.SelectedValue = priceunit;
                    add.ckbDisable.Checked = disabled;
                    add.tbRemarks.Text = remarks;
                    add.ShowDialog();
                }
            }
        }

        private void Warehouse_Activated(object sender, EventArgs e)
        {
            //BindData();
            InitTreeView();
            BindData();
        }

        private void Warehouse_Enter(object sender, EventArgs e)
        {
            
        }

        private void tvWarehouseAttri_Enter(object sender, EventArgs e)
        {
            //InitTreeView();
        }

        private void dgvWarehouse_Enter(object sender, EventArgs e)
        {
            //BindData();
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvGoods);
        }

    }
}
