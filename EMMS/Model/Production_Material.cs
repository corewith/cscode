using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMMS.Model
{
    public class Production_MaterialSet
    {
        public Production_MaterialSet()//
        { 
        }
        public string No { get; set; }//产品BOM编码
        public string ProductionNo { get; set; }
        public string MaterialNo { get; set; }
        public float Proporation { get; set; }
    }
    public class Production_MaterialGet//
    {
        public Production_MaterialGet()
        { }
        public string ProductionNo { get; set; }
        public List<MaterialNoView> MaterialNolist { get; set; }
    }
    public class Production_MaterialView//
    {
        public Production_MaterialView()
        { }
        public string ProductionName { get; set; }
        public List<MaterialNameView> MaterialNameList { get; set; }
    }
    public class MaterialNoView
    {
        public MaterialNoView()
        { }
        public string No { get; set; }//tb_production_material中的no
        public string MaterialNo { get; set; }//tb_production_material中的material_no
        public float Proporation { get; set; }
    }
    public class MaterialNameView//view中显示的
    {
        public MaterialNameView()
        { }
        public string No { get; set; }
        public string MaterialName { get; set; }
        public float Proporation { get; set; }
        public string MaterialNo { get; set; }
    }
    public class BOM
    {
        public BOM()
        { }
        //--物料编码，物料名称，物料类别，物料单位，物料比例
        public string No { get; set; }
        public string MaterialName { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public float Proporation { get; set; }
    }
}
