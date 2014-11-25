using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMMS.View.staff
{
    public partial class Department : Form
    {
        private List<EMMS.Model.Department> modelList = new List<Model.Department>();
        private EMMS.BLL.Department bll = new BLL.Department();
        private int count;//保存dgvWarehouseATtri的行数
        public bool flag { get; set; }
        //public Add add = new Add();
        public EMMS.Common.View view;

        public Department()
        {
            flag = false;
            InitializeComponent();
        }
        public void GetParent(EMMS.Common.View view)//EMMS.View.staff.Add add)
        {
            this.view = view;
        }

        private void BindData()
        {
            DataSet ds = new DataSet();
            ds = bll.GetAllList();
            dgvDepartment.DataSource = ds.Tables["ds"];
        }
        //加载
        private void WarehouseAttri_Load(object sender, EventArgs e)
        {
            BindData();

            dgvDepartment.AllowUserToAddRows = false;
            //dgvWarehouseAttri.Columns[0].HeaderText = "序号";
            dgvDepartment.Columns[0].HeaderText = "部门编码";
            dgvDepartment.Columns[1].HeaderText = "部门名称";
            dgvDepartment.Columns[0].Frozen = true;
            dgvDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            count = dgvDepartment.Rows.Count;
            for (int i = 0; i < count; i++)
                dgvDepartment.Rows[i].ReadOnly = true;
        }

        //添加
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            dgvDepartment.AllowUserToAddRows = true;
            if (dgvDepartment.NewRowIndex != -1)
                dgvDepartment.Rows[dgvDepartment.NewRowIndex].ReadOnly = false;
        }

        private void dgvWarehouseAttri_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        //删除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            dgvDepartment.AllowUserToAddRows = false;
            if (!(dgvDepartment.SelectedRows.Count > 0))
            {
                MessageBox.Show("请至少选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvDepartment.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (MessageBox.Show("确定要删除该行吗？", "确定删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                    string no = row.Cells[0].Value.ToString();
                    if (bll.Delete(no))
                    {
                        MessageBox.Show("删除成功！");
                        BindData();
                    }
                    //dgvWarehouseAttri.Rows.Remove(row);
                }
            }
        }
        //保存
        private void tsbSave_Click(object sender, EventArgs e)
        {
            //this.BindingContext[dgvWarehouseAttri].EndCurrentEdit();
            //在保存前调用此方法触发cellendedit事件
            dgvDepartment.EndEdit();

            for (int i = count; i < dgvDepartment.Rows.Count - 1; i++)
            {
                try
                {
                    string no = dgvDepartment.Rows[i].Cells[0].Value.ToString();
                    string name = dgvDepartment.Rows[i].Cells[1].Value.ToString();
                    //验证no，name的值
                    if (EMMS.Common.PageValidate.IsNumberLetter(no))//no是数字+字母
                    {
                        no = EMMS.Common.PageValidate.StringCheck(no, 8);//no至多8位
                    }
                    else
                    {
                        MessageBox.Show("部门编码输入不合法！请重新输入！");
                        return;
                    }
                    if (EMMS.Common.PageValidate.IsCHZN(name))//name是中文
                    {
                        name = EMMS.Common.PageValidate.StringCheck(name, 5);
                    }
                    else
                    {
                        MessageBox.Show("部门名称输入不合法，请重新输入！");
                        return;
                    }
                    modelList.Add(new Model.Department() { No = no, Name = name });
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
                if (num != dgvDepartment.Rows.Count - count - 1)
                    MessageBox.Show("由于某些原因，部分保存成功！");
                else
                    MessageBox.Show("保存成功！");
            }
            //不可编辑
            count += num;
            for (int i = 0; i < count; i++)
                dgvDepartment.Rows[i].ReadOnly = true;
            dgvDepartment.AllowUserToAddRows = false;
        }
        //删除事件
        private void dgvWarehouseAttri_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDepartment.SelectedRows)
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
            dgvDepartment.AllowUserToAddRows = false;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            dgvDepartment.AllowUserToAddRows = false;
            this.Dispose();
        }

        private void dgvWarehouseAttri_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
          
        }

        private void dgvWarehouseAttri_CurrentCellChanged(object sender, EventArgs e)
        {
          
        }

        private void dgvWarehouseAttri_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.ToolTipText = "请输入不多于8位的数字和字母";
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
                EMMS.Model.Department model = new Model.Department();
                string no = dgvDepartment.Rows[e.RowIndex].Cells[0].Value.ToString();
                model = bll.GetModel(no);
                view.DepartmentFlag = 1;
                view.DepartmentModel = model;
                //add.tbDepartment.Text = model.Name;
                this.Dispose();
            }
        }
    }
}
