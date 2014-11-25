using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Stocking_OrderSet
    {
        public Stocking_OrderSet()
        {
            //DateTime dt = DateTime.Now;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            Random rm = new Random();
            int  ram = rm.Next(100000);
            //string no = string.Format("{0:yyyymddhhmmss}", dt);
            string no = year + month + day + ram.ToString();
            No = no;
            Type = 0; //默认是物料入库
        }
        public string No { get; set; }
        public string Entry { get; set; }
        public string Warehouse { get; set; }
        public int Type { get; set; } //类别
        public string FoundNo { get; set; }
        public string FoundTime { get; set; }
        public string Remarks { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
    }
    public class Stocking_MaterialSet
    {
        public Stocking_MaterialSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
        }
        public string No { get; set; }
        public string Stocking { get; set; }
        public string Material { get; set; }
        public int Counts { get; set; }
    }
    public class Stocking_OrderView
    {
        public Stocking_OrderView()
        {
            //DateTime dt = DateTime.Now;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            Random rm = new Random();
            int ram = rm.Next(100000);
            //string no = string.Format("{0:yyyymddhhmmss}", dt);
            string no = year + month + day + ram.ToString();
            No = no;
            Type = false; 
        }
        public string No { get; set; }//入库编码
        public string WarehouseName { get; set; }//仓库名称
        public bool Type { get; set; }
        public string FoundName { get; set; }//经手人
        public string FoundTime { get; set; }//入库时间
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }//备注
        public string Entry { get; set; }
        //List<MaterialView> MaterialList { get; set; }
    }
    public class Stocking_MaterialView
    {
        public Stocking_MaterialView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
        }
        public string No { get; set; }
        public string MaterialName { get; set; }
        public int Counts { get; set; }
        public string Unit { get; set; }
        //public float Price { get; set; }
        //public string PriceUnit { get; set; }
        public string MaterialNo { get; set; }
    }
}
