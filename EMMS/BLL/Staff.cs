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
    /// tb_staff
    /// </summary>
    public partial class Staff
    {
        private readonly EMMS.DAL.Staff dal = new EMMS.DAL.Staff();
        public Staff()
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
        public bool Add(EMMS.Model.StaffSet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EMMS.Model.StaffSet model)
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
        /// 得到一个对象实体StaffSet
        /// </summary>
        public EMMS.Model.StaffSet GetModel(string no)
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
        public List<EMMS.Model.StaffGet> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EMMS.Model.StaffGet> DataTableToList(DataTable dt)
        {
            List<EMMS.Model.StaffGet> modelList = new List<EMMS.Model.StaffGet>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.StaffGet model;
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
        /// 获得数据列表StaffView
        /// </summary>
        public List<EMMS.Model.StaffView> GetModelListView(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }
        //
        public List<EMMS.Model.StaffView> GetModelListViewByResign(string strWhere)
        {
            DataSet ds = dal.GetListByResign(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }
        //
        public List<EMMS.Model.StaffView> GetModelListViewByLogin(string strWhere)
        {
            DataSet ds = dal.GetListByLogin(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 StaffView
        /// </summary>
        public List<EMMS.Model.StaffView> DataTableToListView(DataTable dt)
        {
            List<EMMS.Model.StaffView> modelList = new List<EMMS.Model.StaffView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.StaffView model;
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
        //得到名称,flag为0表示得到部门名称，1表示得到职务名称
        public List<TreeNode> GetNodeList(int flag)
        {
            return dal.GetNodeList(flag);
        }
        
        #endregion  ExtensionMethod
    }
}

