using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class StaffSet
    {
        public StaffSet()
        {
            Gender = 1;//男
            Login = 0;//不允许登录
            Resign = 0;//不离职
        }
        public string No { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }//职务编码
        public string Department { get; set; }//部门编码
        public int Login { get; set; }
        public int Resign { get; set; }
        public string Remarks { get; set; }
    }
    public class StaffGet
    {
        public StaffGet()
        { }
        public string No { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }//职务名称
        public string Department { get; set; }//部门名称
        public int Login { get; set; }
        public int Resign { get; set; }
        public string Remarks { get; set; }
    }
    public class StaffView
    {
        public StaffView()
        { }
        public string No { get; set; }
        public string Name { get; set; }
        public Sex Gender { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public string Department { get; set; }
        public bool Login { get; set; }
        public bool Resign { get; set; }
        public string Remarks { get; set; }
    }
    public enum Sex
    {
        男,女
    }
}
