using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace EMMS.DbHelper
{
    public enum EffentNextType
    { 
        //对其他语句无任何影响
        None,
        //当前语句必须为"select count(1) from .."格式，如果存在则继续执行，不存在回滚事务
        WhenHaveContine,
        //当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
        WhenNoHaveContine,
        //当前语句影响到的行数必须大于0，否则回滚事务
        ExcuteEffectRows,
        //引发事件-当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
        SolicitationEvent
    }
    public class CommandInfo
    {
        public object ShareObject = null;
        public object OriginaData = null;
        event EventHandler _solicitationEvent;
        public event EventHandler SolicitationEvent
        {
            add
            {
                _solicitationEvent += value;
            }
            remove
            {
                _solicitationEvent -= value;
            }
        }
        public void OnSolicitationEvent()
        {
            if (_solicitationEvent != null)
                _solicitationEvent(this, new EventArgs());
        }
        public string CommandText;
        public DbParameter[] Parameters;
        public EffentNextType EffentNextType = EffentNextType.None;
        public CommandInfo()
        { 
            
        }
        public CommandInfo(string sqlText, SqlParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters=para;
        }
        public CommandInfo(string sqlText, SqlParameter[] para, EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
        }
    }
}
