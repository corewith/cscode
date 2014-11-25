using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EMMS.DbHelper;
using System.Collections;

namespace EMMS.DAL
{
    //数据访问类：Supplier
    public class Supplier
    {
        public Supplier()
        { }

        #region BasicMethod
        //是否存在该记录
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_supplier ");
            strSql.Append("where no=@no");
            SqlParameter[] parameters = { new SqlParameter("@no", SqlDbType.VarChar, 2) };
            parameters[0].Value = no;
            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }
        //增加一条数据
        public bool Add(EMMS.Model.Supplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_supplier( ");
            strSql.Append("no,name ");
            strSql.Append("value(");
            strSql.Append("@no,@name) ");
            SqlParameter[] parameters =
                   {new SqlParameter("@no",SqlDbType.VarChar,2),
                    new SqlParameter("@name",SqlDbType.VarChar,10)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Name;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
                return true;
            else
                return false;
        }
        //更新一条数据
        public bool Update(EMMS.Model.Supplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_supplier set ");
            strSql.Append("name=@name ");
            strSql.Append("where no=@no");
            SqlParameter[] parameters ={new SqlParameter("@no",SqlDbType.VarChar,2),
                                      new SqlParameter("@name",SqlDbType.VarChar,10)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Name;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
                return true;
            else
                return false;
        }
        //删除一条数据
        public bool Delete(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_supplier ");
            strSql.Append("where no=@no ");
            SqlParameter[] parameters = { new SqlParameter("@no", SqlDbType.VarChar, 2) };
            parameters[0].Value = no;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
                return true;
            else
                return false;
        }
        //批量删除数据
        public bool DeleteList(string noList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_supplier ");
            strSql.Append("where no in (" + noList + ") ");

            int rows = DbHelperSql.ExecuteSql(strSql.ToString());
            if (rows > 0)
                return true;
            else
                return false;
        }
        //得到一个对象实体
        public EMMS.Model.Supplier GetModel(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 no, name from tb_supplier ");
            strSql.Append("where no=@no ");

            SqlParameter[] parameters = { new SqlParameter("@no", SqlDbType.VarChar, 2) };
            parameters[0].Value = no;

            //EMMS.Model.Supplier model = new Model.Supplier();
            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
                return DataRowToModel(ds.Tables[0].Rows[0]);
            else
                return null;
        }
        //得到一个对象实体
        public EMMS.Model.Supplier DataRowToModel(DataRow row)
        {
            EMMS.Model.Supplier model = new Model.Supplier();
            if (row != null)
            {
                if (row["no"] != null)
                    model.No = row["no"].ToString();
                if (row["name"] != null)
                    model.Name = row["name"].ToString();
            }
            return model;
        }
        //获得数据列表
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name ");
            strSql.Append("from tb_supplier ");

            if (strWhere.Trim() != "")
                strSql.Append("where" + strWhere);
            return DbHelperSql.Query(strSql.ToString());
        }
        //获得前几行数据
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append("top" + Top.ToString());
            }
            strSql.Append("no,name ");
            strSql.Append("from tb_supplier ");
            if (strWhere.Trim() != "")
                strSql.Append("where " + strWhere);
            strSql.Append("order by " + filedOrder);
            return DbHelperSql.Query(strSql.ToString());
        }
        //获取记录总数
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_supplier ");
            if (strWhere.Trim() != "")
                strSql.Append("where " + strWhere);
            object obj = DbHelperSql.GetSingle(strSql.ToString());
            if (obj == null)
                return 0;
            else
                return Convert.ToInt32(obj);
        }
        //分页获取数据列表
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no, name from( ");
            strSql.Append("select row_number() over ( ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
                strSql.Append("order by T. " + orderby);
            else
                strSql.Append("order by T.no desc ");
            strSql.Append(") as row,T.* from tb_supplier T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql.Append("where " + strWhere);
            strSql.Append(") TT ");
            strSql.AppendFormat("where TT.row between {0} and {1] ", startIndex, endIndex);
            return DbHelperSql.Query(strSql.ToString());
        }
        #endregion BasicMethod

        #region ExtensionMethod
        //批量添加
        public int AddList(List<EMMS.Model.Supplier> modelList)
        {
            //List<String> SqlStrList = new List<String>();
            //Hashtable SqlStrList = new Hashtable();
            //foreach (EMMS.Model.Supplier model in modelList)
            //{
            //    StringBuilder strSql = new StringBuilder();
            //    strSql.Append("insert into tb_supplier( ");
            //    strSql.Append("no,name) ");
            //    strSql.Append("values( ");
            //    strSql.Append("@no,@name");
            //    SqlParameter[] parameters = { new SqlParameter("@no", SqlDbType.VarChar, 2), new SqlParameter("@name", SqlDbType.VarChar, 10) };
            //    SqlStrList.Add(strSql, parameters);
            //}
            //DbHelper.DbHelperSql.ExecuteSqlTran(SqlStrList);
            List<String> SqlStringList = new List<String>();
            foreach (EMMS.Model.Supplier model in modelList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into tb_supplier(no,name) values( '" + model.No + "','" + model.Name + "')");
                SqlStringList.Add(strSql.ToString());
            }
            return DbHelper.DbHelperSql.ExecuteSqlTran(SqlStringList);
        }
        #endregion ExtensionMethod
    }
}
