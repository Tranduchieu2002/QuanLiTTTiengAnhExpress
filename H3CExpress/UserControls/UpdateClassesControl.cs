﻿using DevExpress.XtraBars;
using H3CExpress.Data.NewEntities;
using H3CExpress.Views;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace H3CExpress.UserControls
{
    public partial class UpdateClassesControl : DevExpress.XtraEditors.XtraUserControl
    {
        public UpdateClassesControl()
        {
            InitializeComponent();

        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        private void gridControl_Click(object sender, EventArgs e)
        {

        }
        void loadClass(NewAppContext context)
        {
            var users = from c in context.classes
                        select new
                        {
                            c.id,
                            c.name,
                            teacherName = c.Teacher.name,
                            courseName = c.courses.name,
                            startDate = c.start_time,
                            endDate = c.end_time,
                            schedule = c.learning_time
                        };
            var a = users.Take(10).ToList();
            this.gridControl.DataSource = a;
            bsiRecordsCount.Caption = "Tổng số lớp học : " + a.Count;
        }

        void loadClasses(NewAppContext context)
        {

            loadClass(context);

            var courses = from c in context.courses
                          select new
                          {
                              c.id,
                              c.name,
                              c.description,
                              c.totalAmount
                          };

            /*this.listCourseComboBox.DataSource = courses.Take(10).ToList();
            loadGVToCombobox();*/
        }


        private void UpdateClassesControl_Load(object sender, EventArgs e)
        {
            using (var context = new NewAppContext())
            {
                loadClasses(context);
            }
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateClass updateClass = new UpdateClass(null);

            updateClass.ShowDialog();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Get the selected row(s)
            var selectedRows = gridView.GetSelectedRows();

            // Loop through the selected rows and do something with each row
            foreach (var rowHandle in selectedRows)
            {
                // Get the values of the selected row using the row handle
                var id = int.Parse(gridView.GetRowCellValue(rowHandle, "id").ToString());

                // Do something with the row values
                UpdateClass updateClass = new UpdateClass(id);

                updateClass.ShowDialog();

                updateClass.Close();
            }

        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var context = new NewAppContext())
            {
                loadClasses(context);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedRows = gridView.GetSelectedRows();

            if(selectedRows.Count() == 0)
            {
                MessageBox.Show("Bạn chưa chọn lớp học ");
                return;
            } 
            // Loop through the selected rows and do something with each row
            foreach (var rowHandle in selectedRows)
            {
                // Get the values of the selected row using the row handle
                var id = int.Parse(gridView.GetRowCellValue(rowHandle, "id").ToString());
                AddStudentFromClass addStudentF = new AddStudentFromClass(id);
                addStudentF.ShowDialog();

                addStudentF.Close();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

            var selectedRows = gridView.GetSelectedRows();

            if (selectedRows.Count() == 0)
            {
                MessageBox.Show("Bạn chưa chọn lớp học ");
                return;
            }
            // Loop through the selected rows and do something with each row
            foreach (var rowHandle in selectedRows)
            {
                // Get the values of the selected row using the row handle
                var id = int.Parse(gridView.GetRowCellValue(rowHandle, "id").ToString());

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Nếu người dùng chọn Yes, tiến hành xóa thông tin
                if (result == DialogResult.Yes)
                {
                    using (var context = new NewAppContext())
                    {
                        classes lophoc = context.classes.Find(id);

                        if (lophoc != null)
                        {
                            context.classes.Remove(lophoc);

                            context.SaveChanges();

                            MessageBox.Show("Xóa lớp học thành công !");

                        }
                        else
                        {
                            MessageBox.Show("Chưa có thông tin lớp học !");
                        }
                        return;
                        // Thực hiện xóa thông tin ở đây
                    }

                }
            }
            
        }
    }
}
