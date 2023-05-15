using H3CExpress.FormSchema;
using H3CExpress.UserControls;
using System;
using System.Windows.Forms;

namespace H3CExpress
{
    public partial class MainNavigator : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        UpdateClassesControl updateClassesControl;
        CapNhatGiangVien updateGiangVien;
        CapNhatNguoiDung updateNguoiDung;
        CapNhatNhanVien updateNhanVien;
        DanhGiaHocSinh danhGiaHocSinh;
        QuanLyHoaDon quanLyHoaDon;
        CapNhatKhoaHoc quanLyKhoaHoc;
        QuanLyDiem quanLyDiem;
        public MainNavigator()
        {
            InitializeComponent();
        }

        void LoadToPanel(UserControl control)
        {
            mainContainer.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BringToFront();
        }
        private void updateClasses_Click(object sender, EventArgs e)
        {
            if (updateClassesControl == null)
            {
                updateClassesControl = new UpdateClassesControl();
                LoadToPanel(updateClassesControl);
            }
            else updateClassesControl.BringToFront();
        }

        private void MainNavigator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void updateTeacher_Click(object sender, EventArgs e)
        {
            if (updateGiangVien == null)
            {
                updateGiangVien = new CapNhatGiangVien();
                LoadToPanel(updateGiangVien);
            }
            else updateGiangVien.BringToFront();
        }

        private void updateStudents_Click(object sender, EventArgs e)
        {
            if (updateNguoiDung == null)
            {
                updateNguoiDung = new CapNhatNguoiDung();
                LoadToPanel(updateNguoiDung);
            }
            else updateNguoiDung.BringToFront();
        }

        private void updateEmps_Click(object sender, EventArgs e)
        {
            if (updateNhanVien == null)
            {
                updateNhanVien = new CapNhatNhanVien();
                LoadToPanel(updateNhanVien);
            }
            else updateNhanVien.BringToFront();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (quanLyDiem == null)
            {
                quanLyDiem = new QuanLyDiem();
                LoadToPanel(quanLyDiem);
            }
            else quanLyDiem.BringToFront();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

            if (danhGiaHocSinh == null)
            {
                danhGiaHocSinh = new DanhGiaHocSinh();
                LoadToPanel(danhGiaHocSinh);
            }
            else danhGiaHocSinh.BringToFront();

        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            if (quanLyHoaDon == null)
            {
                quanLyHoaDon = new QuanLyHoaDon();
                LoadToPanel(quanLyHoaDon);
            }
            else quanLyHoaDon.BringToFront();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

            if (quanLyKhoaHoc == null)
            {
                quanLyKhoaHoc = new CapNhatKhoaHoc();
                LoadToPanel(quanLyKhoaHoc);
            }
            else quanLyKhoaHoc.BringToFront();
        }
    }
}
