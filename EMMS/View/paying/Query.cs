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
    public partial class Query : EMMS.Common.View
    {
        private EMMS.BLL.Paying_Order bll = new BLL.Paying_Order();
        private string flag = "";
        public bool judge;
        private EMMS.Common.View view;
        private int role;
        public Query()
        {
            InitializeComponent();
            judge = false;
            role = EMMS.Common.SavedInfo.Role;
        }
        public  void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        private void BindData()
        {
            dgvPaying.DataSource = bll.GetModelListView(flag);
            dgvPaying.Columns[0].HeaderText = "应付款项单编码";
            dgvPaying.Columns[1].HeaderText = "目标单位";
            dgvPaying.Columns[2].HeaderText = "经手人";
            dgvPaying.Columns[3].HeaderText = "经手时间";
            dgvPaying.Columns[4].HeaderText = "状态";
            dgvPaying.Columns[5].HeaderText = "已结束";
            dgvPaying.Columns[6].HeaderText = "制表人";
            dgvPaying.Columns[7].HeaderText = "制表时间";
            dgvPaying.Columns[8].HeaderText = "备注";
            dgvPaying.Columns[9].HeaderText = "进购单编码";
            dgvPaying.Columns[9].Visible = false;
        }
        private void Query_Load(object sender, EventArgs e)
        {
            tsbAdd.Visible = false;
            tsbPayed.Visible = false;

            if (judge == false)
            {
                rbAll.Checked = true;
                BindData();
            }
            else
            {
                tsbPayed.Visible = true;
                rbUnended.Checked = true;
                flag = "0";//未结束
                panel1.Enabled = false;
                BindData();
            }
            if (role == 0)
            {
                tsbAdd.Visible = true;
                tsbPayed.Visible = true;
            }
            else if (role == 3 || role == 31)
            {
                tsbAdd.Visible = true;
            }
            else if (role == 4 || role == 41)
            {
                tsbPayed.Visible = true;
            }
        }
        private void Ended()
        { 
             if (rbAll.Checked == true)
            {
                flag = "";
            }
            if (rbUnended.Checked == true)
            {
                flag = "0";
            }
            if (rbEnded.Checked == true)
            {
                flag = "1";
            }
            BindData();
        }
        private void rbEnded_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            if (judge == false)
            {
                rbAll.Checked = true;
                BindData();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbDetail_Click(object sender, EventArgs e)
        {
            if (dgvPaying.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvPaying.SelectedRows)
            {
                EMMS.Model.Paying_OrderView orderView = new Model.Paying_OrderView();
                List<EMMS.Model.Paying_MaterialView> materialView = new List<Model.Paying_MaterialView>();

                orderView.No = row.Cells["no"].Value.ToString();
                orderView.DepartmentName = row.Cells["departmentname"].Value.ToString();
                orderView.FoundName = row.Cells["foundname"].Value.ToString();
                orderView.FoundTime = row.Cells["foundtime"].Value.ToString();
                orderView.Status = row.Cells["status"].Value.ToString();
                orderView.Ended = bool.Parse(row.Cells["ended"].Value.ToString());
                orderView.MakeName = row.Cells["makename"].Value.ToString();
                orderView.MakeTime = row.Cells["maketime"].Value.ToString();
                orderView.Remarks = row.Cells["remarks"].Value.ToString();
                orderView.Entry = row.Cells["entry"].Value.ToString();

                materialView = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                base.PayingModelFlag = 1;
                base.PayingModelView = orderView;
                base.PayingModelViewList = materialView;

                EMMS.View.paying.Paying_Order pickingView = new Paying_Order();
                pickingView.GetParent(this);
                pickingView.flag = 1;
                pickingView.ShowDialog();
            }
        }
        private void tsbPayed_Click(object sender, EventArgs e)
        {
            if (dgvPaying.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvPaying.SelectedRows)
            {
                if (row.Cells["status"].Value.ToString().Trim().Equals("正在结算"))
                {
                    MessageBox.Show("正在结算，请等待！");
                    return;
                }
                if (row.Cells["status"].Value.ToString().Trim().Equals("已结算"))
                {
                    MessageBox.Show("已结算，无需生成！");
                    return;
                }
                List<EMMS.Model.Payed_MaterialView> payedViewList = new List<Model.Payed_MaterialView>();
                List<EMMS.Model.Paying_MaterialView> payingViewList = new List<Model.Paying_MaterialView>();
                EMMS.Model.Paying_OrderSet payingSet = new Model.Paying_OrderSet();
                payingSet = bll.GetModel(row.Cells["no"].Value.ToString());

                base.PayingModelFlag = 1;
                base.PayingModelSet = payingSet;

                payingViewList = bll.GetModelListView1(row.Cells["no"].Value.ToString());
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

                base.PayedModelFlag = 1;
                base.PayedModelViewList = payedViewList;

                EMMS.View.payed.Payed_Order payed = new payed.Payed_Order();
                payed.GetParent(this);
                payed.flag = 3;
                payed.Show();
            }
            this.Dispose();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void rbUnended_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            EMMS.View.paying.Paying_Order view = new Paying_Order();
            view.Show();
        }

        private void dgvPaying_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (judge == true)
            {
                view.PayingModelFlag = 1;
                view.PayingModelSet = bll.GetModel(dgvPaying.Rows[e.RowIndex].Cells["no"].Value.ToString());
                this.Dispose();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvPaying);
        }

        private void Query_Activated(object sender, EventArgs e)
        {
            if (judge == false)
            {
                rbAll.Checked = true;
                BindData();
            }
        }
    }
}
