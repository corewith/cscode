using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EMMS.DbHelper;
using System.Windows.Forms;
using System.Collections.Generic;//Please add references
namespace EMMS.DAL
{
    /// <summary>
    /// 数据访问类:Storage_Order
    /// </summary>
    public class Storage_Order
    {
        public Storage_Order()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_storage_order");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.Storage_OrderSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_storage_order( ");
            strSql.Append("no,warehouse_no,goods_no,counts,critical,remarks) ");
            strSql.Append(" values (");
            strSql.Append("@no,@warehouse_no,@goods_no,@counts,@critical,@remarks)");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@warehouse_no", SqlDbType.VarChar,8),
					new SqlParameter("@goods_no", SqlDbType.VarChar,8),
					new SqlParameter("@counts", SqlDbType.Int,4),
                    new SqlParameter("@critical",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.WarehouseNo;
            parameters[2].Value = model.GoodsNo;
            parameters[3].Value = model.Counts;
            parameters[4].Value = model.Critical;
            parameters[5].Value = model.Remarks;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EMMS.Model.Storage_OrderSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_storage_order set ");
            strSql.Append("warehouse_no=@warehouse_no,");
            strSql.Append("goods_no=@goods_no,");
            strSql.Append("counts=@counts,");
            strSql.Append("critical=@critical,");
            strSql.Append("remarks=@remarks");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@warehouse_no", SqlDbType.VarChar,8),
					new SqlParameter("@goods_no", SqlDbType.VarChar,8),
					new SqlParameter("@counts", SqlDbType.Int,4),
                    new SqlParameter("@critical",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.WarehouseNo;
            parameters[2].Value = model.GoodsNo;
            parameters[3].Value = model.Counts;
            parameters[4].Value = model.Critical;
            parameters[5].Value = model.Remarks;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_storage_order ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)};
            parameters[0].Value = no;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string nolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_storage_order ");
            strSql.Append(" where no in (" + nolist + ")  ");
            int rows = DbHelperSql.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 从tb_storage_order中得到一个对象实体,WarehousseSet
        /// </summary>
        public EMMS.Model.Storage_OrderSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,warehouse_no,goods_no,counts,critical,remarks from tb_storage_order ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModelSet(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        //
        public EMMS.Model.Storage_OrderSet GetModelByNo(string warehouseno,string goodsno)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,warehouse_no,goods_no,counts,critical,remarks from tb_storage_order ");
            strSql.Append(" where goods_no=@goods_no and warehouse_no=@warehouse_no");
            SqlParameter[] parameters = {
					new SqlParameter("@goods_no", SqlDbType.VarChar,8)	,
                    new SqlParameter("@warehouse_no",SqlDbType.VarChar,8)};
            parameters[0].Value = goodsno;
            parameters[1].Value = warehouseno;

            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModelSet(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public EMMS.Model.Storage_OrderGet DataRowToModel(DataRow row)
        //{
        //    EMMS.Model.Storage_OrderGet model = new EMMS.Model.Storage_OrderGet();
        //    if (row != null)
        //    {
        //        if (row["no"] != null)
        //        {
        //            model.No = row["no"].ToString();
        //        }
        //        if (row["name"] != null)
        //        {
        //            model.Name = row["name"].ToString();
        //        }
        //        if (row["typename"] != null)
        //        {
        //            model.TypeName = row["typename"].ToString();
        //        }
        //        if (row["useable"] != null && row["useable"].ToString() != "")
        //        {
        //            model.Useable = int.Parse(row["useable"].ToString());
        //        }
        //        if (row["remarks"] != null)
        //        {
        //            model.Remarks = row["remarks"].ToString();
        //        }
        //    }
        //    return model;
        //}

        /// <summary>
        /// 从view_storage_order中获得数据列表
        /// </summary>
        public DataSet GetList(string strWarehouse,string strGoods)
        {
            bool flag = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,warehousename,goodsname,counts,critical,remarks,goodsno ");
            strSql.Append(" FROM view_storage_order ");
            if (strWarehouse.Trim() != "")
            {
                flag = true;
                strSql.Append(" where warehousename= '" + strWarehouse + "'");
                //strSql.Append(" or name= '" + strWhere + "'");
                //strSql.Append(" or typename= '" + strWhere + "'");
                //strSql.Append(" or useable= " + strWhere + "");
            }
            if (strGoods.Trim() != "")
            {
                if (flag)
                    strSql.Append(" and goodsname = '" + strGoods + "' ");
                else
                    strSql.Append("where goodsname ='" + strGoods + "'");
            }
            return DbHelperSql.Query(strSql.ToString());
        }
        //得到低于警戒的库存
        public DataSet GetListBelowCritical()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,warehousename,goodsname,counts,critical,remarks,goodsno ");
            strSql.Append(" FROM view_storage_order ");
            strSql.Append(" where critical>counts");  //库存低于警戒线
            return DbHelperSql.Query(strSql.ToString());
        }
        /// <summary>
        ///从view_storage_order中 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" no,warehouename,goodsname,counts,critical,remarks,goodsno ");
            strSql.Append(" FROM view_storage_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSql.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWarehouse,string strGoods)
        {
            bool flag = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM view_storage_order ");
            if (strWarehouse.Trim() != "")
            {
                flag = true;
                strSql.Append(" where warehousename= '" + strWarehouse + "'");
                //strSql.Append(" or name= '" + strWhere + "'");
                //strSql.Append(" or typename= '" + strWhere + "'");
                //strSql.Append(" or useable= " + strWhere + "");
            }
            if (strGoods.Trim() != "")
            {
                if (flag)
                    strSql.Append(" and goodsname = '" + strGoods + "' ");
                else
                    strSql.Append("where goodsname ='" + strGoods + "'");
            }
            object obj = DbHelperSql.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.no desc");
            }
            strSql.Append(")AS Row, T.*  from view_storage_order T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSql.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Storage_OrderView DataRowToModelView(DataRow row)
        {
            EMMS.Model.Storage_OrderView model = new EMMS.Model.Storage_OrderView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["warehousename"] != null)
                {
                    model.WarehouseName = row["warehousename"].ToString();
                }
                if (row["goodsname"] != null)
                {
                    model.GoodsName = row["goodsname"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != "")
                {
                    model.Counts = Convert.ToInt32(row["counts"].ToString());
                }
                if (row["critical"] != null && row["critical"].ToString() != "")
                {
                    model.Critical = Convert.ToInt32(row["critical"].ToString());
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
                if (row["goodsno"] != null)
                {
                    model.GoodsNo = row["goodsno"].ToString();
                }
            }
            return model;
        }
        //得到仓库名称名称
        public List<String> GetWarehouseNameList()
        {
            EMMS.DAL.Warehouse dal = new Warehouse();
            DataSet ds = new DataSet();
            ds = dal.GetList("");
            List<String> nameList = new List<String>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    nameList.Add(row["name"].ToString());
                }
            }
            return nameList;
        }
        //得到物品名称
        public List<String> GetGoodsNameList()
        {
            Goods dal = new Goods();
            DataSet ds = new DataSet();
            ds = dal.GetList("");
            List<String> nameList = new List<String>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    nameList.Add(row["name"].ToString());
                }
            }
            return nameList;
        }
        public List<TreeNode> GetNodeList(int flag)
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            List<String> nameList = new List<string>();
            if (flag == 0)
            {
                nameList = GetWarehouseNameList();
            }
            else
            {
                nameList = GetGoodsNameList();
            }
            foreach (string name in nameList)
            {
                nodeList.Add(new TreeNode() { Text = name });
            }
            return nodeList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Storage_OrderSet DataRowToModelSet(DataRow row)
        {
            EMMS.Model.Storage_OrderSet model = new EMMS.Model.Storage_OrderSet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["warehouse_no"] != null)
                {
                    model.WarehouseNo = row["warehouse_no"].ToString();
                }
                if (row["goods_no"] != null)
                {
                    model.GoodsNo = row["goods_no"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != "")
                {
                    model.Counts = Convert.ToInt32(row["counts"].ToString());
                }
                if (row["critical"] != null && row["critical"].ToString() != "")
                {
                    model.Critical = Convert.ToInt32(row["critical"].ToString());
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }
        #endregion  ExtensionMethod
    }
}

