using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class User
    {
        public User()
        {
            Random rm = new Random();
            int ram = rm.Next(100000);
            Id = "U" + ram.ToString();
        }
        public string Id { get; set; }
        public string No { get; set; }//人员编码
        public int Role { get; set; }//角色编码
        public string Name { get; set; }//用户名
        public string Password { get; set; }//
    }
    public class Role
    {
        public Role()
        { }
        public int No { get; set; }
        public string Name { get; set; }
    }
}
