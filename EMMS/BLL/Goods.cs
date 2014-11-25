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
    /// tb_goods
    /// </summary>
    public partial class Goods
    {
        private readonly EMMS.DAL.Goods dal = new EMMS.DAL.Goods();
        public Goods()
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
        public bool Add(EMMS.Model.GoodsSet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EMMS.Model.GoodsSet model)
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string nolist)
        {
            return dal.DeleteList(EMMS.Common.PageValidate.SafeLongFilter(nolist, 0));
        }

        /// <summary>
        /// 得到一个对象实体GoodsSet
        /// </summary>
        public EMMS.Model.GoodsSet GetModel(string no)
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
        public List<EMMS.Model.GoodsGet> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EMMS.Model.GoodsGet> DataTableToList(DataTable dt)
        {
            List<EMMS.Model.GoodsGet> modelList = new List<EMMS.Model.GoodsGet>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.GoodsGet model;
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
        /// 分页获取数据列表
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
        /// 获得数据列表GoodsView
        /// </summary>
        public List<EMMS.Model.GoodsView> GetModelListView(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }
        //
        public List<EMMS.Model.GoodsView> GetModelListViewByNumber(string strWhere)
        {
            DataSet ds = dal.GetListByNumber(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }
        public List<EMMS.Model.GoodsView> GetModelListViewByNumber1(string strWhere,string strWhere1)
        {
            DataSet ds = dal.GetListByNumber1(strWhere,strWhere1);
            return DataTableToListView(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 GoodsView
        /// </summary>
        public List<EMMS.Model.GoodsView> DataTableToListView(DataTable dt)
        {
            List<EMMS.Model.GoodsView> modelList = new List<EMMS.Model.GoodsView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.GoodsView model;
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
        //得到tb_goodsAttri中物品类别名称
        public List<TreeNode> GetNodeList()
        {
            return dal.GetNodeList();
        }
        #endregion  ExtensionMethod
    }
}

