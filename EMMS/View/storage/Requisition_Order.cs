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
    public partial class Requisition_Order : EMMS.Common.View
    {
        private EMMS.BLL.Requisition_Order bll = new BLL.Requisition_Order();//
        //private EMMS.BLL.Storage_Order bll1 = new BLL.Storage_Order();//库存更新
        private EMMS.Model.Requisition_OrderSet orderModel = new Model.Requisition_OrderSet();//
        private List<EMMS.Model.Requisition_MaterialSet> productionList = new List<Model.Requisition_MaterialSet>();//
        private int index;
        public int flag; //标志，0表示增加，1表示修改,2表示查看详情,3表示由盘点盘生成，出库单后生成
        private EMMS.Common.View view;

        public Requisition_Order()
        {
            InitializeComponent();
            index = -1;
            flag = 0;

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
            dgvRequisition.Columns.Add(c1);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "物料名称";
            btn1.DataPropertyName = "MaterialName";
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Name = "materialname";
            btn1.ToolTipText = "请选择物品";
            dgvRequisition.Columns.Add(btn1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "数量";
            c2.DataPropertyName = "Counts";
            c2.Name = "counts";
            c2.ValueType = typeof(string);
            dgvRequisition.Columns.Add(c2);

            //DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            //c7.HeaderText = "审核人员姓名";
            //c7.Name = "checkname";
            //c7.ValueType = typeof(string);
            //dgvRequisition.Columns.Add(c7);
            //dgvRequisition.Columns["checkname"].Visible = false;

            DataGridViewCheckBoxColumn c8 = new DataGridViewCheckBoxColumn();
            c8.HeaderText = "审核";
            c8.DataPropertyName = "Audited";
            c8.Name = "audited";
            c8.ValueType = typeof(bool);
            dgvRequisition.Columns.Add(c8);
            dgvRequisition.Columns["audited"].Visible = false;

            DataGridViewTextBoxColumn c9 = new DataGridViewTextBoxColumn();
            c9.HeaderText = "审核数量";
            c9.DataPropertyName = "CheckCounts";
            c9.Name = "checkcounts";
            c9.ValueType = typeof(string);
            dgvRequisition.Columns.Add(c9);
            dgvRequisition.Columns["checkcounts"].Visible = false;

            DataGridViewTextBoxColumn c10 = new DataGridViewTextBoxColumn();
            c10.HeaderText = "审核时间";
            c10.DataPropertyName = "CheckTime";
            c10.Name = "checktime";
            c10.ValueType = typeof(string);
            dgvRequisition.Columns.Add(c10);
            dgvRequisition.Columns["checktime"].Visible = false;

            DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
            c11.HeaderText = "编码";
            c11.DataPropertyName = "MaterialNo";
            c11.Name = "materialno";
            c11.ValueType = typeof(string);
            dgvRequisition.Columns.Add(c11);
            //让其隐藏
            dgvRequisition.Columns["materialno"].Visible = false;
        }
        private void Stocking_Order_Load(object sender, EventArgs e)
        {
            Init();
            if (flag == 0)//增加
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
            else if (flag == 1) //审核
            {
                //btnDepartment.Enabled = false;
                //btnStaff.Enabled = false;
                dtpTime.Enabled = false;
                if (view.RequisitionModelViewFlag == 1)
                {
                    dgvRequisition.DataSource=view.RequisitionModelViewList;
                }
            }
            else if(flag==3)
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
                dgvRequisition.DataSource = view.RequisitionModelViewList;
            }
            else if (flag == 2) //查看详情
            {
                tsbSave.Visible = false;
                tbMakeName.ReadOnly = true;
                tbMakeTime.ReadOnly = true;
                tbNo.ReadOnly = true;
                tbRemarks.ReadOnly = true;
                tbStaff.ReadOnly = true;
                dtpTime.Enabled = false;
                //btnStaff.Enabled = false;
                //btnDepartment.Enabled = false;
                dgvRequisition.ReadOnly = true;

                //所有人都可以查看
                //dgvRequisition.Columns["checkname"].Visible = true;
                dgvRequisition.Columns["audited"].Visible = true;
                dgvRequisition.Columns["checkcounts"].Visible = true;
                dgvRequisition.Columns["checktime"].Visible = true;
                //dgvPlan.Columns["materialname"].ReadOnly = true;
  
                tbNo.Text = view.RequisitionModelView.No;
                tbDepartment.Text = view.RequisitionModelView.DepartmentName;
                tbStaff.Text = view.RequisitionModelView.FoundName;
                tbRemarks.Text = view.RequisitionModelView.Remarks;
                dtpTime.Value = DateTime.Parse(view.RequisitionModelView.FoundTime);
                tbMakeName.Text = view.RequisitionModelView.MakeName;
                tbMakeTime.Text = view.RequisitionModelView.MakeTime;

                dgvRequisition.DataSource = view.RequisitionModelViewList;
                //int rowsCount = view.RequisitionModelViewList.Count;
                //List<EMMS.Model.Requisition_MaterialView> list = new List<Model.Requisition_MaterialView>();
                //list = view.RequisitionModelViewList;
                //for (int i = 0; i < rowsCount; i++)
                //{
                //    dgvRequisition.Rows[i].Cells["no"].Value = list[i].No;
                //    dgvRequisition.Rows[i].Cells["materialno"].Value = list[i].MaterialNo;
                //    dgvRequisition.Rows[i].Cells["materialname"].Value = list[i].MaterialName;
                //    dgvRequisition.Rows[i].Cells["counts"].Value = list[i].Counts;
                //    //dgvRequisition.Rows[i].Cells["checkname"].Value = list[i].CheckName;
                //    dgvRequisition.Rows[i].Cells["audited"].Value = list[i].Audited;
                //    dgvRequisition.Rows[i].Cells["checkcounts"].Value = list[i].CheckCounts;
                //    dgvRequisition.Rows[i].Cells["checktime"].Value = list[i].CheckTime;
                //}
                dgvRequisition.ReadOnly = true;
            }
            if (flag != 2)
            {
                if (EMMS.Common.SavedInfo.Role == 0 || EMMS.Common.SavedInfo.Role == 2)
                {
                    //dgvRequisition.Columns["checkname"].Visible = true;
                    dgvRequisition.Columns["audited"].Visible = true;
                    dgvRequisition.Columns["checkcounts"].Visible = true;
                    dgvRequisition.Columns["checktime"].Visible = true;
                }
            }
            //dgvPlan.Columns["audited"]. = false;
        }

        private void dgvStocking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvRequisition.EndEdit();
        }

        private void dgvStocking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (flag != 2)
            {
                if (dgvRequisition.Columns[e.ColumnIndex].Name == "materialname")
                {
                    EMMS.View.goods.List list = new goods.List();
                    list.GetParent(this);
                    list.typename = "物料";
                    list.ShowDialog();
                }
                if (dgvRequisition.Columns[e.ColumnIndex].Name == "audited")
                {
                    if (dgvRequisition.Rows[e.RowIndex].Cells["audited"].Value == null)
                    {
                        dgvRequisition.Rows[e.RowIndex].Cells["audited"].Value = true;
                    }
                    else if (bool.Parse(dgvRequisition.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == true)
                    {
                        dgvRequisition.Rows[e.RowIndex].Cells["audited"].Value = false;
                        this.Validate();
                    }
                    else if (bool.Parse(dgvRequisition.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == false)
                    {
                        dgvRequisition.Rows[e.RowIndex].Cells["audited"].Value = true;
                        this.Validate();
                    }
                }
            }
        }

        private void Stocking_Order_Activated(object sender, EventArgs e)
        {
            if (flag == 0)//增加的时候才需要填写
            {
                if (base.GoodsFlag == 1)
                {
                    dgvRequisition.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
                    if (base.GoodsModel.No != null)
                    {
                        EMMS.Model.Requisition_MaterialSet productionmodel = new Model.Requisition_MaterialSet();
                        dgvRequisition.Rows[index].Cells["no"].Value = productionmodel.No;//
                        dgvRequisition.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;

                    }
                    base.GoodsFlag = 0;
                }
            }
            if(flag==0 || flag==3)
            {
                if (base.StaffFlag == 1)
                {
                    this.tbStaff.Text = base.StaffModel.Name;//赋值创建人员姓名
                    base.StaffFlag = 0;
                }
                if (base.DepartmentFlag == 1)
                {
                    tbDepartment.Text = base.DepartmentModel.Name;
                    base.DepartmentFlag = 0;
                }
            }

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            if (flag != 1 && flag!=2) //不是审核也不是查看
            {
                EMMS.View.staff.List list = new staff.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            dgvRequisition.EndEdit();
            if (flag == 0 || flag==3)
            {
                if (String.IsNullOrEmpty(tbStaff.Text))
                {
                    MessageBox.Show("请选择经手人员！");
                    return;
                }
            }
            if (flag == 0 || flag == 3)
            {
                if (String.IsNullOrEmpty(tbDepartment.Text))
                {
                    MessageBox.Show("请选择目标单位！");
                    return;
                }
            }
            orderModel.No = tbNo.Text;
            if (flag == 0 || flag == 3)
            {
                orderModel.FoundNo = base.StaffModel.No;//得到所选择的人员编码
            }
            else if (flag == 1 )
            {
                orderModel.FoundNo = view.RequisitionModelSet.FoundNo;
            }
            orderModel.FoundTime = dtpTime.Value.ToShortDateString();
            orderModel.Remarks = tbRemarks.Text;
            if (flag == 0 || flag == 3)
            {
                orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;
            }
            else if (flag == 1)
            {
                orderModel.MakeNo = view.RequisitionModelSet.MakeNo;
            }
            orderModel.MakeTime = tbMakeTime.Text;
            if (flag == 0 || flag == 3)
            {
                orderModel.Department = base.DepartmentModel.No;
            }
            else if (flag == 1)
            {
                orderModel.Department = view.RequisitionModelSet.Department;  
            }
   
            if (dgvRequisition.Rows[0].Cells["counts"].Value == null)
            {
                MessageBox.Show("请填写好相关信息！");
                return;
            }
            bool ended = true;//用来判断是否都已审核，若都已经审核，则设为true
            int total = 0;
            if (flag == 0)  //增加
            {
                total = dgvRequisition.Rows.Count - 1;
            }
            else   //审核,生成
            {
                total = dgvRequisition.Rows.Count;
            }
            for (int i = 0; i < total; i++)//得减一行
            {
                //bool ended = true;
                if (dgvRequisition.Rows[i].Cells["no"].Value.ToString() != null)
                {
                   
                    EMMS.Model.Requisition_MaterialSet production = new Model.Requisition_MaterialSet();
                    production.No = dgvRequisition.Rows[i].Cells["no"].Value.ToString();
                    production.Requisition = tbNo.Text;//记录联系
                    production.Material = dgvRequisition.Rows[i].Cells["materialno"].Value.ToString();

                    try
                    {
                        production.Counts = int.Parse(dgvRequisition.Rows[i].Cells["counts"].Value.ToString()); 
                    }
                    catch
                    {
                        MessageBox.Show("请填写正确的请购数目！");
                        return;
                    }
                    if (production.Counts<= 0)
                    {
                        MessageBox.Show("请填写正确的请购数目！");
                        return;
                    }
                    if (dgvRequisition.Rows[i].Cells["audited"].Value != null)
                    {
                        if (bool.Parse(dgvRequisition.Rows[i].Cells["audited"].Value.ToString()) == true)
                        {
                            production.CheckNo = EMMS.Common.SavedInfo.StaffNo;
                            production.Audited = 1;//表示已审核
                            production.CheckCounts = int.Parse(dgvRequisition.Rows[i].Cells["checkcounts"].Value.ToString());
                            production.CheckTime = dgvRequisition.Rows[i].Cells["checktime"].Value.ToString();
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
            }
            if (flag == 0 || flag == 3)
            {
                if (bll.Add(orderModel, productionList))
                {
                    if (ended == true)
                    {
                        MessageBox.Show("保存成功，且已审核！");
                        SaveInfo();
                    }
                    else
                    {
                        MessageBox.Show("保存成功！但还未审核完！");
                    }
                }
            }
            else if (flag == 1)
            {
                if (bll.UpdateOrder(orderModel) && bll.UpdateGoods(productionList))
                {
                    if (ended == true)
                    {
                        MessageBox.Show("更新成功，已审核！");
                        SaveInfo();
                    }
                    else
                    {
                        MessageBox.Show("更新成功，但仍未审核完！");
                    }
                }
            }

            this.Dispose();
        }

        private void SaveInfo()
        {
            //试着去保存到SaveInfo中
            EMMS.Common.SavedInfo.RequisitionOrderSet = bll.GetModel(tbNo.Text); //
            //EMMS.Common.SavedInfo.RequisitionFlag = 1;
            List<EMMS.Model.Requisition_MaterialView> requisitionViewList = bll.GetModelListView1(tbNo.Text);
            List<EMMS.Model.Purchasing_MaterialView> purchasingViewList = new List<Model.Purchasing_MaterialView>();
            for (int i = 0; i < requisitionViewList.Count; i++)
            {
                EMMS.Model.Purchasing_MaterialView view = new Model.Purchasing_MaterialView();
                //view.No
                view.MaterialName = requisitionViewList[i].MaterialName;
                view.Counts = requisitionViewList[i].Counts;
                view.MaterialNo = requisitionViewList[i].MaterialNo;
                purchasingViewList.Add(view);
            }
            EMMS.Common.SavedInfo.PurchasingFlag = 1;
            EMMS.Common.SavedInfo.PurchasingMaterialViewList = purchasingViewList;
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
            if (dgvRequisition.Columns[e.ColumnIndex].Name == "audited")
            {

                if (bool.Parse(dgvRequisition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)//如果选择了审核
                {

                    if (dgvRequisition.Rows[e.RowIndex].Cells["materialno"].Value == null)
                    {
                        MessageBox.Show("请先选择产品！");
                        dgvRequisition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        return;
                    }
                    if (dgvRequisition.Rows[e.RowIndex].Cells["counts"].Value == null)
                    {
                        MessageBox.Show("请先填写请购数量！");
                        dgvRequisition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        return;
                    }
                    //dgvRequisition.Rows[e.RowIndex].Cells["checkname"].Value = EMMS.Common.SavedInfo.StaffName;//

                    dgvRequisition.Rows[e.RowIndex].Cells["checkcounts"].Value = dgvRequisition.Rows[e.RowIndex].Cells["counts"].Value;//

                    dgvRequisition.Rows[e.RowIndex].Cells["checktime"].Value = DateTime.Now.ToShortDateString();
                }
                if (bool.Parse(dgvRequisition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == false)
                {
                    //dgvRequisition.Rows[e.RowIndex].Cells["checkname"].Value = null;

                    dgvRequisition.Rows[e.RowIndex].Cells["checkcounts"].Value = null;

                    dgvRequisition.Rows[e.RowIndex].Cells["checktime"].Value = null;
                }
            }
            //************************管理员或仓库经理***************************************//
        }

        private void dgvDelivery_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            if (flag != 1 && flag != 2)
            {
                EMMS.View.staff.Department view = new staff.Department();
                view.GetParent(this);
                view.flag = true;
                view.ShowDialog();
            }
        }
    }
}
