using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EMMS.Common
{
    public class SavedInfo
    {
        public static int Role;//保存角色
        public static string UserNo;//当前用户编码
        public static string UserName;//当前用户名
        public static string StaffNo;//当前人员编码
        public static string StaffName;//当前人员名称
        public static bool IsAlterPws = false;

        //采购单
        public static int PurchasingFlag;
        public static EMMS.Model.Requisition_OrderSet RequisitionOrderSet;
        public static List<EMMS.Model.Purchasing_MaterialView> PurchasingMaterialViewList;
        //应付款项单
        public static int PayingFlag;
        public static EMMS.Model.Entry_OrderSet EntryOrderSet;
        public static List<EMMS.Model.Paying_MaterialView> PayingMaterialViewList;
        //付款结算单
        public static int PayedFlag;
        public static EMMS.Model.Paying_OrderSet PayingOrderSet;
        public static List<EMMS.Model.Payed_MaterialView> PayedMaterialViewList;
        //物料入库单
        public static int StockingFlag;
        public static EMMS.Model.Entry_OrderSet EntryOrderSet1;
        public static List<EMMS.Model.Stocking_MaterialView> StockingMaterialViewList;
        //成品入库单
        public static int StockingFlag1;
        public static EMMS.Model.Plan_OrderSet PlanOrderSet;
        public static List<EMMS.Model.Stocking_MaterialView> StockingMaterialViewList1;
        //出库单
        public static int DeliveryFlag;
        public static EMMS.Model.Picking_OrderSet PickingOrderSet;
        public static List<EMMS.Model.Delivery_MaterialView> DeliveryMaterialViewList;
        public static BindingList<EMMS.Model.Delivery_MaterialView> DeliveryMaterialViewBindingList;
    }
    public class Stack<T>
    {
        public List<T> StackList = new List<T>();
        public int Top;
        //public Stack(List<T> t)
        //{
        //    this.StackList = t;
        //}
        public void Init()
        {
            Top = -1;
        }
        public void Push(T obj)
        {
            StackList.Add(obj);
            Top++;
        }
        public void Pop(out T obj)
        {
            obj = StackList[Top];
            StackList.RemoveAt(Top);
            Top--;
        }
    }
}
