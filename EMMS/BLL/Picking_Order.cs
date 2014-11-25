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
    public partial class Picking_Order
    {
        private readonly EMMS.DAL.Picking_Order dal = new EMMS.DAL.Picking_Order();
        public Picking_Order()
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
        public bool Add(EMMS.Model.Picking_OrderSet ordermodel, List<EMMS.Model.Picking_MaterialSet> materialmodelList)
        {
            return dal.Add(ordermodel, materialmodelList);
        }
        //更新
        public bool UpdateOrder(EMMS.Model.Picking_OrderSet ordermodel)
        {
            return dal.UpdateOrder(ordermodel);
        }
        //
        public bool UpdateGoods(List<EMMS.Model.Picking_MaterialSet> materialmodelList)
        {
            return dal.UpdateGoods(materialmodelList);
        }


        /// <summary>
        /// 得到一个对象实体Picking_OrderSet
        /// </summary>
        public EMMS.Model.Picking_OrderSet GetModel(string no)
        {

            return dal.GetModel(no);
        }
        //得到一个对象实体Picking_MaterialSet
        public EMMS.Model.Picking_MaterialSet GetModel1(string no)
        {
            return dal.GetModel1(no);
        }

        #endregion  BasicMethod

        #region  ExtensionMethod
        ///
        /// 获得数据列表Picking_OrderView
        /// </summary>
        public List<EMMS.Model.Picking_OrderView> GetModelListView(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListView(ds.Tables[0]);
        }

        public List<EMMS.Model.Picking_MaterialView> GetModelListView1(string no)
        {
            DataSet ds = dal.GetList1(no);
            return DataTableToListView1(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表 Picking_OrderView
        /// </summary>
        public List<EMMS.Model.Picking_OrderView> DataTableToListView(DataTable dt)
        {
            List<EMMS.Model.Picking_OrderView> modelList = new List<EMMS.Model.Picking_OrderView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Picking_OrderView model;
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

        public List<EMMS.Model.Picking_MaterialView> DataTableToListView1(DataTable dt)
        {
            List<EMMS.Model.Picking_MaterialView> modelList = new List<EMMS.Model.Picking_MaterialView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Picking_MaterialView model;
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

