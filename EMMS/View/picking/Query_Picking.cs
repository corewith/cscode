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
    public partial class Query_Picking : EMMS.Common.View
    {
        private EMMS.BLL.Picking_Order bll = new BLL.Picking_Order();
        private string flag = "";
        private EMMS.Common.View view;
        public bool judge;
        private int role;
        public Query_Picking()
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
            dgvPicking.DataSource = bll.GetModelListView(flag);
            dgvPicking.Columns[0].HeaderText = "领料单编码";
            dgvPicking.Columns[1].HeaderText = "目标单位";
            dgvPicking.Columns[2].HeaderText = "经手人";
            dgvPicking.Columns[3].HeaderText = "经手时间";
            dgvPicking.Columns[4].HeaderText = "状态";
            dgvPicking.Columns[5].HeaderText = "已结束";
            dgvPicking.Columns[6].HeaderText = "制表人";
            dgvPicking.Columns[7].HeaderText = "制表时间";
            dgvPicking.Columns[8].HeaderText = "备注";
            dgvPicking.Columns[9].HeaderText = "对应计划单编码";
            dgvPicking.Columns[9].Visible = false;
        }
        private void Query_Picking_Load(object sender, EventArgs e)
        {
            tsbDelivery.Visible=false;
            tsbInventory.Visible = false;

            if (judge == false) //生产部门
            {
                rbAll.Checked = true;
                BindData();
            }
            else //仓库部门
            {
                tsbDelivery.Visible = true;
                rbUnended.Checked = true;
                //panel1.Visible = false;
                panel1.Enabled = false;
                flag = "0"; //未结束的
                BindData();
            }
            if (role == 0 || role == 2 || role == 21)
            {
                tsbDelivery.Visible = true;
                tsbInventory.Visible = true;
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
            if (dgvPicking.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach(DataGridViewRow row in dgvPicking.SelectedRows)
            {
                EMMS.Model.Picking_OrderView orderView = new Model.Picking_OrderView();
                List<EMMS.Model.Picking_MaterialView> materialView = new List<Model.Picking_MaterialView>();

                orderView.No = row.Cells["no"].Value.ToString();
                orderView.DepartmentName = row.Cells["departmentname"].Value.ToString();
                orderView.FoundName = row.Cells["foundname"].Value.ToString();
                orderView.FoundTime = row.Cells["foundtime"].Value.ToString();
                orderView.Status = row.Cells["status"].Value.ToString();
                orderView.Ended=bool.Parse(row.Cells["ended"].Value.ToString());
                orderView.MakeName = row.Cells["makename"].Value.ToString();
                orderView.MakeTime = row.Cells["maketime"].Value.ToString();
                orderView.Remarks = row.Cells["remarks"].Value.ToString();
                orderView.PlanNo = row.Cells["planno"].Value.ToString();

                materialView = bll.GetModelListView1(row.Cells["no"].Value.ToString());

                base.PickingModelView = orderView;
                base.PMList = materialView;

                EMMS.View.picking.Picking_Order pickingView = new Picking_Order();
                pickingView.GetParent(this);
                pickingView.flag = 1;
                pickingView.ShowDialog();
                //this.Dispose();
            }
        }

        private void tsbDelivery_Click(object sender, EventArgs e)
        {
            if (dgvPicking.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            
            foreach (DataGridViewRow row in dgvPicking.SelectedRows)
            {
                if (row.Cells["status"].Value.ToString().Trim().Equals("已出库"))
                {
                    MessageBox.Show("已出库，无需再出库！");
                    return;
                }
                
                if (row.Cells["status"].Value.ToString().Trim().Equals("正在出库"))
                {
                    MessageBox.Show("正在出库，请等待！");
                    return;
                }
                if (bool.Parse(row.Cells["ended"].Value.ToString()) == true)
                {
                    MessageBox.Show("该领料单已经结束，无需再出库！");
                    return;
                }

                //得到所选领料单
                EMMS.Model.Picking_OrderSet pickingSet = bll.GetModel(row.Cells["no"].Value.ToString());
                //得到物料信息
                List<EMMS.Model.Picking_MaterialView> pickingViewList = bll.GetModelListView1(pickingSet.No);
                //
                BindingList<EMMS.Model.Delivery_MaterialView> deliveryViewList = new BindingList<Model.Delivery_MaterialView>();
                if (row.Cells["status"].Value.ToString().Trim().Equals("已部分出库"))
                {
                    if (MessageBox.Show("已部分出库，继续出库？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < pickingViewList.Count; i++)  //
                        {
                            if (pickingViewList[i].Counts > pickingViewList[i].Stocking) //出库数量<领料数量
                            {
                                EMMS.Model.Delivery_MaterialView deliveryView = new Model.Delivery_MaterialView();
                                //deliveryView.No
                                deliveryView.MaterialName = pickingViewList[i].MaterialName;
                                deliveryView.Need = pickingViewList[i].Counts-pickingViewList[i].Stocking;//需要领料数量
                                
                                deliveryView.MaterialNo = pickingViewList[i].MaterialNo;
                                deliveryViewList.Add(deliveryView);
                            }
                            
                        }
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    for (int i = 0; i < pickingViewList.Count; i++)
                    {
                        EMMS.Model.Delivery_MaterialView deliveryView = new Model.Delivery_MaterialView();
                        //deliveryView.No
                        deliveryView.MaterialName = pickingViewList[i].MaterialName;
                        deliveryView.Need = pickingViewList[i].Counts;//需要领料数量
                        //deliveryView.Stocking
                        deliveryView.MaterialNo = pickingViewList[i].MaterialNo;
                        deliveryViewList.Add(deliveryView);
                    }
                }
                base.DeliveryFlag = 1;
                base.PickingModelSet = pickingSet;
                base.DeliveryViewBindingList = deliveryViewList;

                EMMS.View.storage.Delivery_Order delivery = new storage.Delivery_Order();
                delivery.GetParent(this);
                delivery.flag = 3;
                delivery.Show();
                this.Dispose();
            }
        }

        private void tsbInventory_Click(object sender, EventArgs e)
        {
            if (dgvPicking.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvPicking.SelectedRows)
            {
                EMMS.Model.Picking_OrderView ordermodel = new Model.Picking_OrderView();
                ordermodel.No = row.Cells["no"].Value.ToString();
                ordermodel.DepartmentName = row.Cells["departmentname"].Value.ToString();
                ordermodel.FoundName = row.Cells["foundname"].Value.ToString();
                ordermodel.FoundTime = row.Cells["foundtime"].Value.ToString();
                ordermodel.Status = row.Cells["status"].Value.ToString();
                ordermodel.Ended = bool.Parse(row.Cells["ended"].Value.ToString());
                ordermodel.MakeName = row.Cells["makename"].Value.ToString();
                ordermodel.MakeTime = row.Cells["maketime"].Value.ToString();
                ordermodel.Remarks = row.Cells["remarks"].Value.ToString();
                ordermodel.PlanNo = row.Cells["planno"].Value.ToString();

                base.PickingModelFlag = 1;
                base.PickingModelView = ordermodel;
                base.PickingModelSet = bll.GetModel(row.Cells["no"].Value.ToString());
                
                EMMS.View.storage.Inventory_Order inventory = new storage.Inventory_Order();
                inventory.flag = 1; //设置成了1，表示由领料单生成盘点单
                inventory.GetParent(this);
                inventory.Show();
            }
        }

        private void dgvPicking_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (judge == true)
            {
                view.PickingModelFlag = 1;
                view.PickingModelSet = bll.GetModel(dgvPicking.Rows[e.RowIndex].Cells["no"].Value.ToString());
                this.Dispose();
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
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
            excel.coutExcel(dgvPicking);
        }
    }
}
