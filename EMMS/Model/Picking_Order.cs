using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Picking_OrderSet
    {
        public Picking_OrderSet()
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
            Ended = 0;
            Status = "未出库";
        }
        public string No { get; set; }
        public string PlanNo { get; set; }
        public string Department { get; set; }
        public string FoundNo { get; set; }
        public string FoundTime { get; set; }
        public string Status { get; set; }
        public int Ended { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
    }
    public class Picking_MaterialSet
    {
        public Picking_MaterialSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Stocking = 0;//出库数量默认为0
        }
        public string No { get; set; }
        public string Picking { get; set; }
        public string Material { get; set; }
        public int Counts { get; set; }
        public int Stocking { get; set; }
    }
    public class Picking_OrderView
    {
        public Picking_OrderView()
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
        public string DepartmentName { get; set; }
        public string FoundName { get; set; }
        public string FoundTime { get; set; }
        public string Status { get; set; }
        public bool Ended { get; set; }
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        public string PlanNo { get; set; }
    }
    public class Picking_MaterialView
    {
        public Picking_MaterialView()
        {
             No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
             Stocking = 0;
        }
        public string No { get; set; }
        public string MaterialName { get; set; }
        public int Counts { get; set; }
        public string Unit { get; set; }
        public string MaterialNo { get; set; }
        public int Stocking { get; set; }
    }
    //public class PMViewList
    //{
    //    public PMViewList()
    //    { 
    //    }
    //    public List<EMMS.Model.Picking_MaterialView> ViewList = new List<Picking_MaterialView>();
    //    public int  this[string no]//索引器
    //    {
    //        get
    //        {
    //            for (int i = 0; i < ViewList.Count; i++)
    //            {
    //                if (ViewList[i].No == no)
    //                {
    //                    return i;
    //                }
    //            }
    //            return ViewList.Count;
    //        }
    //    }
    //}
}
