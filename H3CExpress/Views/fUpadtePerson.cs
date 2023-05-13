using Guna.UI2.WinForms;
using H3CExpress.Data.NewEntities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace H3CExpress.Views
{
    public partial class fUpadtePerson : Form
    {
        string code;
        public fUpadtePerson(string code, string id = "")
        {
            InitializeComponent();
            this.code = code;
            bool isAdd = id.Equals("");
            if (isAdd)
            {
                cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRole.Enabled = false;
                btnSua.Enabled = false;
                cbGender.SelectedIndex = 0;
            }
            else
            {
                btnThem.Enabled = false;
                updateValue(id);
            }
        }

        public void updateValue(string id)
        {
            using (var context = new NewAppContext())
            {
                int idUserEdit = int.Parse(id);
                var userEdit = context.users.FirstOrDefault(u => u.id == idUserEdit);
                if (userEdit == null)
                {
                    Utils.ShowMessError("Đã xảy ra lỗi!!!");
                    return;
                }
                tbEmail.Text = userEdit.email;
                tbMaUser.Text = userEdit.id.ToString();
                tbPassword.Text = "";
                tbPassword.Enabled = false;
                tbUserName.Text = userEdit.username;
                tbName.Text = userEdit.name;
                cbGender.SelectedItem = userEdit.gender.ToString();
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string err = Utils.AreAllTextBoxHasValue(this);
            err = err.Equals("") ? Utils.AreAllComboBoxesSelected(this) : err;
            if (!err.Equals(""))
            {
                Utils.ShowMessWarn(err);
                return;
            }

            using (var dbContext = new NewAppContext())
            {
                try
                {
                    string genderText = cbGender.SelectedItem.ToString();
                    users newUser = new users
                    {
                        password = tbPassword.Text,
                        username = tbUserName.Text,
                        email = tbEmail.Text,
                        gender = genderText.Equals("Unknown") ? users.Gender.Unknown : genderText.Equals("Male") ? users.Gender.Male : users.Gender.Female,
                        name = tbName.Text,
                        roleId = Int32.Parse(cbRole.SelectedValue.ToString())
                    };
                    dbContext.users.Add(newUser);
                    Utils.ShowMessInfo("Thêm người dùng thành công!!!");
                    dbContext.SaveChanges();
                    Utils.ClearTextBoxes(this);
                }
                catch
                {
                    Utils.ShowMessError("Thêm người dùng thất bại!!!");
                }

            }
        }

        private void fUpadtePerson_Load(object sender, EventArgs e)
        {
            tbMaUser.Enabled = false;
            cbRole.DataSource = null;
            using (var context = new NewAppContext())
            {
                var data = context.roles.ToList();
                cbRole.DataSource = data;
                cbRole.DisplayMember = "name";
                cbRole.ValueMember = "id";
                cbRole.SelectedValue = context.roles.FirstOrDefault(r => r.Code.Equals(code)).id;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string err = Utils.AreAllTextBoxHasValue(this);
            err = err.Equals("") ? Utils.AreAllComboBoxesSelected(this) : err;
            if (!err.Equals(""))
            {
                Utils.ShowMessWarn(err);
                return;
            }
            using (var context = new NewAppContext())
            {
                try
                {
                    string genderText = cbGender.SelectedItem.ToString();
                    var userUpdate = context.users.Find(Int32.Parse(tbMaUser.Text));
                    if (userUpdate == null) return;
                    userUpdate.gender = genderText.Equals("Unknown") ? users.Gender.Unknown : genderText.Equals("Male") ? users.Gender.Male : users.Gender.Female;
                    userUpdate.email = tbEmail.Text;
                    userUpdate.name = tbName.Text;
                    userUpdate.roleId = Int32.Parse(cbRole.SelectedValue.ToString());
                    userUpdate.username = tbUserName.Text;
                    context.SaveChanges();
                    Utils.ShowMessInfo("Cập nhât thông tin thành công!!!");
                    this.Close();
                }
                catch
                {
                    Utils.ShowMessError("Cập nhât thông tin thất bại!!!");
                }
            }
        }
    }
}
