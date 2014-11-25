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
    public partial class Storage_Order
    {
        private readonly EMMS.DAL.Storage_Order dal = new EMMS.DAL.Storage_Order();
        public Storage_Order()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            return dal.Exists(no);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.Storage_OrderSet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EMMS.Model.Storage_OrderSet model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string no)
        {

            return dal.Delete(no);
        }
        /// <summary>
        /// 删除一组数据
        /// </summary>
        public bool DeleteList(string nolist)
        {
            return dal.DeleteList(EMMS.Common.PageValidate.SafeLongFilter(nolist, 0));
        }

        /// <summary>
        /// 得到一个对象实体Storage_OrderSet
        /// </summary>
        public EMMS.Model.Storage_OrderSet GetModel(string no)
        {

            return dal.GetModel(no);
        }
        //
        public EMMS.Model.Storage_OrderSet GetModelByNo(string warehouseno,string goodsno)
        {

            return dal.GetModelByNo(warehouseno,goodsno);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWarehouse,string strGoods)
        {
            return dal.GetList(strWarehouse,strGoods);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<EMMS.Model.Storage_OrderGet> GetModelList(string strWarehouse,string strGoods)
        //{
        //    DataSet ds = dal.GetList(strWarehouse,strGoods);
        //    return DataTableToList(ds.Tables[0]);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<EMMS.Model.Storage_OrderGet> DataTableToList(DataTable dt)
        //{
        //    List<EMMS.Model.Storage_OrderGet> modelList = new List<EMMS.Model.Storage_OrderGet>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        EMMS.Model.Storage_OrderGet model;
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
        public int GetRecordCount(string strWhere,string strWhere1)
        {
            return dal.GetRecordCount(strWhere,strWhere1);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  BasicMethod

        #region  ExtensionMethod
        ///
        /// 获得数据列表Storage_OrderView
        /// </summary>
        public List<EMMS.Model.Storage_OrderView> GetModelListView(string strWarehouse,string strGoods)
        {
            DataSet ds = dal.GetList(strWarehouse,strGoods);
            return DataTableToListView(ds.Tables[0]);
        }
        public List<EMMS.Model.Storage_OrderView> GetListBelowCritical()
        {
            DataSet ds = dal.GetListBelowCritical();
            return DataTableToListView(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 Storage_OrderView
        /// </summary>
        public List<EMMS.Model.Storage_OrderView> DataTableToListView(DataTable dt)
        {
            List<EMMS.Model.Storage_OrderView> modelList = new List<EMMS.Model.Storage_OrderView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Storage_OrderView model;
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
        //得到tb_warehouseAttri中仓库类别名称
        public List<TreeNode> GetNodeList(int flag)
        {
            return dal.GetNodeList(flag);
        }
        ////根据名称获取
        //public List<EMMS.Model.Storage_OrderView> GetModelListViewByName(string name)
        //{
        //    DataSet ds = dal.GetList(name);
        //    return DataTableToListView(ds.Tables[0]);
        //}
        #endregion  ExtensionMethod
    }
}

