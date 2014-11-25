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
    public partial class Stocking_Order
    {
        private readonly EMMS.DAL.Stocking_Order dal = new EMMS.DAL.Stocking_Order();
        public Stocking_Order()
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
        public bool Add(EMMS.Model.Stocking_OrderSet ordermodel,List<EMMS.Model.Stocking_MaterialSet> materialmodelList)
        {
            return dal.Add(ordermodel,materialmodelList);
        }

        /// <summary>
        /// 得到一个对象实体Stocking_OrderSet
        /// </summary>
        public EMMS.Model.Stocking_OrderSet GetModel(string no)
        {

            return dal.GetModel(no);
        }

        //得到一个对象实体Stocking_MaterialSet
        public EMMS.Model.Stocking_MaterialSet GetModel1(string no)
        {
            return dal.GetModel1(no);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        //
        public DataSet GetList1(string strWhere)
        {
            return dal.GetList1(strWhere);
        }
       
        #endregion  BasicMethod

        #region  ExtensionMethod
        ///
        /// 获得数据列表Stocking_OrderView
        /// </summary>
        public List<EMMS.Model.Stocking_OrderView> GetModelListView(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 Stocking_OrderView
        /// </summary>
        public List<EMMS.Model.Stocking_OrderView> DataTableToListView(DataTable dt)
        {
            List<EMMS.Model.Stocking_OrderView> modelList = new List<EMMS.Model.Stocking_OrderView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Stocking_OrderView model;
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

        ///
        /// 获得数据列表Stocking_OrderView
        /// </summary>
        public List<EMMS.Model.Stocking_MaterialView> GetModelListView1(string strWhere)
        {
            DataSet ds = dal.GetList1(strWhere);
            return DataTableToListView1(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 Stocking_OrderView
        /// </summary>
        public List<EMMS.Model.Stocking_MaterialView> DataTableToListView1(DataTable dt)
        {
            List<EMMS.Model.Stocking_MaterialView> modelList = new List<EMMS.Model.Stocking_MaterialView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Stocking_MaterialView model;
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
        #endregion  ExtensionMethod
    }
}

