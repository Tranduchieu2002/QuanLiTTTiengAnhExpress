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
using static H3CExpress.Data.NewEntities.users;

namespace H3CExpress.UserControls
{
    public partial class QuanLyBienLai : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public QuanLyBienLai()
        {
            InitializeComponent();
            cbKhoaHoc.DisplayMember = "name";
            cbKhoaHoc.ValueMember = "id";
            cbKhoaHoc.SelectedIndex = -1;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            bool isSelect = Utils.HasOneRadioSelect(pTimkiem);
            if (!isSelect)
            {
                Utils.ShowMessWarn("Vui lòng chọn thông tin muốn tìm kiếm!!!");
                return;
            }

            using (var context = new NewAppContext())
            {

                try
                {
                    int id = int.Parse(tbMahocvien.Text);
                    this.hocVienList.DataSource = null;
                    var data = context.users
                        .Where(u => u.roles.Code == "USR")
                        .Where(u => rbMahocvien.Checked
                        ? u.id == id
                        : u.name == tbTenhocvien.Text).Select(u =>
                       new
                       {
                           u.id,
                           u.name,
                           u.gender,
                           u.username,
                           u.email,
                       });
                    this.hocVienList.DataSource = data.Take(10).ToList(); ;
                }
                catch
                {
                    Utils.ShowMessError("Có lỗi xảy ra!!!");
                }

            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Utils.ClearTextBoxes(pTimkiem);
            Utils.UnCheckedAllRadioButton(pTimkiem);
        }

        public void loadKhoaHoc()
        {
            using (var context = new NewAppContext())
            {
                try
                {
                    var data = context.courses.ToList();
                    cbKhoaHoc.DataSource = data;
                }
                catch
                {

                }
            }
        }
        public void loadHocVien()
        {
            using (var context = new NewAppContext())
            {
                this.hocVienList.DataSource = null;
                try
                {
                    var hocVienList = context.users.Where(u => u.roles.Code == "USR").Select(u =>
                      new
                      {
                          u.id,
                          u.name,
                          u.gender,
                          u.username,
                          u.email,
                          chucvu = u.roles.name,
                      });
                    var a = hocVienList.Take(10).ToList();
                    this.hocVienList.DataSource = a;
                }
                catch
                {

                }

            }
        }
        public void loadHoaDon()
        {
            using (var context = new NewAppContext())
            {

                try
                {
                    this.hoaDonList.DataSource = null;
                    var data = context.HoaDons.Select(hd => new
                    {
                        hd.SoHoaDon,
                        MaHocVien = hd.MaKH,
                        MaKhoaHoc = hd.MaHang,
                        hd.MaNV,
                        hd.ThanhTien,
                        hd.NgayLap,
                    }).ToList();
                    this.hoaDonList.DataSource = data;
                }
                catch
                {

                }

            }
        }

        private void QuanLyBienLai_Load(object sender, EventArgs e)
        {

            cbKhoaHoc.DataSource = null;
            tbMakhoahoc.Enabled = false;
            nbGiaKhoaHoc.Enabled = false;
            dateTime.Value = DateTime.Now;
            dateTime.Enabled = false;
            loadHocVien();
            loadKhoaHoc();
            loadHoaDon();
        }

        private void cbKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhoaHoc.SelectedIndex == -1) return;
            int idKhoaHoc = int.Parse(cbKhoaHoc.SelectedValue.ToString());
            using (var context = new NewAppContext())
            {
                try
                {
                    var khoaHocSelect = context.courses.FirstOrDefault(c => c.id == idKhoaHoc);
                    if (khoaHocSelect == null)
                    {
                        Utils.ShowMessWarn("Đã xảy ra lỗi!!!");
                        return;
                    }
                    nbGiaKhoaHoc.Value = decimal.Parse(khoaHocSelect.totalAmount.ToString());
                }
                catch
                {
                    Utils.ShowMessError("Có lỗi xảy ra!!!");
                }

            }

        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            nbGiaKhoaHoc.Value = 0;
            cbKhoaHoc.SelectedIndex = -1;
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            GridView gridView = hocVienList.MainView as GridView;
            if (gridView.FocusedRowHandle < 0)
            {
                Utils.ShowMessInfo("Vui lòng chọn học viên muốn mua khóa học!!!");
                return;

            }
            if (cbKhoaHoc.SelectedIndex == -1)
            {
                Utils.ShowMessInfo("Vui lòng chọn khóa học muốn mua!!!");
                return;
            }

            int selectedRowIndex = gridView1.FocusedRowHandle;

            int idHocVien = int.Parse(gridView1.GetRowCellValue(selectedRowIndex, "id").ToString());
            int idKhoaHoc = int.Parse(cbKhoaHoc.SelectedValue.ToString());
            double giaKhoaHoc = (double)nbGiaKhoaHoc.Value;
            using (var dbContext = new NewAppContext())
            {

                try
                {
                    var hoaDonDaMua = dbContext.HoaDons.FirstOrDefault(hd => hd.MaKH == idHocVien && hd.MaHang == idKhoaHoc);
                    if (hoaDonDaMua != null)
                    {
                        Utils.ShowMessError("Bạn đã mua khóa học này rồi!!!");
                        return;

                    }
                    HoaDons newHoaDon = new HoaDons
                    {
                        ThanhTien = giaKhoaHoc,
                        MaKH = idHocVien,
                        MaNV = 1053,
                        NgayLap = dateTime.Value,
                        MaHang = idKhoaHoc,
                    };
                    dbContext.HoaDons.Add(newHoaDon);
                    dbContext.SaveChanges();
                    Utils.ShowMessInfo("Thêm hóa đơn thành công!!!");
                    Utils.ClearTextBoxes(this);
                    cbKhoaHoc.SelectedIndex = -1;
                    loadHoaDon();
                }
                catch
                {
                    Utils.ShowMessError("Thêm hóa đơn thất bại!!!");
                }
            }
        }
    }
}