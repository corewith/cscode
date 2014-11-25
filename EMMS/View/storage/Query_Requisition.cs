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
    public partial class Query_Requisition : EMMS.Common.View
    {
        private EMMS.BLL.Requisition_Order bll = new BLL.Requisition_Order();
        private string flag = "";
        private string flag1 = "";
        private int role;
        public bool judge;
        private EMMS.Common.View view;
        //Predicate<EMMS.Model.Picking_MaterialView> match;
        public Query_Requisition()
        {
            InitializeComponent();
            judge = false;
            role = EMMS.Common.SavedInfo.Role;
        }

        public void GetParent(EMMS.Common.View view)
        {
            this.view=view;
        }
        private void BindData()
        {
            List<EMMS.Model.Requisition_OrderView> modelList = new List<Model.Requisition_OrderView>();
            modelList = bll.GetModelListView(flag, flag1);
            dgvQuery.DataSource = modelList;
            dgvQuery.Columns[0].HeaderText = "请购编码";
            dgvQuery.Columns[1].HeaderText = "目标单位";
            dgvQuery.Columns[2].HeaderText = "经手人";
            dgvQuery.Columns[3].HeaderText = "产生时间";
            dgvQuery.Columns[4].HeaderText = "已审核";
            dgvQuery.Columns[5].HeaderText = "采购状态";
            dgvQuery.Columns[6].HeaderText = "已结束";
            dgvQuery.Columns[7].HeaderText = "制表人员姓名";
            dgvQuery.Columns[8].HeaderText = "制表时间";
            dgvQuery.Columns[9].HeaderText = "备注";
            dgvQuery.ReadOnly = true;
            //dgvQuery.AutoSize = true;
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
            EMMS.View.storage.Requisition_Order view = new Requisition_Order();
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
                if (bool.Parse(row.Cells[4].Value.ToString()) == true)
                {
                    MessageBox.Show("该请购单已经审核！");
                    return;
                }
                if (bool.Parse(row.Cells[6].Value.ToString()) == true)
                {
                    MessageBox.Show("该请购单已经结束，无需审核！");
                    return;
                }
                EMMS.View.storage.Requisition_Order view = new Requisition_Order();
                view.tbNo.Text = row.Cells["no"].Value.ToString();
                view.tbDepartment.Text = row.Cells["departmentname"].Value.ToString();
                view.tbStaff.Text = row.Cells["foundname"].Value.ToString();
                view.dtpTime.Value = DateTime.Parse(row.Cells["foundtime"].Value.ToString());
                view.tbRemarks.Text = row.Cells["remarks"].Value.ToString();
                view.tbMakeName.Text = row.Cells["makename"].Value.ToString();
                view.tbMakeTime.Text = row.Cells["maketime"].Value.ToString();
                base.RequisitionModelSet = bll.GetModel(row.Cells["no"].Value.ToString());//得到一个model,记录下来

                List<EMMS.Model.Requisition_MaterialView> productionList = new List<Model.Requisition_MaterialView>();
                productionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());//得到plan_production

                base.RequisitionModelViewList = productionList;
                base.RequisitionModelViewFlag = 1;

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
                if (bool.Parse(row.Cells[6].Value.ToString()) == true)
                {
                    MessageBox.Show("该请购单已经结束，无需指定结束！");
                    return;
                }
                EMMS.Model.Requisition_OrderSet model = new Model.Requisition_OrderSet();
                model = bll.GetModel(row.Cells["no"].Value.ToString());//得到一个model,记录下来 
                int index = dgvQuery.SelectedRows[0].Index;

                if (MessageBox.Show("确定要指定结束此请购单吗？", "确定指定结束", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
                //((DataGridViewCheckBoxCell)row.Cells[4]).Value = true;
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

        private void tsbDetail_Click(object sender, EventArgs e)
        {
            if (dgvQuery.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvQuery.SelectedRows)
            {
                EMMS.Model.Requisition_OrderView orderModel = new Model.Requisition_OrderView();
                orderModel.No = row.Cells["no"].Value.ToString();
                orderModel.DepartmentName = row.Cells["departmentname"].Value.ToString();
                orderModel.FoundName = row.Cells["foundname"].Value.ToString();
                orderModel.FoundTime = row.Cells["foundtime"].Value.ToString();
                orderModel.Audited = bool.Parse(row.Cells["audited"].Value.ToString());
                orderModel.Status = row.Cells[4].Value.ToString();
                orderModel.Ended = bool.Parse(row.Cells["ended"].Value.ToString());
                orderModel.MakeName = row.Cells["makename"].Value.ToString();
                orderModel.MakeTime = row.Cells["maketime"].Value.ToString();
                orderModel.Remarks = row.Cells["remarks"].Value.ToString();

                List<EMMS.Model.Requisition_MaterialView> productionList = new List<Model.Requisition_MaterialView>();
                productionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                base.RequisitionModelView = orderModel;
                base.RequisitionModelViewList = productionList;

                EMMS.View.storage.Requisition_Order planView = new Requisition_Order();
                planView.flag = 2;
                planView.GetParent(this);
                planView.Show();
            }
        }

        private void tsbPurchasing_Click(object sender, EventArgs e)
        {
            if (dgvQuery.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            foreach (DataGridViewRow row in dgvQuery.SelectedRows)
            {
                if (bool.Parse(row.Cells[4].Value.ToString()) == false)
                {
                    MessageBox.Show("该请购单还未审核完，不能采购！");
                    return;
                }
                if (row.Cells[5].Value.ToString().Trim().Equals("正在采购"))
                {
                    MessageBox.Show("正在采购，无需再采购！");
                    return;
                }
                if (row.Cells[5].Value.ToString().Trim().Equals("已进购未入库"))
                {
                    MessageBox.Show("已进购，无需再采购！");
                    return;
                }
                if (row.Cells[5].Value.ToString().Trim().Equals("已入库"))
                {
                    MessageBox.Show("已入库，无需再采购！");
                }
                if (bool.Parse(row.Cells[6].Value.ToString()) == true)
                {
                    MessageBox.Show("该请购单已经结束，无需采购！");
                    return;
                }
                 //////////////////////////////////////////////////////////
                base.RequisitionModelSet = bll.GetModel(row.Cells["no"].Value.ToString()); //让采购单读取
                base.RequisitionModelViewFlag = 1;
                List<EMMS.Model.Requisition_MaterialView> requisitionViewList = bll.GetModelListView1(row.Cells["no"].Value.ToString());
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
                base.PurchasingModelViewFlag = 1;
                base.PurchasingModelViewList = purchasingViewList;
                //采购界面
                EMMS.View.purchasing.Purchasing_Order purchasingView = new purchasing.Purchasing_Order();
                purchasingView.GetParent(this);
                purchasingView.flag = 3;//设置flag表示是从请购单过来
                purchasingView.Show();
                this.Dispose();
            }
        }

        private void Query_Requisition_Load(object sender, EventArgs e)
        {
            tsbAdd.Visible = false;
            tsbCheck.Visible = false;
            tsbEnd.Visible = false;
            tsbPurchasing.Visible = false;
            
            if (judge == false)
            {
                rbAll.Checked = true;
                rbAll1.Checked = true;
                BindData();
            }
            else
            {
                rbAudited.Checked = true;
                flag = "1";
                //panel1.Visible = false;
                panel1.Enabled = false;

                rbUnended.Checked = true;
                flag = "0";
                //panel2.Visible = false;
                panel2.Enabled = false;

                BindData();
            }
            if (role == 0)
            {
                tsbAdd.Visible = true;
                tsbCheck.Visible = true;
                tsbEnd.Visible = true;
                tsbPurchasing.Visible = true;
            }
            else if (role == 2)
            {
                tsbAdd.Visible = true;
                tsbCheck.Visible = true;
                tsbEnd.Visible = true;
            }
            else if (role == 3 || role == 31)
            {
                tsbPurchasing.Visible = true;
            }
            else
            {
                tsbAdd.Visible = true;
                tsbEnd.Visible = true;
            }

        }

        private void dgvQuery_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (judge == true)
            {
                view.RequisitionModelViewFlag = 1;
                view.RequisitionModelSet = bll.GetModel(dgvQuery.Rows[e.RowIndex].Cells["no"].Value.ToString());
                this.Dispose();
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

        private void rbAll1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            //Ended();
        }

        private void rbAll1_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void rbUnended_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvQuery);
        }
    }
}

