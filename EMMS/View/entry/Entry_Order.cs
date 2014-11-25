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
    public partial class Entry_Order : EMMS.Common.View
    {
        private EMMS.BLL.Entry_Order bll = new BLL.Entry_Order();//
        private EMMS.Model.Entry_OrderSet orderModel = new Model.Entry_OrderSet();//
        private List<EMMS.Model.Entry_MaterialSet> productionList = new List<Model.Entry_MaterialSet>();//
        private int index;
        public int flag; //标志，0表示增加,1表示查看详情
        private EMMS.Common.View view;

        public Entry_Order()
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

            DataGridViewLinkColumn l1 = new DataGridViewLinkColumn();
            l1.UseColumnTextForLinkValue = true;
            l1.HeaderText = "删除";
            l1.Text = "删除";
            l1.Name = "delete";
            dgvEntry.Columns.Add(l1);

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "编码";
            c1.DataPropertyName = "No";
            c1.Name = "no";
            c1.ValueType = typeof(string);
            c1.ReadOnly = true;
            dgvEntry.Columns.Add(c1);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "物料名称";
            btn1.DataPropertyName = "MaterialName";
            btn1.FlatStyle = FlatStyle.Flat; 
            btn1.Name = "materialname";
            btn1.ToolTipText = "请选择物料";
            dgvEntry.Columns.Add(btn1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "进购数量";
            c2.DataPropertyName = "Counts";
            c2.Name = "counts";
            c2.ValueType = typeof(string);
            dgvEntry.Columns.Add(c2);

            //DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            //c7.HeaderText = "状态";
            //c7.Name = "status";
            //c7.ValueType = typeof(string);
            //dgvEntry.Columns.Add(c7);
            //dgvEntry.Columns["status"].Visible = false;

            DataGridViewCheckBoxColumn c8 = new DataGridViewCheckBoxColumn();
            c8.HeaderText = "已付款";
            c8.DataPropertyName = "Payed";
            c8.Name = "payed";
            c8.ValueType = typeof(bool);
            dgvEntry.Columns.Add(c8);
            dgvEntry.Columns["payed"].ReadOnly = true;
        
            DataGridViewTextBoxColumn c10 = new DataGridViewTextBoxColumn();
            c10.HeaderText = "单位";
            c10.DataPropertyName = "Unit";
            c10.Name = "unit";
            c10.ValueType = typeof(string);
            dgvEntry.Columns.Add(c10);
      
            DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
            c11.HeaderText = "物料编码";
            c11.DataPropertyName = "MaterialNo";
            c11.Name = "materialno";
            c11.ValueType = typeof(string);
            dgvEntry.Columns.Add(c11);
            //让其隐藏
            dgvEntry.Columns["materialno"].Visible = false;
        }
        private void Entry_Order_Load(object sender, EventArgs e)
        {
            Init();
            if (flag == 0) //增加
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }

            else if (flag == 1) //查看详情
            {
                dgvEntry.Columns["delete"].Visible = false;
                tsbSave.Visible = false;
                //tsbCopy.Visible = false;
                tbMakeName.ReadOnly = true;
                tbMakeTime.ReadOnly = true;
                tbNo.ReadOnly = true;
                tbRemarks.ReadOnly = true;
                tbStaff.ReadOnly = true;
                dtpTime.Enabled = false;
                //btnSupplier.Enabled = false;
                //btnPurchasing.Enabled = false;
                //btnStaff.Enabled = false;
                   
                if (view.EntryModelFlag == 1)
                {
                    tbNo.Text = view.EntryModelView.No;
                    tbSupplier.Text = view.EntryModelView.SupplierName;
                    tbStaff.Text = view.EntryModelView.FoundName;
                    tbRemarks.Text = view.EntryModelView.Remarks;
                    dtpTime.Value = DateTime.Parse(view.EntryModelView.FoundTime);
                    tbMakeName.Text = view.EntryModelView.MakeName;
                    tbMakeTime.Text = view.EntryModelView.MakeTime;
                    tbPurchasing.Text = view.EntryModelView.Purchasing;

                    dgvEntry.DataSource = view.EntryModelViewList;
                }
                dgvEntry.ReadOnly = true;
               
            }
        }

        private void dgvStocking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvEntry.EndEdit();
        }

        private void dgvStocking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (flag == 0)
            {
                if (dgvEntry.Columns[e.ColumnIndex].Name == "materialname")
                {
                    EMMS.View.goods.List list = new goods.List();
                    list.GetParent(this);
                    list.ShowDialog();
                }
            }
            if (flag != 1) //不是查看详情
            {
                if (dgvEntry.Columns[e.ColumnIndex].Name == "delete")
                {
                    dgvEntry.Rows.RemoveAt(e.RowIndex);
                }
            }
 
        }

        private void Stocking_Order_Activated(object sender, EventArgs e)
        {
            if (flag == 0)//增加的时候才需要填写
            {
                if (base.GoodsFlag == 1)
                {
                    dgvEntry.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
                    if (base.GoodsModel.No != null)
                    {
                        EMMS.Model.Entry_MaterialSet productionmodel = new Model.Entry_MaterialSet();
                        dgvEntry.Rows[index].Cells["no"].Value = productionmodel.No;//
                        dgvEntry.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;
                        dgvEntry.Rows[index].Cells["unit"].Value = base.GoodsModel.Unit;
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
                if (base.PurchasingModelViewFlag == 1)
                {
                    tbPurchasing.Text = base.PurchasingModelSet.No;
                    base.PurchasingModelViewFlag = 0;
                }
            }

        }

        private void btnStaff_Click(object sender, EventArgs e)
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
            //标志，0表示增加,1表示查看详情
            dgvEntry.EndEdit();
            if (flag == 0 )//|| flag == 3)
            {
                if (String.IsNullOrEmpty(tbStaff.Text))
                {
                    MessageBox.Show("请选择经手人员！");
                    return;
                }
                if (String.IsNullOrEmpty(tbPurchasing.Text))
                {
                    MessageBox.Show("请选择与之对应的采购单！");
                    return;
                }
                if (String.IsNullOrEmpty(tbSupplier.Text))
                {
                    MessageBox.Show("请选择供应商！");
                    return;
                }
            }
            
            orderModel.No = tbNo.Text;
            if (flag == 0 )// || flag == 3)
            {
                orderModel.FoundNo = base.StaffModel.No;//得到所选择的人员编码
            }
            orderModel.FoundTime = dtpTime.Value.ToShortDateString();
            orderModel.Remarks = tbRemarks.Text;
            if (flag == 0 )//|| flag == 3)
            {
                orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;
            }
 
            orderModel.MakeTime = tbMakeTime.Text;
            if (flag == 0 )//|| flag == 3)
            {
                orderModel.Supplier = base.SupplierModel.No;
            }
            //记录requisition，保持与之联系
            orderModel.Purchasing = tbPurchasing.Text;


            //很特殊的写法，不完善！
            if (dgvEntry.Rows[0].Cells["counts"].Value == null)
            {
                MessageBox.Show("请填写好相关信息！");
                return;
            }
            
            for (int i = 0; i < dgvEntry.Rows.Count - 1; i++)//得减一行
            {
                //bool ended = true;
                if (dgvEntry.Rows[i].Cells["no"].Value.ToString() != null)
                {
                    //
                    try
                    {
                        if (int.Parse(dgvEntry.Rows[i].Cells["counts"].Value.ToString()) <= 0)
                        {
                            MessageBox.Show("请填写正确的进购数目！");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("请填写正确的进购数目！");
                    }

                    EMMS.Model.Entry_MaterialSet production = new Model.Entry_MaterialSet();
                    production.No = dgvEntry.Rows[i].Cells["no"].Value.ToString();
                    production.Entry = tbNo.Text;//记录联系
                    production.Counts=int.Parse(dgvEntry.Rows[i].Cells["counts"].Value.ToString());
                    production.Material = dgvEntry.Rows[i].Cells["materialno"].Value.ToString();

                    productionList.Add(production);
                }

            }
            if (flag == 0)
            {
                if (bll.Add(orderModel, productionList))
                {
                        MessageBox.Show("保存成功！");
                        //更改采购单状态及使采购单结束
                        EMMS.BLL.Purchasing_Order purchasingBll = new BLL.Purchasing_Order();
                        EMMS.Model.Purchasing_OrderSet purchasingSet = purchasingBll.GetModel(orderModel.Purchasing);
                        //更改请购单状态
                        EMMS.BLL.Requisition_Order requisitionBll = new BLL.Requisition_Order();
                        EMMS.Model.Requisition_OrderSet requisitionSet = requisitionBll.GetModel(purchasingSet.Requisition);
                        
                        purchasingSet.Status = "已进购";
                        purchasingSet.Ended = 1;
                        purchasingBll.UpdateOrder(purchasingSet);
                        //if (purchasingBll.UpdateOrder(purchasingSet))
                        //{
                        //    MessageBox.Show("采购单更新成功！");
                        //}
                        requisitionSet.Status = "已进购未入库";
                        requisitionBll.UpdateOrder(requisitionSet);
                        //if (requisitionBll.UpdateOrder(requisitionSet))
                        //{
                        //    MessageBox.Show("请购单更新成功！");
                        //}
                        ///
                        ///应付款项单复制前置单据
                        ///
                        EMMS.Model.Entry_OrderSet entrySet = bll.GetModel(orderModel.No);
                        EMMS.Common.SavedInfo.EntryOrderSet = entrySet;// 让应付款结算单去读取

                        List<EMMS.Model.Entry_MaterialView> entryList = new List<Model.Entry_MaterialView>();
                        entryList = bll.GetModelListView1(entrySet.No); //得到与之相关的物料信息
                        List<EMMS.Model.Paying_MaterialView> payingViewList = new List<Model.Paying_MaterialView>();
                        EMMS.BLL.Goods goodsBll = new BLL.Goods();
                        for (int i = 0; i < entryList.Count; i++)
                        {
                            EMMS.Model.Paying_MaterialView payingView = new Model.Paying_MaterialView();
                            EMMS.Model.GoodsSet goods = goodsBll.GetModel(entryList[i].MaterialNo);
                            //payingView.No;
                            payingView.MaterialName = entryList[i].MaterialName;
                            payingView.Unit = entryList[i].Unit;
                            payingView.Counts = entryList[i].Counts;
                            payingView.Price = goods.Price;
                            payingView.PriceUnit = goods.PriceUnit;
                            payingView.Cost = payingView.Counts * payingView.Price;
                            payingView.MaterialNo = entryList[i].MaterialNo;
                            payingViewList.Add(payingView);
                        }

                        EMMS.Common.SavedInfo.PayingFlag = 1;
                        EMMS.Common.SavedInfo.PayingMaterialViewList = payingViewList;

                        ///
                        /// 物料入库单复制前置单据
                        ///
                        EMMS.Common.SavedInfo.EntryOrderSet1 = entrySet;// 让物料入库单去读取
                        List<EMMS.Model.Stocking_MaterialView> stockingViewList=new List<Model.Stocking_MaterialView>();
                        for (int i = 0; i < entryList.Count; i++)
                        {
                            EMMS.Model.Stocking_MaterialView stockingView = new Model.Stocking_MaterialView();
                            //stockingView.No;
                            stockingView.MaterialName = entryList[i].MaterialName;
                            stockingView.Counts = entryList[i].Counts;
                            stockingView.Unit = entryList[i].Unit;
                            stockingView.MaterialNo = entryList[i].MaterialNo;
                            stockingViewList.Add(stockingView);
                        }

                        EMMS.Common.SavedInfo.StockingFlag = 1;
                        EMMS.Common.SavedInfo.StockingMaterialViewList = stockingViewList;
                }
            }
            this.Dispose();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvStocking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (flag != 1)
            {
                EMMS.View.purchasing.Supplier view = new purchasing.Supplier();
                view.GetParent(this);
                view.flag = true;
                view.ShowDialog();
            }
        }

        private void btnPurchasing_Click(object sender, EventArgs e)
        {
            if (flag != 1)
            {
                EMMS.View.purchasing.Query query = new purchasing.Query();
                query.GetParent(this);
                query.judge = true;
                query.ShowDialog();
            }
        }

        private void tbPurchasing_TextChanged(object sender, EventArgs e)
        {
            EMMS.BLL.Purchasing_Order purchasingBll = new BLL.Purchasing_Order();
            List<EMMS.Model.Purchasing_MaterialView> purchasingMaterialList = purchasingBll.GetModelListView1(tbPurchasing.Text);
            BindingList<EMMS.Model.Entry_MaterialView> entryMaterialList = new BindingList<Model.Entry_MaterialView>();
            EMMS.BLL.Goods goodsBll = new BLL.Goods();
            //供应商
            EMMS.Model.Purchasing_OrderSet purchasingOrder = purchasingBll.GetModel(tbPurchasing.Text);
            EMMS.BLL.Supplier supplierBll = new BLL.Supplier();
            EMMS.Model.Supplier supplier = new Model.Supplier();
            supplier = supplierBll.GetModel(purchasingOrder.Supplier);
            tbSupplier.Text = supplier.Name;
            base.SupplierModel = supplier;//保存供应商信息

            for (int i = 0; i < purchasingMaterialList.Count; i++)
            {
                EMMS.Model.Entry_MaterialView entryMaterial = new Model.Entry_MaterialView();
                //entryMaterial.No;
                entryMaterial.MaterialName = purchasingMaterialList[i].MaterialName;
                entryMaterial.Counts = purchasingMaterialList[i].CheckCounts;
                entryMaterial.MaterialNo = purchasingMaterialList[i].MaterialNo;
                EMMS.Model.GoodsSet goodsset = new Model.GoodsSet();
                goodsset = goodsBll.GetModel(entryMaterial.MaterialNo);
                entryMaterial.Unit = goodsset.Unit;
                entryMaterialList.Add(entryMaterial);
            }
            dgvEntry.DataSource = entryMaterialList;
        }
    }
}
