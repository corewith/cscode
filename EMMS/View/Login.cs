using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View
{
    public partial class Login : Form
    {
        public EMMS.View.MainWindow mainWindow;
        private EMMS.BLL.User bll = new BLL.User();
        public Login()
        {
            InitializeComponent();
        }
        public void GetParent(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string user = tbUser.Text.Trim();
            string password = tbPassword.Text.Trim();
            if (!(bll.Exists(user)))
            {
                MessageBox.Show("当前无此用户名！");
                return;
            }
            EMMS.Model.User model=bll.GetModel(user);
            if (password.Equals(model.Password))
            {
                //if (model.Role == 0)//管理员
                //{
                //    EMMS.Common.SavedInfo.Role =0;
                //    EMMS.Common.SavedInfo.UserNo = model.Id;
                //    EMMS.Common.SavedInfo.UserName = "jsn";
                //    EMMS.Common.SavedInfo.StaffNo = "0";
                //    EMMS.Common.SavedInfo.StaffName = "超级管理员"; 
                //}
                //else
                //{
                    EMMS.BLL.Staff staffBll = new BLL.Staff();
                    EMMS.Model.StaffSet staffSet=staffBll.GetModel(model.No);
                    //MessageBox.Show("登录成功！");
                    EMMS.Common.SavedInfo.Role = model.Role; //保存当前角色
                    EMMS.Common.SavedInfo.UserNo = model.Id;//当前用户编码
                    EMMS.Common.SavedInfo.UserName = model.Name;//当前用户名
                    EMMS.Common.SavedInfo.StaffNo = model.No;//当前人员编码
                    EMMS.Common.SavedInfo.StaffName = staffSet.Name;//当前人员姓名
                //}
                //设置状态栏信息
                 StringBuilder str1 = new StringBuilder();
                 str1.Append("              登录用户：" + staffSet.Name);
                 mainWindow.tsslName.Text = str1.ToString();

                 StringBuilder str2 = new StringBuilder();
                 str2.Append("登录时间：" + DateTime.Now.ToString());
                 mainWindow.tsslTime.Text = str2.ToString();

                mainWindow.GetParent(this);
                mainWindow.Visible = true;
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("密码错误，请重新输入!");
                tbPassword.Text = "";
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
               System.Environment.Exit(0);
        }

        private void Login_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUser.Text))
            {
                btnOK.Enabled = false;
            }   
            else
            {
                btnOK.Enabled = true;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
