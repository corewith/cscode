using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View
{
    public partial class MainWindow : EMMS.Common.View
    {
        private int role;
        private EMMS.View.Login myLogin;
        public MainWindow()
        {
            InitializeComponent();
            myLogin = null;
        }

        public void GetParent(EMMS.View.Login login)
        {
            this.myLogin = login;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            EMMS.View.Login login = new Login();
            login.GetParent(this);
            login.ShowDialog();

            //备份数据库ToolStripMenuItem.Visible = false;
            //还原数据库ToolStripMenuItem.Visible = false;

            //基本信息ToolStripMenuItem.Visible = false;
            //生产管理ToolStripMenuItem.Visible = false;
            //仓库管理ToolStripMenuItem.Visible = false;
            //采购管理ToolStripMenuItem.Visible = false;
            //财务管理ToolStripMenuItem.Visible = false;

            ////tpPlan, tpWarehouse,tpPuchasing,tpFinance,tpBasicInfo
            //tcEMMS.Controls.Remove(tpPlan);
            //tcEMMS.Controls.Remove(tpWarehouse);
            //tcEMMS.Controls.Remove(tpPuchasing);
            //tcEMMS.Controls.Remove(tpFinance);
            //tcEMMS.Controls.Remove(tpBasicInfo);


            //role = EMMS.Common.SavedInfo.Role;
            //if (role == 0)
            //{
            //    备份数据库ToolStripMenuItem.Visible = true;
            //    还原数据库ToolStripMenuItem.Visible = true;

            //    基本信息ToolStripMenuItem.Visible = true;
            //    生产管理ToolStripMenuItem.Visible = true;
            //    仓库管理ToolStripMenuItem.Visible = true;
            //    采购管理ToolStripMenuItem.Visible = true;
            //    财务管理ToolStripMenuItem.Visible = true;

            //    tcEMMS.Controls.Add(tpPlan);
            //    tcEMMS.Controls.Add(tpWarehouse);
            //    tcEMMS.Controls.Add(tpPuchasing);
            //    tcEMMS.Controls.Add(tpFinance);
            //    tcEMMS.Controls.Add(tpBasicInfo);
            //}
            //else  if (role == 1 || role==11) //产品经理，生产人员
            //{
            //    生产管理ToolStripMenuItem.Visible = true;
            //    tcEMMS.Controls.Add(tpPlan);
            //}
            //else if (role == 2 || role==21) //仓库经理，仓库人员
            //{
            //    仓库管理ToolStripMenuItem.Visible = true;
            //    tcEMMS.Controls.Add(tpWarehouse);
            //}
            //else if (role == 3 || role == 31) //采购经理，采购人员
            //{
            //    采购管理ToolStripMenuItem.Visible = true;
            //    tcEMMS.Controls.Add(tpPuchasing);
            //}
            //else if (role == 4 || role == 41) //财务经理，财务人员
            //{
            //    财务管理ToolStripMenuItem.Visible = true;
            //    tcEMMS.Controls.Add(tpFinance);
            //}
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？", "确定退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
            else
            {
                return;
            }
        }

        private void 仓库信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.warehouse.Warehouse view = new warehouse.Warehouse();
            view.Show();
        }

        private void 物品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.goods.Goods view = new goods.Goods();
            view.Show();
        }

        private void 人员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.staff.Staff view = new staff.Staff();
            view.Show();
        }

        private void 职务信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.staff.Job view = new staff.Job();
            view.Show();
        }

        private void 部门信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.staff.Department view = new staff.Department();
            view.Show();
        }

        private void 出库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Delivery_Order view = new storage.Delivery_Order();
            view.Show();
        }

        private void 入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new storage.Stocking_Order();
            view.Show();
        }

      

        private void 库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Storage_Order view = new storage.Storage_Order();
            view.Show();
        }

        private void 生产计划单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.plan.Plan_Order view = new plan.Plan_Order();
            view.Show();
        }

        private void 生产oolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.plan.Query view = new plan.Query();
            view.Show();
        }

        private void 产品BOM信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.goods.Production_Material view = new goods.Production_Material();
            view.Show();
        }

        private void 查询领料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.picking.Query_Picking view = new picking.Query_Picking();
            view.Show();
        }

        private void 请购单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Requisition_Order view = new storage.Requisition_Order();
            view.Show();
        }

        private void 采购单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMMS.View.purchasing.Purchasing_Order view = new purchasing.Purchasing_Order();
            view.Show();
        }

        private void 查询采购单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.purchasing.Query view = new purchasing.Query();
            view.Show();
        }

        private void 进购单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMMS.View.entry.Entry_Order view = new entry.Entry_Order();
            view.Show();
        }

        private void 查询进购单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.entry.Query query = new entry.Query();
            query.Show();
        }

        private void 应付款项单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.paying.Paying_Order view = new paying.Paying_Order();
            view.Show();
        }

        private void 查询应付款项单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.paying.Query query = new paying.Query();
            query.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.About about = new About();
            about.ShowDialog();
        }

        private void 备份数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.database.BackupDB back = new database.BackupDB();
            back.ShowDialog();
        }

        private void 还原数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.database.RecoverDB recover = new database.RecoverDB();
            recover.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.common.AlterPwd view = new common.AlterPwd();
            view.ShowDialog();
        }

        private void 更换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            EMMS.View.Login login = new Login();
            login.GetParent(this);
            login.ShowDialog();
        }

        private void 仓库类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.warehouse.WarehouseAttri view = new warehouse.WarehouseAttri();
            view.Show();
        }

        private void 物品类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.goods.GoodsAttri view = new goods.GoodsAttri();
            view.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？", "确定退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            if (EMMS.Common.SavedInfo.IsAlterPws == true)
            {
                EMMS.Common.SavedInfo.IsAlterPws = false;
                MessageBox.Show("检测到您已更换密码，请重新登录！");

                this.Visible = false;
                EMMS.View.Login login = new Login();
                login.GetParent(this);
                login.ShowDialog(); 
            }
            if (myLogin != null)
            {
                备份数据库ToolStripMenuItem.Visible = false;
                还原数据库ToolStripMenuItem.Visible = false;

                基本信息ToolStripMenuItem.Visible = false;
                生产管理ToolStripMenuItem.Visible = false;
                仓库管理ToolStripMenuItem.Visible = false;
                采购管理ToolStripMenuItem.Visible = false;
                财务管理ToolStripMenuItem.Visible = false;

                //tpPlan, tpWarehouse,tpPuchasing,tpFinance,tpBasicInfo
                tcEMMS.Controls.Remove(tpPlan);
                tcEMMS.Controls.Remove(tpWarehouse);
                tcEMMS.Controls.Remove(tpPuchasing);
                tcEMMS.Controls.Remove(tpFinance);
                tcEMMS.Controls.Remove(tpBasicInfo);


                role = EMMS.Common.SavedInfo.Role;
                if (role == 0)
                {
                    备份数据库ToolStripMenuItem.Visible = true;
                    还原数据库ToolStripMenuItem.Visible = true;

                    基本信息ToolStripMenuItem.Visible = true;
                    生产管理ToolStripMenuItem.Visible = true;
                    仓库管理ToolStripMenuItem.Visible = true;
                    采购管理ToolStripMenuItem.Visible = true;
                    财务管理ToolStripMenuItem.Visible = true;

                    tcEMMS.Controls.Add(tpPlan);
                    tcEMMS.Controls.Add(tpWarehouse);
                    tcEMMS.Controls.Add(tpPuchasing);
                    tcEMMS.Controls.Add(tpFinance);
                    tcEMMS.Controls.Add(tpBasicInfo);
                }
                else if (role == 1 || role == 11) //产品经理，生产人员
                {
                    生产管理ToolStripMenuItem.Visible = true;
                    tcEMMS.Controls.Add(tpPlan);
                }
                else if (role == 2 || role == 21) //仓库经理，仓库人员
                {
                    仓库管理ToolStripMenuItem.Visible = true;
                    tcEMMS.Controls.Add(tpWarehouse);
                }
                else if (role == 3 || role == 31) //采购经理，采购人员
                {
                    采购管理ToolStripMenuItem.Visible = true;
                    tcEMMS.Controls.Add(tpPuchasing);
                }
                else if (role == 4 || role == 41) //财务经理，财务人员
                {
                    财务管理ToolStripMenuItem.Visible = true;
                    tcEMMS.Controls.Add(tpFinance);
                }
                myLogin = null;
            }
        }

        private void 供应商信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.purchasing.Supplier view = new purchasing.Supplier();
            view.Show();
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            EMMS.View.plan.Plan_Order plan = new View.plan.Plan_Order();
            plan.Show();
        }

        private void btnPicking_Click(object sender, EventArgs e)
        {
            EMMS.View.picking.Query_Picking query = new picking.Query_Picking();
            query.Show();
        }

        private void btnQueryPicking_Click(object sender, EventArgs e)
        {
            EMMS.View.picking.Query_Picking query = new picking.Query_Picking();
            query.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Inventory_Order view = new storage.Inventory_Order();
            view.Show();
        }

        private void btnRequisition_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Requisition_Order view = new storage.Requisition_Order();
            view.Show();
        }

        private void btnQueryRequisition_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Requisition query = new storage.Query_Requisition();
            query.Show();
        }

        private void ssEMMS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPurchasing_Click(object sender, EventArgs e)
        {
            EMMS.View.purchasing.Purchasing_Order view = new purchasing.Purchasing_Order();
            view.Show();
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            EMMS.View.entry.Entry_Order view = new entry.Entry_Order();
            view.Show();
        }

        private void btnPaying_Click(object sender, EventArgs e)
        {
            EMMS.View.paying.Paying_Order view = new paying.Paying_Order();
            view.Show();
        }

        private void 查询入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Stocking query = new storage.Query_Stocking();
            query.Show();
        }

        private void 查询入库单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Delivery query = new storage.Query_Delivery();
            query.Show();
        }

        private void 应付款项单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMMS.View.paying.Paying_Order view = new paying.Paying_Order();
            view.Show();
        }

        private void 查询请购单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Requisition query = new storage.Query_Requisition();
            query.Show();
        }

        private void 查询应付款项单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMMS.View.paying.Query query = new paying.Query();
            query.Show();
        }

        private void 付款结算单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.payed.Payed_Order view = new payed.Payed_Order();
            view.Show();
        }

        private void 查询付款结算单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.payed.Query query = new payed.Query();
            query.Show();
        }

        private void btnQueryPaying_Click(object sender, EventArgs e)
        {
            EMMS.View.paying.Query query = new paying.Query();
            query.Show();
        }

        private void btnPayed_Click(object sender, EventArgs e)
        {
            EMMS.View.payed.Payed_Order view = new payed.Payed_Order();
            view.Show();
        }

        private void 物料入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new storage.Stocking_Order();
            view.Show();
        }

        private void 成品入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new storage.Stocking_Order();
            view.type = 1;
            view.Show();
        }

        private void btnMStocking_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new storage.Stocking_Order();
            view.Show();
        }

        private void btnPStocking_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Stocking_Order view = new storage.Stocking_Order();
            view.type = 1;
            view.Show();
        }

        private void 查询领料单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMMS.View.picking.Query_Picking query = new picking.Query_Picking();
            query.Show();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Delivery_Order view = new storage.Delivery_Order();
            view.Show();
        }

        private void 查询请购单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMMS.View.storage.Query_Requisition query = new storage.Query_Requisition();
            query.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EMMS.View.warehouse.Warehouse view = new warehouse.Warehouse();
            view.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EMMS.View.warehouse.WarehouseAttri view = new warehouse.WarehouseAttri();
            view.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EMMS.View.goods.GoodsAttri view = new goods.GoodsAttri();
            view.Show();
        }

        private void tbWarehouse_Click(object sender, EventArgs e)
        {
            EMMS.View.staff.Department view = new staff.Department();
            view.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EMMS.View.staff.Job view = new staff.Job();
            view.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EMMS.View.purchasing.Supplier view = new purchasing.Supplier();
            view.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EMMS.View.staff.Staff view = new staff.Staff();
            view.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EMMS.View.goods.Goods view = new goods.Goods();
            view.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EMMS.View.goods.Production_Material view = new goods.Production_Material();
            view.Show();
        }

        private void llPlan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.plan.Query query = new plan.Query();
            query.Show();
        }

        private void llInventory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.storage.Query_Inventory query = new storage.Query_Inventory();
            query.Show();
        }

        private void llRequisition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.storage.Query_Requisition query = new storage.Query_Requisition();
            query.Show();
        }

        private void llStocking_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.storage.Query_Stocking query = new storage.Query_Stocking();
            query.Show();
        }

        private void llDelivery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.storage.Query_Delivery query = new storage.Query_Delivery();
            query.Show();
        }

        private void llPurchasing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.purchasing.Query query = new purchasing.Query();
            query.Show();
        }

        private void llEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.entry.Query query = new entry.Query();
            query.Show();
        }

        private void llPaying_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.paying.Query query = new paying.Query();
            query.Show();
        }

        private void llPayed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.payed.Query query = new payed.Query();
            query.Show();
        }

        private void llStorage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMMS.View.storage.Storage_Order view = new storage.Storage_Order();
            view.Show();
        }
    }
}
