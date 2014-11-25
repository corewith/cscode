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
    public partial class Add_Bom : EMMS.Common.View
    {
        private EMMS.BLL.Production_Material bll = new BLL.Production_Material();
        private EMMS.Common.View view;
        private EMMS.Model.GoodsSet goods;
        private int index;
        public int flag; //0表示增加，1表示修改
        public Add_Bom()
        {
            InitializeComponent();
            flag = 0;
            index = -1;
        }

        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        public void GetProd(EMMS.Model.GoodsSet goods)
        {
            this.goods = goods;
        }
        public void Init()
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "编码";
            c1.Name = "no";
            c1.DataPropertyName = "No";
            c1.ValueType = typeof(string);
            dgvBOM.Columns.Add(c1);

            DataGridViewButtonColumn c2 = new DataGridViewButtonColumn();
            c2.HeaderText = "物料名称";
            c2.Name = "materialname";
            c2.DataPropertyName = "MaterialName";
            c2.ValueType = typeof(string);
            dgvBOM.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "比例";
            c3.Name = "proporation";
            c3.DataPropertyName = "Proporation";
            c3.ValueType = typeof(float);
            dgvBOM.Columns.Add(c3);

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.HeaderText = "物料编码";
            c4.Name = "materialno";
            c4.DataPropertyName = "MaterialNo";
            c4.ValueType = typeof(string);
            dgvBOM.Columns.Add(c4);
            //
            dgvBOM.Columns["materialno"].Visible = false;

            for (int i = 0; i < 4; i++)
            {
                if (i == 2 || i == 0)
                    dgvBOM.Columns[i].ReadOnly = false;
                else
                {
                    dgvBOM.Columns[i].ReadOnly = true;
                }
            }
        }
        private void Add_Bom_Load(object sender, EventArgs e)
        {
            Init();
            tbProd.Text = goods.Name;
            if (flag == 1) //修改
            {
                if (view.MaterialFlag == 1)
                {
                    //for (int i = 0; i < view.MaterialView.Count; i++)
                    //{
                    //    //DataGridViewRow row=new DataGridViewRow();
                    //    dgvBOM.Rows[i].Cells["no"].Value = view.MaterialView[i].No;
                    //    dgvBOM.Rows[i].Cells["materialname"].Value = view.MaterialView[i].MaterialName;
                    //    dgvBOM.Rows[i].Cells["proporation"].Value = view.MaterialView[i].Proporation;
                    //    dgvBOM.Rows[i].Cells["materialno"].Value = view.MaterialView[i].MaterialNo;
                    //    //dgvBOM.Rows.Add(row);
                    //}
                    dgvBOM.DataSource = view.MaterialView;
                    //dgvBOM.Columns[0].DataPropertyName = "No";
                    //dgvBOM.Columns[1].DataPropertyName = "MaterialName";
                    //dgvBOM.Columns[2].DataPropertyName = "Proporation";
                    //dgvBOM.Columns[3].DataPropertyName = "MaterialNo";
                    //dgvBOM.Columns[0].HeaderText = "编码";
                    //dgvBOM.Columns[1].HeaderText = "物料名称";
                    //dgvBOM.Columns[2].HeaderText = "比例";
                    //dgvBOM.Columns[3].HeaderText = "物料编码";
                    view.MaterialFlag = 0;
                }
            }
        }

        private void dgvBOM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (dgvBOM.Columns[e.ColumnIndex].Name == "materialname")
            {
                EMMS.View.goods.List list = new List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void Add_Bom_Activated(object sender, EventArgs e)
        {
            if (base.GoodsFlag == 1)
            {
                dgvBOM.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
                dgvBOM.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;
                base.GoodsFlag = 0;
            }
        }

        private void dgvBOM_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            dgvBOM.EndEdit();
            List<EMMS.Model.Production_MaterialSet> bomList = new List<Model.Production_MaterialSet>();

            if (dgvBOM.Rows[0].Cells["no"].Value== null)
            {
                MessageBox.Show("请填写信息完整！");
                return;
            }
            for (int i = 0; i < dgvBOM.Rows.Count - 1; i++)
            {
                EMMS.Model.Production_MaterialSet set = new Model.Production_MaterialSet();
                set.No = dgvBOM.Rows[i].Cells["no"].Value.ToString();
                set.ProductionNo = goods.No;
                set.MaterialNo = dgvBOM.Rows[i].Cells["materialno"].Value.ToString();
                try
                {
                    set.Proporation = float.Parse(dgvBOM.Rows[i].Cells["proporation"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("请填写正确的比例！");
                }
                    bomList.Add(set);
            }
            if (flag == 0)
            {
                if (bll.AddList(bomList))
                {
                    MessageBox.Show("保存成功！");
                }
            }
            else if(flag==1)
            {
                if (bll.UpdateList(bomList))
                {
                    MessageBox.Show("修改成功！");
                }
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
