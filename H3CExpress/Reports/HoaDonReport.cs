using DevExpress.Utils.Extensions;
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
    public partial class HoaDonReport : DevExpress.XtraReports.UI.XtraReport
    {
        public HoaDonReport(int id)
        {
            InitializeComponent();
            loadData(id);
        }

        void loadData(int id)
        {
            using (var context = new NewAppContext())
            {
                var info = context.HoaDons
                    .Where(hd => hd.SoHoaDon == id)
                    .Select(u => new
                    {
                        StudentId = u.users.id,
                        StudentName = u.users.name,
                        Gender = u.users.gender,
                        Email = u.users.email,
                        CourseName = u.courses.name,
                        CoursePrice = u.courses.totalAmount,
                        CreatedDate = u.NgayLap,
                        Total = u.ThanhTien
                    }).ToList();
                this.DataSource= info;
                MessageBox.Show(info[0].CreatedDate.ToString());
                xrLabel19.Text = info[0].Gender.ToString();
                xrLabel20.Text = info[0].Email;
                xrLabel15.Text = info[0].StudentName;
                Total.Text = info[0].Total.ToString();
                StudentId.DataBindings.Add("Text", this.DataSource, "StudentId");
                StudentName.DataBindings.Add("Text", this.DataSource, "StudentName");
                Gender.DataBindings.Add("Text", this.DataSource, "Gender");
                CreatedDate.DataBindings.Add("Text", this.CreatedDate.ToString(), "CreatedDate");
                CourseName.DataBindings.Add("Text", this.DataSource, "CourseName");
                CoursePrice.DataBindings.Add("Text", this.DataSource, "CoursePrice");/*
                NgayDangKy.DataBindings.Add("Text", this.DataSource, "NgayDangKy");
                NgayHetHan.DataBindings.Add("Text", this.DataSource, "NgayHetHan");*/
            }

        }
    }
}
