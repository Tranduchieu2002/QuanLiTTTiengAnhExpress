using DevExpress.XtraEditors;
using H3CExpress.Data.NewEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H3CExpress.Views
{
    public partial class AddStudentFromClass : DevExpress.XtraEditors.XtraForm
    {
        int currentClassesId;
        classes ClassInstance;
        public AddStudentFromClass(int currentClassesId)
        {
            InitializeComponent();
            this.currentClassesId = currentClassesId;

        }

        void loadData(NewAppContext model)
        {

            classes ClassInstance = model.classes.Find(currentClassesId);
            if (ClassInstance == null)
            {
                MessageBox.Show("KHông tìm thấy lớp học");
                this.Close();
            }

            var listStudent = ClassInstance.ClassUser.Select(u => new
            {
                MaChung = u.Id,
                studentId = u.UserId,
                studentName = u.users.name,
                gender = u.users.gender,
                className = u.classes.name,
                courseName = u.classes.courses.name,
            }).ToList();

            this.guna2DataGridView1.DataSource = listStudent;
            var usersNotInClass = model.users
                .Where(u => u.roles.Code == "USR")
                .Where(u => !model.ClassUser.Any(cu => cu.ClassId == ClassInstance.id && cu.UserId == u.id))
                    .Select(u => new
                    {
                        studentId = u.id,
                        studentName = u.name,
                        u.email,
                        u.gender,
                    })
                .ToList();
            /*model.users
                    .Where(u => !u.classes.Any(c => c.id == currentClassesId))
                    .Where(u => u.roles.name == "USER")
                    .Select(u => new
                    {
                        studentId =u.id,
                        studentName = u.name,
                        u.email,
                        u.gender,
                    })
                    .ToList();*/
            this.usersGridView.DataSource = usersNotInClass.ToList();

        }


        private void AddStudentFromClass_Load(object sender, EventArgs e)
        {
            using (var context = new NewAppContext())
            {
                loadData(context);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new NewAppContext())
                {
                    if (usersGridView.SelectedRows.Count == 0)
                    {
                        MessageBox.Show($"Bạn chưa chọn học viên.");
                        return;

                    }
                    foreach (DataGridViewRow row in usersGridView.SelectedRows)
                    {
                        int id = (int)row.Cells["studentId"].Value;
                        var userObj = context.users.FirstOrDefault(u => u.id == id);
                        var classObj = context.classes.FirstOrDefault(c => c.id == ClassInstance.id);
                        if (classObj == null)
                        {
                            Console.WriteLine($"Class with ID {ClassInstance.id} not found.");
                            return;
                        }

                        if (userObj == null)
                        {
                            Console.WriteLine($"User with ID {id} not found.");
                            return;
                        }
                        var classUser = new ClassUser { users = userObj, classes = classObj };

                        context.ClassUser.Add(classUser);
                        context.SaveChanges();

                        MessageBox.Show("Thao tác thành công !");
                        loadData(context);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new NewAppContext())
                {
                    if (guna2DataGridView1.SelectedRows.Count == 0)
                    {
                        MessageBox.Show($"Bạn chưa chọn học viên.");
                        return;

                    }
                    foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                    {
                        int id = (int)row.Cells["MaChung"].Value;
                        var userObj = context.ClassUser.FirstOrDefault(u => u.Id == id);
                        if (userObj == null)
                        {
                            Console.WriteLine($"Class with ID {ClassInstance.id} not found.");
                            return;
                        }

                        context.ClassUser.Remove(userObj);

                        context.SaveChanges();

                        MessageBox.Show("Thao tác thành công !");

                        loadData(context);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}