using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.entry
{
    public partial class Query : EMMS.Common.View
    {
        private EMMS.BLL.Entry_Order bll = new BLL.Entry_Order();
        private string flag = "";
        public bool judge;
        private EMMS.Common.View view;
        public bool judge1;
        public Query()
        {
            InitializeComponent();
            judge = false;
            judge1 = false;
        }

        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        private void BindData()
        {
            dgvQuery.DataSource = bll.GetModelListView(flag);
            dgvQuery.Columns[0].HeaderText = "进购编码";
            dgvQuery.Columns[1].HeaderText = "供应商";
            dgvQuery.Columns[2].HeaderText = "经手人";
            dgvQuery.Columns[3].HeaderText = "经手时间";
            dgvQuery.Columns[4].HeaderText = "状态";
            dgvQuery.Columns[5].HeaderText = "已付款";
            dgvQuery.Columns[6].HeaderText = "制表人";
            dgvQuery.Columns[7].HeaderText = "制表时间";
            dgvQuery.Columns[8].HeaderText = "备注";
            dgvQuery.Columns[9].HeaderText = "采购单编码";
            dgvQuery.Columns[9].Visible = false;
        }
        private void Query_Picking_Load(object sender, EventArgs e)
        {
            if (judge == false && judge1==false)
            {
                rbAll.Checked = true;
                BindData();
            }
            else if(judge==true)
            {
                rbUnPayed.Checked = true;
                flag = "0";
                panel1.Enabled = false;
                BindData();
            }
            else if (judge1 == true)
            {
                tsbPaying.Visible = false;
                rbAll.Checked = true;
                panel1.Enabled = false;
                BindData();
            }
        }

        private void Ended()
        {
            if (rbAll.Checked == true)
            {
                flag = "";
            }
            if (rbPayed.Checked == true)
            {
                flag = "1";
            }
            if (rbUnPayed.Checked == true)
            {
                flag = "0";
            }
            BindData();
        }
        private void rbEnded_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            rbAll.Checked = true;
            BindData();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                EMMS.Model.Entry_OrderView orderView = new Model.Entry_OrderView();
                List<EMMS.Model.Entry_MaterialView> materialView = new List<Model.Entry_MaterialView>();

                orderView.No = row.Cells["no"].Value.ToString();
                orderView.SupplierName = row.Cells["suppliername"].Value.ToString();
                orderView.FoundName = row.Cells["foundname"].Value.ToString();
                orderView.FoundTime = row.Cells["foundtime"].Value.ToString();
                orderView.Status = row.Cells["status"].Value.ToString();
                orderView.Payed = bool.Parse(row.Cells["payed"].Value.ToString());
                orderView.MakeName = row.Cells["makename"].Value.ToString();
                orderView.MakeTime = row.Cells["maketime"].Value.ToString();
                orderView.Remarks = row.Cells["remarks"].Value.ToString();
                orderView.Purchasing = row.Cells["purchasing"].Value.ToString();

                materialView = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                base.EntryModelView = orderView;
                base.EntryModelFlag = 1;
                base.EntryModelViewList = materialView;

                EMMS.View.entry.Entry_Order pickingView = new Entry_Order();
                pickingView.GetParent(this);
                pickingView.flag = 1;
                pickingView.ShowDialog();
            }
        }

        private void tsbDelivery_Click(object sender, EventArgs e)
        {
            if (dgvQuery.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            foreach (DataGridViewRow row in dgvQuery.SelectedRows)
            {
                if (row.Cells[4].Value.ToString().Trim().Equals("已生成付款结算单"))
                {
                    MessageBox.Show("已生成付款结算单，无需再生成！");
                    return;
                }
                if (row.Cells[4].Value.ToString().Trim().Equals("已付款"))
                {
                    MessageBox.Show("已付款，无需再生成！");
                    return;
                }
                if (bool.Parse(row.Cells[5].Value.ToString()) == true)
                {
                    MessageBox.Show("该进购单已经付款，无需再生成！");
                    return;
                }
                EMMS.Model.Entry_OrderSet entrySet= bll.GetModel(row.Cells["no"].Value.ToString());
                base.EntryModelSet = entrySet;// 让应付款结算单去读取

                List<EMMS.Model.Entry_MaterialView> entryList = new List<Model.Entry_MaterialView>();
                entryList = bll.GetModelListView1(entrySet.No); //得到与之相关的物料信息
                List<EMMS.Model.Paying_MaterialView> payingViewList = new List<Model.Paying_MaterialView>();
                EMMS.BLL.Goods goodsBll=new BLL.Goods();
                for (int i = 0; i < entryList.Count; i++)
                {
                    EMMS.Model.Paying_MaterialView payingView = new Model.Paying_MaterialView();
                    EMMS.Model.GoodsSet goods=goodsBll.GetModel(entryList[i].MaterialNo);
                    //payingView.No;
                    payingView.MaterialName = entryList[i].MaterialName;
                    payingView.Unit = entryList[i].Unit;
                    payingView.Counts = entryList[i].Counts;
                    payingView.Price =goods.Price;
                    payingView.PriceUnit =goods.PriceUnit;
                    payingView.Cost = payingView.Counts * payingView.Price;
                    payingView.MaterialNo = entryList[i].MaterialNo;
                    payingViewList.Add(payingView);
                }

                base.PayingModelFlag = 1;
                base.PayingModelViewList = payingViewList;
                EMMS.View.paying.Paying_Order view = new paying.Paying_Order();
                view.GetParent(this);
                view.flag = 2;
                view.Show();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e) //增加
        {
            EMMS.View.entry.Entry_Order view = new Entry_Order();
            view.Show();
        }

        private void dgvQuery_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (judge == true || judge1 == true )
            {
                view.EntryModelSet = bll.GetModel(dgvQuery.Rows[e.RowIndex].Cells["no"].Value.ToString());
                view.EntryModelFlag = 1;
                this.Dispose();
            }
        }

        private void rbAll_Click(object sender, EventArgs e)
        {
           
        }

        private void rbPayed_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            Ended();
        }

        private void Query_Activated(object sender, EventArgs e)
        {
            if (judge == false)
            {
                rbAll.Checked = true;
                BindData();
            }
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvQuery);
        }
    }
}
