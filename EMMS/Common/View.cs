using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace EMMS.Common
{
    public class View:Form
    {
        public View()
        {
            GoodsFlag = 0;
            StaffFlag = 0;
            WarehouseFlag = 0;
            JobFlag = 0;
            DepartmentFlag = 0;
            GoodsAttriFlag = 0;
            StorageSetFlag = 0;
            //CheckFlag = 0;//默认是0，表示这是创建人员的编码
            StorageViewFlag = 0;
            ProductionModelViewFlag = 0;
            PlanFlag = 0;
            //DMViewFlag = 0;
            DeliveryFlag = 0;
            PickingModelFlag = 0;
            RequisitionModelViewFlag = 0;
            SupplierFlag = 0;
            PurchasingModelViewFlag = 0;
            EntryModelFlag = 0;
            MaterialFlag=0;
        }
        public EMMS.Model.GoodsSet GoodsModel { get; set; }
        public EMMS.Model.StaffSet StaffModel { get; set; }
        public EMMS.Model.WarehouseSet WarehouseModel { get; set; }
        public EMMS.Model.Job JobModel { get; set; }
        public EMMS.Model.Department DepartmentModel { get; set; }
        public EMMS.Model.GoodsAttri GoodsAttriModel { get; set; }
        public EMMS.Model.Storage_OrderSet StorageModelSet { get; set; }
        public EMMS.Model.Plan_OrderSet PlanModelSet { get; set; }//
        public EMMS.Model.Picking_OrderSet PickingModelSet { get; set; }
        public EMMS.Model.Delivery_OrderSet DeliveryModelSet { get; set; }
        public EMMS.Model.Requisition_OrderSet RequisitionModelSet { get; set; }
        public EMMS.Model.Requisition_OrderView RequisitionModelView { get; set; }
        public EMMS.Model.Supplier SupplierModel { get; set; }
        public EMMS.Model.Purchasing_OrderSet PurchasingModelSet { get; set; }
        public EMMS.Model.Entry_MaterialSet EntryMaterialSet { get; set; }
        public EMMS.Model.Entry_OrderSet EntryModelSet { get; set; }
        public EMMS.Model.Entry_OrderView EntryModelView { get; set; }
        public EMMS.Model.Paying_OrderSet PayingModelSet { get; set; }
        public EMMS.Model.Paying_OrderView PayingModelView { get; set; }
        public EMMS.Model.Payed_OrderSet PayedModelSet { get; set; }
        public EMMS.Model.Payed_OrderView PayedModelView { get; set; }

        public int GoodsFlag { get; set; }
        public int StaffFlag { get; set; }
        public int WarehouseFlag { get; set; }
        public int JobFlag { get; set; }
        public int DepartmentFlag { get; set; }
        public int GoodsAttriFlag { get; set; }
        public int StorageSetFlag { get; set; }
        //public int CheckFlag { get; set; }//用来判断是创建人员编码还是审核人员编码
        public int ProductionModelViewFlag { get; set; }
        public int PMFlag { get; set; }
        public int PlanFlag { get; set; }
        public int DeliveryFlag { get; set; }
        //public int DMViewFlag { get; set; }
        public int PickingModelFlag { get; set; }
        public int RequisitionModelViewFlag { get; set; }
        public int SupplierFlag { get; set; }
        public int PurchasingModelViewFlag { get; set; }
        public int EntryModelFlag { get; set; }
        public int PayingModelFlag { get; set; }
        public int PayedModelFlag { get; set; }
        public int MaterialFlag{get;set;}
        public int StockingFlag { get; set; }

        public int StorageViewFlag { get; set; }
        public EMMS.Model.Storage_OrderView StorageModelView { get; set; }//
        public List<EMMS.Model.Plan_ProductionView> ProductionModelViewList { get; set; }
        public EMMS.Model.Picking_OrderView PickingModelView { get; set; }
        public EMMS.Model.Plan_OrderView PlanModelView { get; set; }
        public List<EMMS.Model.Picking_MaterialView> PMList { get; set; }
        //public List<EMMS.Model.Delivery_MaterialView> DMViewList { get; set; }
        public EMMS.Model.Delivery_OrderView DeliveryOrderView { get; set; }
        public List<EMMS.Model.Requisition_MaterialView> RequisitionModelViewList { get; set; }
        public EMMS.Model.Purchasing_OrderView PurchasingModelView { get; set; }
        public List<EMMS.Model.Purchasing_MaterialView> PurchasingModelViewList { get; set; }
        public List<EMMS.Model.Entry_MaterialView> EntryModelViewList { get; set; }
        public List<EMMS.Model.Paying_MaterialView> PayingModelViewList { get; set; }
        public List<EMMS.Model.Payed_MaterialView> PayedModelViewList { get; set; }
        public List<EMMS.Model.MaterialNameView> MaterialView{ get;set;}
        public EMMS.Model.Stocking_OrderView StockingOrderView { get; set; }
        public List<EMMS.Model.Stocking_MaterialView> StockingViewList { get; set; }
        public List<EMMS.Model.Delivery_MaterialView> DeliveryViewList { get; set; }
        public BindingList<EMMS.Model.Delivery_MaterialView> DeliveryViewBindingList { get; set; }
        public List<EMMS.Model.Inventory_MaterialView> InventoryViewList { get; set; }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // View
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "View";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);

        }

        private void View_Load(object sender, EventArgs e)
        {

        }
    }
}
