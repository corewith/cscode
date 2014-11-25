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
    public partial class Warehouse
    {
        private readonly EMMS.DAL.Warehouse dal = new EMMS.DAL.Warehouse();
        public Warehouse()
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
        public bool Add(EMMS.Model.WarehouseSet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EMMS.Model.WarehouseSet model)
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
        /// 得到一个对象实体warehouseSet
        /// </summary>
        public EMMS.Model.WarehouseSet GetModel(string no)
        {

            return dal.GetModel(no);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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
        public List<EMMS.Model.WarehouseGet> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EMMS.Model.WarehouseGet> DataTableToList(DataTable dt)
        {
            List<EMMS.Model.WarehouseGet> modelList = new List<EMMS.Model.WarehouseGet>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.WarehouseGet model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
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
        /// 获得数据列表warehouseView
        /// </summary>
        public List<EMMS.Model.WarehouseView> GetModelListView(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }
        //
        public List<EMMS.Model.WarehouseView> GetModelListViewByNumber(string strWhere)
        {
            DataSet ds = dal.GetListByNumber(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 warehouseView
        /// </summary>
        public List<EMMS.Model.WarehouseView> DataTableToListView(DataTable dt)
        {
            List<EMMS.Model.WarehouseView> modelList = new List<EMMS.Model.WarehouseView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.WarehouseView model;
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
        public List<TreeNode> GetNodeList()
        {
            return dal.GetNodeList();
        }
        ////根据名称获取
        //public List<EMMS.Model.WarehouseView> GetModelListViewByName(string name)
        //{
        //    DataSet ds = dal.GetList(name);
        //    return DataTableToListView(ds.Tables[0]);
        //}
        #endregion  ExtensionMethod
    }
}

