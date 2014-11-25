using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.purchasing
{
    public partial class Purchasing_Order : EMMS.Common.View
    {
        private EMMS.BLL.Purchasing_Order bll = new BLL.Purchasing_Order();//
        //private EMMS.BLL.Storage_Order bll1 = new BLL.Storage_Order();//库存更新
        private EMMS.Model.Purchasing_OrderSet orderModel = new Model.Purchasing_OrderSet();//
        private List<EMMS.Model.Purchasing_MaterialSet> productionList = new List<Model.Purchasing_MaterialSet>();//
        private int index;
        public int flag; //标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
        private EMMS.Common.View view;

        public Purchasing_Order()
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
            c1.Name = "no";
            c1.DataPropertyName = "No";
            c1.ValueType = typeof(string);
            c1.ReadOnly = true;
            dgvPurchasing.Columns.Add(c1);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "物料名称";
            btn1.DataPropertyName = "MaterialName";
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Name = "materialname";
            btn1.ToolTipText = "请选择物料";
            dgvPurchasing.Columns.Add(btn1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "数量";
            c2.DataPropertyName = "Counts";
            c2.Name = "counts";
            c2.ValueType = typeof(string);
            dgvPurchasing.Columns.Add(c2);

            //DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            //c7.HeaderText = "审核人员姓名";
            //c7.Name = "checkname";
            //c7.ValueType = typeof(string);
            //dgvPurchasing.Columns.Add(c7);
            //dgvPurchasing.Columns["checkname"].Visible = false;

            DataGridViewCheckBoxColumn c8 = new DataGridViewCheckBoxColumn();
            c8.HeaderText = "审核";
            c8.DataPropertyName = "Audited";
            c8.Name = "audited";
            c8.ValueType = typeof(bool);
            dgvPurchasing.Columns.Add(c8);
            dgvPurchasing.Columns["audited"].Visible = false;

            DataGridViewTextBoxColumn c9 = new DataGridViewTextBoxColumn();
            c9.HeaderText = "审核数量";
            c9.DataPropertyName = "CheckCounts";
            c9.Name = "checkcounts";
            c9.ValueType = typeof(string);
            dgvPurchasing.Columns.Add(c9);
            dgvPurchasing.Columns["checkcounts"].Visible = false;

            DataGridViewTextBoxColumn c10 = new DataGridViewTextBoxColumn();
            c10.HeaderText = "审核时间";
            c10.DataPropertyName = "CheckTime";
            c10.Name = "checktime";
            c10.ValueType = typeof(string);
            dgvPurchasing.Columns.Add(c10);
            dgvPurchasing.Columns["checktime"].Visible = false;

            DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
            c11.HeaderText = "物料编码";
            c11.DataPropertyName = "MaterialNo";
            c11.Name = "materialno";
            c11.ValueType = typeof(string);
            dgvPurchasing.Columns.Add(c11);
            //让其隐藏
            dgvPurchasing.Columns["materialno"].Visible = false;
        }
        private void Purchasing_Order_Load(object sender, EventArgs e)
        {
            Init();
            if (flag == 0)//标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
            if (flag == 3)//标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
                if (view.RequisitionModelViewFlag == 1)
                {
                    tbRequisition.Text = view.RequisitionModelSet.No; //请购单联系
                }
                if (view.PurchasingModelViewFlag == 1)
                {
                    dgvPurchasing.DataSource = view.PurchasingModelViewList;
                }
            }
            else if (flag == 1) //审核
            {
                //btnSupplier.Enabled = false;
                //btnStaff.Enabled = false;
                dtpTime.Enabled = false;

                if (view.PurchasingModelViewFlag == 1)
                {
                    dgvPurchasing.DataSource = view.PurchasingModelViewList;
                }
                for (int i = 0; i < dgvPurchasing.Columns.Count; i++)
                {
                    if (i == 3 || i == 4)
                    {
                        dgvPurchasing.Columns[i].ReadOnly = false;
                    }
                    else
                    {
                        dgvPurchasing.Columns[i].ReadOnly = true;
                    }
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
                //btnSupplier.Enabled = false;
                //btnRequisition.Enabled = false;
                //btnStaff.Enabled = false;
                dgvPurchasing.ReadOnly = true;

                //所有人都可以查看
                //dgvPurchasing.Columns["checkname"].Visible = true;
                dgvPurchasing.Columns["audited"].Visible = true;
                dgvPurchasing.Columns["checkcounts"].Visible = true;
                dgvPurchasing.Columns["checktime"].Visible = true;
                //dgvPlan.Columns["materialname"].ReadOnly = true;

                tbNo.Text = view.PurchasingModelView.No;
                tbSupplier.Text = view.PurchasingModelView.SupplierName;
                tbStaff.Text = view.PurchasingModelView.FoundName;
                tbRemarks.Text = view.PurchasingModelView.Remarks;
                dtpTime.Value = DateTime.Parse(view.PurchasingModelView.FoundTime);
                tbMakeName.Text = view.PurchasingModelView.MakeName;
                tbMakeTime.Text = view.PurchasingModelView.MakeTime;
                tbRequisition.Text = view.PurchasingModelView.Requisition;

                dgvPurchasing.DataSource = view.PurchasingModelViewList;
                //int rowsCount = view.PurchasingModelViewList.Count;
                //List<EMMS.Model.Purchasing_MaterialView> list = new List<Model.Purchasing_MaterialView>();
                //list = view.PurchasingModelViewList;
                //for (int i = 0; i < rowsCount; i++)
                //{
                //    dgvPurchasing.Rows[i].Cells["no"].Value = list[i].No;
                //    dgvPurchasing.Rows[i].Cells["materialno"].Value = list[i].MaterialNo;
                //    dgvPurchasing.Rows[i].Cells["materialname"].Value = list[i].MaterialName;
                //    dgvPurchasing.Rows[i].Cells["counts"].Value = list[i].Counts;
                //    dgvPurchasing.Rows[i].Cells["checkname"].Value = list[i].CheckName;
                //    dgvPurchasing.Rows[i].Cells["audited"].Value = list[i].Audited;
                //    dgvPurchasing.Rows[i].Cells["checkcounts"].Value = list[i].CheckCounts;
                //    dgvPurchasing.Rows[i].Cells["checktime"].Value = list[i].CheckTime;
                //}
                
                dgvPurchasing.ReadOnly = true;
            }
            if (flag != 2)
            {
                if (EMMS.Common.SavedInfo.Role == 0 || EMMS.Common.SavedInfo.Role == 3)
                {
                    //dgvPurchasing.Columns["checkname"].Visible = true;
                    dgvPurchasing.Columns["audited"].Visible = true;
                    dgvPurchasing.Columns["checkcounts"].Visible = true;
                    dgvPurchasing.Columns["checktime"].Visible = true;
                }
            }
        }

        private void dgvStocking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvPurchasing.EndEdit();
        }

        private void dgvStocking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (flag == 0)
            {
                if (dgvPurchasing.Columns[e.ColumnIndex].Name == "materialname")
                {
                    EMMS.View.goods.List list = new goods.List();
                    list.GetParent(this);
                    list.ShowDialog();
                }
            }
            if (flag != 2)
            {
                if (dgvPurchasing.Columns[e.ColumnIndex].Name == "audited")
                {
                    if (dgvPurchasing.Rows[e.RowIndex].Cells["audited"].Value == null)
                    {
                        dgvPurchasing.Rows[e.RowIndex].Cells["audited"].Value = true;
                    }
                    else if (bool.Parse(dgvPurchasing.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == true)
                    {
                        dgvPurchasing.Rows[e.RowIndex].Cells["audited"].Value = false;
                        this.Validate();
                    }
                    else if (bool.Parse(dgvPurchasing.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == false)
                    {
                        dgvPurchasing.Rows[e.RowIndex].Cells["audited"].Value = true;
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
                    dgvPurchasing.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
                    if (base.GoodsModel.No != null)
                    {
                        EMMS.Model.Purchasing_MaterialSet productionmodel = new Model.Purchasing_MaterialSet();
                        dgvPurchasing.Rows[index].Cells["no"].Value = productionmodel.No;//
                        dgvPurchasing.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;

                    }
                    base.GoodsFlag = 0;
                }
                if (base.StaffFlag == 1)
                {
                    this.tbStaff.Text = base.StaffModel.Name;//赋值创建人员姓名
                    base.StaffFlag = 0;
                }
                if (base.SupplierFlag == 1)
                {
                    tbSupplier.Text = base.SupplierModel.Name;
                    base.SupplierFlag = 0;
                }
                if (base.RequisitionModelViewFlag == 1)
                {
                    tbRequisition.Text = base.RequisitionModelSet.No;
                    base.RequisitionModelViewFlag = 0;
                }
            }
            if (flag == 3) //标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            { 
                if (base.GoodsFlag == 1)
                {
                    dgvPurchasing.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
                    if (base.GoodsModel.No != null)
                    {
                        EMMS.Model.Purchasing_MaterialSet productionmodel = new Model.Purchasing_MaterialSet();
                        dgvPurchasing.Rows[index].Cells["no"].Value = productionmodel.No;//
                        dgvPurchasing.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;

                    }
                    base.GoodsFlag = 0;
                }
                if (base.StaffFlag == 1)
                {
                    this.tbStaff.Text = base.StaffModel.Name;//赋值创建人员姓名
                    base.StaffFlag = 0;
                }
                if (base.SupplierFlag == 1)
                {
                    tbSupplier.Text = base.SupplierModel.Name;
                    base.SupplierFlag = 0;
                }
            }

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
            dgvPurchasing.EndEdit();
            if (flag == 0 || flag == 3)//标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            {
                if (String.IsNullOrEmpty(tbStaff.Text))
                {
                    MessageBox.Show("请选择经手人员！");
                    return;
                }
            }
            orderModel.No = tbNo.Text;
            if (flag == 0 || flag==3)
            {
                orderModel.FoundNo = base.StaffModel.No;//得到所选择的人员编码
            }
            else if (flag == 1) //标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            {
                orderModel.FoundNo = view.PurchasingModelSet.FoundNo;
            }
            orderModel.FoundTime = dtpTime.Value.ToShortDateString();
            orderModel.Remarks = tbRemarks.Text;
            if (flag == 0 || flag == 3)//标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            {
                orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;
            }
            else if (flag == 1)//标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            {
                orderModel.MakeNo = view.PurchasingModelSet.MakeNo;
            }
            orderModel.MakeTime = tbMakeTime.Text;
            if (flag == 0 || flag==3)
            {
                orderModel.Supplier = base.SupplierModel.No;
            }
            else if (flag == 1)
            {
                orderModel.Supplier = view.PurchasingModelSet.Supplier;
            }
            //记录requisition，保持与之联系
            orderModel.Requisition = tbRequisition.Text;


            //很特殊的写法，不完善！
            if (dgvPurchasing.Rows[0].Cells["counts"].Value == null)
            {
                MessageBox.Show("请填写好相关信息！");
                return;
            }
            bool ended = true;//用来判断是否都已审核，若都已经审核，则设为true
            //标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            int total = 0;
            if (flag == 0)
            {
                total = dgvPurchasing.Rows.Count - 1;
            }
            else//标志，1表示修改,2表示查看详情,3表示由请购单生成
            {
                total = dgvPurchasing.Rows.Count;
            }
            for (int i = 0; i < total; i++)//
            {
                //bool ended = true;
                if (dgvPurchasing.Rows[i].Cells["no"].Value.ToString() != null)
                {
                
                    EMMS.Model.Purchasing_MaterialSet production = new Model.Purchasing_MaterialSet();
                    production.No = dgvPurchasing.Rows[i].Cells["no"].Value.ToString();
                    production.Purchasing = tbNo.Text;//记录联系
                    production.Material = dgvPurchasing.Rows[i].Cells["materialno"].Value.ToString();

                    try
                    {
                        production.Counts = int.Parse(dgvPurchasing.Rows[i].Cells["counts"].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("请填写正确的采购数目！");
                    }
                    if (int.Parse(dgvPurchasing.Rows[i].Cells["counts"].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("请填写正确的采购数目！");
                        return;
                    }
                    if (dgvPurchasing.Rows[i].Cells["audited"].Value != null)
                    {
                        if (bool.Parse(dgvPurchasing.Rows[i].Cells["audited"].Value.ToString()) == true)
                        {
                            production.CheckNo = EMMS.Common.SavedInfo.StaffNo;
                            production.Audited = 1;//表示已审核
                            production.CheckCounts = int.Parse(dgvPurchasing.Rows[i].Cells["checkcounts"].Value.ToString());
                            production.CheckTime = dgvPurchasing.Rows[i].Cells["checktime"].Value.ToString();
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
            if (flag == 0 || flag == 3)//标志，1表示修改,2表示查看详情,3表示由请购单生成
            {
                if (bll.Add(orderModel, productionList))
                {
                    if (ended == true)
                    {
                        MessageBox.Show("保存成功，且已审核！");
                    }
                    else
                    {
                        MessageBox.Show("保存成功！但还未审核完！");
                    }
                    ChangeStatus(orderModel.Requisition);
                }
            }
            else if (flag == 1)
            {
                if (bll.UpdateOrder(orderModel) && bll.UpdateGoods(productionList))
                {
                    if (ended == true)
                    {
                        MessageBox.Show("更新成功，已审核！");
                    }
                    else
                    {
                        MessageBox.Show("更新成功，但仍未审核完！");
                    }
                    ChangeStatus(orderModel.Requisition);
                }
            }
            
            this.Dispose();
        }

        private void ChangeStatus(string no)
        {
            //修改请购单状态
            EMMS.BLL.Requisition_Order requisitionBll = new BLL.Requisition_Order();
            EMMS.Model.Requisition_OrderSet requisition = requisitionBll.GetModel(no);
            requisition.Status = "正在采购";
            requisitionBll.UpdateOrder(requisition);
            //if (requisitionBll.UpdateOrder(requisition))
            //{
            //    MessageBox.Show("请购单状态修改成功！");
            //}
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
            if (dgvPurchasing.Columns[e.ColumnIndex].Name == "audited")
            {

                if (bool.Parse(dgvPurchasing.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)//如果选择了审核
                {

                    if (dgvPurchasing.Rows[e.RowIndex].Cells["materialno"].Value == null)
                    {
                        MessageBox.Show("请先选择产品！");
                        dgvPurchasing.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        return;
                    }
                    if (dgvPurchasing.Rows[e.RowIndex].Cells["counts"].Value == null)
                    {
                        MessageBox.Show("请先填写采购数量！");
                        dgvPurchasing.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        return;
                    }
                    //dgvPurchasing.Rows[e.RowIndex].Cells["checkname"].Value = EMMS.Common.SavedInfo.StaffName;//

                    dgvPurchasing.Rows[e.RowIndex].Cells["checkcounts"].Value = dgvPurchasing.Rows[e.RowIndex].Cells["counts"].Value;//

                    dgvPurchasing.Rows[e.RowIndex].Cells["checktime"].Value = DateTime.Now.ToShortDateString();
                }
                if (bool.Parse(dgvPurchasing.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == false)
                {
                    //dgvPurchasing.Rows[e.RowIndex].Cells["checkname"].Value = null;

                    dgvPurchasing.Rows[e.RowIndex].Cells["checkcounts"].Value = null;

                    dgvPurchasing.Rows[e.RowIndex].Cells["checktime"].Value = null;
                }
            }
            //************************管理员或仓库经理***************************************//
        }

        private void dgvDelivery_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            //标志，0表示增加，1表示修改,2表示查看详情,3表示由请购单生成
            if (flag != 1 && flag!=2 )
            {
                EMMS.View.purchasing.Supplier view = new Supplier();
                view.GetParent(this);
                view.flag = true;
                view.ShowDialog();
            }
        }

        private void btnRequisition_Click(object sender, EventArgs e)
        {
            if (flag == 0) //增加
            {
                EMMS.View.storage.Query_Requisition query = new storage.Query_Requisition();
                //
                query.GetParent(this);
                query.judge = true;
                query.Show();
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (EMMS.Common.SavedInfo.PurchasingFlag == 1)
            {
                tbRequisition.Text = EMMS.Common.SavedInfo.RequisitionOrderSet.No;
                dgvPurchasing.DataSource = EMMS.Common.SavedInfo.PurchasingMaterialViewList;
                flag = 3;
            }
            else
            {
                MessageBox.Show("未检测到与之相关的请购单！");
                return;
            }
        }

   
    }
}
