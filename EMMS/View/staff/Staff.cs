using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.staff
{
    public partial class Staff : EMMS.Common.View
    {
        public EMMS.BLL.Staff bll = new BLL.Staff();

        public Staff()
        {
            InitializeComponent();
        }
        //初始化
        private void InitTreeView()
        {
            if (tvDepJob != null)
            {
                tvDepJob.Nodes.Clear();
            }
            //根节点
            TreeNode tnRoot1 = new TreeNode();
            tnRoot1.Text = "部门";
            tvDepJob.Nodes.Add(tnRoot1);
            //得到部门名称
            List<TreeNode> nodeDepartmentList = new List<TreeNode>();
            nodeDepartmentList = bll.GetNodeList(0);
            foreach (TreeNode node in nodeDepartmentList)
                tnRoot1.Nodes.Add(node);
            //根节点
            TreeNode tnRoot2 = new TreeNode();
            tnRoot2.Text = "职务";
            tvDepJob.Nodes.Add(tnRoot2);
            //得到职务名称
            List<TreeNode> nodeJobList = new List<TreeNode>();
            nodeJobList = bll.GetNodeList(1);
            foreach (TreeNode node in nodeJobList)
                tnRoot2.Nodes.Add(node);
            //默认展开所有节点
            //tvDepJob.ExpandAll();
        }
        //dgvWarehouse绑定数据
        private void BindData()
        {
            //绑定到DataTable中
            //DataSet ds = new DataSet();
            //ds = bll.GetAllList();
            //dgvWarehouse.DataSource = ds.Tables["ds"];

            //绑定到集合
            //List<EMMS.Model.StaffGet> modelListGet = new List<Model.StaffGet>();
            //modelListGet = bll.GetModelList("");
            //dgvWarehouse.DataSource = modelListGet;

            //绑定到转换后的集合
            List<EMMS.Model.StaffView> modelListView = new List<Model.StaffView>();
            modelListView = bll.GetModelListView(tbSearch.Text.ToString());
            dgvStaff.DataSource = modelListView;

            dgvStaff.AllowUserToAddRows = false;
          
            dgvStaff.ReadOnly = true;

            dgvStaff.Columns[0].HeaderText = "人员编码";
            dgvStaff.Columns[1].HeaderText = "姓名";
            dgvStaff.Columns[2].HeaderText = "性别";
            dgvStaff.Columns[3].HeaderText = "年龄";
            dgvStaff.Columns[4].HeaderText = "职务";
            dgvStaff.Columns[5].HeaderText = "部门";
            dgvStaff.Columns[6].HeaderText = "允许登录";
            dgvStaff.Columns[7].HeaderText = "已离职";
            dgvStaff.Columns[8].HeaderText = "备注";
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {

            InitTreeView();
            BindData();
        }

        private void tvWarehouseAttri_Click(object sender, EventArgs e)
        {
           
        }

        private void tvWarehouseAttri_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            TreeNode node = new TreeNode();
            if (tv.SelectedNode != null)
            {
                node = tv.SelectedNode;
                if (node.Parent != null)
                {
                    List<EMMS.Model.StaffView> modelListView = new List<Model.StaffView>();
                    modelListView = bll.GetModelListView(node.Text.ToString());
                    dgvStaff.DataSource = modelListView;
                }
            }
        }
        //查找按钮
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        //更新(还不够完美)
        private void dgvWarehouse_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > 0 && e.RowIndex < dgvStaff.Rows.Count)
            //{
            //    //让其失去焦点
            //    //dgvWarehouse.EndEdit();

            //    string no = dgvStaff.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    Model.StaffSet model = new Model.StaffSet();
            //    model = bll.GetModel(no);
            //    model.Login = ((Convert.ToBoolean(dgvStaff.Rows[e.RowIndex].Cells[6].Value.ToString())) == true) ? 1 : 0;
            //    model.Resign = ((Convert.ToBoolean(dgvStaff.Rows[e.RowIndex].Cells[7].Value.ToString())) == true) ? 1 : 0;
            //    bll.Update(model);
            //}
        }

        private void dgvWarehouse_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        //刷新
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            InitTreeView();
            BindData();
        }
        //部门
        private void tsbWarehouseAttri_Click(object sender, EventArgs e)
        {
            Job job = new Job();
            job.ShowDialog();
        }
        //增加
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.flag = 0;
            add.ShowDialog();
        }
        //删除
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvStaff.SelectedRows.Count > 0))
            {
                MessageBox.Show("请至少选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvStaff.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (MessageBox.Show("确定要删除该行吗？", "确定删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                    try
                    {
                        string no = row.Cells[0].Value.ToString();
                        if (bll.Delete(no))
                        {
                            MessageBox.Show("删除成功！");
                            BindData();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("由于某些原因，删除失败！");
                    }

                }
            }
        }
        //关闭
        private void tbsClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //修改
        private void tsbAlter_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行！");
                return;
            }
            foreach (DataGridViewRow row in dgvStaff.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    Add add = new Add();
                    add.GetParent(this);
                    add.flag = 1; //表示是修改
                    string no = row.Cells[0].Value.ToString();
                    add.tbNo.Text = no;
                    add.tbNo.ReadOnly = true;
                    string name = row.Cells[1].Value.ToString();
                    add.tbName.Text = name;
                    if (row.Cells[2].Value.ToString() == "男")
                    { 
                        add.rbBoy.Checked = true;
                        add.rbGirl.Checked = false;
                    }
                    else if (row.Cells[2].Value.ToString() == "女")
                    {
                        add.rbGirl.Checked = true;
                        add.rbBoy.Checked = false;
                    }
                    string age=row.Cells[3].Value.ToString();
                    add.age = int.Parse(age);
                    //add.cbAge.SelectedItem = age;
                    //add.cbAge.SelectedIndex = int.Parse(age);

                    string job=row.Cells[4].Value.ToString();
                    add.tbJob.Text = job;
                    string department=row.Cells[5].Value.ToString();
                    add.tbDepartment.Text = department;
                    add.ckbLogin.Checked = bool.Parse(row.Cells[6].Value.ToString());
                    //是否允许登录
                    EMMS.BLL.User userBll = new BLL.User();
                    EMMS.Model.User userModel = userBll.GetModelByStaffNo(no);
                    if (add.ckbLogin.Checked == true)
                    {
                        add.panelUser.Visible = true;
                        add.tbUserName.Text = userModel.Name;
                        add.tbUserName.ReadOnly = true;

                        add.labPwd.Text = "密   码";
                        add.tbPassword.PasswordChar = '*';
                        add.tbPassword.Text = userModel.Password;
                        //EMMS.BLL.Role roleBll = new BLL.Role();
                        //add.cbRole.SelectedText = (roleBll.GetModel(userModel.Role.ToString())).Name;
                        add.role = userModel.Role;
                        //add.cbRole.SelectedIndex=
                        //add.cbRole.SelectedValue = userModel.Role;
                        add.btnReset.Visible = true;
                    }
                    else
                    {
                        add.panelUser.Visible = false;
                    }

                    add.ckbResign.Checked = bool.Parse(row.Cells[7].Value.ToString());
                    add.tbRemarks.Text = row.Cells[8].Value.ToString();
                     
                    //保存在公共信息中，让它弹出来的窗口从中得到值
                    EMMS.BLL.Job jobBll = new BLL.Job();
                    add.jobmodel.Name = job;
                    //add.jobmodel.No = (bll.GetModel(no)).Job;
                    base.JobFlag = 1;
                    base.JobModel = jobBll.GetModel(bll.GetModel(no).Job);
                    add.departmentmodel.Name = department;

                    EMMS.BLL.Department deptBll = new BLL.Department();
                    //add.departmentmodel.No = (bll.GetModel(no)).Department;
                    base.DepartmentFlag = 1;
                    base.DepartmentModel = deptBll.GetModel(bll.GetModel(no).Department);
                   
                    add.ShowDialog();
                }
            }
        }

        private void Warehouse_Activated(object sender, EventArgs e)
        {
            InitTreeView();
            BindData();
        }

        private void Warehouse_Enter(object sender, EventArgs e)
        {
            InitTreeView();
            BindData();
        }

        private void tvWarehouseAttri_Enter(object sender, EventArgs e)
        {
            InitTreeView();
        }

        private void dgvWarehouse_Enter(object sender, EventArgs e)
        {
            //BindData();
        }

        private void tsbDepartment_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.ShowDialog();
        }

        private void tsbOutput_Click(object sender, EventArgs e)
        {
            EMMS.Common.DataToExcel excel = new Common.DataToExcel();
            excel.coutExcel(dgvStaff);
        }

    }
}
