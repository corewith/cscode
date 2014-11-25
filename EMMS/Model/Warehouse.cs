using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class WarehouseSet //仓库表设置
    {
        public WarehouseSet()
        {
            Useable = 1;//默认可用   
        }
        public string No { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }//仓库类别 
        public int Useable { get; set; }//是否可用，0表示不可以用，1表示可用
        public string Remarks { get; set; }
    }
    public class WarehouseGet//仓库表得到
    {
        public WarehouseGet()
        { }
        public string No { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public int Useable { get; set; }//0表示不可用，1表示可用
        public string Remarks { get; set; }
    }
    public class WarehouseView //仓库表显示
    {
        public WarehouseView()
        { }
        public string No { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public bool Disabled { get; set; }//布尔值，对应checkbox的值,为选择表示可用，选择表示不可用
        public string Remarks { get; set; }
    }
}
