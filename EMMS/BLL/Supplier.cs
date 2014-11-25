using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using EMMS.DAL;

namespace EMMS.BLL
{
    //tb_warehouseAttri BLL
    public class Supplier
    {
        private readonly EMMS.DAL.Supplier dal = new EMMS.DAL.Supplier();
        public Supplier()
        { }
        #region BasicMethod
        //是否存在该记录
        public bool Exists(string no)
        {
            return dal.Exists(no);
        }
        //增加一条数据
        public bool Add(EMMS.Model.Supplier model)
        {
            return dal.Add(model);
        }
        //更新一条数据
        public bool Update(EMMS.Model.Supplier model)
        {
            return dal.Update(model);
        }
        //删除一条数据
        public bool Delete(string no)
        {
            return dal.Delete(no);
        }
        //删除一批数据
        public bool DeleteList(string noList)
        {
            return dal.DeleteList(EMMS.Common.PageValidate.SafeLongFilter(noList, 0));
        }
        //得到一个对象实体
        public EMMS.Model.Supplier GetModel(string no)
        {
            return dal.GetModel(no);
        }
        //得到一个对象实体，从缓存中

        //获取数据列表
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        //获得前几行数据
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        //获得数据列表
        public List<EMMS.Model.Supplier> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        //DataTableList实现
        public List<EMMS.Model.Supplier> DataTableToList(DataTable dt)
        {
            List<EMMS.Model.Supplier> modelList = new List<Model.Supplier>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EMMS.Model.Supplier model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                        modelList.Add(model);
                }
            }
            return modelList;
        }
        //获取所有数据列表
        public DataSet GetAllList()
        {
            return GetList("");
        }
        //获取记录总数
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        //分页获取数据列表
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        #endregion

        #region ExtensionMethod
        //批量增加
        public int AddList(List<EMMS.Model.Supplier> modelList)
        {
            return dal.AddList(modelList);
        }
        #endregion ExtensionMethod
    }
}
