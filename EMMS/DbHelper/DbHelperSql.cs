using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.ServiceProcess;

namespace EMMS.DbHelper
{
    //数据库访问抽象基础类
    public class DbHelperSql
    {
        //数据库连接字符串（app.config来配置），多数据库可使用DbHelperSqlP来实现
        public static string connectionString = PubConstant.ConnectionString;
        public static string db = PubConstant.DB;
        private static ServiceController sc = new ServiceController("MSSQLSERVER", "127.0.0.1");
        public DbHelperSql()
        { }

        //判断服务器开启是否开启
        public static bool ExistSqlServerService()
        {
            bool ExistFlag = false;
            //ServiceController[] service = ServiceController.GetServices();
            //for (int i = 0; i < service.Length; i++)
            //{
            //    if (service[i].DisplayName.ToString().Contains("MSSQLSERVER"))
            //        ExistFlag = true;
            //}

            if (sc.Status == ServiceControllerStatus.Running)
                ExistFlag = true;
                    

            return ExistFlag;
        }
        #region 公用方法
        //判断是否存在某表的某个字段
        public static bool ColumnExists(string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "and [name]='" + columnName + "'";
            object res = GetSingle(sql);
            if (res == null)
                return false;
            return Convert.ToInt32(res) > 0;
        }
        //得到某表的某域最大的ID
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strSql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strSql);
            if (obj == null)
                return 1;
            else
                return int.Parse(obj.ToString());
        }
        //判断是否存在某一条记录
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdResult;
            if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
            {
                cmdResult=0;
            }
            else
            {
                cmdResult=int.Parse(obj.ToString());//也可能=0
            }
            if( cmdResult == 0)
                return false;
            else
                return true;

        }
        //判断表是否存在
        public static bool TabExists(string TableName)
        {
            string strSql = "select count(*) from syobjects where id = object_id(N'[" + TableName + "]') and OBJJECTPROPERTY(id,N'IsUserTable')=1";
            object obj = GetSingle(strSql);
            int cmdResult;
            if (Object.Equals(obj, null) || (Object.Equals(obj, System.DBNull.Value)))
                cmdResult = 0;
            else
                cmdResult=int.Parse(obj.ToString());
            if (cmdResult == 0)
                return false;
            else
                return true;
        }
        //根据参数判断是否存在
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdResult;
            if (Object.Equals(obj, null) || (Object.Equals(obj, System.DBNull.Value)))
                cmdResult = 0;
            else
                cmdResult = int.Parse(obj.ToString());
            if (cmdResult == 0)
                return false;
            else
                return true;
        }
        #endregion

        #region 执行简单SQL语句
        //执行SQL语句，返回影响的记录数
        public static int ExecuteSql(string SqlString)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch(System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        //有时间限制的执行Sql语句，返回影响的记录行
        public static int ExecuteSqlByTime(string SqlString, int Times)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                using(SqlCommand cmd=new SqlCommand(SqlString,connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        //执行多条SQL语句，实现数据库事务
        public static int ExecuteSqlTran(List<String> SqlStringList)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
                
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SqlStringList.Count; n++)
                    {
                        string strSql = SqlStringList[n];
                        if (strSql.Trim().Length > 1)
                        {
                            cmd.CommandText = strSql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();//提交事务
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    MessageBox.Show("由于某种原因，事务处理失败！");
                    return 0;
                }
            }
        }
        //执行带参数的SQL语句
        public static int ExecuteSql(string SqlString, string content)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
                
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlString, connection);
                SqlParameter myParameter = new SqlParameter();
                myParameter.Value = content;//参数
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        //执行带一个存储过程参数的SQL语句
        public static object ExecuteSqlGet(string SqlString, string content)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
                return null;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SqlString;
                cmd.Connection = conn;
                SqlParameter myParameter = new SqlParameter();
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();//执行查询，并返回查询结果集中的第一行
                    if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
                        return null;
                    else
                        return obj;
                }
                catch(SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
        //返回一条结果(有时间限制)
        public static object GetSingle(string SqlString, int Times)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
               
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
                            return false;
                        else 
                            return obj;
                    }
                    catch(SqlException e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }
        //执行查询语句，返回DataSet
        public static DataSet Query(string SqlString)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
            }
            DataSet ds = new DataSet();
            //using (SqlConnection conn = new SqlConnection("Data Source=127.0.0.1,1433 ;User ID=sa;Password=corewith;Initial Catalog=db_EMMS;Persist Security Info=True;"))
            using (SqlConnection conn = new SqlConnection(connectionString))//"Data Source=127.0.0.1,1433 ;User ID=sa;Password=corewith;Initial Catalog=db_EMMS;Persist Security Info=True;"))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter cmd = new SqlDataAdapter(SqlString, conn);
                    cmd.Fill(ds, "ds");
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message);
                }
                return ds;
            }
        }
        //执行查询语句，返回DataSet（有时间限制）
        public static DataSet Query(string SqlString, int Times)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
               
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    SqlDataAdapter cmd = new SqlDataAdapter(SqlString, conn);
                    cmd.SelectCommand.CommandTimeout = Times;
                    cmd.Fill(ds, "ds");
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message);
                }
                return ds;
            }
        }
        #endregion

        #region 执行带参数的SQL语句
        //执行SQL语句，返回影响的记录数
        public static int ExecuteSql(string SqlString, params SqlParameter[] cmdParms)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
               
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, SqlString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (SqlException e)
                    {
                        //throw e;
                        MessageBox.Show("由于某种原因，处理失败！\n"+e.Message);
                        return 0;
                    }
                }
            }
        }
        //执行多条SQL语句，实现数据库事务
        //SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）
        public static void ExecuteSqlTran(Hashtable SqlStringList)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
                
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry myDe in SqlStringList)
                        {
                            string cmdText = myDe.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDe.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("很抱歉，执行失败！");
                        trans.Rollback();
                    }
                }
            }
        }
        //执行多条SQL语句，实现数据库事务
        public static int ExecuteSqlTran(List<CommandInfo> cmdList)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
               
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int count = 0;
                        foreach (CommandInfo myDe in cmdList)
                        {
                            string cmdText = myDe.CommandText;
                            SqlParameter[] cmdParms = (SqlParameter[])myDe.Parameters;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);

                            if (myDe.EffentNextType == EffentNextType.WhenHaveContine || myDe.EffentNextType == EffentNextType.WhenNoHaveContine)
                            {
                                if (myDe.CommandText.ToLower().IndexOf("count(") == -1)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                object obj = cmd.ExecuteScalar();
                                bool isHave = false;
                                if (obj == null && obj == DBNull.Value)
                                    isHave = false;
                                isHave = Convert.ToInt32(obj) > 0;
                                if (myDe.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                if (myDe.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                continue;
                            }
                            int val = cmd.ExecuteNonQuery();
                            count += val;
                            if (myDe.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
                            {
                                trans.Rollback();
                                return 0;
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        return count;
                    }
                    catch 
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        //执行多条SQL语句，实现数据库事务
        public static void ExecuteSqlTranWithIndentity(List<CommandInfo> SqlStringList)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
               
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        foreach (CommandInfo myDe in SqlStringList)
                        {
                            string cmdText = myDe.CommandText;
                            SqlParameter[] cmdParms = (SqlParameter[])myDe.Parameters;
                            foreach (SqlParameter q in cmdParms)
                            {
                                //参数的方向
                                if (q.Direction == ParameterDirection.InputOutput)
                                    q.Value = indentity;
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                    indentity = Convert.ToInt32(q.Value);
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch //(SqlException e)
                    {
                        trans.Rollback();
                        throw;
                    }
                }    
            }
        }
        //执行多条SQL语句，实现数据库事务
        public static void ExecuteSqlTransWithIndentity(Hashtable SqlStringList)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
             
            }
            using(SqlConnection conn=new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        foreach (DictionaryEntry myDe in SqlStringList)
                        {
                            string cmdText = myDe.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDe.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                    q.Value = indentity;
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                    indentity = Convert.ToInt32(q.Value);
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch// (SqlException e)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        //执行一条计算查询结果语句，返回查询结果
        public static object GetSingle(string Sqlstring, params SqlParameter[] cmdParms)
        {

            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, Sqlstring, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if((Object.Equals(obj,null))||(Object.Equals(obj,DBNull.Value)))
                            return null;
                        else 
                            return obj;
                    }
                    catch(SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        //执行查询语句，返回SqlDataReader
        public static SqlDataReader ExecuteReader(string SqlString, params SqlParameter[] cmdParms)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
           
            }
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, conn, null, SqlString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        //执行查询语句，返回DataSet
        public static DataSet Query(string SqlString,params SqlParameter[] cmdParms)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
           
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, SqlString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                    return ds;
                }
            }
        }
        //PrepareCommand函数实现
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn,SqlTransaction trans,string cmdText,SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion

        #region 存储过程操作
        //执行存储过程，返回SqlDataReader
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
           
            }
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            conn.Open();
            SqlCommand cmd = BuildQueryCommand(conn, storedProcName, parameters);
            cmd.CommandType = CommandType.StoredProcedure;
            returnReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;
        }
        //执行存储过程，返回DataSet
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters,string tableName)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
                return null;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlDa.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                sqlDa.Fill(dataSet,tableName);
                conn.Close();
                return dataSet;
            }
        }
        //执行存储过程，返回DataSet，有时间限制
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
              
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlDa.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                sqlDa.SelectCommand.CommandTimeout = Times;
                sqlDa.Fill(dataSet, tableName);
                conn.Open();
                return dataSet;
            }
        }
        //构建SqlCommand对象
        private static SqlCommand BuildQueryCommand(SqlConnection conn, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(storedProcName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                { 
                    //检查未分配值得输出参数，将其分配以DBNull.Value
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                        parameter.Value = DBNull.Value;
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd;
        }
        //执行存储过程，返回影响的行数
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int result;
                conn.Open();
                SqlCommand cmd = BuildIntCommand(conn, storedProcName, parameters);
                rowsAffected = cmd.ExecuteNonQuery();
                result = (int)cmd.Parameters["ReturnValue"].Value;
                return result;
            }
        }
        //创建SqlCommand对象实例
        private static SqlCommand BuildIntCommand(SqlConnection conn, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand cmd = BuildQueryCommand(conn, storedProcName, parameters);
            cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return cmd;
        }
        #endregion

        #region 数据库备份还原
        public static bool BackupDatabase(string path)
        { 
             if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
            }
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if ( connection.State != ConnectionState.Open )
                    {
                        connection.Open();
                    }
                    cmd.Connection = connection;
                    cmd.CommandText = "backup database " + db + " to disk = '" + path.Trim() + "'";
//执行存储过程，SqlCommand_ExecuteNonQuery 方法总是返回-1，调试了好长时间，查看数据库已经执行存储过程。
//具体原因为：

//SqlCommand_ExecuteNonQuery 方法返回值
//  1、对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。

//  2、对于所有其他类型的语句，返回值为 -1。如果发生回滚，返回值也为 -1。
                    int row=cmd.ExecuteNonQuery();
                    if (row==-1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool RecoverDatabase(string path)
        {
            if (!DbHelperSql.ExistSqlServerService())
            {
                MessageBox.Show("未检测到服务器开启，请检查服务器开启是否启动正常！");
                System.Environment.Exit(0);
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    cmd.Connection = connection;
                    cmd.CommandText = "use master restore database " + db + " from disk='" + path.Trim() + "'";
                    //cmd.CommandText = "use master restore database db_EMMS from disk='" + path.Trim() + "'";
                    int row = cmd.ExecuteNonQuery();
                    if (row ==-1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion
    }
}
