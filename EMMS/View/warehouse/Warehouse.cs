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
    public partial class Warehouse : Form
    {
        public EMMS.BLL.Warehouse bll = new BLL.Warehouse();

        public Warehouse()
        {
            InitializeComponent();
        }
        //tvWarehouseAttri初始化
        private void InitTreeView()
        {
            if (tvWarehouseAttri != null)
            {
                tvWarehouseAttri.Nodes.Clear();
            }
            //根节点
            TreeNode tnRoot = new TreeNode();
            tnRoot.Text = "仓库类别";
            tvWarehouseAttri.Nodes.Add(tnRoot);
            //得到仓库类别名称
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
            
            List<EMMS.Model.WarehouseView> modelListView = new List<Model.WarehouseView>();
            modelListView = bll.GetModelListView(tbSearch.Text.ToString());
            dgvWarehouse.DataSource = modelListView;

            dgvWarehouse.AllowUserToAddRows = false;

            for (int i = 0; i < dgvWarehouse.Columns.Count; i++)
            {
                if (i == 3)
                    dgvWarehouse.Columns[i].ReadOnly = false;
                else
                    dgvWarehouse.Columns[i].ReadOnly = true;
            }
            dgvWarehouse.Columns[0].HeaderText = "仓库编码";
            dgvWarehouse.Columns[1].HeaderText = "仓库名称";
            dgvWarehouse.Columns[2].HeaderText = "仓库类别";
            dgvWarehouse.Columns[3].HeaderText = "不可用";
            dgvWarehouse.Columns[4].HeaderText = "备注";
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            
            InitTreeView();
            BindData();
        }

        private void tvWarehouseAttri_Click(object sender, EventArgs e)
        {
            //TreeView tv = (TreeView)sender;
            //TreeNode node = tv.SelectedNode;//获取当前选择Node
            //try
            //{
            //    if (node.Parent != null)//不是根节点
            //    {
            //        List<EMMS.Model.WarehouseView> modelListView = new List<Model.WarehouseView>();
            //        modelListView = bll.GetModelListView(node.Text.ToString());
            //        dgvWarehouse.DataSource = modelListView;
            //    }
            //}
            //catch(NullReferenceException ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

        private void tvWarehouseAttri_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            TreeNode node =new TreeNode();
            if(tv.SelectedNode!=null)
            {
                node = tv.SelectedNode;
                if (node.Parent != null)
                {
                    List<EMMS.Model.WarehouseView> modelListView = new List<Model.WarehouseView>();
                    modelListView = bll.GetModelListView(node.Text.ToString());
                    dgvWarehouse.DataSource = modelListView;
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
            if (e.RowIndex > 0 && e.RowIndex < dgvWarehouse.Rows.Count)
            {
                //让其失去焦点
                //dgvWarehouse.EndEdit();

                string no = dgvWarehouse.Rows[e.RowIndex].Cells[0].Value.ToString();
                Model.WarehouseSet model = new Model.WarehouseSet();
                model = bll.GetModel(no);
                model.Useable = ((Convert.ToBoolean(dgvWarehouse.Rows[e.RowIndex].Cells[3].Value.ToString())) == true) ? 0 : 1;
                bll.Update(model);
            }
        }
        
        private void dgvWarehouse_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        //刷新
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            InitTreeView();
            BindData();
        }
        //仓库类别
        private void tsbWarehouseAttri_Click(object sender, EventArgs e)
        {
            WarehouseAttri warehouseAttri = new WarehouseAttri();
            warehouseAttri.ShowDialog();
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
            if (!(dgvWarehouse.SelectedRows.Count > 0))
            {
                MessageBox.Show("请至少选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvWarehouse.SelectedRows)
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
            if (dgvWarehouse.SelectedRows.Count !=1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvWarehouse.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string no = row.Cells[0].Value.ToString();
                    string name = row.Cells[1].Value.ToString();
                    string typename = row.Cells[2].Value.ToString();
                    bool disabled = Convert.ToBoolean(row.Cells[3].Value.ToString());
                    string remarks = row.Cells[4].Value.ToString();
                    Add add = new Add();
                    add.flag = 1;
                    add.warehouseAttrimodel.Name = typename;
                    add.warehouseAttrimodel.No = (bll.GetModel(no)).Type;
                    add.tbNo.Text = no;
                    add.tbName.Text = name;
                    add.tbType.Text = typename;
                    add.ckbDisabled.Checked = disabled;
                    add.tbRemarks.Text = remarks;
                    add.ShowDialog();    
                }
            }
        }

        private void Warehouse_Activated(object sender, EventArgs e)
        {
            //BindData();
        }

        private void Warehouse_Enter(object sender, EventArgs e)
        {
            InitTreeView();
            BindData();
        }

        private void tvWarehouseAttri_Enter(object sender, EventArgs e)
        {
            //InitTreeView();
            InitTreeView();
        }

        private void dgvWarehouse_Enter(object sender, EventArgs e)
        {
            //BindData();
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvWarehouse);
        }
        
    }
}
