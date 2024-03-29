﻿using DevExpress.XtraEditors;
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
                    textBox.Text = "";
                    //textBox.Clear();
                }
                else if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }
        public static void ClearLabels(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is Label)
                {
                    Label label = (Label)c;
                    label.Text = string.Empty;
                }
                else if (c is LabelControl)
                {
                    LabelControl labelControl = (LabelControl)c;
                    labelControl.Text = string.Empty;
                }
                else if (c.HasChildren)
                {
                    ClearLabels(c);
                }
            }
        }
        public static bool HasOneRadioSelect(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)c;
                    if (radioButton.Checked) return true;
                }
                else if (c is Guna2RadioButton)
                {
                    Guna2RadioButton radioButton = (Guna2RadioButton)c;
                    if (radioButton.Checked) return true;
                }
                else if (c.HasChildren)
                {
                    ClearLabels(c);
                }
            }
            return false;
        }

        public static bool UnCheckedAllRadioButton(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)c;
                    radioButton.Checked = false;
                }
                else if (c is Guna2RadioButton)
                {
                    Guna2RadioButton radioButton = (Guna2RadioButton)c;
                    radioButton.Checked = false;
                }
                else if (c.HasChildren)
                {
                    ClearLabels(c);
                }
            }
            return false;
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
                if (c is System.Windows.Forms.ComboBox || c is Guna2ComboBox)
                {
                    if (c is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)c;
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
            return MessageBox.Show(notify, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ShowMessWarn(string notify, string caption = "Thông báo")
        {
            return MessageBox.Show(notify, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}
