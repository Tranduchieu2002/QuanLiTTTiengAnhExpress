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
                    MessageBox.Show("Đã xảy ra lỗi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string err = CheckAllTextboxValid();
            err = err.Equals("") ? CheckAllComboboxValid() : err;
            if (!err.Equals(""))
            {
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dbContext = new NewAppContext())
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
                MessageBox.Show("Thêm người dùng thành công!!!");
                dbContext.SaveChanges();
                resetAllTextBox();
            }
        }

        public string CheckAllComboboxValid(string notify = "")
        {
            string err = "";
            Guna2ComboBox[] comboBoxes = Controls.OfType<Guna2ComboBox>().ToArray();
            foreach (Guna2ComboBox cb in comboBoxes)
            {
                if (cb.SelectedIndex >= 0) continue;
                err = notify.Equals("") ? "Vui lòng nhập đầy đủ thông tin!!!" : notify;
                break;
            }
            return err;
        }
        public string CheckAllTextboxValid(string notify = "")
        {
            string err = "";
            Guna2TextBox[] textboxes = Controls.OfType<Guna2TextBox>().ToArray();
            foreach (Guna2TextBox tb in textboxes)
            {
                if (!tb.Enabled || !tb.Text.Equals("")) continue;
                err = notify.Equals("") ? "Vui lòng nhập đầy đủ thông tin!!!" : notify;
                break;
            }
            return err;
        }

        public void resetAllTextBox()
        {
            Guna2TextBox[] textboxes = Controls.OfType<Guna2TextBox>().ToArray();
            foreach (Guna2TextBox tb in textboxes) tb.Text = "";
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
            string err = CheckAllTextboxValid();
            err = err.Equals("") ? CheckAllComboboxValid() : err;
            if (!err.Equals(""))
            {
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var context = new NewAppContext())
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
                MessageBox.Show("Cập nhât thông tin thành công!!!");
                this.Close();
            }
        }
    }
}
