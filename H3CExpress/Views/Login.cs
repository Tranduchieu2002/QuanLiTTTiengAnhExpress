using H3CExpress.Data.NewEntities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static H3CExpress.Data.NewEntities.users;

namespace H3CExpress.Views
{
    public partial class Login : Form
    {
        Validation validation = new Validation();
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = this.usernameField.Text;
            string password = this.passwordField.Text;
            bool isValidUsername = String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password);
            if (isValidUsername)
            {
                MessageBox.Show("Mật khẩu hoặc User name không được trống !");
                return;
            }

            bool isLoginSuccessed = validation.CheckLogin(username, password);
            if (isLoginSuccessed)
            {
                MainNavigator adminView = new MainNavigator();
                this.Hide();
                adminView.Show();
            }
            else
            {
                MessageBox.Show("Username và password không đúng !");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                using (NewAppContext model = new NewAppContext())
                {
                    bool isInit = model.users.Count() == 0;

                    if (isInit)
                    {
                        List<roles> roles = new List<roles>();
                        roles ADMIN = new roles { name = "ADMIN", Code = "ADM" };
                        roles USER = new roles { name = "USER", Code = "USR" };
                        roles TEACHER = new roles { name = "TEACHER", Code = "TEA" };
                        roles EMPLOYEE = new roles { name = "EMPLOYEE", Code = "EMP" };

                        roles.Add(ADMIN);
                        roles.Add(USER);
                        roles.Add(TEACHER);
                        roles.Add(EMPLOYEE);

                        model.roles.AddRange((IEnumerable<roles>)roles);

                        model.SaveChanges();

                        users user = new users { name = "ADMIN", gender = Gender.Male, email = "admin@admin.com", password = "1234", username = "admin", roles = ADMIN };

                        model.users.Add(user);

                        model.SaveChanges();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
        }

        private void NewLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
