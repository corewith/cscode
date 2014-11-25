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
    public partial class Query_Delivery : EMMS.Common.View
    {
        private EMMS.BLL.Delivery_Order bll = new BLL.Delivery_Order();
        private string flag = "";
        private string flag1 = "";
        private int role;
        //Predicate<EMMS.Model.Picking_MaterialView> match;
        public Query_Delivery()
        {
            InitializeComponent();
            role = EMMS.Common.SavedInfo.Role;
        }

        private void BindData()
        {
            List<EMMS.Model.Delivery_OrderView> modelList = new List<Model.Delivery_OrderView>();
            modelList = bll.GetModelListView(flag, flag1);
            dgvQuery.DataSource = modelList;
            dgvQuery.Columns[0].HeaderText = "出库单编码";
            dgvQuery.Columns[1].HeaderText = "目标单位";
            dgvQuery.Columns[2].HeaderText = "仓库名称";
            dgvQuery.Columns[3].HeaderText = "经手人";
            dgvQuery.Columns[4].HeaderText = "经手时间";
            dgvQuery.Columns[5].HeaderText = "已审核";
            dgvQuery.Columns[6].HeaderText = "已结束";
            dgvQuery.Columns[7].HeaderText = "制表人";
            dgvQuery.Columns[8].HeaderText = "制表时间";
            dgvQuery.Columns[9].HeaderText = "备注";
            dgvQuery.Columns[10].HeaderText = "对应的领料单编码";
            dgvQuery.ReadOnly = true;
            //dgvQuery.AutoSize = true;
        }
        private void Query_Delivery_Load(object sender, EventArgs e)
        {
            rbAll.Checked = true;
            rbAll1.Checked = true;
            BindData();
            if (role == 0 || role == 2)
            { }
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
            EMMS.View.storage.Delivery_Order view = new Delivery_Order();
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
                if (bool.Parse(row.Cells[5].Value.ToString()) == true)
                {
                    MessageBox.Show("该生产计划单已经审核！");
                    return;
                }
                if (bool.Parse(row.Cells[6].Value.ToString()) == true)
                {
                    MessageBox.Show("该生产计划单已经结束，无需审核！");
                    return;
                }
                EMMS.View.storage.Delivery_Order view = new Delivery_Order();
                view.tbNo.Text = row.Cells["no"].Value.ToString();
                view.tbDepartment.Text = row.Cells["departmentname"].Value.ToString();
                view.tbWarehouse.Text = row.Cells["warehousename"].Value.ToString();
                view.tbPicking.Text = row.Cells["picking"].Value.ToString();
                view.tbStaff.Text = row.Cells["foundname"].Value.ToString();
                view.dtpTime.Value = DateTime.Parse(row.Cells["foundtime"].Value.ToString());
                view.tbRemarks.Text = row.Cells["remarks"].Value.ToString();
                view.tbMakeName.Text = row.Cells["makename"].Value.ToString();
                view.tbMakeTime.Text = row.Cells["maketime"].Value.ToString();

                base.DeliveryModelSet = bll.GetModel(row.Cells["no"].Value.ToString());//得到一个model,记录下来

                List<EMMS.Model.Delivery_MaterialView> materialList = new List<Model.Delivery_MaterialView>();
                materialList = bll.GetModelListView1(row.Cells["no"].Value.ToString());//得到deliver_material

                base.DeliveryViewList = materialList;
                base.DeliveryFlag = 1;
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
            rbAll.Checked = true;
            rbAll1.Checked = true;
            BindData();
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
                EMMS.Model.Delivery_OrderView orderModel = new Model.Delivery_OrderView();
                orderModel.No = row.Cells["no"].Value.ToString();
                orderModel.DepartmentName = row.Cells["departmentname"].Value.ToString();
                orderModel.WarehouseName = row.Cells["warehousename"].Value.ToString();
                orderModel.FoundName = row.Cells["foundname"].Value.ToString();
                orderModel.FoundTime = row.Cells["foundtime"].Value.ToString();
                orderModel.Audited = bool.Parse(row.Cells["audited"].Value.ToString());
                orderModel.Ended = bool.Parse(row.Cells["ended"].Value.ToString());
                orderModel.MakeName = row.Cells["makename"].Value.ToString();
                orderModel.MakeTime = row.Cells["maketime"].Value.ToString();
                orderModel.Remarks = row.Cells["remarks"].Value.ToString();
                orderModel.Picking = row.Cells["picking"].Value.ToString();

                List<EMMS.Model.Delivery_MaterialView> materialList = new List<Model.Delivery_MaterialView>();
                materialList = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                base.DeliveryOrderView = orderModel;
                base.DeliveryViewList = materialList;

                EMMS.View.storage.Delivery_Order planView = new Delivery_Order();
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

