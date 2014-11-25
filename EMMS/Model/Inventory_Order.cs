using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Inventory_OrderSet
    {
        public Inventory_OrderSet()
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
        }
        public string No { get; set; }
        public string Warehouse { get; set; }
        public string FoundNo { get; set; }
        public string FoundTime { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        public string Picking { get; set; }
    }
    public class Inventory_MaterialSet
    {
        public Inventory_MaterialSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
        }
        public string No { get; set; }
        public string Inventory { get; set; }
        public string Goods { get; set; }
        public int Counts { get; set; }
        public int Critical { get; set; }
        public int Need { get; set; }
    }
    public class Inventory_OrderView
    {
        public Inventory_OrderView()
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
        }
        public string No { get; set; }
        public string WarehouseName { get; set; }
        public string FoundName { get; set; }
        public string FoundTime { get; set; }
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        public string Picking { get; set; }
    }
    public class Inventory_MaterialView
    {
        public Inventory_MaterialView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
        }
        public string No { get; set; }
        public string GoodsName { get; set; }
        public int Counts { get; set; }
        public int Critical { get; set; }
        public int Need { get; set; }
        public string GoodsNo { get; set; }
    }
}
