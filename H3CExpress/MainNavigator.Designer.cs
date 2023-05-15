namespace H3CExpress
{
    partial class MainNavigator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainNavigator));
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.qldmControl = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.updateClasses = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.updateTeacher = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.updateStudents = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.updateEmps = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ScoreControl = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ReportControls = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.classReport = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.studentReport = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(405, 39);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(860, 573);
            this.mainContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(141)))), ((int)(((byte)(114)))));
            this.accordionControl1.Appearance.AccordionControl.BorderColor = System.Drawing.Color.White;
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl1.Appearance.AccordionControl.Options.UseBorderColor = true;
            this.accordionControl1.Appearance.ItemWithContainer.Default.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(141)))), ((int)(((byte)(114)))));
            this.accordionControl1.Appearance.ItemWithContainer.Default.BorderColor = System.Drawing.Color.White;
            this.accordionControl1.Appearance.ItemWithContainer.Default.Options.UseBackColor = true;
            this.accordionControl1.Appearance.ItemWithContainer.Default.Options.UseBorderColor = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.qldmControl,
            this.ScoreControl,
            this.ReportControls});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(405, 573);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // qldmControl
            // 
            this.qldmControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.updateClasses,
            this.updateTeacher,
            this.updateStudents,
            this.updateEmps});
            this.qldmControl.Expanded = true;
            this.qldmControl.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.qldmControl.Name = "qldmControl";
            this.qldmControl.Text = "Quản lí danh mục";
            // 
            // updateClasses
            // 
            this.updateClasses.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("updateClasses.ImageOptions.SvgImage")));
            this.updateClasses.Name = "updateClasses";
            this.updateClasses.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.updateClasses.Text = "Cập nhật lớp học";
            this.updateClasses.Click += new System.EventHandler(this.updateClasses_Click);
            // 
            // updateTeacher
            // 
            this.updateTeacher.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("updateTeacher.ImageOptions.Image")));
            this.updateTeacher.Name = "updateTeacher";
            this.updateTeacher.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.updateTeacher.Text = "Cập nhật giảng viên";
            this.updateTeacher.Click += new System.EventHandler(this.updateTeacher_Click);
            // 
            // updateStudents
            // 
            this.updateStudents.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("updateStudents.ImageOptions.Image")));
            this.updateStudents.Name = "updateStudents";
            this.updateStudents.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.updateStudents.Text = "Cập nhật học viên";
            this.updateStudents.Click += new System.EventHandler(this.updateStudents_Click);
            // 
            // updateEmps
            // 
            this.updateEmps.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("updateEmps.ImageOptions.Image")));
            this.updateEmps.Name = "updateEmps";
            this.updateEmps.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.updateEmps.Text = "Cập nhật nhân viên";
            this.updateEmps.Click += new System.EventHandler(this.updateEmps_Click);
            // 
            // ScoreControl
            // 
            this.ScoreControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2,
            this.accordionControlElement1});
            this.ScoreControl.Expanded = true;
            this.ScoreControl.Name = "ScoreControl";
            this.ScoreControl.Text = "Quản lí điểm";
            // 
            // ReportControls
            // 
            this.ReportControls.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.classReport,
            this.studentReport});
            this.ReportControls.Name = "ReportControls";
            this.ReportControls.Text = "Báo cáo thống kê";
            // 
            // classReport
            // 
            this.classReport.Name = "classReport";
            this.classReport.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.classReport.Text = "Thông kê theo Lớp";
            // 
            // studentReport
            // 
            this.studentReport.Name = "studentReport";
            this.studentReport.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.studentReport.Text = "Thống kê học viên";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1265, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement2.ImageOptions.Image")));
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Quản lí điểm";
            this.accordionControlElement2.Click += new System.EventHandler(this.accordionControlElement2_Click);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Text = "Đánh gia học sinh";
            this.accordionControlElement1.Click += new System.EventHandler(this.accordionControlElement1_Click);
            // 
            // MainNavigator
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 612);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.Image = global::H3CExpress.Properties.Resources.logo;
            this.IconOptions.SvgImage = global::H3CExpress.Properties.Resources.Goescat_Macaron_Spotify_client;
            this.IconOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MainNavigator";
            this.NavigationControl = this.accordionControl1;
            this.Text = "H3C-English";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainNavigator_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement qldmControl;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement updateClasses;
        private DevExpress.XtraBars.Navigation.AccordionControlElement updateTeacher;
        private DevExpress.XtraBars.Navigation.AccordionControlElement updateStudents;
        private DevExpress.XtraBars.Navigation.AccordionControlElement updateEmps;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ScoreControl;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ReportControls;
        private DevExpress.XtraBars.Navigation.AccordionControlElement classReport;
        private DevExpress.XtraBars.Navigation.AccordionControlElement studentReport;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
    }
}