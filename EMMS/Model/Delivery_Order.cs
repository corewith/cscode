using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Delivery_OrderSet
    {
        public Delivery_OrderSet()
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
            Audited = 0;//默认未
            Ended = 0;//默认未结束
        }
        public string No { get; set; }
        public string Picking { get; set; }
        public string Department { get; set; }//目标单位编码
        public string Warehouse { get; set; }//仓库编码
        public string FoundNo { get; set; }//创建人员编码
        public string FoundTime { get; set; }//创建时间
        public int Audited { get; set; }//是否
        public int Ended { get; set; }//是否结束
        public string Remarks { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
    }
    public class Delivery_MaterialSet
    {
        public Delivery_MaterialSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            //CheckCounts = Counts;
            Audited = 0;//默认未审核
            //Stocking = 0;//默认出库数量为0
            //Total = 0;//默认总出库数量为0
        }
        public string No { get; set; }
        public string Delivery { get; set; }
        public string Material { get; set; }
        public int Counts { get; set; } //所需物料
        public int Stocking { get; set; } //出库物料
        public string CheckNo { get; set; }//审核人员编码
        public int Audited { get; set; }//是否审核
        public int CheckCounts { get; set; }//审核数量
        public string CheckTime { get; set; }//审核时间
       // public int Total { get; set; }
        
    }
    public class Delivery_OrderView
    {
        public Delivery_OrderView()
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
        public string DepartmentName { get; set; }
        public string WarehouseName { get; set; }
        public string FoundName { get; set; }
        public string FoundTime { get; set; }
        public bool Audited { get; set; }
        public bool Ended { get; set; }
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        public string Picking { get; set; }
    }
    public class Delivery_MaterialView
    {
        public Delivery_MaterialView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Audited = false;
            //Stocking = 0;
            //Total = 0;
        }
        public string No { get; set; }
        public string MaterialName { get; set; }       
        public int Need { get; set; } //所需库存
        public int Stocking { get; set; } //已出库的数量
        //public string CheckName { get; set; }
        public bool Audited { get; set; } //审核
        public int CheckCounts { get; set; } //审核数量
        public string CheckTime { get; set; } //
        public string MaterialNo { get; set; }
        public int Counts { get; set; } //库存数量
        public int Critical { get; set; } //警戒线
        //public int Total { get; set; }
    }
}
