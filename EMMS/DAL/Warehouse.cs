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
    /// 数据访问类:Warehouse
    /// </summary>
    public class Warehouse
    {
        public Warehouse()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_warehouse");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.WarehouseSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_warehouse(");
            strSql.Append("no,name,type,useable,remarks)");
            strSql.Append(" values (");
            strSql.Append("@no,@name,@type,@useable,@remarks)");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@name", SqlDbType.VarChar,10),
					new SqlParameter("@type", SqlDbType.VarChar,2),
					new SqlParameter("@useable", SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Useable;
            parameters[4].Value = model.Remarks;

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
        public bool Update(EMMS.Model.WarehouseSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_warehouse set ");
            strSql.Append("name=@name,");
            strSql.Append("type=@type,");
            strSql.Append("useable=@useable,");
            strSql.Append("remarks=@remarks");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,10),
					new SqlParameter("@type", SqlDbType.VarChar,2),
					new SqlParameter("@useable", SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
					new SqlParameter("@no", SqlDbType.VarChar,8)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Useable;
            parameters[3].Value = model.Remarks;
            parameters[4].Value = model.No;

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
            strSql.Append("delete from tb_warehouse ");
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
            strSql.Append("delete from tb_warehouse ");
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
        /// 从tb_warehouse中得到一个对象实体,WarehousseSet
        /// </summary>
        public EMMS.Model.WarehouseSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,name,type,useable,remarks from tb_warehouse ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.WarehouseGet DataRowToModel(DataRow row)
        {
            EMMS.Model.WarehouseGet model = new EMMS.Model.WarehouseGet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["name"] != null)
                {
                    model.Name = row["name"].ToString();
                }
                if (row["typename"] != null)
                {
                    model.TypeName = row["typename"].ToString();
                }
                if (row["useable"] != null && row["useable"].ToString() != "")
                {
                    model.Useable = int.Parse(row["useable"].ToString());
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 从view_warehouse中获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name,typename,useable,remarks ");
            strSql.Append(" FROM view_warehouse ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where no= '" + strWhere+"'");
                strSql.Append(" or name= '" + strWhere+"'");
                strSql.Append(" or typename= '" + strWhere + "'");
                //strSql.Append(" or useable= " + strWhere + "");
            }
            return DbHelperSql.Query(strSql.ToString());
        }
        //
        public DataSet GetListByNumber(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name,typename,useable,remarks ");
            strSql.Append(" FROM view_warehouse ");
            if (strWhere.Trim() != "")
            {
                //strSql.Append(" where no= '" + strWhere + "'");
                //strSql.Append(" or name= '" + strWhere + "'");
                //strSql.Append(" or typename= '" + strWhere + "'");
                strSql.Append("  where useable= " + strWhere + "");
            }
            return DbHelperSql.Query(strSql.ToString());
        }

        /// <summary>
        ///从view_warehouse中 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" no,name,typename,useable,remarks ");
            strSql.Append(" FROM view_warehouse ");
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
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_warehouse ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append(")AS Row, T.*  from view_warehouse T ");
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
        public EMMS.Model.WarehouseView DataRowToModelView(DataRow row)//从view_warehoue中的得到的一行
        {
            EMMS.Model.WarehouseView model = new EMMS.Model.WarehouseView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["name"] != null)
                {
                    model.Name = row["name"].ToString();
                }
                if (row["typename"] != null)
                {
                    model.TypeName = row["typename"].ToString();
                }
                if (row["useable"] != null && row["useable"].ToString() != "")
                {
                    model.Disabled = (Convert.ToInt32(row["useable"].ToString()) == 1) ? false : true;
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }
        //得到仓库类别名称
        public List<String> GetNameList()
        {
            WarehouseAttri dal = new WarehouseAttri();
            DataSet ds = new DataSet();
            ds=dal.GetList("");
            List<String> nameList = new List<String>();
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    nameList.Add(row["name"].ToString());
                }
            }
            return nameList;
        }
        public List<TreeNode> GetNodeList()
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            List<String> nameList = new List<string>();
            nameList = GetNameList();
            foreach (string name in nameList)
            {
                nodeList.Add(new TreeNode() { Text =name });
            }
            return nodeList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.WarehouseSet DataRowToModelSet(DataRow row)//从tb_warehouse中得到的一行
        {
            EMMS.Model.WarehouseSet model = new EMMS.Model.WarehouseSet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["name"] != null)
                {
                    model.Name = row["name"].ToString();
                }
                if (row["type"] != null)
                {
                    model.Type = row["type"].ToString();
                }
                if (row["useable"] != null && row["useable"].ToString() != "")
                {
                    model.Useable = int.Parse(row["useable"].ToString());
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

