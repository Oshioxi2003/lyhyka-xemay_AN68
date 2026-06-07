using Lyhyka.Core;
using Lyhyka.DBCore;
using Lyhyka.Forms.Motobikes;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.Forms
{
    public partial class FrmLogin : Form
    {
        string _selectedMenu = "";
        public FrmLogin(string selectedMenu)
        {
            InitializeComponent();
            _selectedMenu = selectedMenu;
            this.AcceptButton = btnLogin; // btnLogin là Button trong form
        }  
        private void btnOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var context = new MyDbContext())
            {
                var admin = context.Admins.FirstOrDefault(a => a.IsTester!=1 && a.UserName == txtUsername.Text && a.Password == txtPassword.Text);
                if (admin != null)
                { 
                    this.DialogResult = DialogResult.OK; // Trả về OK nếu đăng nhập thành công
                    switch (_selectedMenu.ToLower())
                    {
                        case MenuConstants.Calibrate:
                            var frmCalibration = new FrmCalib(); 
                            frmCalibration.ShowDialog();
                            break;
                        case MenuConstants.Setting:
                            var frmSetting = new FrmSetting(); 
                            frmSetting.ShowDialog();
                            break;
                        
                        default:
                            MessageBox.Show("Chức năng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                e.Handled = true; // Ngăn chặn xử lý mặc định
            }
        }
    }
}
