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
    //数据访问类：User
    public class User
    {
        public User()
        { }

        #region BasicMethod
        //是否存在该记录
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_user ");
            strSql.Append("where name=@name");
            SqlParameter[] parameters = { new SqlParameter("@name", SqlDbType.VarChar, 8) };
            parameters[0].Value = no;
            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }
        //增加一条数据
        public bool Add(EMMS.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user( ");
            strSql.Append(" id,no,role,name,password) ");
            strSql.Append("values(");
            strSql.Append(" @id,@no,@role,@name,@password) ");
            SqlParameter[] parameters =
                   {new SqlParameter("@id",SqlDbType.VarChar,6),
                       new SqlParameter("@no",SqlDbType.VarChar,8),
                       new SqlParameter("@role",SqlDbType.Int,4),
                       new SqlParameter("@name",SqlDbType.VarChar,10),
                       new SqlParameter("@password",SqlDbType.VarChar,15)
                   };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.No ;
            parameters[2].Value = model.Role;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Password;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
                return true;
            else
                return false;
        }
        //更新一条数据
        public bool Update(EMMS.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("no=@no, ");
            strSql.Append("role=@role, ");
            strSql.Append("name=@name, ");
            strSql.Append("password=@password ");
            strSql.Append("where id=@id");
            SqlParameter[] parameters =
                   {   new SqlParameter("@id",SqlDbType.VarChar,6),
                       new SqlParameter("@no",SqlDbType.VarChar,8),
                       new SqlParameter("@role",SqlDbType.Int,4),
                       new SqlParameter("@name",SqlDbType.VarChar,10),
                       new SqlParameter("@password",SqlDbType.VarChar,15)
                   };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.No;
            parameters[2].Value = model.Role;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Password;

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
            strSql.Append("delete from tb_user ");
            strSql.Append("where id=@id ");
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
            strSql.Append("delete from tb_user ");
            strSql.Append("where id in (" + noList + ") ");

            int rows = DbHelperSql.ExecuteSql(strSql.ToString());
            if (rows > 0)
                return true;
            else
                return false;
        }
        //得到一个对象实体
        public EMMS.Model.User GetModel(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,no,role, name,password from tb_user ");
            strSql.Append("where name=@name ");

            SqlParameter[] parameters = { new SqlParameter("@name", SqlDbType.VarChar, 8) };
            parameters[0].Value = name;

            //EMMS.Model.User model = new Model.User();
            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
                return DataRowToModel(ds.Tables[0].Rows[0]);
            else
                return null;
        }
        //通过人员编号得到其登录信息
        public EMMS.Model.User GetModelByStaffNo(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,no,role, name,password from tb_user ");
            strSql.Append("where no=@no ");

            SqlParameter[] parameters = { new SqlParameter("@no", SqlDbType.VarChar, 8) };
            parameters[0].Value = no;

            //EMMS.Model.User model = new Model.User();
            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
                return DataRowToModel(ds.Tables[0].Rows[0]);
            else
                return null;
        }
        //得到一个对象实体
        public EMMS.Model.User DataRowToModel(DataRow row)
        {
            EMMS.Model.User model = new Model.User();
            if (row != null)
            {
                if (row["id"] != null)
                    model.Id = row["id"].ToString();
                if (row["no"] != null)
                    model.No = row["no"].ToString();
                if (row["role"] != null)
                    model.Role = int.Parse(row["role"].ToString());
                if (row["name"] != null)
                    model.Name = row["name"].ToString();
                if (row["password"] != null)
                    model.Password = row["password"].ToString();
            }
            return model;
        }
        //获得数据列表
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,no,role,name,password ");
            strSql.Append("from tb_user ");

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
            strSql.Append("from tb_user ");
            if (strWhere.Trim() != "")
                strSql.Append("where " + strWhere);
            strSql.Append("order by " + filedOrder);
            return DbHelperSql.Query(strSql.ToString());
        }
        //获取记录总数
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_user ");
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
            strSql.Append(") as row,T.* from tb_user T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql.Append("where " + strWhere);
            strSql.Append(") TT ");
            strSql.AppendFormat("where TT.row between {0} and {1] ", startIndex, endIndex);
            return DbHelperSql.Query(strSql.ToString());
        }
        #endregion BasicMethod

        #region ExtensionMethod
        //批量添加
        public int AddList(List<EMMS.Model.User> modelList)
        {
     
            List<String> SqlStringList = new List<String>();
            foreach (EMMS.Model.User model in modelList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into tb_user(no,name) values( '" + model.No + "','" + model.Name + "')");
                SqlStringList.Add(strSql.ToString());
            }
            return DbHelper.DbHelperSql.ExecuteSqlTran(SqlStringList);
        }
        #endregion ExtensionMethod
    }
}
