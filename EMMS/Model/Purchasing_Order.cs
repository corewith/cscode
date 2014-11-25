using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Purchasing_OrderSet
    {
        public Purchasing_OrderSet()
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
            Audited = 0;
            Status = "未进购";
            Ended = 0;
        }
        public string No { get; set; }
        public string Requisition { get; set; }
        public string Supplier { get; set; }
        public string FoundNo { get; set; }
        public string FoundTime { get; set; }
        public int Audited { get; set; }
        public string Status { get; set; }
        public int Ended { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
    }
    public class Purchasing_MaterialSet
    {
        public Purchasing_MaterialSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Audited = 0;
        }
        public string No { get; set; }
        public string Purchasing { get; set; }
        public string Material { get; set; }
        public int Counts { get; set; }
        public string CheckNo { get; set; }
        public string CheckTime { get; set; }
        public int Audited { get; set; }
        public int CheckCounts { get; set; }
    }
    public class Purchasing_OrderView
    {
        public Purchasing_OrderView()
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
            Audited = false;
            Status = "未进购";
            Ended = false;
        }
        public string No { get; set; }
        public string SupplierName { get; set; }
        public string FoundName { get; set; }
        public string FoundTime { get; set; }
        public bool Audited { get; set; }
        public string Status { get; set; }
        public bool Ended { get; set; }
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        public string Requisition { get; set; }
    }
    public class Purchasing_MaterialView
    {
        public Purchasing_MaterialView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Audited = false;
        }
        public string No { get; set; }
        public string MaterialName { get; set; }
        public int Counts { get; set; }
        //public string CheckName { get; set; }
        public string CheckTime { get; set; }
        public bool Audited { get; set; }
        public int CheckCounts { get; set; }
        public string MaterialNo { get; set; }
    }
}
