using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.paying
{
    public partial class Paying_Order : EMMS.Common.View
    {
        private EMMS.Common.View view;
        private EMMS.Model.Paying_OrderSet orderModel = new Model.Paying_OrderSet();
        private List<EMMS.Model.Paying_MaterialSet> materialList = new List<Model.Paying_MaterialSet>();
        private EMMS.BLL.Paying_Order bll = new BLL.Paying_Order();
        private int index;
        public int flag;
        //flag=0;表示增加;flag=1;表示查看详情,2表示由进购单生成,3由复制前置单据
        public Paying_Order()
        {
            InitializeComponent();
            flag = 0;
            index = -1;
        }
        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        private void BindData()
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "编码";
            c1.DataPropertyName = "No";
            c1.Name = "no";
            c1.ValueType = typeof(string);
            c1.ReadOnly = true;
            dgvPaying.Columns.Add(c1);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "物料名称";
            btn1.DataPropertyName = "MaterialName";
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Name = "materialname";
            btn1.ToolTipText = "请选择物料";
            dgvPaying.Columns.Add(btn1);

            DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            c7.HeaderText = "单位";
            c7.DataPropertyName = "Unit";
            c7.Name = "unit";
            c7.ValueType = typeof(string);
            dgvPaying.Columns.Add(c7);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "数量";
            c2.DataPropertyName = "Counts";
            c2.Name = "counts";
            c2.ValueType = typeof(int);
            dgvPaying.Columns.Add(c2);

            DataGridViewTextBoxColumn c8 = new DataGridViewTextBoxColumn();
            c8.HeaderText = "单价";
            c8.DataPropertyName = "Price";
            c8.Name = "price";
            c8.ValueType = typeof(float);
            dgvPaying.Columns.Add(c8);
            
            DataGridViewTextBoxColumn c9 = new DataGridViewTextBoxColumn();
            c9.HeaderText = "货币单位";
            c9.DataPropertyName = "PriceUnit";
            c9.Name = "priceunit";
            c9.ValueType = typeof(string);
            dgvPaying.Columns.Add(c9);
            

            DataGridViewTextBoxColumn c10 = new DataGridViewTextBoxColumn();
            c10.HeaderText = "总价格";
            c10.DataPropertyName = "Cost";
            c10.Name = "cost";
            c10.ValueType = typeof(float);
            dgvPaying.Columns.Add(c10);
            

            DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
            c11.HeaderText = "物料编码";
            c11.DataPropertyName = "MaterialNo";
            c11.Name = "materialno";
            c11.ValueType = typeof(string);
            dgvPaying.Columns.Add(c11);
            //让其隐藏
            dgvPaying.Columns["materialno"].Visible = false;
        }
        private void Paying_Order_Load(object sender, EventArgs e)
        {
            //flag=0;表示增加;flag=1;表示查看详情,2表示由进购单生成,3由复制前置单据
            BindData();
            if (flag == 0) //增加
            {
                //BindData();
                tbNo.Text = orderModel.No;
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
            else if (flag == 1) //查看详情
            {
                tbNo.ReadOnly = true;
                tbDepartment.ReadOnly = true;
                tbFoundName.ReadOnly = true;
                tbRemarks.ReadOnly = true;
                //btnDepartment.Enabled = false;
                //btnFoundName.Enabled = false;
                //btnEntry.Enabled = false;
                dtpTime.Enabled = false;
                tsbCopy.Visible = false;
                tsbSave.Visible = false;

                tbNo.Text = view.PayingModelView.No;
                tbDepartment.Text = view.PayingModelView.DepartmentName;
                tbFoundName.Text = view.PayingModelView.FoundName;
                dtpTime.Value = DateTime.Parse(view.PayingModelView.FoundTime);
                tbRemarks.Text = view.PayingModelView.Remarks;
                tbMakeName.Text = view.PayingModelView.MakeName;
                tbMakeTime.Text = view.PayingModelView.MakeTime;

                dgvPaying.ReadOnly = true;

                if (view.PayingModelFlag == 1)
                {
                    tbEntry.Text = view.PayingModelView.Entry;
                    dgvPaying.DataSource = view.PayingModelViewList;
                }
            }
            else if (flag == 2) //由进购单生成
            { 
                //得到good相关信息
                //EMMS.BLL.Goods goodBll = new BLL.Goods();  
                //
                tbNo.Text = orderModel.No;
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
                dgvPaying.ReadOnly = true;

                if (view.PayingModelFlag == 1)
                {
                    tbEntry.Text = view.EntryModelSet.No;
                    dgvPaying.DataSource = view.PayingModelViewList;                   
                }
            }
            else if (flag == 3)
            {
                dgvPaying.ReadOnly = true;
                tbNo.Text = orderModel.No;
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
        }
   
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            //flag=0;表示增加;flag=1;表示查看详情,2表示由进购单生成,3由复制前置单据
            if (flag != 1)
            {
                EMMS.View.staff.Department department = new staff.Department();
                department.flag = true;
                department.GetParent(this);
                department.ShowDialog();
            }
        }

        private void btnFoundName_Click(object sender, EventArgs e)
        {
            //flag=0;表示增加;flag=1;表示查看详情,2表示由进购单生成,3由复制前置单据
            if (flag != 1)
            {
                EMMS.View.staff.List list = new staff.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            //flag=0;表示增加;flag=1;表示查看详情,2表示由复制前置单据，或由进购单生成
            if (string.IsNullOrEmpty(tbFoundName.Text))
            {
                MessageBox.Show("经手人还未填写！");
                return;
            }
            if (string.IsNullOrEmpty(tbDepartment.Text))
            {
                MessageBox.Show("目标单位还未填写！");
                return;
            }
            if (string.IsNullOrEmpty(tbEntry.Text))
            {
                MessageBox.Show("与之对应的进购单未选择！");
                return;
            }
            orderModel.FoundNo = base.StaffModel.No;
            orderModel.Department = base.DepartmentModel.No;

            orderModel.FoundTime = dtpTime.Value.ToShortDateString();
            orderModel.Remarks = tbRemarks.Text;
            orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;
            orderModel.MakeTime = tbMakeTime.Text;
            orderModel.Entry = tbEntry.Text;
            //flag=0;表示增加;flag=1;表示查看详情,2表示由复制前置单据，或由进购单生成
            int total = 0;
            if (flag == 0)
            {
                total = dgvPaying.Rows.Count - 1;
            }
            else
            {
                total = dgvPaying.Rows.Count;
            }
            for (int i = 0; i < total; i++)
            {
                if (dgvPaying.Rows[i].Cells["no"].Value.ToString() != null)
                {
                    //
                    try
                    {
                        
                        if (int.Parse(dgvPaying.Rows[i].Cells["counts"].Value.ToString()) <= 0)
                        {
                            MessageBox.Show("请填写正确的进购数目！");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("请填写正确的进购数目！");
                    }
                    EMMS.Model.Paying_MaterialSet set = new Model.Paying_MaterialSet();
                    set.No = dgvPaying.Rows[i].Cells["no"].Value.ToString();
                    set.Counts = int.Parse(dgvPaying.Rows[i].Cells["counts"].Value.ToString());
                    set.Paying = tbNo.Text;
                    set.Material = dgvPaying.Rows[i].Cells["materialno"].Value.ToString();
                    set.Cost = float.Parse(dgvPaying.Rows[i].Cells["cost"].Value.ToString());
                    materialList.Add(set);
                }
            }
            if (bll.Add(orderModel, materialList))
            {
                MessageBox.Show("保存成功！");
                //修改进购单状态status
                EMMS.Model.Entry_OrderSet set = new Model.Entry_OrderSet();
                EMMS.BLL.Entry_Order entryBll = new BLL.Entry_Order();
                set = entryBll.GetModel(orderModel.Entry);
                set.Status = "已生成付款结算单";
                entryBll.UpdateOrder(set);
                //if (entryBll.UpdateOrder(set))
                //{
                //    MessageBox.Show("进购单状态更新成功！");
                //}


                List<EMMS.Model.Payed_MaterialView> payedViewList = new List<Model.Payed_MaterialView>();
                List<EMMS.Model.Paying_MaterialView> payingViewList = new List<Model.Paying_MaterialView>();
                EMMS.Model.Paying_OrderSet payingSet = new Model.Paying_OrderSet();
                payingSet = bll.GetModel(orderModel.No);

                payingViewList = bll.GetModelListView1(orderModel.No);
                for (int i = 0; i < payingViewList.Count; i++)
                {
                    EMMS.Model.Payed_MaterialView payedView = new Model.Payed_MaterialView();
                    //payedView.No
                    payedView.MaterialName = payingViewList[i].MaterialName;
                    payedView.Unit = payingViewList[i].Unit;
                    payedView.Counts = payingViewList[i].Counts;
                    payedView.Price = payingViewList[i].Price;
                    payedView.PriceUnit = payingViewList[i].PriceUnit;
                    payedView.Cost = payingViewList[i].Cost;
                    payedView.MaterialNo = payingViewList[i].MaterialNo;
                    payedViewList.Add(payedView);
                }

                EMMS.Common.SavedInfo.PayingOrderSet = payingSet;
                EMMS.Common.SavedInfo.PayedFlag = 1;
                EMMS.Common.SavedInfo.PayedMaterialViewList = payedViewList;
            }
            this.Dispose();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Picking_Order_Activated(object sender, EventArgs e)
        {
            //flag=0;表示增加;flag=1;表示查看详情,2表示由进购单生成,3由复制前置单据
            if (flag == 0 )  //增加
            {
                if (base.GoodsFlag == 1)
                {
                    EMMS.Model.Paying_MaterialSet material = new Model.Paying_MaterialSet();
                    dgvPaying.Rows[index].Cells["no"].Value = material.No;
                    dgvPaying.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
                    dgvPaying.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;
                    dgvPaying.Rows[index].Cells["unit"].Value = base.GoodsModel.Unit;
                    dgvPaying.Rows[index].Cells["price"].Value = base.GoodsModel.Price;
                    dgvPaying.Rows[index].Cells["priceunit"].Value = base.GoodsModel.PriceUnit;

                    base.GoodsFlag = 0;
                }

                if (base.EntryModelFlag == 1)
                {
                    tbEntry.Text = base.EntryModelSet.No;
                    base.EntryModelFlag = 0;
                }
            }
            if (flag != 1)
            {
                if (base.DepartmentFlag == 1)
                {
                    tbDepartment.Text = base.DepartmentModel.Name;
                    base.DepartmentFlag = 0;
                }
                if (base.StaffFlag == 1)
                {
                    tbFoundName.Text = base.StaffModel.Name;
                    base.StaffFlag = 0;
                }
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                EMMS.View.entry.Query query = new entry.Query();
                query.GetParent(this);
                query.judge = true;
                query.ShowDialog();
            }
        }

        private void dgvPaying_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            this.dgvPaying.EndEdit();
            
        }

        private void dgvPaying_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
            if (flag == 0)
            {
                if (dgvPaying.Columns[e.ColumnIndex].Name == "counts")
                {
                    try
                    {
                        dgvPaying.Rows[e.RowIndex].Cells["cost"].Value = float.Parse(dgvPaying.Rows[e.RowIndex].Cells["price"].Value.ToString()) * int.Parse(dgvPaying.Rows[e.RowIndex].Cells["counts"].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("请输入正确的进购数量！");
                        return;
                    }
                }
            }
        }

        private void dgvPaying_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //flag=0;表示增加;flag=1;表示查看详情,2表示由进购单生成,3由复制前置单据
            index = e.RowIndex;
            this.Validate();
            if (flag == 0)
            {
                if (dgvPaying.Columns[e.ColumnIndex].Name == "materialname")
                {
                    EMMS.View.goods.List list = new goods.List();
                    list.GetParent(this);
                    list.ShowDialog();
                }
            }
        }

        private void dgvPaying_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Validate();
        }

        private void dgvPaying_KeyDown(object sender, KeyEventArgs e)
        {
            //if (dgvPaying.Rows[index].Cells["materialno"].Value == null)
            //{
            //    MessageBox.Show("请先选择物料！");
            //    return;
            //}
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (EMMS.Common.SavedInfo.PayingFlag == 1)
            {
                tbEntry.Text = EMMS.Common.SavedInfo.EntryOrderSet.No;
                dgvPaying.DataSource = EMMS.Common.SavedInfo.PayingMaterialViewList;
                flag = 3;
            }
            else
            {
                MessageBox.Show("未检测到与之相关的进购单！");
                return;
            }
        }
    }
}
