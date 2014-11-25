using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Paying_OrderSet
    {
        public Paying_OrderSet()
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
            Status = "未结算";
            Ended = 0;
        }
        public string No { get; set; }
        public string Entry { get; set; }
        public string Department { get; set; }
        public string FoundNo { get; set; }
        public string FoundTime { get; set; }
        public string Status { get; set; }
        public int Ended { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
    }
    public class Paying_MaterialSet
    {
        public Paying_MaterialSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
        }
        public string No { get; set; }
        public string Paying { get; set; }
        public string Material { get; set; }
        public int Counts { get; set; }
        public float Cost { get; set; } 
    }
    public class Paying_OrderView
    {
        public Paying_OrderView()
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
            Status = "未结算";
            Ended = false;
        }
        public string No { get; set; }
        public string DepartmentName { get; set; }
        public string FoundName { get; set; }
        public string FoundTime { get; set; }
        public string Status { get; set; }
        public  bool Ended { get; set; }
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        public string Entry { get; set; }
    }
    public class Paying_MaterialView
    {
        public Paying_MaterialView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
        }
        public string No { get; set; }
        public string MaterialName { get; set; }
        public string Unit { get; set; }
        public int Counts { get; set; }
        public float Price { get; set; }
        public string PriceUnit { get; set; }
        public float Cost { get; set; }
        public string MaterialNo { get; set; }
    }
}
