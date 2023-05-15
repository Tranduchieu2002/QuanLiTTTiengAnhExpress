﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using H3CExpress.Data.NewEntities;
using H3CExpress.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static H3CExpress.Data.NewEntities.users;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace H3CExpress.UserControls
{
    public partial class QuanLyDiem : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public QuanLyDiem()
        {
            InitializeComponent();
        }

        void loadData(string id)
        {
            using (var context = new NewAppContext())
            {
                classes ClassInstance = context.classes.Find(int.Parse(id));
                if (ClassInstance == null)
                {
                    MessageBox.Show("KHông tìm thấy lớp học");
                    this.Close();
                }
                this.gridControl1.DataSource = null;
                var listStudent = ClassInstance.ClassUser.Select(u => new
                {
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
            cbLop.DisplayMember = "name";
            cbLop.ValueMember = "id";
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
            updateInfoLop();
            GridView gridView = gridControl1.MainView as GridView;
            var selectRows = gridView.GetSelectedRows();
            lbMahocvien.Text = "";
            lbTenHocVien.Text = "";
            foreach (var rowHandle in selectRows)
            {
                lbMahocvien.Text = gridView.GetRowCellValue(rowHandle, "studentId").ToString();
                lbTenHocVien.Text = gridView.GetRowCellValue(rowHandle, "studentName").ToString();
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

            decimal speakingV = (speaking.Value);
            decimal listeningV = (listening.Value);
            decimal readingV = (reading.Value);
            decimal writingV = (writing.Value);

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
                    classUser.SpeakingScore = (float)speakingV;
                    classUser.ListeningScore = (float)listeningV;
                    classUser.ReadingScore = (float)readingV;
                    classUser.WritingScore = (float)writingV;

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

    }
}