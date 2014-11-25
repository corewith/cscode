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
    public partial class List : Form
    {
        public EMMS.BLL.Staff bll = new BLL.Staff();
        //public EMMS.View.storage.Storage_Order view;
        private EMMS.Common.View view;
        //private int value;
        public List()
        {
            InitializeComponent();
            //value = 0;
        }
        //public void GetValue(int value)
        //{
        //    this.value = value;
        //}
        public void GetParent(EMMS.Common.View view)//EMMS.View.storage.Storage_Order view)
        {
            //this.view = view;
            this.view = view;

        }
        private void BindData()
        {
            //绑定到转换后的集合
            List<EMMS.Model.StaffView> modelListView = new List<Model.StaffView>();
            modelListView = bll.GetModelListViewByResign("0");//tbSearch.Text.ToString());
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
            dgvStaff.Columns[6].Visible = false;
            dgvStaff.Columns[7].Visible = false;
            dgvStaff.Columns[8].Visible = false;
        }
        private void List_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvStaff_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EMMS.Model.StaffSet model = new Model.StaffSet();
            string no = dgvStaff.Rows[e.RowIndex].Cells[0].Value.ToString();
            string name = dgvStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
            int gender = (dgvStaff.Rows[e.RowIndex].Cells[2].Value.ToString() == "男") ? 0 : 1;
            int age = int.Parse(dgvStaff.Rows[e.RowIndex].Cells[3].Value.ToString());
            string job = dgvStaff.Rows[e.RowIndex].Cells[4].Value.ToString();
            string department = dgvStaff.Rows[e.RowIndex].Cells[5].Value.ToString();

            model.No = no;
            model.Name = name;
            model.Gender = gender;
            model.Age = age;
            model.Job = job;
            model.Department = department;

            view.StaffModel = model;
            view.StaffFlag = 1;
            //if (value == 1)
            //{
            //    view.CheckFlag = 1;
            //}
            this.Dispose();
        }
    }
}
