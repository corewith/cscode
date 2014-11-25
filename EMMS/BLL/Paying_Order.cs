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
    public partial class Paying_Order
    {
        private readonly EMMS.DAL.Paying_Order dal = new EMMS.DAL.Paying_Order();
        public Paying_Order()
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
        public bool Add(EMMS.Model.Paying_OrderSet ordermodel, List<EMMS.Model.Paying_MaterialSet> materialmodelList)
        {
            return dal.Add(ordermodel, materialmodelList);
        }
        //更新
        public bool UpdateOrder(EMMS.Model.Paying_OrderSet ordermodel)
        {
            return dal.UpdateOrder(ordermodel);
        }
        //
        public bool UpdateGoods(List<EMMS.Model.Paying_MaterialSet> materialmodelList)
        {
            return dal.UpdateGoods(materialmodelList);
        }


        /// <summary>
        /// 得到一个对象实体Paying_OrderSet
        /// </summary>
        public EMMS.Model.Paying_OrderSet GetModel(string no)
        {

            return dal.GetModel(no);
        }
        //得到一个对象实体Paying_MaterialSet
        public EMMS.Model.Paying_MaterialSet GetModel1(string no)
        {
            return dal.GetModel1(no);
        }

        #endregion  BasicMethod

        #region  ExtensionMethod
        ///
        /// 获得数据列表Paying_OrderView
        /// </summary>
        public List<EMMS.Model.Paying_OrderView> GetModelListView(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }

        public List<EMMS.Model.Paying_MaterialView> GetModelListView1(string no)
        {
            DataSet ds = dal.GetList1(no);
            return DataTableToListView1(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 Paying_OrderView
        /// </summary>
        public List<EMMS.Model.Paying_OrderView> DataTableToListView(DataTable dt)
        {
            List<EMMS.Model.Paying_OrderView> modelList = new List<EMMS.Model.Paying_OrderView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Paying_OrderView model;
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

        public List<EMMS.Model.Paying_MaterialView> DataTableToListView1(DataTable dt)
        {
            List<EMMS.Model.Paying_MaterialView> modelList = new List<EMMS.Model.Paying_MaterialView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Paying_MaterialView model;
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

