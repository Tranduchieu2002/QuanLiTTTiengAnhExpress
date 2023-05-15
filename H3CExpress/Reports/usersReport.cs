using DevExpress.XtraReports.UI;
using H3CExpress.Data.NewEntities;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace H3CExpress.Reports
{
    public partial class usersReport : DevExpress.XtraReports.UI.XtraReport
    {
        public usersReport()
        {
            InitializeComponent();

            loadData();
        }

        void loadData()
        {
            using (var context = new NewAppContext())
            {
                var info = context.ClassUser
                    .Select( u => new
                {
                    StudentId = u.users.id,
                    StudentName = u.users.name,
                    Gender = u.users.gender,
                    ClassName = u.classes.name,
                    CourseName = u.classes.courses.name,
                    CoursePrice = u.classes.courses.totalAmount,
                    ClassTeacher = u.classes.Teacher.name
                }).ToList();

                MessageBox.Show(info.Count.ToString());
                this.DataSource = info;

                StudentId.DataBindings.Add("Text", this.DataSource, "StudentId");
                StudentName.DataBindings.Add("Text", this.DataSource, "StudentName");
                Gender.DataBindings.Add("Text", this.DataSource, "Gender");
                ClassName.DataBindings.Add("Text", this.DataSource, "ClassName");
                CourseName.DataBindings.Add("Text", this.DataSource, "CourseName");
                CoursePrice.DataBindings.Add("Text", this.DataSource, "CoursePrice");/*
                NgayDangKy.DataBindings.Add("Text", this.DataSource, "NgayDangKy");
                NgayHetHan.DataBindings.Add("Text", this.DataSource, "NgayHetHan");*/
            }
        }

    }
}
