using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace EMMS.DbHelper
{
    public class PubConstant
    {
        //获取连接字符串
        public static string ConnectionString
        {
            get
            {
                string _connectionString = Properties.Settings.Default["ConnectionString"].ToString();
                return _connectionString;
            }
        }

        //得到app.config里配置的数据库连接字符串
        public static string GetConnectionString(string configName)
        {
            return ConfigurationManager.ConnectionStrings[configName].ConnectionString.ToString();
        }
        public static string DB
        {
            get
            { 
                return  Properties.Settings.Default["DB"].ToString();
            }
        }
    }
}
