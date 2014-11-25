using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.common
{
    public partial class AlterPwd : Form
    {
        private bool judge;
        private bool isSuccess;
        public AlterPwd()
        {
            InitializeComponent();
            judge = false;
            isSuccess = false;
            
        }

        private void AlterPwd_Load(object sender, EventArgs e)
        {
            tbUser.Text = EMMS.Common.SavedInfo.UserName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EMMS.Model.User userModel = new Model.User();
            EMMS.BLL.User userBll = new BLL.User();
            if (!(string.IsNullOrEmpty(tbPwd.Text) || string.IsNullOrEmpty(tbAgain.Text)) ) //两者非空
            {
                if (!(EMMS.Common.PageValidate.IsNumberLetter(tbPwd.Text) && EMMS.Common.PageValidate.IsNumberLetter(tbAgain.Text))) //输入不合法
                {
                    MessageBox.Show("输入密码不合法，请输入字母或数字！");
                    tbPwd.Text = "";
                    tbAgain.Text = "";
                    return;
                }
                if (!(tbPwd.Text.Equals(tbAgain.Text))) //两次密码不一致
                {
                    MessageBox.Show("两次密码不一致，请重新输入！");
                    tbPwd.Text = "";
                    tbAgain.Text = "";
                    return;
                }
                userModel = userBll.GetModel(tbUser.Text);
                userModel.Password = tbPwd.Text;
                if (userBll.Update(userModel))
                {
                    MessageBox.Show("密码修改成功！");
                    EMMS.Common.SavedInfo.IsAlterPws = true;
                    //this.Dispose();
                    isSuccess = true;
                    this.Close();
                }
            }
            else 
            {
                MessageBox.Show("请填写信息完整！");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (judge == true)
            //{
            //    if (MessageBox.Show("密码已修改，确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        this.Dispose();
            //    }
            //    //else
            //    //{
            //    //    return;
            //    //}
            //}
        }

        private void AlterPwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSuccess == false)
            {
                if (judge == true)
                {
                    if (MessageBox.Show("密码已修改，确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Dispose();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }  
        }

        private void tbPwd_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPwd.Text) && string.IsNullOrEmpty(tbAgain.Text)) //两者都为空
            {
                judge = false;
            }
            else
            {
                judge = true;
            }
        }

        private void AlterPwd_Activated(object sender, EventArgs e)
        {
            tbPwd.Focus();
        }
    }
}
