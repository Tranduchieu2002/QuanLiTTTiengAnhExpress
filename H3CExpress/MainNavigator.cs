using H3CExpress.UserControls;
using System;
using System.Windows.Forms;

namespace H3CExpress
{
    public partial class MainNavigator : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        UpdateClassesControl updateClassesControl;
        CapNhatGiangVien updateGiangVien;

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
    }
}
