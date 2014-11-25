using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.warehouse
{
    public partial class Add : Form
    {
        public EMMS.Model.WarehouseAttri warehouseAttrimodel = new Model.WarehouseAttri();
        private EMMS.BLL.Warehouse bll = new BLL.Warehouse();
        private EMMS.Model.WarehouseSet warehousemodel = new Model.WarehouseSet();
        public int flag = 0;
        public Add()
        {
            InitializeComponent();
            ttNo.SetToolTip(tbNo, "请输入不超过8位的数字和字母组合");
            ttName.SetToolTip(tbName, "请输入不超过的5位的中文");
        }

        private void btnAttri_Click(object sender, EventArgs e)
        {
            WarehouseAttri warehouseAttri = new WarehouseAttri();
            warehouseAttri.flag = true;
            warehouseAttri.GetParent(this);
            warehouseAttri.ShowDialog();
        }
        //保存
        private void Save()
        {
            if (String.IsNullOrEmpty(tbNo.Text))
            {
                MessageBox.Show("仓库编码不能为空！");
                return;
            }
            else if (String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("仓库名称不能为空");
                return;
            }
            else if (String.IsNullOrEmpty(tbType.Text))
            {
                MessageBox.Show("仓库类别未选择");
                return;
            }
            else
            {
                string no = EMMS.Common.PageValidate.StringCheck(tbNo.Text, 8);
                string name = EMMS.Common.PageValidate.StringCheck(tbName.Text, 5);
                string type = warehouseAttrimodel.No;
                int useable = (ckbDisabled.Checked) ? 0 : 1;
                string remarks = EMMS.Common.PageValidate.StringCheck(tbRemarks.Text, 50);
                if (!((EMMS.Common.PageValidate.IsNumberLetter(no)) && (EMMS.Common.PageValidate.IsCHZN(name))))
                {
                    MessageBox.Show("输入值不合法，请重新输入！");
                    return;
                }
                warehousemodel.No = no;
                warehousemodel.Name = name;
                warehousemodel.Type = type;
                warehousemodel.Useable = useable;
                warehousemodel.Remarks = remarks;
                if (flag == 0)
                {
                    if (bll.Exists(no))
                    {
                        MessageBox.Show("已有相同编码的仓库存在，请换个编码！");
                        return;
                    }
                    if (bll.Add(warehousemodel))
                        MessageBox.Show("保存成功！");
                }
                else if (flag == 1)
                    if (bll.Update(warehousemodel))
                        MessageBox.Show("保存成功");
            }
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        //关闭
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbSaveAdd_Click(object sender, EventArgs e)
        {
            Save();
            tbNo.Text = "";
            tbName.Text = "";
            tbType.Text = "";
            tbRemarks.Text = "";
            ckbDisabled.Checked = false;
        }

        private void tsbSaveClose_Click(object sender, EventArgs e)
        {

            Save();
            this.Dispose();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                tbNo.ReadOnly = true;
            }
        }
    }
}
