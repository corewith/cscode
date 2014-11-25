using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMMS.View.warehouse
{
    public partial class WarehouseAttri : Form
    {
        private List<EMMS.Model.WarehouseAttri> modelList=new List<Model.WarehouseAttri>();
        private EMMS.BLL.WarehouseAttri bll = new BLL.WarehouseAttri();
        private int count;//保存dgvWarehouseATtri的行数
        public bool flag { get; set; }
        public Add add = new Add();

        public WarehouseAttri()
        {
            flag = false;
            InitializeComponent();
        }
        public void GetParent(EMMS.View.warehouse.Add add)
        {
            this.add = add;
        }

        private void BindData()
        {
            DataSet ds = new DataSet();
            ds = bll.GetAllList();
            dgvWarehouse.DataSource = ds.Tables["ds"];
        }
        //加载
        private void WarehouseAttri_Load(object sender, EventArgs e)
        {
            BindData();

            //DataSet ds = new DataSet();
            //ds = bll.GetAllList();

            //dgvWarehouseAttri.DataSource = ds.Tables["ds"];
            
            //添加了using System.Data.SqlClient;
            //添加了DAL引用
            //string strConn = "Data Source=127.0.0.1,1433 ;User ID=sa;Password=corewith;Initial Catalog=db_EMMS;Persist Security Info=True;";//EMMS.DbHelper.PubConstant.ConnectionString;
            //string strCmd = "select no,name from tb_warehouseAttri";
            //using (SqlConnection conn = new SqlConnection(strConn))
            //{
            //    conn.Open();
            //    SqlDataAdapter sa = new SqlDataAdapter(strCmd, conn);
            //    DataSet ds = new DataSet();
            //    sa.Fill(ds, "ds");
            //    dgvWarehouseAttri.DataSource = ds.Tables["ds"];
            //}

            dgvWarehouse.AllowUserToAddRows = false;
            //dgvWarehouseAttri.Columns[0].HeaderText = "序号";
            dgvWarehouse.Columns[0].HeaderText = "仓库类别编码";
            dgvWarehouse.Columns[1].HeaderText = "仓库类别名称";
            dgvWarehouse.Columns[0].Frozen = true;

            //dgvWarehouseAttri.Columns[0].ToolTipText = "请输入不多于2位的数字";
            //dgvWarehouseAttri.Columns[1].ToolTipText = "请输入不多于5位的汉字";

            //dgvWarehouseAttri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;// ExceptHeader;
            //dgvWarehouseAttri.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvWarehouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dgvWarehouseAttri.RowHeadersWidthSizeMode =DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders; 

            //dgvWarehouseAttri.EditMode = DataGridViewEditMode.EditProgrammatically;//不可编辑
            count = dgvWarehouse.Rows.Count;
            for(int i=0;i<count;i++)
                dgvWarehouse.Rows[i].ReadOnly = true;
        }

        //添加
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            dgvWarehouse.AllowUserToAddRows = true;
            if(dgvWarehouse.NewRowIndex!=-1)
                dgvWarehouse.Rows[dgvWarehouse.NewRowIndex].ReadOnly = false;
        }

        private void dgvWarehouseAttri_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //删除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            dgvWarehouse.AllowUserToAddRows = false;
            if (!(dgvWarehouse.SelectedRows.Count>0))
            {
                MessageBox.Show("请至少选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvWarehouse.SelectedRows)
            {
                if (row.Cells[0].Value.Equals("01") || row.Cells[0].Value.Equals("02"))
                {
                    MessageBox.Show("系统预设值，不可删除");
                    return;
                }
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
            dgvWarehouse.EndEdit();
            modelList.Clear();//先清空
            for (int i = count; i < dgvWarehouse.Rows.Count-1; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(dgvWarehouse.Rows[i].Cells[0].Value.ToString()) || string.IsNullOrEmpty(dgvWarehouse.Rows[i].Cells[1].Value.ToString()))
                    {
                        MessageBox.Show("信息不能为全，请填写完整！");
                        return;
                    }
                    string no = dgvWarehouse.Rows[i].Cells[0].Value.ToString();
                    string name = dgvWarehouse.Rows[i].Cells[1].Value.ToString();
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
                    modelList.Add(new Model.WarehouseAttri() { No = no, Name = name });
                }
                catch
                {
                    MessageBox.Show("信息不能为全，请填写完整！");
                }
            }
            //MessageBox.Show(dgvWarehouseAttri.Rows.Count.ToString());
            int num = bll.AddList(modelList);
            if (num > 0)
            {
                if (num != dgvWarehouse.Rows.Count - count - 1)
                    MessageBox.Show("由于某些原因，部分保存成功！");
                else
                    MessageBox.Show("保存成功！");
            }
                //不可编辑
                count += num;
                for (int i = 0; i < count; i++)
                    dgvWarehouse.Rows[i].ReadOnly = true;
                dgvWarehouse.AllowUserToAddRows = false;
        }
        //删除事件
        private void dgvWarehouseAttri_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dgvWarehouse.SelectedRows)
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
            dgvWarehouse.AllowUserToAddRows = false;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            dgvWarehouse.AllowUserToAddRows = false;
            this.Dispose();
        }

        private void dgvWarehouseAttri_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //MessageBox.Show("增加了一行！ ");
        }

        private void dgvWarehouseAttri_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (dgvWarehouseAttri.SelectedRows.Count > 0)
            //{
            //    if (dgvWarehouseAttri.CurrentRow.IsNewRow == true)//当前行是新行
            //    {
            //        intList.Add(dgvWarehouseAttri.CurrentCell.RowIndex);
            //    }
            //}
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
                EMMS.Model.WarehouseAttri model = new Model.WarehouseAttri();
                string no = dgvWarehouse.Rows[e.RowIndex].Cells[0].Value.ToString();
                model = bll.GetModel(no);
                add.warehouseAttrimodel = model;
                add.tbType.Text = model.Name;
                this.Dispose();
            }
        }
    }
}
