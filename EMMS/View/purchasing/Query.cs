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
    public partial class Query : EMMS.Common.View
    {
        private EMMS.BLL.Purchasing_Order bll = new BLL.Purchasing_Order();
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
            List<EMMS.Model.Purchasing_OrderView> modelList = new List<Model.Purchasing_OrderView>();
            modelList = bll.GetModelListView(flag, flag1);
            dgvQuery.DataSource = modelList;
            dgvQuery.Columns[0].HeaderText = "采购单编码";
            dgvQuery.Columns[1].HeaderText = "供应商";
            dgvQuery.Columns[2].HeaderText = "经手人";
            dgvQuery.Columns[3].HeaderText = "产生时间";
            dgvQuery.Columns[4].HeaderText = "已审核";
            dgvQuery.Columns[5].HeaderText = "进购状态";
            dgvQuery.Columns[6].HeaderText = "已结束";
            dgvQuery.Columns[7].HeaderText = "制表人员姓名";
            dgvQuery.Columns[8].HeaderText = "制表时间";
            dgvQuery.Columns[9].HeaderText = "备注";
            dgvQuery.Columns[10].HeaderText = "对应的请购单编码";
            dgvQuery.ReadOnly = true;
            //dgvQuery.AutoSize = true;
        }
        private void Query_Load(object sender, EventArgs e)
        {
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
                flag1 = "0";
                //panel2.Visible = false;
                panel2.Enabled = false;
                BindData();
            }
            if (role == 0 || role == 3) //采购经理
            {

            }
            else
            {
                tsbCheck.Visible = false;
                //tsbEnd.Visible = false;
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            EMMS.View.purchasing.Purchasing_Order view = new Purchasing_Order();
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
                    MessageBox.Show("该采购单已经审核！");
                    return;
                }
                if (bool.Parse(row.Cells[6].Value.ToString()) == true)
                {
                    MessageBox.Show("该采购单已经结束，无需审核！");
                    return;
                }
                EMMS.View.purchasing.Purchasing_Order view = new Purchasing_Order();
                view.tbNo.Text = row.Cells["no"].Value.ToString();
                view.tbSupplier.Text = row.Cells["suppliername"].Value.ToString();
                view.tbStaff.Text = row.Cells["foundname"].Value.ToString();
                view.dtpTime.Value = DateTime.Parse(row.Cells["foundtime"].Value.ToString());
                view.tbRemarks.Text = row.Cells["remarks"].Value.ToString();
                view.tbMakeName.Text = row.Cells["makename"].Value.ToString();
                view.tbMakeTime.Text = row.Cells["maketime"].Value.ToString();
                view.tbRequisition.Text = row.Cells["requisition"].Value.ToString();
                base.PurchasingModelSet = bll.GetModel(row.Cells["no"].Value.ToString());//得到一个model,记录下来

                List<EMMS.Model.Purchasing_MaterialView> productionList = new List<Model.Purchasing_MaterialView>();
                productionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());//得到plan_production

                base.PurchasingModelViewList = productionList;
                base.PurchasingModelViewFlag = 1;
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
                    MessageBox.Show("该采购单已经结束，无需指定结束！");
                    return;
                }
                EMMS.Model.Purchasing_OrderSet model = new Model.Purchasing_OrderSet();
                model = bll.GetModel(row.Cells["no"].Value.ToString());//得到一个model,记录下来  
                int index = dgvQuery.SelectedRows[0].Index;

                if (MessageBox.Show("确定要指定结束此采购单吗？", "确定指定结束", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
                //同时应该修改请购单状态
                EMMS.BLL.Requisition_Order requisitionBll = new BLL.Requisition_Order();
                EMMS.Model.Requisition_OrderSet requisition = requisitionBll.GetModel(row.Cells[10].Value.ToString());
                requisition.Status = "未采购";
                requisitionBll.UpdateOrder(requisition);
                //if (requisitionBll.UpdateOrder(requisiti
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
                EMMS.Model.Purchasing_OrderView orderModel = new Model.Purchasing_OrderView();
                orderModel.No = row.Cells["no"].Value.ToString();
                orderModel.SupplierName = row.Cells["suppliername"].Value.ToString();
                orderModel.FoundName = row.Cells["foundname"].Value.ToString();
                orderModel.FoundTime = row.Cells["foundtime"].Value.ToString();
                orderModel.Audited = bool.Parse(row.Cells["audited"].Value.ToString());
                orderModel.Status = row.Cells[4].Value.ToString();
                orderModel.Ended = bool.Parse(row.Cells["ended"].Value.ToString());
                orderModel.MakeName = row.Cells["makename"].Value.ToString();
                orderModel.MakeTime = row.Cells["maketime"].Value.ToString();
                orderModel.Remarks = row.Cells["remarks"].Value.ToString();
                orderModel.Requisition = row.Cells["requisition"].Value.ToString();

                List<EMMS.Model.Purchasing_MaterialView> productionList = new List<Model.Purchasing_MaterialView>();
                productionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                base.PurchasingModelView = orderModel; 
                base.PurchasingModelViewList = productionList;

                EMMS.View.purchasing.Purchasing_Order planView = new Purchasing_Order();
                planView.flag = 2;
                planView.GetParent(this);
                planView.Show();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvQuery_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (judge == true)
            {
                view.PurchasingModelViewFlag = 1;
                view.PurchasingModelSet = bll.GetModel(dgvQuery.Rows[e.RowIndex].Cells["no"].Value.ToString());
                this.Dispose();
            }
        }

        private void rbUnaudited_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked == true)
            {
                flag = "";
            }
            else if (rbAudited.Checked == true)
            {
                flag = "1";
            }
            else if (rbUnaudited.Checked == true)
            {
                flag = "0";
            }
            BindData();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
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
        private void rbEnded_CheckedChanged(object sender, EventArgs e)
        {
            Ended();   
        }
        private void rbAudited_CheckedChanged(object sender, EventArgs e)
        {
            Audited();
        }
        private void Audited()
        {
            if (rbAll.Checked == true)
            {
                flag = "";
            }
            else if (rbAudited.Checked == true)
            {
                flag = "1";
            }
            else if (rbUnaudited.Checked == true)
            {
                flag = "0";
            }
            BindData();
        }
        private void Ended()
        {
            if (rbAll1.Checked == true)
            {
                flag1 = "";
            }
            else if (rbEnded.Checked == true)
            {
                flag1 = "1";
            }
            else if (rbUnended.Checked == true)
            {
                flag1 = "0";
            }
            BindData();
        }
    }
}

