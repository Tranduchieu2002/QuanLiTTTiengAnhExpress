using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using H3CExpress.Data.NewEntities;
using H3CExpress.Views;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace H3CExpress.UserControls
{
    public partial class CapNhatGiangVien : DevExpress.XtraEditors.XtraUserControl
    {
        int idxRowSelect = -1;
        public CapNhatGiangVien()
        {
            InitializeComponent();
        }

        private void CapNhatGiangVien_Load(object sender, System.EventArgs e)
        {
            loadData();
        }
        void loadData()

        {
            using (var context = new NewAppContext())
            {
                this.gridControl1.DataSource = null;
                var teacherList = context.users.Where(u => u.roles.Code == "Tea").Select(u =>
                   new
                   {
                       u.id,
                       u.name,
                       u.gender,
                       u.username,
                       u.email,
                       chucvu = u.roles.Code,
                   });
                var a = teacherList.Take(10).ToList();
                this.gridControl1.DataSource = a;
            }

        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            fUpadtePerson f = new fUpadtePerson("Tea");
            this.Hide();
            f.ShowDialog();
            this.Show();
            loadData();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridView gridView = gridControl1.MainView as GridView;
            var selectRows = gridView.GetSelectedRows();
            foreach (var rowHandle in selectRows)
            {
                var id = int.Parse(gridView.GetRowCellValue(rowHandle, "id").ToString());
                string name = gridView.GetRowCellValue(rowHandle, "name").ToString();
                DialogResult r = MessageBox.Show("Bạn có muốn xóa giáo viên  " + name, "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (r == DialogResult.Cancel) return;
                using (var context = new NewAppContext())
                {
                    var dataToDelete = context.users.Find(id);
                    context.users.Remove(dataToDelete);
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            loadData();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            this.idxRowSelect = e.RowIndex;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridView gridView = gridControl1.MainView as GridView;
            var selectRows = gridView.GetSelectedRows();
            foreach (var rowHandle in selectRows)
            {
                var id = gridView.GetRowCellValue(rowHandle, "id").ToString();
                var code = gridView.GetRowCellValue(rowHandle, "chucvu").ToString();
                fUpadtePerson f = new fUpadtePerson(code, id);
                this.Hide();
                f.ShowDialog();
                this.Show();
                loadData();
            }
        }
    }
}
