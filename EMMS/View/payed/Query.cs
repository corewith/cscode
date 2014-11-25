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
    public partial class Query : EMMS.Common.View
    {
        private EMMS.BLL.Payed_Order bll = new BLL.Payed_Order();
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
            List<EMMS.Model.Payed_OrderView> modelList = new List<Model.Payed_OrderView>();
            modelList = bll.GetModelListView(flag, flag1);
            dgvQuery.DataSource = modelList;
            dgvQuery.Columns[0].HeaderText = "付款结算单编码";
            dgvQuery.Columns[1].HeaderText = "经手人";
            dgvQuery.Columns[2].HeaderText = "产生时间";
            dgvQuery.Columns[3].HeaderText = "已审核";
            dgvQuery.Columns[4].HeaderText = "已结束";
            dgvQuery.Columns[5].HeaderText = "制表人员姓名";
            dgvQuery.Columns[6].HeaderText = "制表时间";
            dgvQuery.Columns[7].HeaderText = "备注";
            dgvQuery.Columns[8].HeaderText = "对应的应付款项单编码";
            dgvQuery.ReadOnly = true;
            //dgvQuery.AutoSize = true;
        }
        private void Query_Load(object sender, EventArgs e)
        {
            rbAll.Checked = true;
            rbAll1.Checked = true;
            BindData();
            if (role == 0 || role == 4)
            {
                tsbCheck.Visible = true;
            }
            else 
            {
                tsbCheck.Visible = false;
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
            EMMS.View.payed.Payed_Order view = new Payed_Order();
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
                if (bool.Parse(row.Cells[3].Value.ToString()) == true)
                {
                    MessageBox.Show("该付款结算单已经审核！");
                    return;
                }
                if (bool.Parse(row.Cells[4].Value.ToString()) == true)
                {
                    MessageBox.Show("该付款结算单已经结束，无需审核！");
                    return;
                }
                EMMS.View.payed.Payed_Order view = new Payed_Order();
                view.tbNo.Text = row.Cells["no"].Value.ToString();
                view.tbStaff.Text = row.Cells["foundname"].Value.ToString();
                view.dtpTime.Value = DateTime.Parse(row.Cells["foundtime"].Value.ToString());
                view.tbRemarks.Text = row.Cells["remarks"].Value.ToString();
                view.tbMakeName.Text = row.Cells["makename"].Value.ToString();
                view.tbMakeTime.Text = row.Cells["maketime"].Value.ToString();
                view.tbPaying.Text = row.Cells["paying"].Value.ToString();
                base.PayedModelSet = bll.GetModel(row.Cells["no"].Value.ToString());//得到一个model,记录下来

                List<EMMS.Model.Payed_MaterialView> productionList = new List<Model.Payed_MaterialView>();
                productionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());//得到

                base.PayedModelViewList = productionList;
                base.PayedModelFlag = 1;
                view.flag = 1;
                view.GetParent(this);
                view.ShowDialog();
            }
        }


        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            rbAll.Checked = true;
            rbAll1.Checked = true;
            BindData();
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
                EMMS.Model.Payed_OrderView orderModel = new Model.Payed_OrderView();
                orderModel.No = row.Cells["no"].Value.ToString();
                
                orderModel.FoundName = row.Cells["foundname"].Value.ToString();
                orderModel.FoundTime = row.Cells["foundtime"].Value.ToString();
                orderModel.Audited = bool.Parse(row.Cells["audited"].Value.ToString());
                
                orderModel.Ended = bool.Parse(row.Cells["ended"].Value.ToString());
                orderModel.MakeName = row.Cells["makename"].Value.ToString();
                orderModel.MakeTime = row.Cells["maketime"].Value.ToString();
                orderModel.Remarks = row.Cells["remarks"].Value.ToString();
                orderModel.Paying = row.Cells["paying"].Value.ToString();

                List<EMMS.Model.Payed_MaterialView> productionList = new List<Model.Payed_MaterialView>();
                productionList = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                base.PayedModelView = orderModel;
                base.PayedModelViewList = productionList;

                EMMS.View.payed.Payed_Order planView = new Payed_Order();
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

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvQuery);
        }
    }
}

