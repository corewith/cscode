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
    public partial class Storage_Order :EMMS.Common.View
    {
        private EMMS.BLL.Storage_Order bll = new BLL.Storage_Order();
        public EMMS.Model.GoodsSet goodsmodel = new Model.GoodsSet();
        public EMMS.Model.WarehouseSet warehousemodel=new Model.WarehouseSet();
        private List<EMMS.Model.Storage_OrderView> StorageOrderViewList = new List<Model.Storage_OrderView>();
        public bool flag;
        private bool judge;
        //public int judge;
        /// <summary>
        /// 分页需要的各属性
        /// </summary>
        /// 
        #region 
        static int rowsall = 0;//总行数
        static int pageall = 0;//总页数
        static int page = 0;//第几页
        static int count = 13;//返回20行
        static int start = 0;//从第start行开始返回
        #endregion
        public Storage_Order()
        {
            InitializeComponent();
            flag = false;
            judge = false;
            //judge = 0;
        }
        private void InitTreeView()
        {
            if (tvStorage.Nodes.Count > 0)
                tvStorage.Nodes.Clear();
            //根节点
            TreeNode tnRoot1 = new TreeNode();
            tnRoot1.Text = "仓库";
            tvStorage.Nodes.Add(tnRoot1);
            //得到仓库名称
            List<TreeNode> nodeDepartmentList = new List<TreeNode>();
            nodeDepartmentList = bll.GetNodeList(0);
            foreach (TreeNode node in nodeDepartmentList)
                tnRoot1.Nodes.Add(node);
            //根节点
            TreeNode tnRoot2 = new TreeNode();
            tnRoot2.Text = "物品";
            tvStorage.Nodes.Add(tnRoot2);
            //得到物品名称
            List<TreeNode> nodeJobList = new List<TreeNode>();
            nodeJobList = bll.GetNodeList(1);
            foreach (TreeNode node in nodeJobList)
                tnRoot2.Nodes.Add(node);
            //默认展开所有节点
            //tvStorage.ExpandAll();
        }
        private void BindData()
        {
            List<EMMS.Model.Storage_OrderView> StorageOrderViewList = new List<Model.Storage_OrderView>();
            StorageOrderViewList= bll.GetModelListView(tbWarehouse.Text, tbGoods.Text);
            dgvStorage.DataSource = StorageOrderViewList;
            dgvStorage.Columns[0].HeaderText = "库存编码";
            dgvStorage.Columns[1].HeaderText = "仓库名称";
            dgvStorage.Columns[2].HeaderText = "物品名称";
            dgvStorage.Columns[3].HeaderText = "库存量";
            dgvStorage.Columns[4].HeaderText = "警戒线";
            dgvStorage.Columns[5].HeaderText = "备注";
            dgvStorage.Columns[6].HeaderText = "物品编码";
            dgvStorage.Columns[6].Visible = false;
        }
        private void Storage_Order_Load(object sender, EventArgs e)
        {
            InitTreeView();
            //BindData();
            upPage(tbWarehouse.Text, tbGoods.Text);
        }

        private void tsbIn_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new Stocking_Order();
            view.ShowDialog();
        }

        private void tsbOut_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Delivery_Order view = new Delivery_Order();
            view.ShowDialog();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            tbWarehouse.Text = "";
            tbGoods.Text = "";
            InitTreeView();
            //BindData();
            upPage(tbWarehouse.Text, tbGoods.Text);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            EMMS.View.warehouse.List list = new warehouse.List();
            list.GetParent(this);
            list.ShowDialog();
        }

        private void btnGoods_Click(object sender, EventArgs e)
        {
            EMMS.View.goods.List list = new EMMS.View.goods.List();
            list.all = true;
            list.GetParent(this);
            list.ShowDialog();
        }

        private void tbGoods_TextChanged(object sender, EventArgs e)
        {
            //BindData();
            upPage(tbWarehouse.Text, tbGoods.Text);
        }

        private void tbWarehouse_TextChanged(object sender, EventArgs e)
        {
            //BindData();
            upPage(tbWarehouse.Text,tbGoods.Text);
        }

        private void tvStorage_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            TreeNode node = new TreeNode();
            if (tv.SelectedNode != null)
            {
                node = tv.SelectedNode;
                if (node.Parent != null)
                {
                    if (node.Parent.Text == "仓库")
                    {
                        //
                        List<EMMS.Model.Storage_OrderView> modelListView = new List<Model.Storage_OrderView>();
                        //StorageOrderViewList= bll.GetModelListView(node.Text.ToString(),tbGoods.Text);
                        upPage(node.Text, tbGoods.Text);
                        tbWarehouse.Text = "";//
                        modelListView = SubList(StorageOrderViewList, 1);
                        dgvStorage.DataSource = modelListView;
                    }
                    else if (node.Parent.Text == "物品")
                    {
                        List<EMMS.Model.Storage_OrderView> modelListView = new List<Model.Storage_OrderView>();
                        //StorageOrderViewList = bll.GetModelListView(tbWarehouse.Text,node.Text.ToString());
                        upPage(tbWarehouse.Text, node.Text);
                        tbGoods.Text = "";
                        modelListView = SubList(StorageOrderViewList, 1);
                        dgvStorage.DataSource = modelListView;
                    }
                }
            }
        }

        private void Storage_Order_Activated(object sender, EventArgs e)
        {
            if (base.WarehouseFlag == 1)
            {
                this.tbWarehouse.Text = base.WarehouseModel.Name;
                base.WarehouseFlag = 0;
            }
            if (base.GoodsFlag == 1)
            {
                this.tbGoods.Text = base.GoodsModel.Name;
                base.GoodsFlag = 0;
            }
            InitTreeView();
            //BindData();
            upPage(tbWarehouse.Text,tbGoods.Text);
            //dgvStorage.ReadOnly = true;
        }

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new Stocking_Order();
            view.ShowDialog();
        }

        private void 出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Delivery_Order view = new Delivery_Order();
            view.ShowDialog();
        }

        private void 出库审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 请购ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Requisition_Order view = new Requisition_Order();
            view.Show();
        }

        private void 查询领料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.picking.Query_Picking query = new picking.Query_Picking();
            query.Show();
        }

        private void 盘点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Inventory_Order view = new Inventory_Order();
            view.Show();
        }

        private void tsbPicking_Click(object sender, EventArgs e)
        {
            EMMS.View.picking.Query_Picking query = new picking.Query_Picking();
            query.Show();
        }

        private void tsbCritical_Click(object sender, EventArgs e)
        {
            //设置警戒线
            if( flag== false)
                flag = true;
            else if( flag == true)
                flag = false;
            if( flag == true)
            {
                dgvStorage.ReadOnly = false;
                for (int i = 0; i < dgvStorage.Columns.Count; i++)
                {
                    if (i == 4) 
                        dgvStorage.Columns[i].ReadOnly = false;
                    else
                        dgvStorage.Columns[i].ReadOnly = true;
                }
            }
            else if (flag == false)
            {
                dgvStorage.ReadOnly = true;
            }
        }

        private void dgvStorage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flag == true) //点击了设置警戒线才需要
            {
                //if (judge == 0)
                //{
                //    judge++;
                //}
                //else
                //{
                    dgvStorage.EndEdit();
                    for (int i = 0; i < dgvStorage.Rows.Count; i++)
                    {
                        EMMS.Model.Storage_OrderSet orderSet = new Model.Storage_OrderSet();
                        orderSet = bll.GetModel(dgvStorage.Rows[i].Cells["no"].Value.ToString());
                        orderSet.Critical = int.Parse(dgvStorage.Rows[i].Cells["critical"].Value.ToString()); //得到新的警戒线
                        bll.Update(orderSet);
                        //if (bll.Update(orderSet))
                        //{
                        //    MessageBox.Show("设置警戒线成功！");
                        //}
                    }
                //}
            }
        }

        private void dgvStorage_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }

        private void dgvStorage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }

        private void 设置警戒值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //设置警戒线
            if (flag == false)
                flag = true;
            else if (flag == true)
                flag = false;
            if (flag == true)
            {
                dgvStorage.ReadOnly = false;
                for (int i = 0; i < dgvStorage.Columns.Count; i++)
                {
                    if (i == 4)
                        dgvStorage.Columns[i].ReadOnly = false;
                    else
                        dgvStorage.Columns[i].ReadOnly = true;
                }
            }
            else if (flag == false)
            {
                dgvStorage.ReadOnly = true;
            }
        }

        private void 查询出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Delivery query = new Query_Delivery();
            query.Show();
        }

        private void 请购单查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Requisition query = new Query_Requisition();
            query.Show();
        }
        private void tsbInventory_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Inventory_Order view = new Inventory_Order();
            view.Show();
        }

        private void 成品入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new Stocking_Order();
            view.type = 1;
            view.Show();
        }

        private void 物料入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new Stocking_Order();
        
            view.Show();
        }

        private void tsbPStocking_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new Stocking_Order();
            view.type = 1;
            view.Show();
        }

        private void 查询盘点单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Inventory query = new Query_Inventory();
            query.Show();
        }

        private void tsbQueryCritical_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Critical query = new Query_Critical();
            query.Show();
        }

        private void 查询警戒库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Critical query = new Query_Critical();
            query.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvStorage);
        }


        private void upPage(string warehousename,string goodsname)
        {
            rowsall = bll.GetRecordCount(warehousename, goodsname);
            //if (rowsall == 0)
            //{ 
            //    //如果没有数据
            //    btnFirst.Enabled = false;
            //    btnPreview.Enabled = false;
            //    btnNext.Enabled = false;
            //    btnLast.Enabled = false;

            //    page = 0;
            //    pageall = 0;
            //    rowsall = 0;
            //    dgvStorage.DataSource = 
            //    lCounts.Text = "共" + rowsall.ToString() + "个记录";//总行数
            //    tbPage.Text = page.ToString();//当前页数
            //    lPageAll.Text = pageall.ToString();//总页数
            //    dgvStorage.Columns[0].HeaderText = "库存编码";
            //    dgvStorage.Columns[1].HeaderText = "仓库名称";
            //    dgvStorage.Columns[2].HeaderText = "物品名称";
            //    dgvStorage.Columns[3].HeaderText = "库存量";
            //    dgvStorage.Columns[4].HeaderText = "警戒线";
            //    dgvStorage.Columns[5].HeaderText = "备注";
            //    dgvStorage.Columns[6].HeaderText = "物品编码";
            //    dgvStorage.Columns[6].Visible = false;
            //    return;
            //}
            btnFirst.Enabled = true;
            btnNext.Enabled = true;
            btnPreview.Enabled = true;
            btnLast.Enabled = true;

            if (rowsall > 0)
            {
                page = 1;
                judge = true;//值改变就将judge为true
                btnPreview.Enabled = false;
                tbPage.Enabled = true;
                start = 0;
            }
            else
            {
                btnPreview.Enabled = false;
                btnNext.Enabled = false;
                btnFirst.Enabled = false;
                btnLast.Enabled = false;
                tbPage.Text = "0";
                tbPage.Enabled = false;
            }
            int surplus = rowsall % count;
            if (surplus == 0)
            {
                if (rowsall > 0 && rowsall < count)
                {
                    pageall = 1;
                    btnPreview.Enabled = false;
                    btnNext.Enabled = false;
                }
                else
                {
                    pageall = rowsall / count;
                }
            }
            else
            {
                pageall = rowsall / count + 1;
            }
            if (pageall == 1)
            {
                btnPreview.Enabled = false;
                btnNext.Enabled = false;
            }
            lCounts.Text = "共" + rowsall.ToString() + "个记录";//总行数
            tbPage.Text = page.ToString();//当前页数
            lPageAll.Text = pageall.ToString();//总页数 
            StorageOrderViewList = bll.GetModelListView(warehousename, goodsname);
            List<EMMS.Model.Storage_OrderView> modelList = new List<Model.Storage_OrderView>();
            modelList = SubList(StorageOrderViewList, 1);//默认显示第一页

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
        private void btnFirst_Click(object sender, EventArgs e)
        {
            List<EMMS.Model.Storage_OrderView> modelList = new List<Model.Storage_OrderView>();
            page = 1;
            judge = true;
            modelList = SubList(StorageOrderViewList, page);//移到第一页
            dgvStorage.DataSource = modelList;
            tbPage.Text = page.ToString() ;
            btnPreview.Enabled = false;
            btnNext.Enabled = true;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            List<EMMS.Model.Storage_OrderView> modelList = new List<Model.Storage_OrderView>();
            modelList = SubList(StorageOrderViewList, --page);//移动到上一页
            judge = true;
            dgvStorage.DataSource = modelList;
            tbPage.Text = page.ToString();
            if (page == 1)
            {
                btnPreview.Enabled = false;
            }
            if (page == pageall - 1)
            {
                btnNext.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            List<EMMS.Model.Storage_OrderView> modelList = new List<Model.Storage_OrderView>();
            modelList = SubList(StorageOrderViewList, ++page);//移动到下一页
            judge = true;
            dgvStorage.DataSource = modelList;
            tbPage.Text = page.ToString();
            if (page == pageall)
            {
                btnNext.Enabled = false;
            }
            if (page == 2)
            {
                btnPreview.Enabled = true;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            List<EMMS.Model.Storage_OrderView> modelList = new List<Model.Storage_OrderView>();
            page = pageall;
            judge = true;
            modelList = SubList(StorageOrderViewList, page);//移到最后一页
            dgvStorage.DataSource = modelList;
            tbPage.Text = pageall.ToString();
            btnNext.Enabled = false;
            btnPreview.Enabled = true;
        }
        private List<EMMS.Model.Storage_OrderView> SubList(List<EMMS.Model.Storage_OrderView> storageOrderViewList, int pageIndex)
        {
            List<EMMS.Model.Storage_OrderView> subViewList = new List<Model.Storage_OrderView>();
            if (rowsall < pageIndex * count) //当前页未满
            {
                for (int i = (pageIndex - 1) * count; i < rowsall; i++)
                {
                    subViewList.Add(storageOrderViewList[i]);
                }
            }
            else
            {
                for (int i = (pageIndex - 1) * count; i < pageIndex * count; i++)
                {
                    subViewList.Add(storageOrderViewList[i]);
                }
            }
            return subViewList;
        }

        private void tbPage_TextChanged(object sender, EventArgs e)
        {
            if (rowsall > 0)
            {
                if (judge == true)
                {
                    judge = false;
                }
                else
                {
                    try
                    {
                        int value = int.Parse(tbPage.Text);
                        if (value < 0 || value > pageall)
                        {
                            MessageBox.Show("请输入大于0小于" + pageall+1 + "的数字！");
                            return;
                        }
                        List<EMMS.Model.Storage_OrderView> modelList = new List<Model.Storage_OrderView>();
                        page = value;
                        modelList = SubList(StorageOrderViewList, page);
                        dgvStorage.DataSource = modelList;
                        tbPage.Text = page.ToString();
                        if (page == 1)
                        {
                            btnPreview.Enabled = false;
                        }
                        else if (page == pageall)
                        {
                            btnNext.Enabled = false;
                        }
                        if (page == 2)
                        {
                            btnPreview.Enabled = true;
                        }
                        if (page == pageall - 1)
                        {
                            btnNext.Enabled = true;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("请输入数字！");
                    }
                }
            }
        }

    }
}
