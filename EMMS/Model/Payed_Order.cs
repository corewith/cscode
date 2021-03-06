﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Payed_OrderSet
    {
        public Payed_OrderSet()
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
        }
        public string No { get; set; }
        public string Paying { get; set; }
        public string FoundNo{get;set;}
        public string FoundTime{get;set;}
        public int Audited { get; set; }
        public int Ended { get; set; }
        public string MakeNo { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
    }
    public class Payed_MaterialSet
    {
        public Payed_MaterialSet()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Audited = 0;
        }
        public string No { get; set; }
        public string Payed { get; set; }
        public string Material { get; set; }
        public int Counts { get; set; }
        public float Cost { get; set; }
        public int Audited { get; set; }
        public string CheckNo { get; set; }
        public string CheckTime { get; set; }
    }
    public class Payed_OrderView
    {
        public Payed_OrderView()
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
            Ended = false;
        }
        public string No { get; set; }
        public string FoundName { get; set; }
        public string FoundTime { get; set; }
        public bool Audited { get; set; }
        public bool Ended { get; set; }
        public string MakeName { get; set; }
        public string MakeTime { get; set; }
        public string Remarks { get; set; }
        public string Paying { get; set; }
    }
    public class Payed_MaterialView
    {
        public Payed_MaterialView()
        {
            No = System.Guid.NewGuid().ToString("N").Substring(0, 13);
            Audited = false;
        }
        public string No { get; set; }
        public string MaterialName { get; set; }
        public string Unit { get; set; }
        public int Counts { get; set; }
        public float Price { get; set; }
        public string PriceUnit { get; set; }
        public float Cost { get; set; }
        //public string CheckName { get; set; }
        public bool Audited { get; set; }
        public string CheckTime { get; set; }
        public string MaterialNo { get; set; }
    }
}
