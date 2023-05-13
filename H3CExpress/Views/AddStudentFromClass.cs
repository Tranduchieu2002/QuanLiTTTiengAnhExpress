using DevExpress.XtraEditors;
using H3CExpress.Data.NewEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            ClassInstance = model.classes.Find(currentClassesId);
            if (ClassInstance == null)
            {
                MessageBox.Show("KHông tìm thấy lớp học");
                this.Close();
            }

            var listStudent = ClassInstance.ClassUser.Select(u => new
            {
                id = u.UserId,
                name = u.users.name,
                email = u.users.email,
                gender = u.users.gender,
                className = u.classes.name,
                courseName= u.classes.courses.name,
                classId = u.classes.id
            }).ToList();

            this.guna2DataGridView1.DataSource = listStudent;


            var usersNotInClass = model.users
                        .Where(u => !u.classes.Any(c => c.id == currentClassesId))
                        .Where(u => u.roles.name == "USER")
                        .Select(u => new
                        {
                            u.id,
                            u.name,
                            u.email,
                            u.username,
                            u.gender,
                            role = u.roles.name,
                        })
                        .ToList();
            this.usersGridView.DataSource= usersNotInClass.ToList();

        }


        private void AddStudentFromClass_Load(object sender, EventArgs e)
        {
            using(var context = new NewAppContext())
            {
                loadData(context);
            }
        }

    }
}