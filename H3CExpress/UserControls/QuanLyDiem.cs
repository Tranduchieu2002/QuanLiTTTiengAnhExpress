using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using H3CExpress.Data.NewEntities;
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
    public partial class QuanLyDiem : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public QuanLyDiem()
        {
            InitializeComponent();
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLop.SelectedIndex < 0) return;
            lbMalop.Text = cbLop.SelectedValue.ToString();
            lbTenLop.Text = cbLop.SelectedItem.ToString();
            //loadData();
        }
        void loadData()

        {
            using (var context = new NewAppContext())
            {
                this.gridControl1.DataSource = null;
                var hocSinhList = context.users.Where(u => u.roles.Code == "USR").Select(u =>
                   new
                   {
                       u.id,
                       u.name,
                       u.gender,
                       u.username,
                       u.email,
                   });
                var a = hocSinhList.Take(10).ToList();
                this.gridControl1.DataSource = a;
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
                cbLop.DisplayMember = "name";
                cbLop.ValueMember = "id";
            }
            Utils.ClearLabels(pInfo);
        }
    }
}