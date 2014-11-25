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
    public partial class Production_Material
    {
        private readonly EMMS.DAL.Production_Material dal = new EMMS.DAL.Production_Material();
        public Production_Material()
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
        public bool Add(EMMS.Model.Production_MaterialSet model)
        {
            return dal.Add(model);
        }
        //
        public bool AddList(List<EMMS.Model.Production_MaterialSet> modelList)
        {
            return dal.AddList(modelList);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EMMS.Model.Production_MaterialSet model)
        {
            return dal.Update(model);
        }
        //
        public bool UpdateList(List<EMMS.Model.Production_MaterialSet> modelList)
        {
            return dal.UpdateList(modelList);
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
            return dal.DeleteList(nolist);//EMMS.Common.PageValidate.SafeLongFilter(nolist, 0));
        }

        /// <summary>
        /// 得到一个对象实体Production_MaterialSet
        /// </summary>
        public EMMS.Model.Production_MaterialSet GetModel(string no)
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
        //public List<EMMS.Model.Production_MaterialGet> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<EMMS.Model.Production_MaterialGet> DataTableToList(DataTable dt)
        //{
        //    List<EMMS.Model.Production_MaterialGet> modelList = new List<EMMS.Model.Production_MaterialGet>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        EMMS.Model.Production_MaterialGet model;
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  BasicMethod

        #region  ExtensionMethod
        ///
        /// 获得数据列表Production_MaterialView
        /// </summary>
        public EMMS.Model.Production_MaterialView GetModelListView(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListView(ds.Tables[0],strWhere);
        }
        public List<EMMS.Model.BOM> GetBom(string prodNo)
        {
            DataSet ds = dal.GetMaterialList(prodNo);
            return DataToBomView(ds.Tables[0]);
        }
        //
        public List<EMMS.Model.BOM> DataToBomView(DataTable dt)
        {
            List<EMMS.Model.BOM> modelList = new List<BOM>();

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                
                for (int n = 0; n < rowsCount; n++)
                {
                    EMMS.Model.BOM model = new BOM();
                    model.No = dt.Rows[n]["no"].ToString();
                    model.MaterialName = dt.Rows[n]["materialname"].ToString();
                    model.Type = dt.Rows[n]["type"].ToString();
                    model.Unit = dt.Rows[n]["unit"].ToString();
                    model.Proporation = float.Parse(dt.Rows[n]["proporation"].ToString());
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表 Production_MaterialView
        /// </summary>
        public EMMS.Model.Production_MaterialView DataTableToListView(DataTable dt,string strWhere)
        {
            List<EMMS.Model.MaterialNameView> modelList = new List<EMMS.Model.MaterialNameView>();//物料列表
            EMMS.Model.Production_MaterialView model = new Production_MaterialView();
            model.ProductionName = strWhere;//产品名称
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.MaterialNameView namemodel = new MaterialNameView();
                for (int n = 0; n < rowsCount; n++)
                {
                    namemodel = dal.DataRowToModelView(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(namemodel);
                    }
                }
            }
            model.MaterialNameList = modelList;//物料列表
            return model;
        }
        //得到物料名称作为节点
        public List<TreeNode> GetNodeList(string strName)
        {
            return dal.GetNodeList(strName);
        }
        //得到成品名称
        public List<EMMS.Model.GoodsSet> GetGoodsList()
        {
            
            DataSet ds = new DataSet();
            ds = dal.GetGoodsList();
            List<EMMS.Model.GoodsSet> GoodsList = new List<GoodsSet>();
            int count = ds.Tables[0].Rows.Count;
            for (int i = -1; i < count; i++)
            {
                if (i == -1)
                {
                    EMMS.Model.GoodsSet set = new GoodsSet();
                    set.No = "0";
                    set.Name = "请选择产品...";
                    GoodsList.Add(set);
                }
                else
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    EMMS.Model.GoodsSet set = new GoodsSet();
                    set.No = row["no"].ToString();
                    set.Name = row["name"].ToString();
                    GoodsList.Add(set);
                }
            }
            return GoodsList;
        }
        #endregion  ExtensionMethod
    }
}

