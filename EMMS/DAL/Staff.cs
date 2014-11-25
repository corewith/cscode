using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EMMS.DbHelper;
using System.Windows.Forms;
using System.Collections.Generic;
using EMMS.Model;//Please add references
namespace EMMS.DAL
{
    /// <summary>
    /// 数据访问类:Staff
    /// </summary>
    public class Staff
    {
        public Staff()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_staff");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.StaffSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_staff(");
            strSql.Append("no,name,gender,age,job,department,login,resign,remarks) ");
            strSql.Append(" values (");
            strSql.Append("@no,@name,@gender,@age,@job,@department,@login,@resign,@remarks) ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@name", SqlDbType.VarChar,10),
                    new SqlParameter("@gender",SqlDbType.Int,4),
					new SqlParameter("@age", SqlDbType.Int,4),
					new SqlParameter("@job", SqlDbType.VarChar,2),
                    new SqlParameter("@department",SqlDbType.VarChar,8),
                    new SqlParameter("@login",SqlDbType.Int,4),
                    new SqlParameter("@resign",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Gender;
            parameters[3].Value = model.Age;
            parameters[4].Value = model.Job;
            parameters[5].Value = model.Department;
            parameters[6].Value = model.Login;
            parameters[7].Value = model.Resign;
            parameters[8].Value = model.Remarks;

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
        public bool Update(EMMS.Model.StaffSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_staff set ");
            strSql.Append("name=@name,");
            strSql.Append("gender=@gender,");
            strSql.Append("age=@age,");
            strSql.Append("job=@job,");
            strSql.Append("department=@department,");
            strSql.Append("login=@login,");
            strSql.Append("resign=@resign,");
            strSql.Append("remarks=@remarks");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@name", SqlDbType.VarChar,10),
                    new SqlParameter("@gender",SqlDbType.Int,4),
					new SqlParameter("@age", SqlDbType.Int,4),
					new SqlParameter("@job", SqlDbType.VarChar,2),
                    new SqlParameter("@department",SqlDbType.VarChar,8),
                    new SqlParameter("@login",SqlDbType.Int,4),
                    new SqlParameter("@resign",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Gender;
            parameters[3].Value = model.Age;
            parameters[4].Value = model.Job;
            parameters[5].Value = model.Department;
            parameters[6].Value = model.Login;
            parameters[7].Value = model.Resign;
            parameters[8].Value = model.Remarks;

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
            strSql.Append("delete from tb_staff ");
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
            strSql.Append("delete from tb_staff ");
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
        /// 从tb_staff中得到一个对象实体,
        /// </summary>
        public EMMS.Model.StaffSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,name,gender,age,job,department,login,resign,remarks from tb_staff ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            EMMS.Model.StaffGet model = new EMMS.Model.StaffGet();
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
        public EMMS.Model.StaffGet DataRowToModel(DataRow row)
        {
            EMMS.Model.StaffGet model = new EMMS.Model.StaffGet();
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
                if (row["gender"] != null && row["gender"].ToString() !="")
                {
                    model.Gender = int.Parse(row["gender"].ToString());
                }
                if (row["age"] != null && row["age"].ToString() != "")
                {
                    model.Age = int.Parse(row["age"].ToString());
                }
                if (row["job"] != null)
                {
                    model.Job = row["job"].ToString();
                }
                if (row["department"] != null)
                {
                    model.Department = row["department"].ToString();
                }
                if (row["login"] != null && row["login"].ToString() != "")
                {
                    model.Login = int.Parse(row["Login"].ToString());
                }
                if (row["resign"] != null && row["resign"].ToString() != "")
                {
                    model.Resign = int.Parse(row["resign"].ToString());
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 从view_staff中获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name,gender,age,job,department,login,resign,remarks ");
            strSql.Append(" FROM view_staff ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where no= '" + strWhere + "'");
                strSql.Append(" or name= '" + strWhere + "'");
                strSql.Append(" or job= '" + strWhere + "'");
                strSql.Append(" or department= '" + strWhere + "'");
                //strSql.Append(" or resign= " + strWhere );
            }
            return DbHelperSql.Query(strSql.ToString());
        }
        //
        public DataSet GetListByResign(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name,gender,age,job,department,login,resign,remarks ");
            strSql.Append(" FROM view_staff ");
            if (strWhere.Trim() != "")
            {
                    strSql.Append(" where resign= " + strWhere );
            }
            return DbHelperSql.Query(strSql.ToString());
        }
        //
        public DataSet GetListByLogin(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name,gender,age,job,department,login,resign,remarks ");
            strSql.Append(" FROM view_staff ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where login= " + strWhere);
            }
            return DbHelperSql.Query(strSql.ToString());
        }
        /// <summary>
        ///从view_staff中 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" no,name,gender,age,job,department,login,resign,remarks ");
            strSql.Append(" FROM view_staff ");
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
            strSql.Append("select count(1) FROM tb_staff ");
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
            strSql.Append(")AS Row, T.*  from view_staff T ");
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
        public EMMS.Model.StaffView DataRowToModelView(DataRow row)
        {
            EMMS.Model.StaffView model = new EMMS.Model.StaffView();
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
                if (row["gender"] != null && row["gender"].ToString() != "")
                {
                    model.Gender = (Sex)(int.Parse(row["gender"].ToString()));//(Sex)((Convert.ToInt32(row["gender"].ToString())==0)?0:1);
                }
                if (row["age"] != null && row["age"].ToString() != "")
                {
                    model.Age = int.Parse(row["age"].ToString());
                }
                if (row["job"] != null)
                {
                    model.Job = row["job"].ToString();
                }
                if (row["department"] != null)
                {
                    model.Department = row["department"].ToString();
                }
                if (row["login"] != null && row["login"].ToString() != "")
                {
                    model.Login = (int.Parse(row["Login"].ToString()) == 0) ? false : true;
                }
                if (row["resign"] != null && row["resign"].ToString() != "")
                {
                    model.Resign = (int.Parse(row["resign"].ToString()) == 0) ? false : true;
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }
        //得到部门名称
        public List<String> GetDepartmentNameList()
        {
            Department dal = new Department();
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
        //得到职务名称
        public List<String> GetJobNameList()
        {
            Job dal = new Job();
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
                nameList = GetDepartmentNameList();
            else if (flag == 1)
                nameList = GetJobNameList();
            foreach (string name in nameList)
            {
                nodeList.Add(new TreeNode() { Text = name });
            }
            return nodeList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.StaffSet DataRowToModelSet(DataRow row)
        {
            EMMS.Model.StaffSet model = new EMMS.Model.StaffSet();
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
                if (row["gender"] != null && row["gender"].ToString() != "")
                {
                    model.Gender = int.Parse(row["gender"].ToString());
                }
                if (row["age"] != null && row["age"].ToString() != "")
                {
                    model.Age = int.Parse(row["age"].ToString());
                }
                if (row["job"] != null)
                {
                    model.Job = row["job"].ToString();
                }
                if (row["department"] != null)
                {
                    model.Department = row["department"].ToString();
                }
                if (row["login"] != null && row["login"].ToString() != "")
                {
                    model.Login = int.Parse(row["Login"].ToString());
                }
                if (row["resign"] != null && row["resign"].ToString() != "")
                {
                    model.Resign = int.Parse(row["resign"].ToString());
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

