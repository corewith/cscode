using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Storage_OrderSet
    {
        public Storage_OrderSet()
        {
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            Random rm=new Random();
            int ram = rm.Next(100);
            No = "S" + month + day + ram.ToString();
        }
        public string No { get; set; }
        public string WarehouseNo { get; set; }
        public string GoodsNo { get; set; }
        public int Counts { get; set; }
        public int Critical { get; set; }
        public string Remarks { get; set; }
    }
    public class Storage_OrderView
    {
        public Storage_OrderView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
        }
        public string No { get; set; }
        public string WarehouseName { get; set; }
        public string GoodsName { get; set; }
        public int Counts { get; set; }
        public int Critical { get; set; }
        public string Remarks { get; set; }
        public string GoodsNo { get; set; }
    }
}
