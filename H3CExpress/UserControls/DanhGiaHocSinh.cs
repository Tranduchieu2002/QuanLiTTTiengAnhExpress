using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using H3CExpress.Data.NewEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H3CExpress.UserControls
{
    public partial class DanhGiaHocSinh : DevExpress.XtraEditors.XtraUserControl
    {
        XtraUserControl employeesUserControl;
        XtraUserControl customersUserControl;
        public DanhGiaHocSinh()
        {
            InitializeComponent();
            employeesUserControl = CreateUserControl("Employees");
            customersUserControl = CreateUserControl("Customers");
            accordionControl.SelectedElement = employeesAccordionControlElement;
        }
        XtraUserControl CreateUserClassControl(string text, string labelP)
        {
            XtraUserControl result = new ClassUserView(int.Parse(labelP));
            result.Name = text.ToLower() + "UserControl";
            result.Text = text;
            LabelControl label = new LabelControl();
            label.Parent = result;
            label.Appearance.Font = new Font("Tahoma", 25.25F);
            label.Appearance.ForeColor = Color.Gray;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.AutoSizeMode = LabelAutoSizeMode.None;
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            label.Text = text;
            return result;
        }
        XtraUserControl CreateUserControl(string text)
        {
            XtraUserControl result = new XtraUserControl();
            result.Name = text.ToLower() + "UserControl";
            result.Text = text;
            LabelControl label = new LabelControl();
            label.Parent = result;
            label.Appearance.Font = new Font("Tahoma", 25.25F);
            label.Appearance.ForeColor = Color.Gray;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.AutoSizeMode = LabelAutoSizeMode.None;
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            label.Text = text;
            return result;
        }
        void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            if (e.Element == null) return;
            if(e.Element.Tag != null)
            {
                UserControl userView = this.CreateUserClassControl(text: e.Element.Text, e.Element.Tag.ToString());
                tabbedView.ActivateDocument(userView);
                tabbedView.AddDocument(userView);
                return;
            }
            XtraUserControl userControl = e.Element.Text == "Employees" ? employeesUserControl : customersUserControl;
            tabbedView.AddDocument(userControl);
            tabbedView.ActivateDocument(userControl);
        }
        void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            accordionControl.SelectedElement = mainAccordionGroup.Elements[barItemIndex];
        }
        void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            RecreateUserControls(e);
            SetAccordionSelectedElement(e);
        }
        void SetAccordionSelectedElement(DocumentEventArgs e)
        {
            if (tabbedView.Documents.Count != 0)
            {
                if (e.Document.Caption == "Employees") accordionControl.SelectedElement = customersAccordionControlElement;
                else accordionControl.SelectedElement = employeesAccordionControlElement;
            }
            else
            {
                accordionControl.SelectedElement = null;
            }
        }
        void RecreateUserControls(DocumentEventArgs e)
        {
            if (e.Document.Caption == "Employees") employeesUserControl = CreateUserControl("Employees");
            else customersUserControl = CreateUserControl("Customers");
        }

        private void employeesAccordionControlElement_Click(object sender, EventArgs e)
        {

        }

        private void DanhGiaHocSinh_Load(object sender, EventArgs e)
        {
            using (var context = new NewAppContext())
            {
                var lophocs = context.classes.Select(c => new
                {
                    c.id,
                    c.name
                }).ToList();

                List<AccordionControlElement> ListElement = new List<AccordionControlElement>();
                foreach (var lophoc in lophocs)
                {

                    AccordionControlElement newElement = new AccordionControlElement();
                    newElement.Name = "lophoc" + lophoc.id +"AccordionControlElement";
                    newElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
                    newElement.Text = lophoc.name;
                    newElement.Tag = lophoc.id;
                    newElement.Click += new System.EventHandler(this.employeesAccordionControlElement_Click);

                    ListElement.Add(newElement);
                    // Add the new group to the main group
                }
                this.mainAccordionGroup.Elements.AddRange(ListElement.ToArray());
            }
        }
    }
}