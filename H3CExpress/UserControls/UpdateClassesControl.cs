using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using H3CExpress.Data.NewEntities;
using H3CExpress.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
/*
                listCourseComboBox.DisplayMember = "name";
                listCourseComboBox.ValueMember = "id";*/

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
            }

        }
    }
}
