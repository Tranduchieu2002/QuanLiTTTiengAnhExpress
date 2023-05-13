using DevExpress.XtraEditors;
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
    public partial class UpdateClass : DevExpress.XtraEditors.XtraUserControl
    {
        int id;
        classes classInstance;
        public UpdateClass(int classId)
        {
         
            InitializeComponent();

            id = classId;
            
        }
        void loadClassInfo(NewAppContext context, int id) {
            classInstance = context.classes.Find(id);

            MessageBox.Show(classInstance.name);

            idClassLabel.Text = classInstance.id.ToString();

            NameClassLabel.Text = classInstance.name;

            NameCourseLabel.Text = classInstance.courses.name;

            totalStuLabel.Text = classInstance.ClassUser.Count.ToString();

            startDateLabel.Text = classInstance.start_time.ToShortDateString();

            endDateLabel.Text = classInstance.end_time.ToShortDateString();


        }
        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateClass_Load(object sender, EventArgs e)
        {
            using (NewAppContext context = new NewAppContext())
            {
                loadClassInfo(context, id);
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
