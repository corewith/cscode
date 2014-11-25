using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Entry_OrderSet
    {
        public Entry_OrderSet()
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
            Payed = 0;//默认未付款
            Status = "未付款";
        }
        public string No { get; set; }
        public string Purchasing { get; set; }
        public string Supplier { get; set; }
        public string FoundNo { get; set; }
        public string FoundTime { get; set; }
        public int Payed { get; set; }
        public string Status { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
    }
    public class Entry_MaterialSet
    { 
        public Entry_MaterialSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Payed = 0;
        }
        public string No { get; set; }
        public string Entry { get; set; }
        public string Material { get; set; }
        public int Counts { get; set; }
        public int Payed { get; set; }
    }
    public class Entry_OrderView
    {
        public Entry_OrderView()
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
            Status = "未付款";
            Payed = false;
        }
        public string No { get; set; }
        public string SupplierName { get; set; }
        public string FoundName { get; set; }
        public string FoundTime { get; set; }
        public string Status { get; set; }
        public bool Payed { get; set; }
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        public string Purchasing { get; set; }
    }
    public class Entry_MaterialView
    {
        public Entry_MaterialView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Payed = false;
        }
        public string No { get; set; }
        public string MaterialName { get; set; }
        public int Counts { get; set; }
        public bool Payed { get; set; }
        public string Unit { get; set; }
        public string MaterialNo { get; set; }
    }
}
