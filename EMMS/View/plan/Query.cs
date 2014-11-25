using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.plan
{
    public partial class Query : EMMS.Common.View
    {
        private EMMS.BLL.Plan_Order bll = new BLL.Plan_Order();
        private string flag = "";
        private string flag1 = "";
        public bool judge;
        private EMMS.Common.View view;
        private int role;
        //Predicate<EMMS.Model.Picking_MaterialView> match;
        public Query()
        {
            InitializeComponent();
            judge = false;
            role = EMMS.Common.SavedInfo.Role;
        }

        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        private void BindData()
        {
            List<EMMS.Model.Plan_OrderView> modelList = new List<Model.Plan_OrderView>();
            modelList = bll.GetModelListView(flag,flag1);
            dgvQuery.DataSource = modelList;
            dgvQuery.Columns[0].HeaderText = "生产计划单编码";
            dgvQuery.Columns[1].HeaderText = "经手人";
            dgvQuery.Columns[2].HeaderText = "产生时间";
            dgvQuery.Columns[3].HeaderText = "已审核";
            dgvQuery.Columns[4].HeaderText = "状态";
            dgvQuery.Columns[5].HeaderText = "已结束";
            dgvQuery.Columns[6].HeaderText = "制表人员姓名";
            dgvQuery.Columns[7].HeaderText = "制表时间";
            dgvQuery.Columns[8].HeaderText = "备注";
            dgvQuery.ReadOnly = true;
            //dgvQuery.Columns[2].SortMode = DataGridViewColumnSortMode.Programmatic;
            //dgvQuery.Sort(dgvQuery.Columns[2], ListSortDirection.Ascending);
            //dgvQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            //dgvQuery.AutoResizeColumnHeadersHeight(0);
            //dgvQuery.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgvQuery.AutoSize = true;
        }
        private void Query_Load(object sender, EventArgs e)
        {
            tsbAdd.Visible = false;
            tsbCheck.Visible = false;
            tsbEnd.Visible = false;
            tsbPicking.Visible = false;

            if (judge == false)
            {
                rbAll.Checked = true;
                rbAll1.Checked = true;
                BindData();
            }
            else
            {
                rbAudited.Checked = true;
                flag = "1";//已审核的
                //panel1.Visible = false;
                panel1.Enabled = false;

                rbUnended.Checked = true;
                flag1 = "0";//未结束的
                //panel2.Visible = false;
                panel2.Enabled = false;
                BindData();
            }
            if (role == 0 )
            {
                tsbAdd.Visible = true;
                tsbCheck.Visible = true;
                tsbEnd.Visible = true;
                tsbPicking.Visible = true;
            }
            else if(role==1)
            {
                tsbAdd.Visible = true;
                tsbCheck.Visible = true;
                tsbEnd.Visible = true;
                tsbPicking.Visible = true;
            }
            else if (role == 11)
            {
                tsbAdd.Visible = true;
                tsbEnd.Visible = true;
                tsbPicking.Visible = true;
            }
        }
        private void Audited()
        {
            if (rbAll.Checked == true)
            {
                flag = "";
            }
            if (rbAudited.Checked == true)
            {
                flag = "1";
            }
            if (rbUnaudited.Checked == true)
            {
                flag = "0";
            }
            BindData();
        }
        private void rbAudited_CheckedChanged(object sender, EventArgs e)
        {
            Audited();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            EMMS.View.plan.Plan_Order view = new Plan_Order();
            view.Show();
        }

        private void tsbCheck_Click(object sender, EventArgs e)
        {
            if (dgvQuery.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            foreach (DataGridViewRow row in dgvQuery.SelectedRows)
            {
                if (bool.Parse(row.Cells[5].Value.ToString()) == true)
                {
                    MessageBox.Show("该生产计划单已经结束，无需审核！");
                    return;
                }
                if (bool.Parse(row.Cells[3].Value.ToString() )== true)
                {
                    MessageBox.Show("该生产计划单已经审核！");
                    return;
                } 
                EMMS.View.plan.Plan_Order view = new Plan_Order();
                view.tbNo.Text = row.Cells["no"].Value.ToString();
                view.tbStaff.Text = row.Cells["foundname"].Value.ToString();
                view.dtpTime.Value = DateTime.Parse(row.Cells["foundtime"].Value.ToString());
                view.tbRemarks.Text= row.Cells["remarks"].Value.ToString();
                view.tbMakeName.Text = row.Cells["makename"].Value.ToString();
                view.tbMakeTime.Text = row.Cells["maketime"].Value.ToString();
                base.PlanModelSet = bll.GetModel(row.Cells["no"].Value.ToString());//得到一个model,记录下来

                List<EMMS.Model.Plan_ProductionView> productionList = new List<Model.Plan_ProductionView>();
                productionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());//得到plan_production

                base.ProductionModelViewList = productionList;
                base.ProductionModelViewFlag = 1;
                //view.dgvPlan.DataSource = productionList;
                ////绑定之后需要更改HeaderText
                //view.dgvPlan.Columns[0].HeaderText = "编码";
                //view.dgvPlan.Columns[0].HeaderText = "产品名称";
                //view.dgvPlan.Columns[0].HeaderText = "数量";
                //view.dgvPlan.Columns[0].HeaderText = "审核人员姓名";
                //view.dgvPlan.Columns[0].HeaderText = "审核";
                //view.dgvPlan.Columns[0].HeaderText = "审核数量";
                //view.dgvPlan.Columns[0].HeaderText = "审核时间";
                //view.dgvPlan.Columns[0].HeaderText = "编码";
                view.flag = 1;
                view.GetParent(this);
                view.ShowDialog();
            }
        }

        private void tsbEnd_Click(object sender, EventArgs e)
        {
            if (dgvQuery.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            foreach (DataGridViewRow row in dgvQuery.SelectedRows)
            {
                if (bool.Parse(row.Cells[5].Value.ToString()) == true)
                {
                    MessageBox.Show("该生产计划单已经结束，无需指定结束！");
                    return;
                }

                EMMS.Model.Plan_OrderSet model = new Model.Plan_OrderSet();
                model = bll.GetModel(row.Cells["no"].Value.ToString());//得到一个model,记录下来  
                int index = dgvQuery.SelectedRows[0].Index;

                if (MessageBox.Show("确定要指定结束此生产计划单吗？", "确定指定结束", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
                //((DataGridViewCheckBoxCell)row.Cells[5]).Value = true;
                dgvQuery.Rows[index].Cells["ended"].Value = true;
                model.Ended = 1;
                //bll.UpdateOrder(model);
                if (bll.UpdateOrder(model))
                {
                    MessageBox.Show("指定结束成功！");     
                 }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            if (judge == false)
            {
                rbAll.Checked = true;
                rbAll1.Checked = true;
                BindData();
            }
        }
        private void Ended()
        {
            if (rbAll1.Checked == true)
            {
                flag1 = "";
            }
            if (rbEnded.Checked == true)
            {
                flag1 = "1";
            }
            if (rbUnended.Checked == true)
            {
                flag1 = "0";
            }
            BindData();
        }
        private void rbEnded_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void Query_Activated(object sender, EventArgs e)
        {
            if (judge == false)
            {
                rbAll.Checked = true;
                rbAll1.Checked = true;
                BindData();
            }
        }

        private void tsbPicking_Click(object sender, EventArgs e)
        {
            if (dgvQuery.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            foreach (DataGridViewRow row in dgvQuery.SelectedRows)
            {
                if (bool.Parse(row.Cells[5].Value.ToString()) == true)
                {
                    MessageBox.Show("该生产计划单已经结束，无需领料！");
                    return;
                }
                if (bool.Parse(row.Cells[3].Value.ToString()) == false)
                {
                    MessageBox.Show("该生产计划单还未审核完，不能领料！");
                    return;
                }
                if (row.Cells[4].Value.ToString().Trim().Equals("正在领料中"))
                {
                    MessageBox.Show("正在领料中，无需再领料！");
                    return;
                }
                if (row.Cells[4].Value.ToString().Trim().Equals("已领料"))
                {
                    MessageBox.Show("已领料，无需再领料！");
                    return;
                }
                if (row.Cells[4].Value.ToString().Trim().Equals("已部分领料"))
                {
                    MessageBox.Show("已部分领料，请等待！");
                    return;
                }
                
                //***********************************************产品BOM处理代码*******************************************//
                //1,得到该生产计划单上的产品
                List<EMMS.Model.Plan_ProductionView> ProductionList = new List<Model.Plan_ProductionView>();
                ProductionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                //2,用来保存得到物料信息  //no, materialname, counts, unit, materialno
                List<EMMS.Model.Picking_MaterialView> MaterialList = new List<Model.Picking_MaterialView>();
                //EMMS.Model.PMViewList PM=new Model.PMViewList();
               
                for (int i = 0; i < ProductionList.Count; i++)//所有的产品
                {
                    //3，声明一个栈
                    EMMS.Common.Stack<EMMS.Model.BOM> stack = new Common.Stack<EMMS.Model.BOM>();
                    stack.Init();                
                    //4，根据产品BOM，得到与该产品编码相关的物料信息
                    //得到产品编码
                    string productionNo = ProductionList[i].GoodsNo;
                    EMMS.BLL.Production_Material Bombll = new BLL.Production_Material();
                    List<EMMS.Model.BOM> BomList = new List<Model.BOM>();
                    BomList = Bombll.GetBom(productionNo); //得到的bom信息
                    for (int n = 0; n < BomList.Count; n++) //全部进栈
                    {
                        stack.Push(BomList[n]);
                    }
                    //出栈
                    while (stack.Top != -1 )
                    {
                        EMMS.Model.BOM temp = new Model.BOM();
                        stack.Pop(out temp);
                        //若得到的仍是成品，则将其相关物料继续进栈
                        if (temp.Type == "01")
                        {
                            List<EMMS.Model.BOM> TempList = new List<Model.BOM>();
                            float proporation = temp.Proporation;//记录其比例
                            TempList = Bombll.GetBom(temp.No);
                            foreach (EMMS.Model.BOM b in TempList)
                            {
                                b.Proporation *= proporation; //应让其比例在原来的基础上增加
                                stack.Push(b);//继续进栈
                            }
                        }
                        else
                        {
                            EMMS.Model.Picking_MaterialView  picking= new Model.Picking_MaterialView();
                            picking.MaterialNo = temp.No; //记录物料编码
                            picking.MaterialName = temp.MaterialName; //记录物料名称
                            picking.Unit = temp.Unit; //记录单位
                            //得到物料需求量
                            //1,产品生产量
                            int prodCounts = ProductionList[i].CheckCounts;//按审核的数量来计算
                            float proporation = temp.Proporation;
                            int total = 0;
                            if (prodCounts * proporation == prodCounts * (int)proporation)//若刚好为整数
                            {
                                total = (int)(prodCounts * proporation);
                            }
                            else //若不是整数，则多生产一个
                            {
                                total = (int)(prodCounts * proporation) + 1;
                            }
                            picking.Counts = total;//该物料需求量
                           //保存到之前的声明的List中
                            //PM.ViewList[PM[picking.MaterialNo]] = picking;
                            bool flag = true;
                            for(int j=0;j<MaterialList.Count;j++)
                            {
                                if(MaterialList[j].MaterialNo==picking.MaterialNo)
                                {
                                    MaterialList[j].Counts +=picking.Counts;
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                MaterialList.Add(picking);
                            }
                        }
                    }
                    
                }
                //基类保存领料单中物料记录
                base.PMFlag = 1;
                base.PMList = MaterialList;
                //基类保存生产计划单记录
                base.PlanFlag = 1;
                EMMS.Model.Plan_OrderSet set = new Model.Plan_OrderSet();
                set = bll.GetModel(row.Cells["no"].Value.ToString());
                base.PlanModelSet = set;
                
                //*******************************************************************************************************//
                EMMS.View.picking.Picking_Order view = new picking.Picking_Order();
                view.GetParent(this);
                view.Show();
                this.Dispose();
            }
        }

        private void tsbDetail_Click(object sender, EventArgs e)
        {
            if (dgvQuery.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach(DataGridViewRow row in dgvQuery.SelectedRows)
            {
                EMMS.Model.Plan_OrderView orderModel = new Model.Plan_OrderView();
                orderModel.No = row.Cells["no"].Value.ToString();
                orderModel.FoundName = row.Cells["foundname"].Value.ToString();
                orderModel.FoundTime = row.Cells["foundtime"].Value.ToString();
                orderModel.Audited = bool.Parse(row.Cells["audited"].Value.ToString());
                orderModel.Status = row.Cells[4].Value.ToString();
                orderModel.Ended=bool.Parse(row.Cells["ended"].Value.ToString());
                orderModel.MakeName=row.Cells["makename"].Value.ToString();
                orderModel.MakeTime = row.Cells["maketime"].Value.ToString();
                orderModel.Remarks = row.Cells["remarks"].Value.ToString();

                List<EMMS.Model.Plan_ProductionView> productionList = new List<Model.Plan_ProductionView>();
                productionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                base.PlanModelView = orderModel;
                base.ProductionModelViewList = productionList;

                EMMS.View.plan.Plan_Order planView = new Plan_Order();
                planView.flag = 2;
                planView.GetParent(this);
                planView.Show();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            Audited();
        }

        private void rbUnaudited_CheckedChanged(object sender, EventArgs e)
        {
            Audited();
        }

        private void rbAll1_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void rbUnended_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void dgvQuery_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (judge == true)
            {
                view.PlanFlag = 1;
                view.PlanModelSet = bll.GetModel(dgvQuery.Rows[e.RowIndex].Cells["no"].Value.ToString());
                this.Dispose();
            }
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvQuery);
        }
        
    }        
}

