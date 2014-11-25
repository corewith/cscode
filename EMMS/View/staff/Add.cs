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
    public partial class Add : EMMS.Common.View
    {
        public EMMS.Model.Job jobmodel = new Model.Job();
        public EMMS.Model.Department departmentmodel = new Model.Department();

        private EMMS.Model.User user = new Model.User();
        private EMMS.Model.StaffSet staffmodel = new Model.StaffSet();
        private EMMS.BLL.Staff bll = new BLL.Staff(); 
        private EMMS.BLL.Role rolebll = new BLL.Role();
        private EMMS.BLL.User userbll = new BLL.User();
        private EMMS.Common.View view;

        public int flag = 0;
        public int age = 0;
        public int role = 0;
        public Add()
        {
            InitializeComponent();
            ttNo.SetToolTip(tbNo, "请输入不超过8位的数字和字母组合");
            ttName.SetToolTip(tbName, "请输入不超过的5位的中文");
            ttUser.SetToolTip(tbUserName,"用户名只能是字母和数字");
            ttPassword.SetToolTip(tbPassword, "密码只能是字母和数字");
            //初始重置密码设置不可用
            btnReset.Visible = false;
        }
        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        private void btnAttri_Click(object sender, EventArgs e)
        {
            Job job = new Job();
            job.flag = true;
            job.GetParent(this);
            job.ShowDialog();
        }
        //保存
        private void save()
        {
            if (String.IsNullOrEmpty(tbNo.Text))
            {
                MessageBox.Show("人员编码不能为空！");
                return;
            }
            if (String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("人员名称不能为空！");
                return;
            }
            if ((!rbBoy.Checked) && (!rbGirl.Checked))
            {
                MessageBox.Show("性别未选择！");
                return;
            }
            if (cbAge.SelectedIndex==0)//String.IsNullOrEmpty(cbAge.SelectedValue.ToString()))
            {
                MessageBox.Show("年龄未选择！");
                return;
            }
            if (String.IsNullOrEmpty(tbJob.Text))
            {
                MessageBox.Show("职务为选择！");
                return;
            }
           if (String.IsNullOrEmpty(tbDepartment.Text))
            {
                MessageBox.Show("部门未选择！");
                return;
            }
                string no = EMMS.Common.PageValidate.StringCheck(tbNo.Text, 8); //
                string name = EMMS.Common.PageValidate.StringCheck(tbName.Text, 5); //
                int gender = rbBoy.Checked ? 0 : 1;
                int age = int.Parse(cbAge.SelectedValue.ToString());
                string job="";
                string department="";
                if (flag == 0) //增加
                {
                    job = base.JobModel.No; //
                    department = base.DepartmentModel.No; //
                }
                else if (flag == 1) //修改
                {
                    //
                    if (base.JobFlag == 1)
                    {
                        job = base.JobModel.No; //
                    }
                    else
                    {
                        job = view.JobModel.No;
                    }

                    if (base.DepartmentFlag == 1)
                    {
                        department = base.DepartmentModel.No;
                    }
                    else
                    {
                        department = view.DepartmentModel.No;
                    }
                }
                int login = ckbLogin.Checked ? 1 : 0;
                int resign = ckbResign.Checked ? 1 : 0;
                string remarks = EMMS.Common.PageValidate.StringCheck(tbRemarks.Text, 50);
                if (!((EMMS.Common.PageValidate.IsNumberLetter(no)) && (EMMS.Common.PageValidate.IsCHZN(name))))
                {
                    MessageBox.Show("输入值不合法，请重新输入！");
                    return;
                }
                
                if (resign == 1)
                {
                      login = 0;//离职就不让登录
                      if (tbUserName.Text != "") //若用户名不空，则删除登录用户名
                      {
                          user = userbll.GetModel(tbUserName.Text);
                          userbll.Delete(user.Id);//删除用户名以及密码
                      }
                }

                staffmodel.No = no;
                staffmodel.Name = name;
                staffmodel.Gender = gender;
                staffmodel.Age = age;
                staffmodel.Job = job;
                staffmodel.Department = department;
                staffmodel.Login = login;
                staffmodel.Resign = resign;
                staffmodel.Remarks = remarks;

                bool check = true; //表明数据库已有用户名和密码
                if (ckbLogin.Checked == false)
                {
                    if (flag == 1)
                    {
                        if (tbUserName.Text != "")
                        { 
                            //表示之前有用户名以及密码，但现在不用了
                            user = userbll.GetModel(tbUserName.Text);
                            userbll.Delete(user.Id);
                        }
                    }
                }
                if (ckbLogin.Checked == true)
                {
                    if (String.IsNullOrEmpty(tbUserName.Text))
                    {
                        MessageBox.Show("已允许登录，请设置用户名！");
                        return;
                    }
                    string username = EMMS.Common.PageValidate.StringCheck(tbUserName.Text, 10);
                    string password = "";

                    if (!(EMMS.Common.PageValidate.IsNumberLetter(username)))
                    {
                        MessageBox.Show("用户名只允许字母和数字！请重新填写！");
                        return;
                    }
                    if (!(string.IsNullOrEmpty(tbPassword.Text)))
                    {
                        password = EMMS.Common.PageValidate.StringCheck(tbPassword.Text, 15);
                        if (!(EMMS.Common.PageValidate.IsNumberLetter(password)))
                        {
                            MessageBox.Show("密码只允许字母和数字！请重新设置！");
                            return;
                        }
                    }
                    if (flag == 1)
                    {
                        user = userbll.GetModel(username); //根据用户名得到model
                        if (user == null)
                        {
                            check = false; //表明修改人员信息时数据库中无与此人对应的用户名和密码
                            user = new Model.User();
                        }
                    }
                    user.No = no;
                    user.Role = ((EMMS.Model.Role)cbRole.SelectedItem).No;
                    user.Name = username;
                    user.Password = password;
                    if (flag == 0)
                    {
                        if(userbll.Exists(username)) //如果已经存在该用户名
                        {
                            MessageBox.Show("该用户名已经存在，请重新输入一个！");
                            return;
                        }
                        userbll.Add(user); //增加人员是可能是插入用户名和密码
                        //if (userbll.Add(user))
                        //    MessageBox.Show("用户名密码保存成功！");
                    }
                    else if (flag == 1)
                    {
                        if (check == true)
                        {
                            userbll.Update(user);
                        }
                        else
                        {
                            userbll.Add(user);
                        }
                        //if (userbll.Update(user))
                        //    MessageBox.Show("用户名密码修改成功！");
                    }
                }
                if (flag == 0)
                {
                    if(bll.Exists(no))
                    {
                        MessageBox.Show("该人员编码已经存在，请重新输入一个！");
                        return;
                    }
                    if (bll.Add(staffmodel))
                        MessageBox.Show("保存成功！");
                }
                else if (flag == 1)
                {
                    if (bll.Update(staffmodel))
                        MessageBox.Show("更新成功！");
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
                rbBoy.Checked=false;
                rbGirl.Checked=false;
                cbAge.SelectedIndex = 0;
                tbJob.Text = "";
                tbDepartment.Text="";
                ckbLogin.Checked=false;
                ckbResign.Checked=false;
                tbRemarks.Text = "";
        }

        private void tsbSaveClose_Click(object sender, EventArgs e)
        {
            save();           
            this.Dispose();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                panelUser.Visible = false;
            }
                List<ComboBoxItem> items = new List<ComboBoxItem>();
                for (int i = 0; i <= 100; i++)
                {
                    if (i == 0)
                        //cbAge.Items.Add("请选择...");
                        items.Add(new ComboBoxItem() { DisplayValue = "请选择...", RealValue = "0" });
                    else
                        // cbAge.Items.Add(i.ToString());
                        items.Add(new ComboBoxItem() { DisplayValue = "" + i, RealValue = "" + i });

                }
                cbAge.DataSource = items;
                cbAge.DisplayMember = "DisplayValue";
                cbAge.ValueMember = "RealValue";
                cbAge.SelectedIndex = age;

                cbRole.DataSource = rolebll.GetModelList("");
                cbRole.DisplayMember = "name";
                cbRole.ValueMember = "no";
                cbRole.SelectedValue = role;
                //cbRole.SelectedText = (rolebll.GetModel(role.ToString())).Name;
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.flag = true;
            department.GetParent(this);
            department.ShowDialog();

        }

        private void Add_Activated(object sender, EventArgs e)
        {
            if (base.JobFlag == 1)
            {
                this.tbJob.Text = base.JobModel.Name;
                //base.JobFlag = 0;
            }
            if (base.DepartmentFlag == 1)
            {
                this.tbDepartment.Text = base.DepartmentModel.Name;
                //base.DepartmentFlag = 0;
            }
        }

        private void ckbLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbLogin.Checked == true)
                panelUser.Visible = true;
            else
                panelUser.Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            labPwd.Text = "初始密码";
            tbPassword.Text = "";
            tbPassword.PasswordChar=' ';
            
        }
    }
    public class ComboBoxItem
    {
        public string DisplayValue { get; set; }
        public string RealValue { get; set; }
    }
}
