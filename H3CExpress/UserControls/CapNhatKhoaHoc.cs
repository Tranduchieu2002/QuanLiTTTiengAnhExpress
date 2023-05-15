using DevExpress.XtraBars;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H3CExpress.UserControls
{
    public partial class CapNhatKhoaHoc : DevExpress.XtraEditors.XtraUserControl
    {
        public CapNhatKhoaHoc()
        {
            InitializeComponent();
        }
        void loadData()

        {
            using (var context = new NewAppContext())
            {
                try
                {
                    this.gridControl1.DataSource = null;
                    var khoaHocList = context.courses.Select(c => new
                    {
                        c.id,
                        c.name,
                        c.description,
                        c.totalAmount
                    }).ToList();
                    this.gridControl1.DataSource = khoaHocList;
                }
                catch
                {
                    Utils.ShowMessError("Có lỗi xảy ra khi lấy dữ liệu!!!");
                }
            }
        }


        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            fUpdateKhoaHoc f = new fUpdateKhoaHoc();
            this.Hide();
            f.ShowDialog();
            this.Show();
            loadData();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

            GridView gridView = gridControl1.MainView as GridView;
            var selectRows = gridView.GetSelectedRows();
            foreach (var rowHandle in selectRows)
            {
                var id = gridView.GetRowCellValue(rowHandle, "id").ToString();
                fUpdateKhoaHoc f = new fUpdateKhoaHoc(id);
                this.Hide();
                f.ShowDialog();
                this.Show();
                loadData();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridView gridView = gridControl1.MainView as GridView;
            var selectRows = gridView.GetSelectedRows();
            foreach (var rowHandle in selectRows)
            {
                var id = int.Parse(gridView.GetRowCellValue(rowHandle, "id").ToString());
                string name = gridView.GetRowCellValue(rowHandle, "name").ToString();
                DialogResult r = Utils.ShowMessWarn("Bạn có muốn xóa khóa học " + name);
                if (r == DialogResult.Cancel) return;
                using (var context = new NewAppContext())
                {
                    try
                    {
                        var dataToDelete = context.courses.Find(id);
                        context.courses.Remove(dataToDelete);
                        context.SaveChanges();
                        Utils.ShowMessInfo("Xóa thành công!!!");
                    }
                    catch
                    {
                        Utils.ShowMessInfo("Xóa thất bại!!!");
                    }
                }
            }
            loadData();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadData();
        }

        private void CapNhatKhoaHoc_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
