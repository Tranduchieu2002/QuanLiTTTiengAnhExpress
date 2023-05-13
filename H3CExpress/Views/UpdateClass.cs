using DevExpress.XtraEditors;
using H3CExpress.FormSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H3CExpress.Views
{
    public partial class UpdateClass : DevExpress.XtraEditors.XtraForm
    {
        public UpdateClass(int id)
        {
            InitializeComponent();
            H3CExpress.FormSchema.UpdateClass updateClass = new H3CExpress.FormSchema.UpdateClass(id);

            this.panelControl1.Controls.Add(updateClass);

            updateClass.Dock = DockStyle.Fill;
        }

        private void purchaseCourse1_Load(object sender, EventArgs e)
        {
            
        }
    }
}