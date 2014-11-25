using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMMS.View.purchasing
{
    public partial class Supplier : Form
    {
        private List<EMMS.Model.Supplier> modelList = new List<Model.Supplier>();
        private EMMS.BLL.Supplier bll = new BLL.Supplier();
        private int count;//保存dgvWarehouseATtri的行数
        public bool flag { get; set; }
        public EMMS.Common.View view = new Common.View();

        public Supplier()
        {
            flag = false;
            InitializeComponent();
        }
        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }

        private void BindData()
        {
            DataSet ds = new DataSet();
            ds = bll.GetAllList();
            dgvSupplier.DataSource = ds.Tables["ds"];
        }
        //加载
        private void Supplier_Load(object sender, EventArgs e)
        {
            BindData();
            dgvSupplier.AllowUserToAddRows = false;
            //dgvWarehouseAttri.Columns[0].HeaderText = "序号";
            dgvSupplier.Columns[0].HeaderText = "供应商编码";
            dgvSupplier.Columns[1].HeaderText = "供应商名称";
            dgvSupplier.Columns[0].Frozen = true;

            //dgvWarehouseAttri.Columns[0].ToolTipText = "请输入不多于2位的数字";
            //dgvWarehouseAttri.Columns[1].ToolTipText = "请输入不多于5位的汉字";

            //dgvWarehouseAttri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;// ExceptHeader;
            //dgvWarehouseAttri.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dgvWarehouseAttri.RowHeadersWidthSizeMode =DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders; 

            //dgvWarehouseAttri.EditMode = DataGridViewEditMode.EditProgrammatically;//不可编辑
            count = dgvSupplier.Rows.Count;
            for (int i = 0; i < count; i++)
                dgvSupplier.Rows[i].ReadOnly = true;
        }
        //添加
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            dgvSupplier.AllowUserToAddRows = true;
            if (dgvSupplier.NewRowIndex != -1)
                dgvSupplier.Rows[dgvSupplier.NewRowIndex].ReadOnly = false;
        }

        private void dgvWarehouseAttri_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        //删除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            dgvSupplier.AllowUserToAddRows = false;
            if (!(dgvSupplier.SelectedRows.Count > 0))
            {
                MessageBox.Show("请至少选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvSupplier.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (MessageBox.Show("确定要删除该行吗？", "确定删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                    string no = row.Cells[0].Value.ToString();
                    if (bll.Delete(no))
                    {
                        MessageBox.Show("删除成功！");
                        
                    }
                    //dgvWarehouseAttri.Rows.Remove(row);
                }
            }
            BindData();
        }
        //保存
        private void tsbSave_Click(object sender, EventArgs e)
        {
            //this.BindingContext[dgvWarehouseAttri].EndCurrentEdit();
            //在保存前调用此方法触发cellendedit事件
            dgvSupplier.EndEdit();

            for (int i = count; i < dgvSupplier.Rows.Count - 1; i++)
            {
                try
                {
                    string no = dgvSupplier.Rows[i].Cells[0].Value.ToString();
                    string name = dgvSupplier.Rows[i].Cells[1].Value.ToString();
                    //验证no，name的值
                    if (EMMS.Common.PageValidate.IsNumber(no))//no是数字
                    {
                        no = EMMS.Common.PageValidate.StringCheck(no, 2);//no至多2位
                    }
                    else
                    {
                        MessageBox.Show("仓库属类别码输入不合法！请重新输入！");
                        return;
                    }
                    if (EMMS.Common.PageValidate.IsCHZN(name))//name是中文
                    {
                        name = EMMS.Common.PageValidate.StringCheck(name, 5);
                    }
                    else
                    {
                        MessageBox.Show("仓库类别名称输入不合法，请重新输入！");
                        return;
                    }
                    modelList.Add(new Model.Supplier() { No = no, Name = name });
                }
                catch
                {
                    MessageBox.Show("信息不能为空，请填写完整！");
                }
            }
            //MessageBox.Show(dgvWarehouseAttri.Rows.Count.ToString());
            int num = bll.AddList(modelList);
            if (num > 0)
            {
                if (num != dgvSupplier.Rows.Count - count - 1)
                    MessageBox.Show("由于某些原因，部分保存成功！");
                else
                    MessageBox.Show("保存成功！");
            }
            //不可编辑
            count += num;
            for (int i = 0; i < count; i++)
                dgvSupplier.Rows[i].ReadOnly = true;
            dgvSupplier.AllowUserToAddRows = false;
        }
        //删除事件
        private void dgvWarehouseAttri_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSupplier.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (MessageBox.Show("确定要删除该行吗？", "确定删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                    string no = row.Cells[0].Value.ToString();
                    if (bll.Delete(no))
                        MessageBox.Show("删除成功！");
                    //dgvWarehouseAttri.Rows.Remove(row);
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            BindData();
            dgvSupplier.AllowUserToAddRows = false;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            dgvSupplier.AllowUserToAddRows = false;
            this.Dispose();
        }

        private void dgvWarehouseAttri_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //MessageBox.Show("增加了一行！ ");
        }

        private void dgvWarehouseAttri_CurrentCellChanged(object sender, EventArgs e)
        {
          
        }

        private void dgvWarehouseAttri_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.ToolTipText = "请输入不多于2位的数字";
            else if (e.ColumnIndex == 1)
                e.ToolTipText = "请输入不多于5位的汉字";
        }

        private void dgvWarehouseAttri_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }

        private void dgvWarehouseAttri_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (flag)
            {
                EMMS.Model.Supplier model = new Model.Supplier();
                string no = dgvSupplier.Rows[e.RowIndex].Cells[0].Value.ToString();
                model = bll.GetModel(no);
                view.SupplierModel = model;
                view.SupplierFlag = 1;
                //add.tbType.Text = model.Name;
                this.Dispose();
            }
        }

    }
}
