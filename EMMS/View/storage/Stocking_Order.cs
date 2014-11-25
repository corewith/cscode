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
    public partial class Stocking_Order : EMMS.Common.View
    {
        private EMMS.BLL.Stocking_Order bll = new BLL.Stocking_Order();
        private EMMS.BLL.Storage_Order bll1 = new BLL.Storage_Order();
        private EMMS.Model.Stocking_OrderSet orderModel = new Model.Stocking_OrderSet();//保留入库单信息
        private List<EMMS.Model.Stocking_MaterialSet> materialList = new List<Model.Stocking_MaterialSet>();//保留入库-物料联系信息
        private EMMS.Common.View view;
        public int flag; // 0 表示增加，1表示查看详情，2表示复制前置单据
        private int index;
        public int type;  //0表示物料入库，1表示成品入库
        //private bool judge;

        public Stocking_Order()
        {
            InitializeComponent();
            flag = 0;
            type = 0;
            index = -1;
            //judge = false;
            
        }
        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        public void Init()
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "编码";
            c1.DataPropertyName = "No";
            c1.Name = "no";
            c1.ValueType = typeof(string);
            c1.ReadOnly = true;
            dgvStocking.Columns.Add(c1);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "物品名称";
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.DataPropertyName = "MaterialName";
            btn1.Name = "materialname";
            btn1.ToolTipText = "请选择物品";
            dgvStocking.Columns.Add(btn1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "数量";
            c2.DataPropertyName = "Counts";
            c2.Name = "counts";
            c2.ValueType = typeof(string);
            dgvStocking.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "单位";
            c3.DataPropertyName = "Unit";
            c3.Name = "unit";
            c3.ValueType = typeof(string);
            dgvStocking.Columns.Add(c3); 

            DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            c7.HeaderText = "编码";
            c7.DataPropertyName = "MaterialNo";
            c7.Name = "materialno";
            c7.ValueType = typeof(string);
            dgvStocking.Columns.Add(c7);
            //让其隐藏
            dgvStocking.Columns["materialno"].Visible = false;
        }
        private void Stocking_Order_Load(object sender, EventArgs e)
        {
            if (type == 1)
            {
                orderModel.Type = 1;//若为生产计划单，则类别为1
                labType.Text = "生产计划单";
            }
            Init();
            if (flag == 0 ) // 0 表示增加，1表示查看详情，2表示复制前置单据
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
            else if (flag == 2)
            {
                tbNo.Text = orderModel.No;//入库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
                dgvStocking.ReadOnly = true;
            }
            else if (flag == 1)
            {
                //设置不可用
                tsbSave.Visible = false;
                tsbCopy.Visible = false;

                //btnEntry.Enabled = false;
                //btnStaff.Enabled = false;
                //btnWarehouse.Enabled = false;
                dtpTime.Enabled = false;
                tbRemarks.ReadOnly = true;

                if (view.StockingFlag == 1)
                {
                    tbNo.Text = view.StockingOrderView.No;
                    tbStaff.Text = view.StockingOrderView.FoundName;
                    tbWarehouse.Text = view.StockingOrderView.WarehouseName;
                    tbMakeName.Text = view.StockingOrderView.MakeName;
                    tbMakeTime.Text = view.StockingOrderView.MakeTime;
                    tbRemarks.Text = view.StockingOrderView.Remarks;
                    tbEntry.Text = view.StockingOrderView.Entry;
                    dtpTime.Value = DateTime.Parse(view.StockingOrderView.FoundTime);

                    dgvStocking.DataSource = view.StockingViewList;
                }
                dgvStocking.ReadOnly = true;
            }
        }

        private void dgvStocking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void dgvStocking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 0 表示增加，1表示查看详情，2表示复制前置单据
            index = e.RowIndex;
            if (flag == 0)
            {
                if (dgvStocking.Columns[e.ColumnIndex].Name == "materialname")
                {
                    EMMS.View.goods.List list = new goods.List();
                    list.GetParent(this);
                    list.ShowDialog();
                }
            }
        }

        private void Stocking_Order_Activated(object sender, EventArgs e)
        {
            //从GoodsModel中dgvStocking该行赋值
            // 0 表示增加，1表示查看详情，2表示复制前置单据
            if (flag == 0)
            {
                if (base.GoodsFlag == 1)
                {
                    if (base.GoodsModel.Name != null)
                    {
                        dgvStocking.Rows[index].Cells["materialname"].Value = base.GoodsModel.Name;
                    }
                    if (base.GoodsModel.Unit != null)
                    {
                        dgvStocking.Rows[index].Cells["unit"].Value = base.GoodsModel.Unit;
                    }
                    //if (base.GoodsModel.Price.ToString() != null)
                    //{
                    //    dgvStocking.Rows[index].Cells["price"].Value = base.GoodsModel.Price.ToString();
                    //}
                    //if (base.GoodsModel.PriceUnit != null)
                    //{
                    //    dgvStocking.Rows[index].Cells["priceunit"].Value = base.GoodsModel.PriceUnit;
                    //}
                    dgvStocking.Rows[index].Cells["materialno"].Value = base.GoodsModel.No;
                    //编码赋值
                    if (base.GoodsModel.No != null)
                    {
                        if (dgvStocking.Rows[index].Cells["no"].Value == null)
                        {
                            EMMS.Model.Stocking_MaterialSet materialmodel = new Model.Stocking_MaterialSet();
                            dgvStocking.Rows[index].Cells["no"].Value = materialmodel.No;//入库单-物料联系编码    
                        }
                    }
                    base.GoodsFlag = 0;
                }
            }
                if (base.StaffFlag == 1)
                {
                    this.tbStaff.Text = base.StaffModel.Name;
                    base.StaffFlag = 0;
                }
                if (base.WarehouseFlag == 1)
                {
                    this.tbWarehouse.Text = base.WarehouseModel.Name;
                    base.WarehouseFlag = 0;
                }
                if (type == 0) //物料入库，进购单
                {
                    if (base.EntryModelFlag == 1)
                    {
                        this.tbEntry.Text = base.EntryModelSet.No;
                        base.EntryModelFlag = 0;
                    }
                }
                else if (type == 1) //成品入库，生产计划单
                {
                    if (base.PlanFlag == 1)
                    {
                        this.tbEntry.Text = base.PlanModelSet.No;
                        base.PlanFlag = 0;
                    }
                }
      
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            // 0 表示增加，1表示查看详情，2表示复制前置单据
            if (flag != 1 )
            {
                EMMS.View.warehouse.List list = new warehouse.List();
                list.GetParent(this);
                list.ShowDialog();
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
            // 0 表示增加，1表示查看详情，2表示复制前置单据
            dgvStocking.EndEdit();
            if (String.IsNullOrEmpty(tbWarehouse.Text))
            {
                MessageBox.Show("请选择仓库！");
                return;
            }
            if (String.IsNullOrEmpty(tbStaff.Text))
            {
                MessageBox.Show("请选择经手人员！");
                return;
            }
            if (flag == 0)
            {
                if (type == 0) //物料，进购单
                {
                    if (string.IsNullOrEmpty(tbEntry.Text))
                    {
                        MessageBox.Show("请先选择进购单！");
                        return;
                    }
                }
                else if (type == 1) //成品，生产计划单
                {
                    if (string.IsNullOrEmpty(tbEntry.Text))
                    {
                        MessageBox.Show("请先选择生产计划单！");
                        return;
                    }
                }
            }
            // 0 表示增加，1表示查看详情，2表示复制前置单据
            //entry还未赋值,未与进购单联系起来
            orderModel.Entry = tbEntry.Text;

            orderModel.Warehouse = base.WarehouseModel.No;//得到选择的仓库编码
            orderModel.FoundNo = base.StaffModel.No;//得到所选择的人员编码
            orderModel.FoundTime = dtpTime.Value.ToShortDateString();//
            orderModel.Remarks = tbRemarks.Text;
            orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;//制表人员编码
            orderModel.MakeTime = tbMakeTime.Text;//制表时间

            if (dgvStocking.Rows[0].Cells["no"].Value==null)
            {
                MessageBox.Show("请填写好相关信息！");
                return;
            }
            // 0 表示增加，1表示查看详情，2表示复制前置单据
            int total = 0;
            if (flag == 0)
            {
                total = dgvStocking.Rows.Count - 1;
            }
            else
            {
                total = dgvStocking.Rows.Count;
            }
            for (int i = 0; i < total; i++)//
            {
           
                if (dgvStocking.Rows[i].Cells["no"].Value.ToString() != null)
                {
                    EMMS.Model.Stocking_MaterialSet material = new Model.Stocking_MaterialSet();
                    material.No = dgvStocking.Rows[i].Cells["no"].Value.ToString();
                    material.Material = dgvStocking.Rows[i].Cells["materialno"].Value.ToString();
                    material.Stocking = tbNo.Text;
                    try
                    {
                        material.Counts = int.Parse(dgvStocking.Rows[i].Cells["counts"].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("请填写正确的入库数目！");
                    }
                    if (material.Counts <= 0)
                    {
                        MessageBox.Show("请填写正确的入库数目！");
                        return;
                    }
                    materialList.Add(material);
                }
            }
            if (bll.Add(orderModel, materialList))
            {
                MessageBox.Show("入库成功！");
                //库存数量增加,不管是成品或物料
                for (int i = 0; i < materialList.Count; i++)
                {
                    EMMS.Model.Storage_OrderSet model=new Model.Storage_OrderSet();
                    model = bll1.GetModelByNo(orderModel.Warehouse, materialList[i].Material);//仓库编码，物品编码
                    if (model != null)//要是有库存，则更新
                    {
                        model.Counts += materialList[i].Counts;
                        //bll1.Update(model);
                        if (bll1.Update(model))
                        {
                            //MessageBox.Show("库存更新成功！");
                        }
                        //else
                        //    MessageBox.Show("库存更新失败！");
                    }
                    else//要是没有，则插入
                    {
                        EMMS.Model.Storage_OrderSet model1 = new Model.Storage_OrderSet();
                        model1.WarehouseNo = orderModel.Warehouse;
                        model1.GoodsNo = materialList[i].Material;
                        model1.Counts = materialList[i].Counts;
                        model1.Critical = 0;
                        //bll1.Add(model1);
                        if (bll1.Add(model1))
                        {
                            //MessageBox.Show("库存更新成功！");
                        }
                        //else
                        //    MessageBox.Show("库存更新失败！");
                    }
                }
                Update(orderModel, materialList);
                this.Dispose();
            }
            
        }
        public void Update(EMMS.Model.Stocking_OrderSet model,List<EMMS.Model.Stocking_MaterialSet> list)
        {
            //
            if (type == 0) //物料入库，若入库单counts >= 请购单counts，则请购单结束，
            {
                //进购单
                EMMS.BLL.Entry_Order entryBll = new BLL.Entry_Order();
                EMMS.Model.Entry_OrderSet entrySet = entryBll.GetModel(model.Entry);
                //采购单
                EMMS.BLL.Purchasing_Order purchasingBll = new BLL.Purchasing_Order();
                EMMS.Model.Purchasing_OrderSet purchasingSet = purchasingBll.GetModel(entrySet.Purchasing);
                //请购单
                EMMS.BLL.Requisition_Order requisitionBll = new BLL.Requisition_Order();
                EMMS.Model.Requisition_OrderSet requisitionSet = requisitionBll.GetModel(purchasingSet.Requisition);
                //请购单物料联系
                List<EMMS.Model.Requisition_MaterialView> viewList = new List<Model.Requisition_MaterialView>();
                viewList = requisitionBll.GetModelListView1(requisitionSet.No);

                //若进购单物料种类小于请购单物料种类，则明显请购单还未结束
                if (viewList.Count > list.Count)
                { }
                else
                {
                    bool ended = true;
                    for (int j = 0; j < viewList.Count; j++) //请购单
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (viewList[j].MaterialNo.Equals(list[k].Material)) //找到相同的
                            {
                                //判断数目
                                if (viewList[j].CheckCounts <= list[k].Counts) //进购单数目>=请购单审核数目
                                { }
                                else
                                {
                                    ended = false; //表示有一个不足
                                    break;
                                }
                            }
                        }
                    }
                    if (ended == true)
                    {
                        //表明请购的物料都已经入库
                        requisitionSet.Status = "已入库";
                        requisitionSet.Ended = 1;
                        if (requisitionBll.UpdateOrder(requisitionSet))
                        {
                            //MessageBox.Show("请购单更新成功！");
                        }

                    }
                }
            }
            else if (type == 1) //成品入库，若入库单counts>=生产计划单counts，则生产计划单结束
            {
                EMMS.BLL.Plan_Order planBll = new BLL.Plan_Order();
                EMMS.Model.Plan_OrderSet planSet = planBll.GetModel(orderModel.Entry);
                List<EMMS.Model.Plan_ProductionView> viewList = planBll.GetModelListView1(planSet.No);

                if (viewList.Count > list.Count) //表明生产计划单未结束
                {
                }
                else
                {
                    bool ended = true;
                    for (int j = 0; j < viewList.Count; j++)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (viewList[j].GoodsNo.Equals(list[k].Material))
                            {
                                if (viewList[j].CheckCounts <= list[k].Counts) //入库单>=生产计划单
                                {
                                }
                                else
                                {
                                    ended = false;
                                }
                            }
                        }
                    }
                    if (ended == true)  //
                    {
                        planSet.Status = "已入库";
                        planSet.Ended = 1;
                        if (planBll.UpdateOrder(planSet))
                        {
                            //MessageBox.Show("生产计划单更新成功！");
                        }
                    }
                }
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvStocking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            if (flag != 1)
            {
                if (type == 0) //物料入库，进购单
                {
                    EMMS.View.entry.Query query = new entry.Query();
                    query.judge1 = true;
                    query.GetParent(this);
                    query.ShowDialog();
                }
                else if (type == 1) //成品入库，生产计划单
                {
                    EMMS.View.plan.Query query = new plan.Query();
                    query.judge = true;
                    query.GetParent(this);
                    query.ShowDialog();
                }
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            //judge = true;
            if (type == 0)//物料入库
            {
                if (EMMS.Common.SavedInfo.StockingFlag == 1)
                {
                    tbEntry.Text = EMMS.Common.SavedInfo.EntryOrderSet1.No;
                    dgvStocking.DataSource = EMMS.Common.SavedInfo.StockingMaterialViewList;
                    // 0 表示增加，1表示查看详情，2表示复制前置单据
                    flag = 2;
                }
                else
                {
                    MessageBox.Show("未检测到与之对应的进购单！");
                    return;
                }
            }
            else if (type == 1) //成品入库
            {
                if (EMMS.Common.SavedInfo.StockingFlag1 == 1)
                {
                    tbEntry.Text = EMMS.Common.SavedInfo.PlanOrderSet.No;
                    dgvStocking.DataSource = EMMS.Common.SavedInfo.StockingMaterialViewList1;
                }
                else
                {
                    MessageBox.Show("未检测到与之对应的生产计划单！");
                    return;
                }
            }
        }

        private void tbEntry_TextChanged(object sender, EventArgs e)
        {
            //if(judge == false)//未点击复制前置单据
            //{
                flag = 2;//和复制前置单据等同
                //dgvStocking.ReadOnly = true;
                if (type == 0)//物料入库
                {
                    EMMS.BLL.Entry_Order entryBll = new BLL.Entry_Order();
                    List<EMMS.Model.Entry_MaterialView> entryMaterialList = entryBll.GetModelListView1(tbEntry.Text);
                    List<EMMS.Model.Stocking_MaterialView> stockingMaterialList = new List<Model.Stocking_MaterialView>();
                    for (int i = 0; i < entryMaterialList.Count; i++)
                    {
                        EMMS.Model.Stocking_MaterialView stockingMaterial = new Model.Stocking_MaterialView();
                        //stockingMaterial.No;
                        stockingMaterial.MaterialName = entryMaterialList[i].MaterialName;
                        stockingMaterial.Counts = entryMaterialList[i].Counts;
                        stockingMaterial.Unit = entryMaterialList[i].Unit;
                        stockingMaterial.MaterialNo = entryMaterialList[i].MaterialNo;
                        stockingMaterialList.Add(stockingMaterial);
                    }
                    dgvStocking.DataSource = stockingMaterialList;
                }
                else
                {
                    EMMS.BLL.Plan_Order planBll = new BLL.Plan_Order();
                    List<EMMS.Model.Plan_ProductionView> planProductionList = planBll.GetModelListView1(tbEntry.Text);
                    List<EMMS.Model.Stocking_MaterialView> stockingMaterialList = new List<Model.Stocking_MaterialView>();
                    EMMS.BLL.Goods goodsBll = new BLL.Goods();
                    for (int i = 0; i < planProductionList.Count; i++)
                    {
                        EMMS.Model.Stocking_MaterialView stockingMaterial = new Model.Stocking_MaterialView();
                        //stockingMaterial.No;
                        stockingMaterial.MaterialName = planProductionList[i].GoodsName;
                        stockingMaterial.Counts = planProductionList[i].CheckCounts;//审核的数量
                        stockingMaterial.MaterialNo = planProductionList[i].GoodsNo;

                        EMMS.Model.GoodsSet goodsset = goodsBll.GetModel(stockingMaterial.MaterialNo);
                        stockingMaterial.Unit = goodsset.Unit;
                        
                        stockingMaterialList.Add(stockingMaterial);
                    }
                    dgvStocking.DataSource = stockingMaterialList;
                }
            //}

        }
    }
}
