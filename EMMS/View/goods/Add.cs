using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.goods
{
    public partial class Add : EMMS.Common.View
    {
        public EMMS.Model.GoodsAttri goodsAttrimodel = new Model.GoodsAttri();
        private EMMS.BLL.Goods bll = new BLL.Goods();
        private EMMS.Model.GoodsSet goodsmodel = new Model.GoodsSet();
        public int flag = 0;
        //public string priceunit = "人民币元";

        public Add()
        {
            InitializeComponent();
            ttNo.SetToolTip(tbNo, "请输入不超过8位的数字和字母组合");
            ttName.SetToolTip(tbName, "请输入不超过5位的中文");
            ttUnit.SetToolTip(tbUnit, "请输入一个中文");
            ttPrice.SetToolTip(tbPrice, "请输入数字");
        }

        private void btnAttri_Click(object sender, EventArgs e)
        {
            GoodsAttri GoodsAttri = new GoodsAttri();
            GoodsAttri.flag = true;
            GoodsAttri.GetParent(this);
            GoodsAttri.ShowDialog();
        }
        //保存
        private void save()
        { 
            if (String.IsNullOrEmpty(tbNo.Text))
            {
                MessageBox.Show("物品编码不能为空！");
                return;
            }
            else if (String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("物品名称不能为空");
                return;
            }
            else if (String.IsNullOrEmpty(tbType.Text))
            {
                MessageBox.Show("物品类别未选择");
                return;
            }
            else if (String.IsNullOrEmpty(tbUnit.Text))
            {
                MessageBox.Show("物品单位不能为空！");
                return;
            }
            else if (String.IsNullOrEmpty(tbPrice.Text))
            {
                MessageBox.Show("物品单价不能为空！");
                return;
            }
            else
            {
                
                string no = EMMS.Common.PageValidate.StringCheck(tbNo.Text, 8);
                string name = EMMS.Common.PageValidate.StringCheck(tbName.Text, 5);
                string type = goodsAttrimodel.No;
                string unit = EMMS.Common.PageValidate.StringCheck(tbUnit.Text, 1);
                float price=0;
                string priceunit = ((ComboBoxItem)cbPriceUnit.SelectedItem).DisplayValue;
                int disable = (ckbDisable.Checked) ? 1 : 0;
                string remarks = EMMS.Common.PageValidate.StringCheck(tbRemarks.Text, 50);
                if (flag == 0)
                {
                    if (bll.Exists(no))
                    {
                        MessageBox.Show("该物品编码已经存在，请重新输入一个！");
                        return;
                    }
                }
                try
                {
                    price = float.Parse(tbPrice.Text);
                    if (!((EMMS.Common.PageValidate.IsNumberLetter(no)) && (EMMS.Common.PageValidate.IsCHZN(name))))
                    {
                        MessageBox.Show("输入值不合法，请重新输入！");
                        return;
                    }
                 
                }
                catch
                {
                    MessageBox.Show("单价输入不合法，请重新输入！");
                    return;
                }
                finally
                {                   
                    goodsmodel.No = no;
                    goodsmodel.Name = name;
                    goodsmodel.Type = type;
                    goodsmodel.Unit = unit;
                    goodsmodel.Price = price;
                    goodsmodel.PriceUnit = priceunit;
                    goodsmodel.Disable = disable;
                    goodsmodel.Remarks = remarks;
                    if (flag == 0)
                    {
                        if (bll.Add(goodsmodel))
                            MessageBox.Show("保存成功！");
                    }
                    else if (flag == 1)
                        if (bll.Update(goodsmodel))
                            MessageBox.Show("保存成功");
                }
            }
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            save();
        }
        //关闭
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbSaveAdd_Click(object sender, EventArgs e)
        {
            save();
                tbNo.Text = "";
                tbName.Text = "";
                tbType.Text = "";
                tbUnit.Text = "";
                tbPrice.Text = "";
                cbPriceUnit.SelectedIndex = 0;
                tbRemarks.Text = "";
                ckbDisable.Checked = false;
            
        }

        private void tsbSaveClose_Click(object sender, EventArgs e)
        {
                save();
                this.Dispose();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            items.Add(new ComboBoxItem() {DisplayValue="人民币元",RealValue="0"});
            items.Add(new ComboBoxItem() {DisplayValue="美元",RealValue="1" });
            items.Add(new ComboBoxItem() {DisplayValue="欧元",RealValue="2" });
            items.Add(new ComboBoxItem() {DisplayValue="港元",RealValue="3" });
            cbPriceUnit.DataSource = items;
            cbPriceUnit.DisplayMember = "DisplayValue";
            cbPriceUnit.ValueMember = "RealValue";
            cbPriceUnit.SelectedIndex = 0;
        }

        private void Add_Activated(object sender, EventArgs e)
        {
            if (base.GoodsAttriModel.Name != null)
            {
                //this.tbGood
                this.tbType.Text= base.GoodsAttriModel.Name;
            }
        }
    }
    public class ComboBoxItem
    {
        public string DisplayValue { get; set; }
        public string RealValue { get; set; }
    }
}
