using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace H3CExpress
{
    internal class Utils
    {
        public static void ClearTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBoxBase)
                {
                    TextBoxBase textBox = (TextBoxBase)c;
                    textBox.Clear();
                }
                else if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }

        public static string AreAllTextBoxHasValue(Control control, string notify = "")
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBoxBase)
                {
                    if (!c.Enabled || !c.Text.Equals("")) continue;
                    return notify.Equals("") ? "Vui lòng nhập đầy đủ thông tin!!!" : notify;
                }
                else if (c.HasChildren)
                {
                    string err = AreAllTextBoxHasValue(c, notify);
                    if (err.Equals("")) continue;
                    return err;
                }
            }
            return "";
        }
        public static string AreAllComboBoxesSelected(Control control, string notify = "")
        {
            foreach (Control c in control.Controls)
            {
                if (c is ComboBox || c is Guna2ComboBox)
                {
                    if (c is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)c;
                        if (comboBox.SelectedIndex >= 0) continue;
                        return notify.Equals("") ? "Vui lòng nhập đầy đủ thông tin!!!" : notify;

                    }
                    else if (c is Guna2ComboBox)
                    {
                        Guna2ComboBox guna2ComboBox = (Guna2ComboBox)c;
                        if (guna2ComboBox.SelectedIndex >= 0) continue;
                        return notify.Equals("") ? "Vui lòng nhập đầy đủ thông tin!!!" : notify;
                    }
                }
                else if (c.HasChildren)
                {
                    string err = AreAllComboBoxesSelected(c, notify);
                    if (err.Equals("")) continue;
                    return err;
                }
            }

            return "";
        }
        public static DialogResult ShowMessInfo(string notify, string caption = "Thông báo")
        {
            return MessageBox.Show(notify, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowMessError(string notify, string caption = "Có lỗi xảy ra")
        {
            return MessageBox.Show(notify, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
        public static DialogResult ShowMessWarn(string notify, string caption = "Thông báo")
        {
            return MessageBox.Show(notify, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
