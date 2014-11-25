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
    public partial class Production_Material : EMMS.Common.View
    {
        private EMMS.BLL.Production_Material bll = new BLL.Production_Material();
        //private int flag;
        public Production_Material()
        {
            InitializeComponent();
            //flag = 1;
        }
        private void Init(TreeNode root,List<TreeNode> nodeList,string strProd)
        {
            if(strProd.Equals("请选择产品..."))
            {}
            else
            {
                nodeList = bll.GetNodeList(strProd);
                foreach (TreeNode node in nodeList)
                {
                    root.Nodes.Add(node);
                      if(bll.GetNodeList(node.Text)!=null)
                          Init(node,bll.GetNodeList(node.Text),node.Text);
                }   
            }
        }
        private void InitTree()
        {
            if (tvBOM.Nodes.Count > 0)
            {
                tvBOM.Nodes.Clear();
            }
            TreeNode root = new TreeNode();
            root.Text = "产品BOM";
            //test
            //MessageBox.Show(cbProduction.SelectedIndex.ToString());
            //MessageBox.Show(((ComboBoxItem)cbProduction.SelectedItem).DisplayValue);
            //MessageBox.Show(cbProduction.SelectedText);
            //MessageBox.Show(cbProduction.SelectedValue.ToString());
            //if (root.Nodes.Count > 0)
            //{
            //    root.Nodes.Clear();
            //}
            Init(root, bll.GetNodeList(cbProduction.SelectedValue.ToString()), ((ComboBoxItem)cbProduction.SelectedItem).DisplayValue);
            tvBOM.Nodes.Add(root);
            tvBOM.ExpandAll();
        }
        private void BindData()
        {
            string strProd = ((ComboBoxItem)cbProduction.SelectedItem).DisplayValue;
            if (strProd.Equals("请选择产品..."))
            {
                dgvBOM.DataSource = null;
            }
            else
            {
                EMMS.Model.Production_MaterialView model = new Model.Production_MaterialView();
                model = bll.GetModelListView(strProd);
                dgvBOM.DataSource = model.MaterialNameList;
                dgvBOM.Columns[0].HeaderText = "产品BOM编码";
                dgvBOM.Columns[1].HeaderText = "组成物品名称";
                dgvBOM.Columns[2].HeaderText = "比例";
                dgvBOM.Columns[3].HeaderText = "物料编码";
                //
                dgvBOM.Columns[3].Visible = false;
            } 
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitTree();
            BindData();
        }

        private void dgvBOM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void Production_Material_Load(object sender, EventArgs e)
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            List<EMMS.Model.GoodsSet> goodsList=bll.GetGoodsList();
            
            foreach (EMMS.Model.GoodsSet model  in goodsList)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.DisplayValue = model.Name;
                item.RealValue = model.No;
                items.Add(item);
            }
            cbProduction.DataSource = items;
            cbProduction.DisplayMember = "DisplayValue";
            cbProduction.ValueMember = "RealValue";

            
        }
        private void Add()
        {
            EMMS.Model.GoodsSet goods = new Model.GoodsSet();
            goods.Name = (((ComboBoxItem)cbProduction.SelectedItem)).DisplayValue;
            goods.No = (((ComboBoxItem)cbProduction.SelectedItem)).RealValue;

            EMMS.View.goods.Add_Bom add = new Add_Bom();
            add.GetProd(goods);
            add.ShowDialog();
        }
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (((ComboBoxItem)cbProduction.SelectedItem).DisplayValue== "请选择产品...")
            {
                MessageBox.Show("请先选择一个产品！");
                return;
            }
            if ((bll.GetModelListView(((ComboBoxItem)cbProduction.SelectedItem).DisplayValue).MaterialNameList.Count!=0))
            {
                if (MessageBox.Show("该产品已有一个产品BOM，是否转为修改？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Alter();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Add();
            }

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (((ComboBoxItem)cbProduction.SelectedItem).DisplayValue == "请选择产品...")
            {
                MessageBox.Show("请先选择一个产品！");
                return;
            }
            //
            List<EMMS.Model.MaterialNameView> viewList = bll.GetModelListView(((ComboBoxItem)cbProduction.SelectedItem).DisplayValue).MaterialNameList;
            //List<EMMS.Model.Production_MaterialSet> setList = new List<Model.Production_MaterialSet>();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < viewList.Count; i++)
            {
                //EMMS.Model.Production_MaterialSet set = new Model.Production_MaterialSet();
                //set.No = viewList[i].No;
                //set.ProductionNo=((ComboBoxItem)cbProduction.SelectedItem).RealValue;
                //set.MaterialNo = viewList[i].MaterialNo;
                //set.Proporation = viewList[i].Proporation;
                //setList.Add(set);
                if (i == 0)
                {
                    str.Append("'"+viewList[i].No+"'");
                }
                else
                {
                    str.Append("," + "'"+viewList[i].No+"'");
                }
            }
            if(bll.DeleteList(str.ToString()))
            {
                MessageBox.Show("删除成功！");
                dgvBOM = null;
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            cbProduction.SelectedIndex = 0;
            InitTree();
            BindData();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Alter()
        {
            EMMS.Model.GoodsSet goods = new Model.GoodsSet();
            goods.Name = (((ComboBoxItem)cbProduction.SelectedItem)).DisplayValue;
            goods.No = (((ComboBoxItem)cbProduction.SelectedItem)).RealValue;

            EMMS.Model.Production_MaterialView model = new Model.Production_MaterialView();
            model = bll.GetModelListView(((ComboBoxItem)cbProduction.SelectedItem).DisplayValue);
            base.MaterialView = model.MaterialNameList;
            base.MaterialFlag = 1;

            EMMS.View.goods.Add_Bom add = new Add_Bom();
            add.flag = 1;
            add.GetProd(goods);
            add.GetParent(this);
            add.ShowDialog();
        }
        private void tsbAlter_Click(object sender, EventArgs e)
        {
            if (((ComboBoxItem)cbProduction.SelectedItem).DisplayValue == "请选择产品...")
            {
                MessageBox.Show("请先选择一个产品！");
                return;
            }
            if ((bll.GetModelListView(((ComboBoxItem)cbProduction.SelectedItem).DisplayValue).MaterialNameList.Count == 0))
            {
                if (MessageBox.Show("该产品还未有一个产品BOM，是否转为增加？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Add();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Alter();
            }
        }
    }
   
}
