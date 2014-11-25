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
    public partial class Delivery_Order : EMMS.Common.View
    {
        private EMMS.BLL.Delivery_Order bll = new BLL.Delivery_Order();//
        private EMMS.BLL.Storage_Order bll1 = new BLL.Storage_Order();//库存更新
        private EMMS.Model.Delivery_OrderSet orderModel = new Model.Delivery_OrderSet();//保留出库单信息
        private List<EMMS.Model.Delivery_MaterialSet> materialList = new List<Model.Delivery_MaterialSet>();//保留出库-物料联系信息
        private EMMS.Common.View view;
        private int index;
        private StringBuilder record = new StringBuilder();
        public int flag; //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据

        public Delivery_Order()
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
            dgvDelivery.Columns.Add(l1);

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "编码";
            c1.DataPropertyName = "No";
            c1.Name = "no";
            c1.ValueType = typeof(string);
            c1.ReadOnly = true;
            dgvDelivery.Columns.Add(c1);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "物料名称";
            btn1.DataPropertyName = "MaterialName";
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Name = "materialname";
            btn1.ToolTipText = "请选择物品";
            dgvDelivery.Columns.Add(btn1);


            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "出库数量";
            c2.DataPropertyName = "Stocking";
            c2.Name = "stocking";
            c2.ValueType = typeof(string);
            dgvDelivery.Columns.Add(c2);

            //DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            //c7.HeaderText = "审核人员";
            //c7.Name = "checkname";
            //c7.ValueType = typeof(string);
            //dgvDelivery.Columns.Add(c7);
            //dgvDelivery.Columns["checkname"].Visible = false;

            DataGridViewCheckBoxColumn c8 = new DataGridViewCheckBoxColumn();
            c8.HeaderText = "审核";
            c8.DataPropertyName = "Audited";
            c8.Name = "audited";
            c8.ValueType = typeof(bool);
            dgvDelivery.Columns.Add(c8);
            dgvDelivery.Columns["audited"].Visible = false;

            DataGridViewTextBoxColumn c9 = new DataGridViewTextBoxColumn();
            c9.HeaderText = "审核数量";
            c9.DataPropertyName = "CheckCounts";
            c9.Name = "checkcounts";
            c9.ValueType = typeof(string);
            dgvDelivery.Columns.Add(c9);
            dgvDelivery.Columns["checkcounts"].Visible = false;

            DataGridViewTextBoxColumn c10 = new DataGridViewTextBoxColumn();
            c10.HeaderText = "审核时间";
            c10.DataPropertyName = "CheckTime";
            c10.Name = "checktime";
            c10.ValueType = typeof(string);
            dgvDelivery.Columns.Add(c10);
            dgvDelivery.Columns["checktime"].Visible = false;

            DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
            c11.HeaderText = "物料编码";
            c11.DataPropertyName = "MaterialNo";
            c11.Name = "materialno";
            c11.ValueType = typeof(string);
            dgvDelivery.Columns.Add(c11);
            //让其隐藏
            dgvDelivery.Columns["materialno"].Visible = false;

            DataGridViewTextBoxColumn c12 = new DataGridViewTextBoxColumn();
            c12.HeaderText = "库存量";
            c12.DataPropertyName = "Counts";
            c12.Name = "counts";
            c12.ValueType = typeof(int);
            dgvDelivery.Columns.Add(c12);
            //dgvDelivery.Columns["counts"].Visible = false;

            DataGridViewTextBoxColumn c13 = new DataGridViewTextBoxColumn();
            c13.HeaderText = "警戒线";
            c13.DataPropertyName = "Critical";
            c13.Name = "critical";
            c13.ValueType = typeof(int);
            dgvDelivery.Columns.Add(c13);
            dgvDelivery.Columns["critical"].Visible = false;

            DataGridViewTextBoxColumn c14 = new DataGridViewTextBoxColumn();
            c14.HeaderText = "所需数量";
            c14.DataPropertyName = "Need";
            c14.Name = "need";
            c14.ValueType = typeof(int);
            dgvDelivery.Columns.Add(c14);
            dgvDelivery.Columns["need"].Visible = false;
        }
        private void Stocking_Order_Load(object sender, EventArgs e)
        {
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            Init();
            if (flag == 0 || flag==3 || flag==4)//增加,3,4,
            {
                tbNo.Text = orderModel.No;//出库单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
            else if (flag == 1)//审核
            {
                dgvDelivery.Columns["delete"].Visible = false;
                tbDepartment.ReadOnly = true;
                tbRemarks.ReadOnly = true;
                tbStaff.ReadOnly = true;
                tbWarehouse.ReadOnly = true;
                //btnDepartment.Enabled = false;
                //btnStaff.Enabled = false;
                //btnWarehouse.Enabled = false;
                dtpTime.Enabled = false;
                //btnPicking.Enabled = false;

                if (view.DeliveryFlag == 1)
                {
                    dgvDelivery.DataSource = view.DeliveryViewList;
                    for (int i = 0; i < dgvDelivery.Columns.Count; i++)
                    {
                        if (i == 1 || i == 2)
                        {
                            dgvDelivery.Columns[i].ReadOnly = true;
                        }
                        else
                        {
                            dgvDelivery.Columns[i].ReadOnly = false;
                        }
                    }
                }
            }
            else if (flag == 2)//查看详情
            {
                dgvDelivery.Columns["delete"].Visible = false;
                tsbSave.Visible = false;
                tsbCopy.Visible = false;
                tbDepartment.ReadOnly = true;
                tbRemarks.ReadOnly = true;
                tbStaff.ReadOnly = true;
                tbWarehouse.ReadOnly = true;
                //btnDepartment.Enabled = false;
                //btnStaff.Enabled = false;
                //btnWarehouse.Enabled = false;
                dtpTime.Enabled = false;
                //btnPicking.Enabled = false;

                tbNo.Text=view.DeliveryOrderView.No;
                tbDepartment.Text=view.DeliveryOrderView.WarehouseName;
                tbMakeName.Text=view.DeliveryOrderView.MakeName;
                tbMakeTime.Text=view.DeliveryOrderView.MakeTime;
                tbRemarks.Text=view.DeliveryOrderView.Remarks;
                tbStaff.Text=view.DeliveryOrderView.FoundName;
                tbWarehouse.Text=view.DeliveryOrderView.WarehouseName;
                dtpTime.Value=DateTime.Parse(view.DeliveryOrderView.FoundTime);
                tbPicking.Text=view.DeliveryOrderView.Picking;

                //dgvDelivery.Columns["checkname"].Visible = true;
                dgvDelivery.Columns["audited"].Visible = true;
                dgvDelivery.Columns["checkcounts"].Visible = true;
                dgvDelivery.Columns["checktime"].Visible = true;

                dgvDelivery.DataSource = view.DeliveryViewList;
            }
            if (flag == 3)
            {
                if (view.DeliveryFlag == 1)
                {
                    tbPicking.Text = view.PickingModelSet.No;
                    dgvDelivery.DataSource = view.DeliveryViewBindingList;
                 
                }
            }
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if (flag != 2)
            {
                if (EMMS.Common.SavedInfo.Role == 0 || EMMS.Common.SavedInfo.Role == 2)
                {
                    //dgvDelivery.Columns["checkname"].Visible = true;
                    dgvDelivery.Columns["audited"].Visible = true;
                    dgvDelivery.Columns["checkcounts"].Visible = true;
                    dgvDelivery.Columns["checktime"].Visible = true;
                }
            }
            if (flag == 3 || flag == 4)
            {
                for (int i = 0; i < dgvDelivery.Rows.Count - 1; i++)
                {
                    dgvDelivery.Rows[i].Cells["stocking"].Value = dgvDelivery.Rows[i].Cells["need"].Value;
                }
            }
        }

        private void dgvStocking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvDelivery.EndEdit();
        }

        private void dgvStocking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            index = e.RowIndex;
            if (flag == 0)  //增加时才需要判断
            {
                if (dgvDelivery.Columns[e.ColumnIndex].Name == "materialname")
                {
                    if (tbWarehouse.Text == null || tbWarehouse.Text.ToString() == "")
                    {
                        MessageBox.Show("请先选择仓库！");
                        return;
                    }
                    EMMS.View.storage.List list = new List();
                    list.GetParent(this);
                    list.ShowDialog();
                }
            }
            if (flag == 1 || flag==0 || flag==3 || flag==4) //0,1,3,4时才需要
            {
                if (dgvDelivery.Columns[e.ColumnIndex].Name == "audited")
                {
                    if (dgvDelivery.Rows[e.RowIndex].Cells["audited"].Value == null)
                    {
                        dgvDelivery.Rows[e.RowIndex].Cells["audited"].Value = true;
                    }
                    else if (bool.Parse(dgvDelivery.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == true)
                    {
                        dgvDelivery.Rows[e.RowIndex].Cells["audited"].Value = false;
                        this.Validate();
                    }
                    else if (bool.Parse(dgvDelivery.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == false)
                    {
                        dgvDelivery.Rows[e.RowIndex].Cells["audited"].Value = true;
                        this.Validate();
                    }
                }
            }
            if (flag != 1 && flag != 2) //不是审核也不是查看详情
            {
                if (dgvDelivery.Columns[e.ColumnIndex].Name == "delete")
                {
                    dgvDelivery.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void Stocking_Order_Activated(object sender, EventArgs e)
        {
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            //从GoodsModel中dgvStocking该行赋值
            if (flag == 0) //增加时才需要
            {
                if (base.StorageViewFlag == 1)
                {
                    dgvDelivery.Rows[index].Cells["materialname"].Value = base.StorageModelView.GoodsName;
                    dgvDelivery.Rows[index].Cells["materialno"].Value = base.StorageModelView.GoodsNo;
                    dgvDelivery.Rows[index].Cells["counts"].Value = base.StorageModelView.Counts;
                    dgvDelivery.Rows[index].Cells["critical"].Value = base.StorageModelView.Critical;
                    if (dgvDelivery.Rows[index].Cells["no"].Value == null)
                    {
                        EMMS.Model.Delivery_MaterialSet materialmodel = new Model.Delivery_MaterialSet();
                        dgvDelivery.Rows[index].Cells["no"].Value = materialmodel.No;//出库单-物料联系编码
                    }
                    base.StorageViewFlag = 0;
                }
                if (base.PickingModelFlag == 1)
                {
                    tbPicking.Text = base.PickingModelSet.No;
                    base.PickingModelFlag = 0;
                }
            }
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if ( flag != 1 ) 
            {
                if (base.WarehouseFlag == 1)
                {
                    this.tbWarehouse.Text = base.WarehouseModel.Name;
                    EMMS.Model.Storage_OrderView view = new Model.Storage_OrderView();
                    view.WarehouseName = this.tbWarehouse.Text;
                    base.StorageModelView=view;//赋值
                    base.WarehouseFlag = 0;
                    if (flag == 3 || flag==4) //领料单过来,复制前置单据
                    { 
                        //根据仓库判断库存
                        tbRemarks.Text="";
                        StringBuilder str=new StringBuilder();
                        str.Append("审核前\r\n");
                        //每选一次仓库则清空一次record
                        //record.Clear();
                        EMMS.BLL.Storage_Order storageBll = new BLL.Storage_Order();
                        List<EMMS.Model.Storage_OrderView> storageViewList = storageBll.GetModelListView(tbWarehouse.Text, ""); //得到给出的仓库所有库存
                        for (int i = 0; i < dgvDelivery.Rows.Count-1; i++)
                        {
                            //设置一个布尔变量
                            bool exist = false;
                            for (int j = 0; j < storageViewList.Count; j++)
                            {
                                if (dgvDelivery.Rows[i].Cells["materialno"].Value.Equals(storageViewList[j].GoodsNo)) //能在库存中找到
                                {
                                    exist = true; //存在
                                    int need=int.Parse(dgvDelivery.Rows[i].Cells["need"].Value.ToString());
                                    //找到相同的物料，更改其库存和警戒线
                                    dgvDelivery.Rows[i].Cells["counts"].Value = storageViewList[j].Counts;
                                    dgvDelivery.Rows[i].Cells["critical"].Value = storageViewList[j].Critical;
                                    dgvDelivery.Rows[i].Cells["stocking"].Value = need;

                                    if (need > storageViewList[j].Counts) //所需物料数量>库存数量
                                    {
                                        int range = need - storageViewList[j].Counts;
                                        str.Append(dgvDelivery.Rows[i].Cells["materialname"].Value.ToString() + "库存不够，已切换成库存量，还差" + range.ToString() + "\r\n");
                                        dgvDelivery.Rows[i].Cells["stocking"].Value = storageViewList[j].Counts;
                                    }
                                    //else
                                    //{
                                    //    //int range = storageViewList[j].Counts - need;
                                    //    //if (range < storageViewList[j].Critical) //出库后库存低于警戒线
                                    //    //{
                                    //    //    record.Append(dgvDelivery.Rows[i].Cells["materialname"].Value.ToString() + "低于警戒线，请及时补充！\r\n");
                                    //    //}
                                    //}
                                }
                            }
                            //经过一轮下来，如果exist依旧是false 找不到，说明没有库存
                            if (exist == false)
                            {
                                str.Append(dgvDelivery.Rows[i].Cells["materialname"].Value.ToString() + "没有库存，需要" +dgvDelivery.Rows[i].Cells["need"].Value.ToString()+ "\r\n");
                                dgvDelivery.Rows[i].Cells["stocking"].Value = 0; 
                            }
                        }
                        tbRemarks.Text = str.ToString();
                    }  
                }
            }
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if (flag == 0 || flag == 3 || flag==4)
            {
                if (base.DepartmentFlag == 1)
                {
                    this.tbDepartment.Text = base.DepartmentModel.Name;
                    base.DepartmentFlag = 0;
                }
                if (base.StaffFlag == 1)
                {
                    this.tbStaff.Text = base.StaffModel.Name;//赋值创建人员姓名
                    base.StaffFlag = 0;
                }
            }
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if (flag != 1 && flag!=2)
            {
                EMMS.View.warehouse.List list = new warehouse.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if (flag != 1 && flag!=2)
            {
                EMMS.View.staff.List list = new staff.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            dgvDelivery.EndEdit();
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
            if (string.IsNullOrEmpty(tbDepartment.Text))
            {
                MessageBox.Show("请选择目标仓库！");
                return;
            }

            orderModel.No = tbNo.Text;
            orderModel.Picking = tbPicking.Text;//base.PickingModelSet.No;
            orderModel.FoundTime = dtpTime.Value.ToShortDateString();//出库时间
            orderModel.MakeTime = tbMakeTime.Text;
            
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if (flag == 0 || flag==3 || flag==4)
            {
                orderModel.Warehouse = base.WarehouseModel.No;//得到选择的仓库编码
                orderModel.Department = base.DepartmentModel.No;
                orderModel.FoundNo = base.StaffModel.No;//得到所选择的人员编码
                orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;  
            }
            else if (flag == 1) //审核
            {
                orderModel.Warehouse = view.DeliveryModelSet.Warehouse;
                orderModel.Department = view.DeliveryModelSet.Department;
                orderModel.FoundNo = view.DeliveryModelSet.FoundNo;
                orderModel.MakeNo = view.DeliveryModelSet.MakeNo;
            }

            if (dgvDelivery.Rows[0].Cells["no"].Value==null)
            {
                MessageBox.Show("请填写好相关信息！");
                return;
            }
            bool ended = true;//用来判断是否都已审核，若都已经审核，则设为true，出库单结束
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            int total = 0;
            if (flag == 1) //审核
            {
                total = dgvDelivery.Rows.Count ;
            }
            else 
            {
                total = dgvDelivery.Rows.Count - 1;
            }
            int check = 0;
            for (int i = 0; i < total; i++)//
            {
                if (dgvDelivery.Rows[i].Cells["no"].Value.ToString() != null)
                {
                    EMMS.Model.Delivery_MaterialSet material = new Model.Delivery_MaterialSet();
                    material.No = dgvDelivery.Rows[i].Cells["no"].Value.ToString();
                    material.Delivery = tbNo.Text;//记录联系
                    material.Material = dgvDelivery.Rows[i].Cells["materialno"].Value.ToString();
                    try
                    {
                        //material.Counts表示所需物料
                        material.Counts = int.Parse(dgvDelivery.Rows[i].Cells["need"].Value.ToString()); //所需物料
                        material.Stocking = int.Parse(dgvDelivery.Rows[i].Cells["stocking"].Value.ToString()); //出库数量
                    }
                    catch
                    {
                        MessageBox.Show("请填写正确的出库数目！");
                        return;
                    }
                    if (material.Stocking <= 0)
                    {
                        MessageBox.Show("请填写正确的出库数目！");
                        return;
                    }
                   
                    if (dgvDelivery.Rows[i].Cells["audited"].Value != null)
                    {
                        if (bool.Parse(dgvDelivery.Rows[i].Cells["audited"].Value.ToString()) == true)
                        {
                            material.CheckNo = EMMS.Common.SavedInfo.StaffNo;
                            material.Audited = 1;//表示已审核
                            try
                            {
                                material.CheckCounts = int.Parse(dgvDelivery.Rows[i].Cells["checkcounts"].Value.ToString());
                            }
                            catch
                            {
                                MessageBox.Show("请填写正确的审核数量！");
                            }
                            if (material.CheckCounts <= 0)
                            {
                                MessageBox.Show("请填写正确的审核数目！");
                                return;
                            }
                            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
                            //在保存前判断
                            if (material.CheckCounts > int.Parse(dgvDelivery.Rows[i].Cells["counts"].Value.ToString())) //库存不够
                            {
                                string temp = string.Format("{0}已审核，但库存不够，已转换成库存量，还差{1}", dgvDelivery.Rows[i].Cells["materialname"].Value.ToString(), (material.CheckCounts - (int.Parse(dgvDelivery.Rows[i].Cells["counts"].Value.ToString()))).ToString());
                                //record.Append(dgvDelivery.Rows[i].Cells["materialname"].Value.ToString() + "低于警戒线，请及时补充！\r\n");
                                MessageBox.Show(temp);
                                material.CheckCounts = int.Parse(dgvDelivery.Rows[i].Cells["counts"].Value.ToString());
                                if (check == 0)
                                {
                                    StringBuilder strb1 = new StringBuilder(tbRemarks.Text);
                                    strb1.Append("审核后\r\n");
                                    tbRemarks.Text = strb1.ToString();
                                    check++;
                                }
                                    StringBuilder strb = new StringBuilder(tbRemarks.Text);
                                    strb.Append(temp + "\r\n");
                                    tbRemarks.Text = strb.ToString();
                            }
                            //else
                            //{
                            //    //int range = int.Parse(dgvDelivery.Rows[i].Cells["counts"].Value.ToString()) - material.CheckCounts; //查看余库存
                            //    //if(range<(int.Parse(dgvDelivery.Rows[i].Cells["critical"].Value.ToString())))
                            //    //{
                            //    //    record.Append(dgvDelivery.Rows[i].Cells["materialname"].Value.ToString() + "低于警戒线，请及时补充！\r\n");
                            //    //}
                            //}
                            material.CheckTime = dgvDelivery.Rows[i].Cells["checktime"].Value.ToString();
                        }
                        else
                        {
                            ended = false;
                        }
                    }
                    else
                    {
                        ended = false;
                    }
                    materialList.Add(material);
                }
                orderModel.Remarks = tbRemarks.Text;
            }
            if (ended == true)
            {
                orderModel.Audited = 1;  //都已审核
                orderModel.Ended = 1; //既然都已审核，则出库单结束
            }

            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if (flag == 0 || flag == 3 || flag == 4)
            {
                if (bll.Add(orderModel, materialList))
                {
                    if (ended == true)
                    {
                        MessageBox.Show("保存成功，且已审核完！");
                    }
                    else
                    {
                        MessageBox.Show("保存成功，但未审核完！");
                    }
                    Update(orderModel,materialList,ended);
                }
            }
            else if (flag == 1)
            {
                if (bll.UpdateOrder(orderModel) && bll.UpdateGoods(materialList))
                {
                    if (ended == true)
                    {
                        MessageBox.Show("保存成功，且已审核完！");
                    }
                    else
                    {
                        MessageBox.Show("保存成功，但未审核完！");
                    }
                    Update(orderModel, materialList, ended);
                }
            }
            this.Dispose();
        }
        private void Update(EMMS.Model.Delivery_OrderSet model,List<EMMS.Model.Delivery_MaterialSet> list, bool audited)
        {
            if (audited == true) //审核完
            {
                //更新库存
                EMMS.BLL.Goods goodsBll = new BLL.Goods();
                EMMS.BLL.Storage_Order storageBll = new BLL.Storage_Order();
                //List<EMMS.Model.Storage_OrderView> storageViewList = storageBll.GetModelListView(tbWarehouse.Text, ""); //查找该仓库的库存
                List<EMMS.Model.Requisition_MaterialView> requisitionMaterialList = new List<Model.Requisition_MaterialView>();
                for (int i = 0; i < list.Count; i++)
                { 
                    EMMS.Model.Storage_OrderSet storageSet = storageBll.GetModelByNo(model.Warehouse, list[i].Material);
                    storageSet.Counts -= list[i].CheckCounts;    //库存减少
                    if (storageSet.Critical>storageSet.Counts) //库存低于警戒线
                    {
                        EMMS.Model.Requisition_MaterialView requisitionMaterial = new Model.Requisition_MaterialView();
                        //requisitionMaterial.No;
                        requisitionMaterial.Counts = storageSet.Critical - storageSet.Counts;//请购数量
                        requisitionMaterial.MaterialNo = storageSet.GoodsNo;
                        
                        EMMS.Model.GoodsSet goods = new Model.GoodsSet();
                        goods = goodsBll.GetModel(list[i].Material);
                        record.Append( goods.Name+"库存量低于警戒线\r\n");

                        requisitionMaterial.MaterialName = goods.Name;
                        requisitionMaterialList.Add(requisitionMaterial);
                    }
                    if (storageBll.Update(storageSet))
                    {
                        //MessageBox.Show("库存更新成功！");
                    }
                }   
                //更新领料单，status="已出库",ended=1;已结束
                string picking = model.Picking;
                EMMS.BLL.Picking_Order pickingBll = new BLL.Picking_Order();
                EMMS.Model.Picking_OrderSet pickingSet = pickingBll.GetModel(picking);

                List<EMMS.Model.Picking_MaterialView> pickingViewList = pickingBll.GetModelListView1(picking); //得到与该领料单相关的物料信息
                bool ended = true;//若有一样物料未足够出库，则不能结束物料单

                for (int i = 0; i < pickingViewList.Count; i++) //领料单物料信息
                {
                    for (int j = 0; j < list.Count; j++) //出库单物料信息
                    {
                        if (pickingViewList[i].MaterialNo.Equals(list[j].Material))
                        {
                            if (pickingViewList[i].Counts > pickingViewList[i].Stocking + list[j].CheckCounts) // 物料所需数量>出库数量+已出库数量
                            {
                                ended = false;
                            }
                            //更新物料出库数量
                            pickingViewList[i].Stocking += list[j].CheckCounts; 
                            break;//
                        }
                    }
                }

                if (ended == true)
                {
                    List<EMMS.Model.Picking_MaterialSet> pickingMaterialSetList = new List<Model.Picking_MaterialSet>();
                    for (int i = 0; i < pickingViewList.Count; i++)
                    {
                        EMMS.Model.Picking_MaterialSet set = pickingBll.GetModel1(pickingViewList[i].No);
                        set.Stocking = pickingViewList[i].Stocking;
                        pickingMaterialSetList.Add(set);
                    }

                    pickingSet.Status = "已出库";
                    pickingSet.Ended = 1;

                    if (pickingBll.UpdateOrder(pickingSet))
                    {
                        //MessageBox.Show("领料单更新成功！");
                    }
                    //更新计划单，status="已领料"
                    string plan = pickingSet.PlanNo;
                    EMMS.BLL.Plan_Order planBll = new BLL.Plan_Order();
                    EMMS.Model.Plan_OrderSet planSet = planBll.GetModel(plan);
                    planSet.Status = "已领料";
                    if (planBll.UpdateOrder(planSet))
                    {
                        //MessageBox.Show("生产计划单更新成功！");
                    }
                }
                else
                {
                    List<EMMS.Model.Picking_MaterialSet> pickingMaterialSetList = new List<Model.Picking_MaterialSet>();
                    for (int i = 0; i < pickingViewList.Count; i++)
                    {
                        EMMS.Model.Picking_MaterialSet set = pickingBll.GetModel1(pickingViewList[i].No);
                        set.Stocking = pickingViewList[i].Stocking;
                        pickingMaterialSetList.Add(set);
                    }

                    pickingSet.Status = "已部分出库";
                    if (pickingBll.UpdateOrder(pickingSet) && pickingBll.UpdateGoods(pickingMaterialSetList))
                    {
                        //MessageBox.Show("领料单更新成功！");
                    }
                    //更新计划单
                    string plan = pickingSet.PlanNo;
                    EMMS.BLL.Plan_Order planBll = new BLL.Plan_Order();
                    EMMS.Model.Plan_OrderSet planSet = planBll.GetModel(plan);
                    planSet.Status = "已部分领料";
                    if (planBll.UpdateOrder(planSet))
                    {
                        //MessageBox.Show("生产计划单更新成功！");
                    }
                }
                //首先应该判断已经有与该领料单相关的出库单，若存在，则应该先读取其中出库数目
                //List<EMMS.Model.Delivery_OrderSet> previewOrderList = bll.GetModelListByPicking(picking);

                //若得到的previewOrderList数量==1，则表明是刚才插入的数据
                //if (previewOrderList.Count==1)
                //{
                //    for (int i = 0; i < pickingViewList.Count; i++) //所有的领料单上的物料信息
                //    {
                //        for (int j = 0; j < list.Count; j++)
                //        {
                //            if (pickingViewList[i].MaterialNo.Equals(list[j].Material))  //找到
                //            {
                //                if (pickingViewList[i].Counts > list[j].CheckCounts) //若领料单上物料数量大于出库单上的物料信息
                //                {
                //                    ended = false;
                //                    break;
                //                }
                //            }
                //        }
                //    }
                //    if (ended == true) //如果都已出库
                //    {
                //        pickingSet.Status = "已出库";
                //        pickingSet.Ended = 1;
                //        if (pickingBll.UpdateOrder(pickingSet))
                //        {
                //            MessageBox.Show("领料单更新成功！");
                //        }
                //        更新计划单，status="已领料"
                //        string plan = pickingSet.PlanNo;
                //        EMMS.BLL.Plan_Order planBll = new BLL.Plan_Order();
                //        EMMS.Model.Plan_OrderSet planSet = planBll.GetModel(plan);
                //        planSet.Status = "已领料";
                //        if (planBll.UpdateOrder(planSet))
                //        {
                //            MessageBox.Show("生产计划单更新成功！");
                //        }
                //    }
                //    else
                //    {
                //        pickingSet.Status = "已部分出库";
                //        if (pickingBll.UpdateOrder(pickingSet))
                //        {
                //            MessageBox.Show("领料单更新成功！");
                //        }
                //        更新计划单
                //        string plan = pickingSet.PlanNo;
                //        EMMS.BLL.Plan_Order planBll = new BLL.Plan_Order();
                //        EMMS.Model.Plan_OrderSet planSet = planBll.GetModel(plan);
                //        planSet.Status = "已部分领料";
                //        if (planBll.UpdateOrder(planSet))
                //        {
                //            MessageBox.Show("生产计划单更新成功！");
                //        }
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i < pickingViewList.Count; i++) //从领料单中的得到所需物料
                //    {
                //        int count = 0;
                //        for (int j = 0; j < previewOrderList.Count; j++) //得到之前的出库单
                //        {
                //            if(previewOrderList[j].No.ToString().Equals(model.No))//若是之前插入的数据，则过滤掉
                //            {
                //                continue;
                //            }
                //            List<EMMS.Model.Delivery_MaterialView> previewlist = bll.GetModelListView1(previewOrderList[j].No); //与之相关的物料单
                //            for (int k = 0; k < previewlist.Count; k++)
                //            {
                //                if(pickingViewList[i].MaterialNo.Equals(previewlist[k].MaterialNo))
                //                { 
                //                    count += previewlist[k].CheckCounts;
                //                }
                //            }
                //        }
                //        for (int l = 0; l < list.Count; l++)
                //        {
                //            if (pickingViewList[i].MaterialNo.Equals(list[l].Material))
                //            {
                //                count += list[l].CheckCounts;
                //                if (pickingViewList[i].Counts > count) //依旧不够
                //                {
                //                    ended = false;
                //                    break;
                //                }
                //            }
                //        }
                //    }
                //    if (ended == true)
                //    {
                //        pickingSet.Status = "已出库";
                //        pickingSet.Ended = 1;
                //        if (pickingBll.UpdateOrder(pickingSet))
                //        {
                //            MessageBox.Show("领料单更新成功！");
                //        }

                //        更新计划单，status="已领料"
                //        string plan = pickingSet.PlanNo;
                //        EMMS.BLL.Plan_Order planBll = new BLL.Plan_Order();
                //        EMMS.Model.Plan_OrderSet planSet = planBll.GetModel(plan);
                //        planSet.Status = "已领料";
                //        if (planBll.UpdateOrder(planSet))
                //        {
                //            MessageBox.Show("生产计划单更新成功！");
                //        }
                //    }
                //    else
                //    {
                //        pickingSet.Status = "已部分出库";
                //        if (pickingBll.UpdateOrder(pickingSet))
                //        {
                //            MessageBox.Show("领料单更新成功！");
                //        }
                //        更新计划单
                //        string plan = pickingSet.PlanNo;
                //        EMMS.BLL.Plan_Order planBll = new BLL.Plan_Order();
                //        EMMS.Model.Plan_OrderSet planSet = planBll.GetModel(plan);
                //        planSet.Status = "已部分领料";
                //        if (planBll.UpdateOrder(planSet))
                //        {
                //            MessageBox.Show("生产计划单更新成功！");
                //        }
                //    }
                //}  
                
                //如果低于，则预警
                if (string.IsNullOrEmpty(record.ToString()))
                {
                }
                else
                {
                    record.Append("是否立即生成相应的请购单?");
                    if (MessageBox.Show(record.ToString(), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        EMMS.View.storage.Requisition_Order requisition = new Requisition_Order();
                        requisition.flag = 3;
                        base.RequisitionModelViewList = requisitionMaterialList;
                        //requisition.dgvRequisition.DataSource = requisitionMaterialList;
                        requisition.GetParent(this);
                        requisition.Show();
                    }
                }
            }
            else
            { 
                //更新领料单，status="正在出库"
                string picking = model.Picking;
                EMMS.BLL.Picking_Order pickingBll = new BLL.Picking_Order();
                EMMS.Model.Picking_OrderSet pickingSet = pickingBll.GetModel(picking);
                pickingSet.Status = "正在出库";
                if (pickingBll.UpdateOrder(pickingSet))
                {
                    //MessageBox.Show("领料单更新成功！");
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if (flag != 1 && flag!=2 )
            {
                EMMS.View.staff.Department view = new staff.Department();
                view.GetParent(this);
                view.flag = true;
                view.ShowDialog();
            }
        }

        private void dgvDelivery_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvDelivery.Rows[e.RowIndex].Cells["counts"].Value.ToString() != null)
            //{
            //    dgvDelivery.Rows[e.RowIndex].Cells["checkcounts"].Value = dgvDelivery.Rows[e.RowIndex].Cells["counts"].Value.ToString();
            //}
            //************************管理员或仓库经理***************************************//
            if (dgvDelivery.Columns[e.ColumnIndex].Name == "audited")
            {
                
                if (bool.Parse(dgvDelivery.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)//如果选择了审核
                {
                    if (dgvDelivery.Rows[e.RowIndex].Cells["materialno"].Value==null)
                    {
                        MessageBox.Show("请先选择物料！");
                       dgvDelivery.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false; 
                        return;
                    }
                    if (dgvDelivery.Rows[e.RowIndex].Cells["stocking"].Value==null)
                    {
                        MessageBox.Show("请先填写出库数量！");
                        dgvDelivery.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false; 
                        return;
                    }
                    //dgvDelivery.Rows[e.RowIndex].Cells["checkname"].Value = EMMS.Common.SavedInfo.StaffName;//

                    dgvDelivery.Rows[e.RowIndex].Cells["checkcounts"].Value = dgvDelivery.Rows[e.RowIndex].Cells["stocking"].Value;//

                    dgvDelivery.Rows[e.RowIndex].Cells["checktime"].Value = DateTime.Now.ToShortDateString();
                }
                if (bool.Parse(dgvDelivery.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == false)
                {
                    //dgvDelivery.Rows[e.RowIndex].Cells["checkname"].Value = null;

                    dgvDelivery.Rows[e.RowIndex].Cells["checkcounts"].Value = null;

                    dgvDelivery.Rows[e.RowIndex].Cells["checktime"].Value = null;
                }
            }
            if (dgvDelivery.Columns[e.ColumnIndex].Name == "checkcounts")
            {
                if (dgvDelivery.Rows[e.RowIndex].Cells["no"].Value == null)
                {
                    MessageBox.Show("请先选择物料！");
                    dgvDelivery.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; 
                }
                if (dgvDelivery.Rows[e.RowIndex].Cells["stocking"].Value == null)
                {
                    MessageBox.Show("请先填写出库数量！");
                    dgvDelivery.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    return;
                }
            }
            //************************管理员或仓库经理***************************************//
        }

        private void dgvDelivery_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void btnPicking_Click(object sender, EventArgs e)
        {
            //0增加，1审核，2查看详情，3由领料单过来,4复制前置单据
            if (flag ==0)
            {
                EMMS.View.picking.Query_Picking query = new picking.Query_Picking();
                query.judge = true;
                query.GetParent(this);
                query.Show();
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (EMMS.Common.SavedInfo.DeliveryFlag == 1)
            {
                flag = 4;
                tbPicking.Text = EMMS.Common.SavedInfo.PickingOrderSet.No;
                dgvDelivery.DataSource = EMMS.Common.SavedInfo.DeliveryMaterialViewBindingList;
                
            }
            else
            {
                MessageBox.Show("未检测到与之相关的领料单！");
                return;
            }
        }
    }
}
