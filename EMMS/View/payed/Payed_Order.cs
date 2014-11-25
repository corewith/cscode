using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.payed
{
    public partial class Payed_Order : EMMS.Common.View
    {
        private EMMS.BLL.Payed_Order bll = new BLL.Payed_Order();//
        //private EMMS.BLL.Storage_Order bll1 = new BLL.Storage_Order();//库存更新
        private EMMS.Model.Payed_OrderSet orderModel = new Model.Payed_OrderSet();//
        private List<EMMS.Model.Payed_MaterialSet> productionList = new List<Model.Payed_MaterialSet>();//
        private int index;
        public int flag; //标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成,4表示复制前置单据
        private EMMS.Common.View view;
        private int role;

        public Payed_Order()
        {
            InitializeComponent();
            index = -1;
            flag = 0;
            role = EMMS.Common.SavedInfo.Role;

        }
        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        public void Init()
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "编码";
            c1.DataPropertyName = "No";
            c1.Name = "no";
            c1.ValueType = typeof(string);
            c1.ReadOnly = true;
            dgvPayed.Columns.Add(c1);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "物料名称";
            btn1.DataPropertyName = "MaterialName";
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Name = "materialname";
            btn1.ToolTipText = "请选择物料";
            dgvPayed.Columns.Add(btn1);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "单位";
            c3.DataPropertyName = "Unit";
            c3.Name = "unit";
            c3.ValueType = typeof(string);
            dgvPayed.Columns.Add(c3);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "数量";
            c2.DataPropertyName = "Counts";
            c2.Name = "counts";
            c2.ValueType = typeof(int);
            dgvPayed.Columns.Add(c2);

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.HeaderText = "单价";
            c4.DataPropertyName = "Price";
            c4.Name = "price";
            c4.ValueType = typeof(float);
            dgvPayed.Columns.Add(c4);

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "货币单位";
            c5.DataPropertyName = "PriceUnit";
            c5.Name = "priceunit";
            c5.ValueType = typeof(string);
            dgvPayed.Columns.Add(c5);

            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "总价格";
            c6.DataPropertyName = "Cost";
            c6.Name = "cost";
            c6.ValueType = typeof(float);
            dgvPayed.Columns.Add(c6);

            //DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            //c7.HeaderText = "审核人员姓名";
            //c7.Name = "checkname";
            //c7.ValueType = typeof(string);
            //dgvPayed.Columns.Add(c7);
            //dgvPayed.Columns["checkname"].Visible = false;

            DataGridViewCheckBoxColumn c8 = new DataGridViewCheckBoxColumn();
            c8.HeaderText = "审核";
            c8.DataPropertyName = "Audited";
            c8.Name = "audited";
            c8.ValueType = typeof(bool);
            dgvPayed.Columns.Add(c8);
            dgvPayed.Columns["audited"].Visible = false;

            DataGridViewTextBoxColumn c10 = new DataGridViewTextBoxColumn();
            c10.HeaderText = "审核时间";
            c10.DataPropertyName = "CheckTime";
            c10.Name = "checktime";
            c10.ValueType = typeof(string);
            c10.ReadOnly = true;
            dgvPayed.Columns.Add(c10);
            dgvPayed.Columns["checktime"].Visible = false;

            DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
            c11.HeaderText = "物料编码";
            c11.DataPropertyName = "MaterialNo";
            c11.Name = "materialno";
            c11.ValueType = typeof(string);
            dgvPayed.Columns.Add(c11);
            //让其隐藏
            dgvPayed.Columns["materialno"].Visible = false;
        }

        private void Payed_Order_Load(object sender, EventArgs e)
        {
            Init();
            if (flag == 0)//标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
            if (flag == 3)//标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
                if (view.PayedModelFlag == 1)
                {
                    tbPaying.Text = view.PayingModelSet.No; //请购单联系
                    dgvPayed.DataSource = view.PayedModelViewList;
                }
            }
            else if (flag == 1) //审核//标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            {

                //btnStaff.Enabled = false;
                dtpTime.Enabled = false;
                //
                //tbNo.Text = view.PayedModelView.No;

                //tbStaff.Text = view.PayedModelView.FoundName;
                //tbRemarks.Text = view.PayedModelView.Remarks;
                //dtpTime.Value = DateTime.Parse(view.PayedModelView.FoundTime);
                //tbMakeName.Text = view.PayedModelView.MakeName;
                //tbMakeTime.Text = view.PayedModelView.MakeTime;
                //tbPaying.Text = view.PayedModelView.Paying;

                if (view.PayedModelFlag == 1)
                {
                    dgvPayed.DataSource = view.PayedModelViewList;
                }
            }
            else if (flag == 2) //查看详情
            {
                tsbSave.Visible = false;
                tsbCopy.Visible = false;
                tbMakeName.ReadOnly = true;
                tbMakeTime.ReadOnly = true;
                tbNo.ReadOnly = true;
                tbRemarks.ReadOnly = true;
                tbStaff.ReadOnly = true;
                dtpTime.Enabled = false;

                //btnPaying.Enabled = false;
                //btnStaff.Enabled = false;
                dgvPayed.ReadOnly = true;

                //所有人都可以查看
                //dgvPayed.Columns["checkname"].Visible = true;
                dgvPayed.Columns["audited"].Visible = true;

                dgvPayed.Columns["checktime"].Visible = true;
                //dgvPlan.Columns["materialname"].ReadOnly = true;

                tbNo.Text = view.PayedModelView.No;

                tbStaff.Text = view.PayedModelView.FoundName;
                tbRemarks.Text = view.PayedModelView.Remarks;
                dtpTime.Value = DateTime.Parse(view.PayedModelView.FoundTime);
                tbMakeName.Text = view.PayedModelView.MakeName;
                tbMakeTime.Text = view.PayedModelView.MakeTime;
                tbPaying.Text = view.PayedModelView.Paying;

                dgvPayed.DataSource = view.PayedModelViewList;
                dgvPayed.ReadOnly = true;
            }
            else if (flag == 4)
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
            if (flag != 2)
            {
                if (EMMS.Common.SavedInfo.Role == 0 || EMMS.Common.SavedInfo.Role == 4) //管理员或财务经理
                {
                    //dgvPayed.Columns["checkname"].Visible = true;
                    dgvPayed.Columns["audited"].Visible = true;

                    dgvPayed.Columns["checktime"].Visible = true;
                }
            }
        }

        private void dgvStocking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvPayed.EndEdit();
        }

        private void dgvStocking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //审核//标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            index = e.RowIndex;
            if (flag==0)
            {
                if (dgvPayed.Columns[e.ColumnIndex].Name == "materialname")
                {
                    EMMS.View.goods.List list = new goods.List();
                    list.GetParent(this);
                    list.ShowDialog();
                }
            }
            if(flag!=2)
            {
                if (dgvPayed.Columns[e.ColumnIndex].Name == "audited")
                {
                    if (dgvPayed.Rows[e.RowIndex].Cells["audited"].Value == null)
                    {
                        dgvPayed.Rows[e.RowIndex].Cells["audited"].Value = true;
                    }
                    else if (bool.Parse(dgvPayed.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == true)
                    {
                        dgvPayed.Rows[e.RowIndex].Cells["audited"].Value = false;
                        this.Validate();
                    }
                    else if (bool.Parse(dgvPayed.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == false)
                    {
                        dgvPayed.Rows[e.RowIndex].Cells["audited"].Value = true;
                        this.Validate();
                    }
                }
            }
        }

        private void Stocking_Order_Activated(object sender, EventArgs e)
        {
            if (flag == 0 )//增加的时候才需要填写  //标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成,4
            {
                if (base.GoodsFlag == 1)
                {
                    dgvPayed.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
                    EMMS.Model.Payed_MaterialSet productionmodel = new Model.Payed_MaterialSet();
                    dgvPayed.Rows[index].Cells["no"].Value = productionmodel.No;//
                    dgvPayed.Rows[index].Cells["unit"].Value = base.GoodsModel.Unit;
                    dgvPayed.Rows[index].Cells["price"].Value = base.GoodsModel.Price;
                    dgvPayed.Rows[index].Cells["priceunit"].Value = base.GoodsModel.PriceUnit;
                    dgvPayed.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;
                    if (dgvPayed.Rows[index].Cells["counts"].Value != null)
                    {
                        dgvPayed.Rows[index].Cells["cost"].Value = (int)(dgvPayed.Rows[index].Cells["counts"].Value) * (float)(dgvPayed.Rows[index].Cells["price"].Value);
                    }

                    base.GoodsFlag = 0;
                }
                 if (base.PayingModelFlag == 1) 
                {
                    tbPaying.Text = base.PayingModelSet.No;
                    base.PayingModelFlag = 0;
                }
            }
            if(flag!=2)
            {
                if (base.StaffFlag == 1) 
                {
                    this.tbStaff.Text = base.StaffModel.Name;//赋值创建人员姓名
                    base.StaffFlag = 0;
                }
            }
               
            //}
            //if (flag == 3)  //标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            //{
            //    if (base.GoodsFlag == 1)
            //    {
            //        dgvPayed.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
            //        EMMS.Model.Payed_MaterialSet productionmodel = new Model.Payed_MaterialSet();
            //        dgvPayed.Rows[index].Cells["no"].Value = productionmodel.No;//
            //        dgvPayed.Rows[index].Cells["unit"].Value = base.GoodsModel.Unit;
            //        dgvPayed.Rows[index].Cells["price"].Value = base.GoodsModel.Price;
            //        dgvPayed.Rows[index].Cells["priceunit"].Value = base.GoodsModel.PriceUnit;
            //        dgvPayed.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;
            //        if (dgvPayed.Rows[index].Cells["counts"].Value != null)
            //        {
            //            dgvPayed.Rows[index].Cells["cost"].Value = (int)(dgvPayed.Rows[index].Cells["counts"].Value) * (float)(dgvPayed.Rows[index].Cells["price"].Value);
            //        }

            //        base.GoodsFlag = 0;
            //    }
            //    if (base.StaffFlag == 1)
            //    {
            //        this.tbStaff.Text = base.StaffModel.Name;//赋值创建人员姓名
            //        base.StaffFlag = 0;
            //    }

            //}

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            if (flag != 1 && flag!=2 )
            {
                EMMS.View.staff.List list = new staff.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            dgvPayed.EndEdit();
            if (flag == 0 || flag == 3 || flag==4)//标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            {
                if (String.IsNullOrEmpty(tbStaff.Text))
                {
                    MessageBox.Show("请选择经手人员！");
                    return;
                }
            }
            orderModel.No = tbNo.Text;
            if (flag == 0 || flag == 3 || flag==4)//标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            {
                orderModel.FoundNo = base.StaffModel.No;//得到所选择的人员编码
            }
            else if (flag == 1)
            {
                orderModel.FoundNo = view.PayedModelSet.FoundNo;
            }
            orderModel.FoundTime = dtpTime.Value.ToShortDateString();
            orderModel.Remarks = tbRemarks.Text;
            if (flag == 0 || flag == 3 || flag==4)
            {
                orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;
            }
            else if (flag == 1)
            {
                orderModel.MakeNo = view.PayedModelSet.MakeNo;
            }
            orderModel.MakeTime = tbMakeTime.Text;
     
            //记录requisition，保持与之联系
            orderModel.Paying = tbPaying.Text;


            //很特殊的写法，不完善！
            if (dgvPayed.Rows[0].Cells["counts"].Value == null)
            {
                MessageBox.Show("请填写好相关信息！");
                return;
            }
            bool ended = true;//用来判断是否都已审核，若都已经审核，则设为true
            //标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            int total = 0;
            if (flag == 0)
            {
                total = dgvPayed.Rows.Count - 1;
            }
            else
            {
                total = dgvPayed.Rows.Count;
            }
            for (int i = 0; i < total ; i++)//得减一行
            {
                //bool ended = true;
                if (dgvPayed.Rows[i].Cells["no"].Value.ToString() != null)
                {
                    EMMS.Model.Payed_MaterialSet production = new Model.Payed_MaterialSet();
                    production.No = dgvPayed.Rows[i].Cells["no"].Value.ToString();
                    production.Payed = tbNo.Text;//记录联系
                    production.Material = dgvPayed.Rows[i].Cells["materialno"].Value.ToString();

                    try
                    {
                        production.Counts = int.Parse(dgvPayed.Rows[i].Cells["counts"].Value.ToString());
                       
                    }
                    catch
                    {
                        MessageBox.Show("请填写正确的进购数目！");
                    }
                    if (production.Counts<= 0)
                    {
                        MessageBox.Show("请填写正确的进购数目！");
                        return;
                    }
                    production.Cost = float.Parse(dgvPayed.Rows[i].Cells["cost"].Value.ToString());
                    if (dgvPayed.Rows[i].Cells["audited"].Value != null)
                    {
                        if (bool.Parse(dgvPayed.Rows[i].Cells["audited"].Value.ToString()) == true)
                        {
                            production.CheckNo = EMMS.Common.SavedInfo.StaffNo;
                            production.Audited = 1;//表示已审核

                            production.CheckTime = dgvPayed.Rows[i].Cells["checktime"].Value.ToString();
                        }
                        else
                        {
                            ended = false;
                        }
                    }
                    else
                    {
                        ended = false;
                    }
                    productionList.Add(production);
                }

            }
            //此处可用触发器代替
            if (ended == true)
            {
                orderModel.Audited = 1;//所有的都已审核
                //则该付款结算单结束
                orderModel.Ended = 1;
            }
            if (flag == 0 || flag == 3 || flag==4)//标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            {
                if (bll.Add(orderModel, productionList))
                {
                    if (ended == true)  //所有都已审核
                    {
                        MessageBox.Show("保存成功，且已审核，付款结算单结束！");
                        //修改进购单status="已付款" ，payed=1，应付款项单status="已付款"，ended=1 
                    }
                    else
                    {
                        MessageBox.Show("保存成功！但还未审核完！");
                        //修改进购单status="正在结算"，应付款项单status="正在结算"
                    }
                    Update(orderModel.Paying, ended);
                }
            }
            else if (flag == 1) //标志，0表示增加，1表示修改,2表示查看详情,3表示由付款结算单生成
            {
                if (bll.UpdateOrder(orderModel) && bll.UpdateGoods(productionList))
                {
                    if (ended == true)
                    {
                        MessageBox.Show("更新成功，已审核，付款结算单结束！");
                        //修改进购单status="已付款" ，payed=1，应付款项单status="已付款"，ended=1
                    }
                    else
                    {
                        MessageBox.Show("更新成功，但仍未审核完！");
                        //修改进购单status="正在结算"，应付款项单status="正在结算"
                    }
                    Update(orderModel.Paying, ended);
                }
            }
            this.Dispose();
        }
        private void Update(string no,bool audited)
        {
            EMMS.BLL.Paying_Order payingBll = new BLL.Paying_Order();
            EMMS.BLL.Entry_Order entryBll = new BLL.Entry_Order();

            EMMS.Model.Paying_OrderSet payingSet = new Model.Paying_OrderSet();
            EMMS.Model.Entry_OrderSet entrySet = new Model.Entry_OrderSet();
            List<EMMS.Model.Entry_MaterialSet> entryMaterialSetList = new List<Model.Entry_MaterialSet>();

            payingSet = payingBll.GetModel(no);
            entrySet = entryBll.GetModel(payingSet.Entry);
            if (audited)
            {
                payingSet.Status = "已结算";
                payingSet.Ended = 1;
                
                entrySet.Status = "已付款";
                entrySet.Payed = 1;
                //应该使对应的进购单相关的物料都设为已付款
                List<EMMS.Model.Entry_MaterialView> entryMateriaList = entryBll.GetModelListView1(entrySet.No);
                for (int i = 0; i < entryMateriaList.Count; i++)
                {
                    //entryMateriaList[i].Payed = true;
                    EMMS.Model.Entry_MaterialSet set = entryBll.GetModel1(entryMateriaList[i].No);
                    set.Payed = 1;
                    entryMaterialSetList.Add(set);
                }
            }
            else
            {
                payingSet.Status = "正在结算";
             
                entrySet.Status = "正在结算";
            }
            if (payingBll.UpdateOrder(payingSet) && entryBll.UpdateOrder(entrySet) && entryBll.UpdateGoods(entryMaterialSetList))
            {
               // MessageBox.Show("应付款项单以及进购单更新成功！");
            }
        }
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvStocking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDelivery_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //************************管理员或仓库经理***************************************//
            if (dgvPayed.Columns[e.ColumnIndex].Name == "audited")
            {

                if (bool.Parse(dgvPayed.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)//如果选择了审核
                {

                    if (dgvPayed.Rows[e.RowIndex].Cells["materialno"].Value == null)
                    {
                        dgvPayed.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        MessageBox.Show("请先选择物料！");
                        return;
                    }
                    if (dgvPayed.Rows[e.RowIndex].Cells["counts"].Value == null)
                    {
                        MessageBox.Show("请先填写进购数量！");
                        dgvPayed.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        return;
                    }
                    //dgvPayed.Rows[e.RowIndex].Cells["checkname"].Value = EMMS.Common.SavedInfo.StaffName;//

                    //dgvPayed.Rows[e.RowIndex].Cells["checkcounts"].Value = dgvPayed.Rows[e.RowIndex].Cells["counts"].Value;//

                    dgvPayed.Rows[e.RowIndex].Cells["checktime"].Value = DateTime.Now.ToShortDateString();
                }
                if (bool.Parse(dgvPayed.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == false)
                {
                    //dgvPayed.Rows[e.RowIndex].Cells["checkname"].Value = null;

                    //dgvPayed.Rows[e.RowIndex].Cells["checkcounts"].Value = null;

                    dgvPayed.Rows[e.RowIndex].Cells["checktime"].Value = null;
                }   
            }
            if (dgvPayed.Columns[e.ColumnIndex].Name == "counts")
            {
                //if (dgvPayed.Rows[e.RowIndex].Cells["materialname"].Value == null)
                //{
                //    MessageBox.Show("请先选择物料！");
                //    dgvPayed.Rows[e.RowIndex].Cells["counts"].Value = null;
                //    return;
                //}
                if (dgvPayed.Rows[e.RowIndex].Cells["counts"].Value != null)
                {
                    try
                    {
                        dgvPayed.Rows[e.RowIndex].Cells["cost"].Value = (int)(dgvPayed.Rows[e.RowIndex].Cells["counts"].Value) * (float)(dgvPayed.Rows[e.RowIndex].Cells["price"].Value);
                    }
                    catch
                    {
                        MessageBox.Show("请先选择物料！");
                        return;
                    }
                }
            }
            //************************管理员或仓库经理***************************************//
        }

        private void dgvDelivery_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void btnPaying_Click(object sender, EventArgs e)
        {
            if (flag == 0) //增加
            {
                EMMS.View.paying.Query query = new paying.Query();
                //
                query.GetParent(this);
                query.judge = true;
                query.Show();
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (EMMS.Common.SavedInfo.PayedFlag == 1)
            {
                tbPaying.Text = EMMS.Common.SavedInfo.PayingOrderSet.No;
                dgvPayed.DataSource = EMMS.Common.SavedInfo.PayedMaterialViewList;
                flag = 4;
            }
            else
            {
                MessageBox.Show("未检测到与之相关的应付款项单！");
                return;
            }
        }

        private void dgvPayed_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("输入格式不正确，请重新输入！");
            return;
        }
    }
}
