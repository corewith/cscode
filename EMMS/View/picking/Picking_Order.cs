using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.picking
{
    public partial class Picking_Order :EMMS.Common.View
    {
        private EMMS.Common.View view;
        private EMMS.Model.Picking_OrderSet orderModel = new Model.Picking_OrderSet();
        private List<EMMS.Model.Picking_MaterialSet> materialList = new List<Model.Picking_MaterialSet>();
        private EMMS.BLL.Picking_Order bll = new BLL.Picking_Order();
        public int flag;
        //flag=0;表示增加;flag=1;表示查看详情
        public Picking_Order()
        {
            InitializeComponent();
            flag = 0;
        }
        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        private void BindData()
        {
            dgvPicking.DataSource = view.PMList;
            dgvPicking.Columns[0].HeaderText = "编码";
            dgvPicking.Columns[1].HeaderText = "物料名称";
            dgvPicking.Columns[2].HeaderText = "领料数量";
            dgvPicking.Columns[3].HeaderText = "单位";
            dgvPicking.Columns[4].HeaderText = "物料编码";
            dgvPicking.Columns[4].Visible = false;
            dgvPicking.Columns[5].HeaderText = "出库数量";
            dgvPicking.Columns[5].Visible = false;
        }
        private void Picking_Order_Load(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                BindData();
                tbNo.Text = orderModel.No;
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
                //设置领料单与生产计划单的联系
                if (view.PlanFlag == 1)
                    orderModel.PlanNo = view.PlanModelSet.No;
            }
            else if (flag == 1)
            {
                //groupBox1.Enabled = false;
                //groupBox2.Enabled = false;
                tbNo.ReadOnly = true;
                tbDepartment.ReadOnly = true;
                tbFoundName.ReadOnly = true;
                tbRemarks.ReadOnly = true;
                //btnDepartment.Enabled = false;
                //btnFoundName.Enabled = false;
                dtpTime.Enabled = false;
                tsbSave.Visible = false;

                tbNo.Text = view.PickingModelView.No;
                tbDepartment.Text = view.PickingModelView.DepartmentName;
                tbFoundName.Text = view.PickingModelView.FoundName;
                dtpTime.Value = DateTime.Parse(view.PickingModelView.FoundTime);
                tbRemarks.Text = view.PickingModelView.Remarks;
                tbMakeName.Text = view.PickingModelView.MakeName;
                tbMakeTime.Text = view.PickingModelView.MakeTime;

                dgvPicking.DataSource = view.PMList;
                dgvPicking.Columns[0].HeaderText = "编码";
                dgvPicking.Columns[1].HeaderText = "物料名称";
                dgvPicking.Columns[2].HeaderText = "领料数量";
                dgvPicking.Columns[3].HeaderText = "单位";
                dgvPicking.Columns[4].HeaderText = "物料编码";
                dgvPicking.Columns[4].Visible = false;
                dgvPicking.Columns[5].HeaderText = "出库数量";
                dgvPicking.Columns[5].Visible = false;
                
            }
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
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
            if (flag != 1)
            {
                EMMS.View.staff.List list = new staff.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbFoundName.Text))
            {
                MessageBox.Show("经手人还未填写！");
                return;
            }
            if (string.IsNullOrEmpty(tbDepartment.Text))
            {
                MessageBox.Show("目标单位还未填写！");
                return;
            }
            orderModel.FoundNo = base.StaffModel.No;
            orderModel.FoundTime = dtpTime.Value.ToShortDateString();
            orderModel.Department = base.DepartmentModel.No;
            orderModel.Remarks = tbRemarks.Text;
            orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;
            orderModel.MakeTime = tbMakeTime.Text;

            foreach (DataGridViewRow row in dgvPicking.Rows)
            {
                EMMS.Model.Picking_MaterialSet set = new Model.Picking_MaterialSet();
                set.No = row.Cells["no"].Value.ToString();
                set.Picking = tbNo.Text;
                set.Material = row.Cells["materialno"].Value.ToString();
                set.Counts = int.Parse(row.Cells["counts"].Value.ToString());
                //set.Stocking
                materialList.Add(set);
            }
            if (bll.Add(orderModel, materialList))
            {
                MessageBox.Show("保存成功！");
                //修改生产计划单状态status
                EMMS.BLL.Plan_Order planBll=new BLL.Plan_Order();
                EMMS.Model.Plan_OrderSet planSet = new Model.Plan_OrderSet(); 
                planSet=planBll.GetModel(orderModel.PlanNo);
                planSet.Status = "正在领料中";
                planBll.UpdateOrder(planSet);
                //if (planBll.UpdateOrder(planSet))
                //{
                //    MessageBox.Show("生产计划单更新成功！");
                //}

                //得到所选领料单
                EMMS.Model.Picking_OrderSet pickingSet = bll.GetModel(orderModel.No);
                //得到物料信息
                List<EMMS.Model.Picking_MaterialView> pickingViewList = bll.GetModelListView1(pickingSet.No);
                BindingList<EMMS.Model.Delivery_MaterialView> deliveryViewList = new BindingList<Model.Delivery_MaterialView>();
                for (int i = 0; i < pickingViewList.Count; i++)
                {
                    EMMS.Model.Delivery_MaterialView deliveryView = new Model.Delivery_MaterialView();
                    //deliveryView.No
                    deliveryView.MaterialName = pickingViewList[i].MaterialName;
                    deliveryView.Need = pickingViewList[i].Counts;
                    //deliveryView.Stocking//出库
                    //
                    deliveryView.MaterialNo = pickingViewList[i].MaterialNo;
                    deliveryViewList.Add(deliveryView);
                }

                EMMS.Common.SavedInfo.DeliveryFlag = 1;
                EMMS.Common.SavedInfo.PickingOrderSet = pickingSet;
                EMMS.Common.SavedInfo.DeliveryMaterialViewBindingList = deliveryViewList;

                this.Dispose();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Picking_Order_Activated(object sender, EventArgs e)
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
}
