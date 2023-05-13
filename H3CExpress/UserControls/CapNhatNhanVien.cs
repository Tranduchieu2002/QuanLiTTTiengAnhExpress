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
    public partial class CapNhatNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        public CapNhatNhanVien()
        {
            InitializeComponent();
        }
        void loadData()

        {
            using (var context = new NewAppContext())
            {
                this.gridControl1.DataSource = null;
                var teacherList = context.users.Where(u => u.roles.Code == "EMP").Select(u =>
                   new
                   {
                       u.id,
                       u.name,
                       u.gender,
                       u.username,
                       u.email,
                       chucvu = u.roles.name,
                   });
                var a = teacherList.Take(10).ToList();
                this.gridControl1.DataSource = a;
            }
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            fUpadtePerson f = new fUpadtePerson("EMP");
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
                fUpadtePerson f = new fUpadtePerson("EMP", id);
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
                DialogResult r = Utils.ShowMessWarn("Bạn có muốn xóa nhân viên " + name);
                if (r == DialogResult.Cancel) return;
                using (var context = new NewAppContext())
                {
                    try
                    {
                        var dataToDelete = context.users.Find(id);
                        context.users.Remove(dataToDelete);
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

        private void gridControl_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
