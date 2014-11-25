using System;
using System.Data;
using System.Collections.Generic;
using EMMS.Common;
using EMMS.Model;
using System.Windows.Forms;
namespace EMMS.BLL
{
    //业务逻辑层
    /// <summary>
    /// tb_warehouse
    /// </summary>
    public partial class Requisition_Order
    {
        private readonly EMMS.DAL.Requisition_Order dal = new EMMS.DAL.Requisition_Order();
        public Requisition_Order()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        //public bool Exists(string no)
        //{
        //    return dal.Exists(no);
        //}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.Requisition_OrderSet ordermodel, List<EMMS.Model.Requisition_MaterialSet> productionmodelList)
        {
            return dal.Add(ordermodel, productionmodelList);
        }
        //更新
        public bool UpdateOrder(EMMS.Model.Requisition_OrderSet ordermodel)
        {
            return dal.UpdateOrder(ordermodel);
        }
        //
        public bool UpdateGoods(List<EMMS.Model.Requisition_MaterialSet> productionmodelList)
        {
            return dal.UpdateGoods(productionmodelList);
        }


        /// <summary>
        /// 得到一个对象实体Requisition_OrderSet
        /// </summary>
        public EMMS.Model.Requisition_OrderSet GetModel(string no)
        {

            return dal.GetModel(no);
        }
        //得到一个对象实体Requisition_MaterialSet
        public EMMS.Model.Requisition_MaterialSet GetModel1(string no)
        {
            return dal.GetModel1(no);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    return dal.GetList(strWhere);
        //}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<EMMS.Model.WarehouseGet> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<EMMS.Model.WarehouseGet> DataTableToList(DataTable dt)
        //{
        //    List<EMMS.Model.WarehouseGet> modelList = new List<EMMS.Model.WarehouseGet>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        EMMS.Model.WarehouseGet model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = dal.DataRowToModel(dt.Rows[n]);
        //            if (model != null)
        //            {
        //                modelList.Add(model);
        //            }
        //        }
        //    }
        //    return modelList;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}

        /// <summary>
        /// 获得数据总数
        /// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    return dal.GetRecordCount(strWhere);
        //}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        //}

        #endregion  BasicMethod

        #region  ExtensionMethod
        ///
        /// 获得数据列表Requisition_OrderView
        /// </summary>
        public List<EMMS.Model.Requisition_OrderView> GetModelListView(string strWhere, string strWhere1)
        {
            DataSet ds = dal.GetList(strWhere, strWhere1);
            return DataTableToListView(ds.Tables[0]);
        }

        public List<EMMS.Model.Requisition_MaterialView> GetModelListView1(string planno)
        {
            DataSet ds = dal.GetList1(planno);
            return DataTableToListView1(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 Requisition_OrderView
        /// </summary>
        public List<EMMS.Model.Requisition_OrderView> DataTableToListView(DataTable dt)
        {
            List<EMMS.Model.Requisition_OrderView> modelList = new List<EMMS.Model.Requisition_OrderView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Requisition_OrderView model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelView(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public List<EMMS.Model.Requisition_MaterialView> DataTableToListView1(DataTable dt)
        {
            List<EMMS.Model.Requisition_MaterialView> modelList = new List<EMMS.Model.Requisition_MaterialView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Requisition_MaterialView model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelView1(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        //得到tb_warehouseAttri中仓库类别名称
        //public List<TreeNode> GetNodeList()
        //{
        //    return dal.GetNodeList();
        //}
        ////根据名称获取
        //public List<EMMS.Model.Requisition_OrderView> GetModelListViewByName(string name)
        //{
        //    DataSet ds = dal.GetList(name);
        //    return DataTableToListView(ds.Tables[0]);
        //}
        #endregion  ExtensionMethod
    }
}

