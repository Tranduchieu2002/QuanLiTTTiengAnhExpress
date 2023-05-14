using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.TextEditController.Win32;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using Guna.UI2.WinForms;
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
        int? id;
        classes classInstance;
        public UpdateClass(int? classId)
        {
         
            InitializeComponent();

            if(classId != null) {
                id = (int)classId;
            }
            
        }
        void loadClassInfo(NewAppContext context, int? id)
        {
            if(id == null)
            {
                return;
            }
            classInstance = context.classes.Find(id);

            idEdit.Text = classInstance.id.ToString();

            System.Windows.Forms.ComboBox listCourseComboBox1 = listCourseComboBox;
            SetComboBoxValue(listCourseComboBox1, classInstance.course_id.ToString());

            SetComboBoxValue(giaovienCbb, classInstance.teacher_id.ToString());

            LoadDataToLabels(classInstance);
        }

        void LoadDataToLabels(classes classInstance)
        {
            startDateEdit.DateTime = classInstance.start_time;
            endDateEdit.DateTime = classInstance.end_time;
            System.DateTime dateTime = System.DateTime.MinValue.Add(classInstance.learning_time);
            learingTimeTb.DateTime = dateTime;

            idClassLabel.Text = classInstance.id.ToString();

            NameClassLabel.Text = classInstance.name;
            nameEdit.Text = classInstance.name;

            NameCourseLabel.Text = classInstance.courses.name;

            totalStuLabel.Text = classInstance.ClassUser.Count.ToString();

            startDateLabel.Text = classInstance.start_time.ToShortDateString();

            endDateLabel.Text = classInstance.end_time.ToShortDateString();

            sisoLabel.Text = classInstance.ClassUser.Count.ToString();
        }

        private void UpdateClass_Load(object sender, EventArgs e)
        {
            using (NewAppContext context = new NewAppContext())
            {
                LoadCourseComboBox(context);
                LoadTeacherComboBox(context);
                if(id != null)
                {
                    loadClassInfo(context, id);
                    return;
                }
            }
        }

        void LoadCourseComboBox(NewAppContext context)
        {
            var courses = from c in context.courses
                          select new
                          {
                              c.id,
                              c.name,
                              c.description,
                              totalAmount = c.totalAmount.ToString()
                          };

            listCourseComboBox.DataSource = courses.Take(10).ToList();
            listCourseComboBox.DisplayMember = "name";
            listCourseComboBox.ValueMember = "id";
        }

        void LoadTeacherComboBox(NewAppContext context)
        {
            var teacher = from t in context.users where t.roles.name == "TEACHER" select t;

            var teacherI = teacher.ToList();
            if (teacher.Count() > 0)
            {
                giaovienCbb.DataSource = teacherI;
                giaovienCbb.DisplayMember = "name";
                giaovienCbb.ValueMember = "id";
                giaovienCbb.SelectedIndex = 0;
            }
        }

        void SetComboBoxValue(System.Windows.Forms.ComboBox comboBox, string searchValue)
        {
            int index = comboBox.FindStringExact(searchValue);
            if (index >= 0)
            {
                comboBox.SelectedIndex = index;
            }
        }


        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl11_Paint(object sender, PaintEventArgs e)
        {

        }
        public bool CheckAllTextboxValid()
        {

            bool allValid = true;
            foreach (Control control in this.Controls)
            {
                if (control is TextEdit textEdit)
                {
                    // Check if the TextEdit control has a valid value
                    if (String.IsNullOrEmpty(textEdit.Text.Trim()))
                    {
                        allValid = false;
                        break;
                    }
                }
                else if (control is ComboBoxEdit comboBoxEdit)
                {
                    // Check if the ComboBoxEdit control has a selected value
                    if (comboBoxEdit.SelectedIndex == -1)
                    {
                        allValid = false;
                        break;
                    }
                }
                
            }

            if (!allValid)
            {
                // Some controls have invalid values
                MessageBox.Show("Thông tin thêm vào chưa hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return allValid;

        }
        System.TimeSpan getSelectedHours()
        {
            System.DateTime selectedTime = learingTimeTb.DateTime;
            System.TimeSpan timeSpan = System.DateTime.Now.TimeOfDay - selectedTime.TimeOfDay;
            return timeSpan;
        }
        private async void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool valid = CheckAllTextboxValid();

            if (valid)
            {
                string idClass = (idEdit.Text.Trim());
                string name = nameEdit.Text.Trim();
                DateTime startDate = startDateEdit.DateTime;
                DateTime endDate = endDateEdit.DateTime;
                TimeSpan learingTime = getSelectedHours();
                var teacherId = giaovienCbb.SelectedIndex == -1 ? -1 : int.Parse(giaovienCbb.SelectedValue.ToString());

                using (var context= new NewAppContext())
                {
                    if(string.IsNullOrEmpty(idClass)) {

                        classes ClassIns = new classes
                        {
                            name = name,
                            course_id = int.Parse(listCourseComboBox.SelectedValue.ToString()),
                            start_time = startDate,
                            end_time = endDate,
                            learning_time = learingTime,
                        };

                        if (teacherId >= 0)
                        {
                            ClassIns.teacher_id = teacherId;
                        }

                        MessageBox.Show("adu " + teacherId + "  " + (listCourseComboBox.SelectedValue.ToString()));

                        context.classes.Add(ClassIns);

                        context.SaveChanges();

                        MessageBox.Show("Tạo thành công lớp học " + ClassIns.name);

                        classInstance = context.classes.Find(ClassIns.id);
                        id = classInstance.id;
                        return;
                    }
                    classes lophoc = context.classes.Find(int.Parse(idClass));
                    if (lophoc != null)
                    {
                        lophoc.name = name;
                        lophoc.course_id = int.Parse(listCourseComboBox.SelectedValue.ToString());
                        lophoc.Status = Status.ACTIVE;
                        lophoc.end_time = endDate;
                        lophoc.learning_time = learingTime;
                        lophoc.start_time = startDate;
                        if (teacherId > 0)
                        {
                            lophoc.teacher_id = teacherId;
                        }
                    }

                    context.SaveChanges();

                    MessageBox.Show("Update thành công lớp học " + lophoc.name);
                }

            }
        }

        private void sisoLabel_Click(object sender, EventArgs e)
        {

        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(id != null)
            {
                using(var context = new NewAppContext())
                {
                    classes lophoc = context.classes.Find(id);
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // Nếu người dùng chọn Yes, tiến hành xóa thông tin
                    if (result == DialogResult.No) return;
                    if (lophoc != null)
                    {
                        context.classes.Remove(lophoc);

                        context.SaveChanges();

                    }

                    classInstance = null;
                    id = null;

                    MessageBox.Show("Xóa lớp học thành công !");

                    this.Hide();
                }
            } else {
                    MessageBox.Show("Chưa có thông tin lớp học !");
            }
        }
    }
}
