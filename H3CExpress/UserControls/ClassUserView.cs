using DevExpress.XtraEditors;
using H3CExpress.Data.NewEntities;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H3CExpress.UserControls
{
    public partial class ClassUserView : DevExpress.XtraEditors.XtraUserControl
    {
        int currentClassesId;
        classes ClassInstance;
        public ClassUserView(int currentClassesId)
        {
            InitializeComponent();
            this.currentClassesId = currentClassesId;
        }

        private void gridControl_Load(object sender, EventArgs e)
        {
            using (var context = new NewAppContext())
            {
                ClassInstance = context.classes.Find(currentClassesId);
                if (ClassInstance == null)
                {
                    MessageBox.Show("KHông tìm thấy lớp học");
                    return;
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

                gridControl.DataSource = listStudent;
            }
        }
    }
}
