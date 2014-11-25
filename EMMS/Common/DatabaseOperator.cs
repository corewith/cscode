using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMMS.DbHelper;

namespace EMMS.Common
{
    public class DatabaseOperator
    {
        public DatabaseOperator()
        {
        
        }
        public bool BackupDatabase(string path)
        {
            return DbHelperSql.BackupDatabase(path);
        }
        public bool RecoverDatabase(string path)
        {
            return DbHelperSql.RecoverDatabase(path);
        }
    }
}
