using Lyhyka.DBCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.Forms.Motobikes
{
    public partial class FrmSettingCompany : Form
    {
        public FrmSettingCompany()
        {
            InitializeComponent();
        }

        private void FrmSettingCompany_Load(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var setting = context.Settings.FirstOrDefault();
                if (setting != null)
                {
                    txtCompanyName.Text = setting.CompanyName;
                    txtPhone.Text = setting.CompanyPhoneNumber;
                    txtAddress.Text = setting.Address;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var setting = context.Settings.FirstOrDefault();
                if (setting != null)
                {
                    setting.CompanyName = txtCompanyName.Text;
                    setting.CompanyPhoneNumber = txtPhone.Text;
                    setting.Address = txtAddress.Text;
                    context.SaveChanges();
                }
                else
                {
                    setting = new Setting
                    {
                        CompanyName = txtCompanyName.Text,
                        CompanyPhoneNumber = txtPhone.Text,
                        Address = txtAddress.Text
                    };
                    context.Settings.Add(setting);
                    context.SaveChanges();
                }    
            }
            this.Close();
        }
    }
}
