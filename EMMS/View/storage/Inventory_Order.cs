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
    public partial class Inventory_Order : EMMS.Common.View
    {
        private EMMS.Model.Inventory_OrderSet inventoryOrder = new Model.Inventory_OrderSet();
        private List<EMMS.Model.Inventory_MaterialSet> MaterialSetList = new List<Model.Inventory_MaterialSet>();
        private EMMS.BLL.Inventory_Order inventoryBll = new BLL.Inventory_Order();
        private EMMS.Common.View view;
        public int flag;//默认是0，1表示从领料单过来,2查看详情
        private int count;
        private int index;
        //
        private List<EMMS.Model.Inventory_MaterialView> inventoryMaterialViewList = new List<Model.Inventory_MaterialView>();
        //
        private EMMS.BLL.Picking_Order pickingBll = new BLL.Picking_Order();//得到与领料单相连的物料编码
        private List<EMMS.Model.Picking_MaterialView> pickingMaterilaViewList = new List<Model.Picking_MaterialView>();
        //
        private EMMS.BLL.Storage_Order storageBll = new BLL.Storage_Order();
        private List<EMMS.Model.Storage_OrderView> storageOrderViewList = new List<Model.Storage_OrderView>();
        private EMMS.Model.Storage_OrderSet storageOrder = new Model.Storage_OrderSet();
        
        public Inventory_Order()
        {
            InitializeComponent();
            flag = 0;
            count = 0;
            index = -1;
        }

        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        private void BindData()
        {
            //清空
            //Init();
            tbRemarks.ReadOnly = true;
            tbRemarks.Text = "";
            dgvInventory.DataSource = null;
            inventoryMaterialViewList.Clear();
            //得到库存物料
            storageOrderViewList = storageBll.GetModelListView(tbWarehouse.Text, ""); 
            //
            for (int i = 0; i < pickingMaterilaViewList.Count; i++) //领料单中物料信息
            {
                bool judge = true;
                for (int j = 0; j < storageOrderViewList.Count; j++) //库存中物料信息
                {
                    if (pickingMaterilaViewList[i].MaterialName.Equals(storageOrderViewList[j].GoodsName)) //如果相等
                    {
                        EMMS.Model.Inventory_MaterialView temp= new Model.Inventory_MaterialView();
                        //temp.No=
                        temp.GoodsName = pickingMaterilaViewList[i].MaterialName;
                        temp.Counts = storageOrderViewList[j].Counts; //物料库存量
                        temp.Critical = storageOrderViewList[j].Critical; //境界线
                        temp.Need = pickingMaterilaViewList[i].Counts;//物料需求量
                        temp.GoodsNo = pickingMaterilaViewList[i].MaterialNo;//物料编码
                        inventoryMaterialViewList.Add(temp);
                        if (temp.Counts < temp.Need)
                        {
                            tbRemarks.Text +=temp.GoodsName+"库存不够，还差"+(temp.Need-temp.Counts).ToString()+"\r\n";
                        }
                        judge = false;
                        break;
                    }
                }
                if (judge == true)
                {
                    tbRemarks.Text += pickingMaterilaViewList[i].MaterialName + "没有库存，差" + pickingMaterilaViewList[i].Counts.ToString() + "\r\n";
                }
            }
            dgvInventory.DataSource = inventoryMaterialViewList;
            this.Validate();
            //dgvInventory.Columns[0].HeaderText = "编码";
            //dgvInventory.Columns[1].HeaderText = "物料名称";
            //dgvInventory.Columns[2].HeaderText = "库存量";
            //dgvInventory.Columns[3].HeaderText = "警戒线";
            //dgvInventory.Columns[4].HeaderText = "所需物料量";
            //dgvInventory.Columns[5].HeaderText = "物料编码";
            //dgvInventory.Columns[5].Visible = false;
        }
        private void Init()
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "No";
            c1.Name = "no";
            c1.HeaderText = "编码";
            c1.ValueType = typeof(string);
            dgvInventory.Columns.Add(c1);

            DataGridViewButtonColumn c2 = new DataGridViewButtonColumn();
            c2.DataPropertyName = "GoodsName";
            c2.Name = "goodsname";
            c2.FlatStyle = FlatStyle.Flat;
            c2.HeaderText = "物料名称";
            c2.ValueType = typeof(string);
            dgvInventory.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Counts";
            c3.Name = "counts";
            c3.HeaderText = "库存量";
            c3.ValueType = typeof(int);
            dgvInventory.Columns.Add(c3);

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Critical";
            c4.Name = "critical";
            c4.HeaderText = "警戒线";
            c4.ValueType = typeof(int);
            dgvInventory.Columns.Add(c4);

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Need";
            c5.Name = "need";
            c5.HeaderText = "所需物料量";
            c5.ValueType = typeof(int);
            dgvInventory.Columns.Add(c5);

            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "GoodsNo";
            c6.Name = "goodsno";
            c6.HeaderText = "物料编码";
            c6.ValueType = typeof(string);
            dgvInventory.Columns.Add(c6);
            dgvInventory.Columns["goodsno"].Visible = false;
        }
        private void Inventory_Order_Load(object sender, EventArgs e)
        {
            //BindData();
            Init();
            if (flag != 2)
            {
                tbWarehouse.Text = "";
            }
            tbNo.Text = inventoryOrder.No;
            tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
            tbMakeTime.Text = DateTime.Now.ToShortDateString();
            //
            if (flag == 1)
            {
                if (view.PickingModelFlag == 1)
                {
                    //得到与之相关的领料单编码
                    string no = view.PickingModelSet.No;
                    //得到与领料单关联的物料
                    pickingMaterilaViewList = pickingBll.GetModelListView1(no);
                }
            }
            else if (flag == 2)
            {
                tsbSave.Visible = false;
                //btnFound.Enabled = false;
                //btnWarehouse.Enabled = false;
                tbRemarks.ReadOnly = true;
                dtpTime.Enabled = false;

                dgvInventory.DataSource = view.InventoryViewList;
            }
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            if (flag != 2)
            {
                EMMS.View.warehouse.List list = new warehouse.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void Inventory_Order_Activated(object sender, EventArgs e)
        {
            //默认是0，1表示从领料单过来,2查看详情
            if (flag != 2)
            {
                if (count == 0)
                {
                    count++;
                    MessageBox.Show("请先选择仓库！");
                }

                if (base.StaffFlag == 1)
                {
                    tbFoundName.Text = base.StaffModel.Name;
                    base.StaffFlag = 0;
                }
                if (base.WarehouseFlag == 1)
                {
                    tbWarehouse.Text = base.WarehouseModel.Name;
                    base.WarehouseFlag = 0;
                }
                if (flag == 0)
                {
                    if (base.StorageViewFlag == 1 && base.StorageSetFlag == 1)
                    {
                        EMMS.Model.Inventory_MaterialSet set = new Model.Inventory_MaterialSet();
                        dgvInventory.Rows[index].Cells["no"].Value = set.No;
                        dgvInventory.Rows[index].Cells["goodsname"].Value = base.StorageModelView.GoodsName;
                        dgvInventory.Rows[index].Cells["counts"].Value = base.StorageModelView.Counts;
                        dgvInventory.Rows[index].Cells["critical"].Value = base.StorageModelView.Critical;
                        dgvInventory.Rows[index].Cells["goodsno"].Value = base.StorageModelSet.GoodsNo;
                    }
                    base.StorageSetFlag = 0;
                    base.StorageViewFlag = 0;
                }
            }
        }

        private void tbWarehouse_TextChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                BindData();
            }
        }

        private void btnFound_Click(object sender, EventArgs e)
        {
            if (flag != 2)
            {
                EMMS.View.staff.List list = new staff.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            this.dgvInventory.EndEdit();
            //保存
            if (tbFoundName.Text == "")
            {
                MessageBox.Show("经手人未填写！");
                return;
            }
            if (tbWarehouse.Text == "")
            {
                MessageBox.Show("仓库未填写！");
                return;
            }
            //inventoryOrder.No
            inventoryOrder.Warehouse = base.WarehouseModel.No;
            inventoryOrder.FoundNo = base.StaffModel.No;
            inventoryOrder.FoundTime = dtpTime.Value.ToShortDateString();
            inventoryOrder.MakeNo = EMMS.Common.SavedInfo.StaffNo;
            inventoryOrder.MakeTime = tbMakeTime.Text;
            if (flag == 1)
            {
                inventoryOrder.Picking = view.PickingModelSet.No;
            }
            inventoryOrder.Remarks = tbRemarks.Text;

            int total = 0;
            if (flag == 0)
            {
                total = dgvInventory.Rows.Count - 1;
            }
            else
            {
                total = dgvInventory.Rows.Count;
            }
            List<EMMS.Model.Requisition_MaterialView> requisitionMaterialList = new List<Model.Requisition_MaterialView>();
            for (int i = 0; i < total; i++)
            {
                EMMS.Model.Inventory_MaterialSet set = new Model.Inventory_MaterialSet();
                set.No = dgvInventory.Rows[i].Cells["no"].Value.ToString();
                set.Inventory = tbNo.Text;
                set.Goods = dgvInventory.Rows[i].Cells["goodsno"].Value.ToString();
                set.Counts = int.Parse(dgvInventory.Rows[i].Cells["counts"].Value.ToString());
                set.Critical = int.Parse(dgvInventory.Rows[i].Cells["critical"].Value.ToString());
                set.Need = int.Parse(dgvInventory.Rows[i].Cells["need"].Value.ToString());
                if (set.Counts < set.Need)//如果库存不够
                {
                    EMMS.Model.Requisition_MaterialView requisitionMaterial = new Model.Requisition_MaterialView();
                    //requisitionMaterial.No;
                    requisitionMaterial.MaterialName = dgvInventory.Rows[i].Cells["goodsname"].Value.ToString();
                    requisitionMaterial.Counts = int.Parse(dgvInventory.Rows[i].Cells["need"].Value.ToString())- int.Parse(dgvInventory.Rows[i].Cells["counts"].Value.ToString());
                    requisitionMaterial.MaterialNo = dgvInventory.Rows[i].Cells["goodsno"].Value.ToString();
                    requisitionMaterialList.Add(requisitionMaterial);
                }
                MaterialSetList.Add(set);
            }
            if (inventoryBll.Add(inventoryOrder, MaterialSetList))
            {
                MessageBox.Show("保存成功！");
                if (requisitionMaterialList.Count > 0)
                {
                    if (MessageBox.Show("是否将库存不够的生成请购单？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        EMMS.View.storage.Requisition_Order requisition = new Requisition_Order();
                        requisition.flag = 3;
                        base.RequisitionModelViewList = requisitionMaterialList;
                        //requisition.dgvRequisition.DataSource = requisitionMaterialList;
                        requisition.GetParent(this);
                        requisition.Show();
                    }
                }
                this.Dispose();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (flag == 0)
            {
                if (dgvInventory.Columns[e.ColumnIndex].Name == "goodsname")
                {
                    if (string.IsNullOrEmpty(tbWarehouse.Text))
                    {
                        MessageBox.Show("请先选择仓库！");
                        return;
                    }
                    EMMS.Model.Storage_OrderView storageView = new Model.Storage_OrderView();
                    base.StorageModelView = storageView;
                    base.StorageModelView.WarehouseName = tbWarehouse.Text;
                    EMMS.View.storage.List list = new List();
                    list.GetParent(this);
                    list.ShowDialog();
                }
            }
        }

        private void dgvInventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }
    }
}
