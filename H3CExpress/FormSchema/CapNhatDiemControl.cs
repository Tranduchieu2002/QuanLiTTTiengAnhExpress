using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using H3CExpress.Data.NewEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H3CExpress.FormSchema
{
    public partial class CapNhatDiemControl : DevExpress.XtraEditors.XtraUserControl
    {
        public CapNhatDiemControl()
        {
            InitializeComponent();
            cbLop.DisplayMember = "name";
            cbLop.ValueMember = "id";

        }
        void loadData(string id)
        {
            using (var context = new NewAppContext())
            {
                classes ClassInstance = context.classes.Find(int.Parse(id));
                if (ClassInstance == null)
                {
                    MessageBox.Show("KHông tìm thấy lớp học");
                    return;
                }
                this.gridControl1.DataSource = null;
                var listStudent = ClassInstance.ClassUser.Select(u => new
                {
                    classId = u.ClassId,
                    MaChung = u.Id,
                    studentId = u.UserId,
                    studentName = u.users.name,
                    gender = u.users.gender,
                    className = u.classes.name,
                    courseName = u.classes.courses.name,
                }).ToList();

                this.gridControl1.DataSource = listStudent;
            }
        }

        private void QuanLyDiem_Load(object sender, EventArgs e)
        {
            cbLop.DataSource = null;
            
            using (var context = new NewAppContext())
            {
                var data = context.classes.Select(c => new
                {
                    name = c.name,
                    id = c.id
                }).ToList();
                cbLop.DataSource = data;
                cbLop.SelectedIndex = 0;
            }
            Utils.ClearLabels(pInfo);
        }
        public void updateInfoLop()
        {
            if (cbLop.SelectedIndex == -1) return;
            string id = cbLop.SelectedValue.ToString();
            lbMalop.Text = id;
            var selectedItem = cbLop.SelectedItem;
            string tenLop = string.Empty;

            if (selectedItem != null)
            {
                tenLop = selectedItem.GetType().GetProperty(cbLop.DisplayMember)?.GetValue(selectedItem)?.ToString();
            }
            lbTenLop.Text = tenLop.ToString();

        }
        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLop.SelectedIndex == -1) return;
            loadData(cbLop.SelectedValue.ToString());
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridView = gridControl1.MainView as GridView;
            var selectRows = gridView.GetSelectedRows();
            lbMahocvien.Text = "";
            lbTenHocVien.Text = "";
            foreach (var rowHandle in selectRows)
            {
                lbMahocvien.Text = gridView.GetRowCellValue(rowHandle, "studentId").ToString();
                lbTenHocVien.Text = gridView.GetRowCellValue(rowHandle, "studentName").ToString();

                // Lấy điểm của học viên và hiển thị lên các input tương ứng
                int studentId = int.Parse(gridView.GetRowCellValue(rowHandle, "studentId").ToString());
                int classId = int.Parse(gridView.GetRowCellValue(rowHandle, "classId").ToString());
                string className = gridView.GetRowCellValue(rowHandle, "className").ToString();
                lbMalop.Text = classId.ToString();
                lbTenLop.Text = className;
                using (var context = new NewAppContext())
                {
                    var classUser = context.ClassUser.FirstOrDefault(cu => cu.ClassId == (classId) && cu.UserId == studentId);
                    if (classUser != null)
                    {
                        listening.Value = Convert.ToDecimal(classUser.ListeningScore ?? 0);
                        reading.Value = Convert.ToDecimal(classUser.ReadingScore ?? 0);
                        speaking.Value = Convert.ToDecimal(classUser.SpeakingScore ?? 0);
                        writing.Value = Convert.ToDecimal(classUser.WritingScore ?? 0);
                    }
                }
            }
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            string maLop = lbMalop.Text;
            string tenLop = lbTenLop.Text;
            string maHocVien = lbMahocvien.Text;
            string tenHocVien = lbTenHocVien.Text;

            if (string.IsNullOrEmpty(maHocVien) || string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng chọn học viên cần sửa.");
                return;
            }

            float speakingV = (float)(speaking.Value);
            float listeningV = (float)(listening.Value);
            float readingV = (float)(reading.Value);
            float writingV = (float)(writing.Value);

            int classId = int.Parse(maLop);
            int userId = int.Parse(maHocVien);
            // Cập nhật điểm cho học viên
            using (var context = new NewAppContext())
            {
                // Tìm kiếm bản ghi của học viên trong lớp học
                var classUser = context.ClassUser.SingleOrDefault(cu => cu.ClassId == classId && cu.UserId == userId);

                if (classUser != null)
                {
                    // Cập nhật điểm và trạng thái
                    classUser.SpeakingScore = speakingV;
                    classUser.ListeningScore = listeningV;
                    classUser.ReadingScore = readingV;
                    classUser.WritingScore = writingV;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    // Cập nhật lại danh sách học viên trong lớp học
                    loadData(maLop);

                    MessageBox.Show($"Đã cập nhật điểm cho học viên {tenHocVien} trong lớp {tenLop}");
                }
                else
                {
                    MessageBox.Show($"Học viên {tenHocVien} không tồn tại trong lớp {tenLop}");
                }
            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }
    }

}