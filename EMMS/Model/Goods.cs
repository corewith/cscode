using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class GoodsSet
    {
        public GoodsSet()
        {
            Disable = 0;
            PriceUnit = "人民币元";
        }
        public string No { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }//物品类别编码
        public string Unit { get; set; }
        public float Price { get; set; }
        public string PriceUnit { get; set; }
        public int Disable { get; set; }
        public string Remarks { get; set; }
    }
    public class GoodsGet
    { 
        public GoodsGet()
        {}
        public string No { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }//物品类别名称
        public string Unit { get; set; }
        public float Price { get; set; }
        public string PriceUnit { get; set; }
        public int Disable { get; set; }
        public string Remarks { get; set; }
    }
    public class GoodsView
    {
        public GoodsView()
        { }
        public string No { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string Unit { get; set; }
        public float Price { get; set; }
        public string PriceUnit { get; set; }
        public bool Disable { get; set; }
        public string Remarks { get; set; }
    }
}
