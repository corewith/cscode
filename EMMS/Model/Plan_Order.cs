using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Plan_OrderSet
    {
        public Plan_OrderSet()
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
            Ended = 0;
            Status = "未领料";
        }
        public string No { get; set; }
        public string FoundNo { get; set; }
        public string FoundTime { get; set; }
        
        public int Audited { get; set; }
        public string Status { get; set; }
        public int Ended { get; set; }
        public string Remarks { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
        
    }
    public class Plan_ProductionSet
    {
        public Plan_ProductionSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Audited = 0;
        }
        public string No { get; set; }
        public string PlanNo { get; set; }
        public string Goods { get; set; }
        public int Counts { get; set; }
        public string CheckNo { get; set; }
        public string CheckTime { get; set; }
        public int Audited { get; set; }
        public int CheckCounts { get; set; }
    }
    public class Plan_OrderView
    {
        public Plan_OrderView()
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
            Ended = false;
        }
        public string No { get; set; }
        public string FoundName { get; set; }
        public string FoundTime { get; set; }
        public bool Audited { get; set; }
        public string Status { get; set; }
        public bool Ended { get; set; }
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        //public List<Plan_ProductionView> ProductionList { get; set; }
    }
    public class Plan_ProductionView
    {
        public Plan_ProductionView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
        }
        public string No { get; set; }
        //public string PlanNo { get; set; }
        public string GoodsName { get; set; }
        public int Counts { get; set; }
        //public string CheckName { get; set; }
        public bool Audited { get; set; }
        public int CheckCounts { get; set; }
        public string CheckTime { get; set; }
        public string GoodsNo { get; set; }
    }
}
