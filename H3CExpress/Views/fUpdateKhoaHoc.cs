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
using static Guna.UI2.Native.WinApi;

namespace H3CExpress.Views
{
    public partial class fUpdateKhoaHoc : Form
    {
        public fUpdateKhoaHoc(string id = "")
        {
            InitializeComponent();
            nbGiaTien.Maximum = 999999;
            nbGiaTien.Minimum = 0;
            bool isEdit = !id.Equals("");
            if (!isEdit)
            {
                btnSua.Enabled = false;
                return;
            }
            updateValue(id);

            btnThem.Enabled = false;
        }
        public void updateValue(string id)
        {
            using (var context = new NewAppContext())
            {
                int idKhoaHocEdit = int.Parse(id);
                var khoaHocEdit = context.courses.FirstOrDefault(u => u.id == idKhoaHocEdit);
                if (khoaHocEdit == null)
                {
                    Utils.ShowMessError("Đã xảy ra lỗi!!!");
                    return;
                }
                tbMaKhoaHoc.Text = khoaHocEdit.id.ToString();
                tbNameKhoaHoc.Text = khoaHocEdit.name;
                rtbMotaKhoaHoc.Text = khoaHocEdit.description.ToString();
                nbGiaTien.Value = decimal.Parse(khoaHocEdit.totalAmount.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string err = Utils.AreAllTextBoxHasValue(this);
            err = err.Equals("") ? Utils.AreAllComboBoxesSelected(this) : err;
            if (!err.Equals(""))
            {
                Utils.ShowMessWarn(err);
                return;
            }

            using (var dbContext = new NewAppContext())
            {
                try
                {
                    courses newKhoaHoc = new courses
                    {
                        description = rtbMotaKhoaHoc.Text,
                        totalAmount = nbGiaTien.Value,
                        name = tbNameKhoaHoc.Text,
                    };
                    dbContext.courses.Add(newKhoaHoc);
                    dbContext.SaveChanges();
                    Utils.ClearTextBoxes(this);
                    Utils.ShowMessInfo("Thêm khóa học thành công!!!");
                    nbGiaTien.Value = 0;
                    rtbMotaKhoaHoc.Text = "";
                }
                catch
                {
                    Utils.ShowMessError("Thêm khóa học thất bại!!!");
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string err = Utils.AreAllTextBoxHasValue(this);
            err = err.Equals("") ? Utils.AreAllComboBoxesSelected(this) : err;
            if (!err.Equals(""))
            {
                Utils.ShowMessWarn(err);
                return;
            }
            using (var context = new NewAppContext())
            {
                try
                {
                    var khoaHocUpdate = context.courses.Find(Int32.Parse(tbMaKhoaHoc.Text));
                    if (khoaHocUpdate == null) return;
                    khoaHocUpdate.name = tbNameKhoaHoc.Text;
                    khoaHocUpdate.description = rtbMotaKhoaHoc.Text;
                    khoaHocUpdate.totalAmount = nbGiaTien.Value;
                    context.SaveChanges();
                    Utils.ShowMessInfo("Cập nhât thông tin thành công!!!");
                    this.Close();
                }
                catch
                {
                    Utils.ShowMessError("Cập nhât thông tin thất bại!!!");
                }

            }
        }

        private void fUpdateKhoaHoc_Load(object sender, EventArgs e)
        {
            tbMaKhoaHoc.Enabled = false;
        }
    }
}
