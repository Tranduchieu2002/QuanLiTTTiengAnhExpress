namespace H3CExpress.UserControls
{
    partial class ClassUserView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.teacherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.courseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.schedule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.startDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.endDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.studentName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1067, 522);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.Load += new System.EventHandler(this.gridControl_Load);
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.studentName,
            this.name,
            this.teacherName,
            this.courseName,
            this.schedule,
            this.startDate,
            this.endDate});
            this.gridView.DetailHeight = 431;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            // 
            // id
            // 
            this.id.Caption = "Mã lớp học";
            this.id.DisplayFormat.FormatString = "Mã lớp học";
            this.id.FieldName = "classId";
            this.id.MinWidth = 25;
            this.id.Name = "id";
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            this.id.Width = 87;
            // 
            // name
            // 
            this.name.Caption = "Tên lớp";
            this.name.FieldName = "className";
            this.name.MinWidth = 25;
            this.name.Name = "name";
            this.name.Visible = true;
            this.name.VisibleIndex = 2;
            this.name.Width = 87;
            // 
            // teacherName
            // 
            this.teacherName.Caption = "Tên Giáo Viên";
            this.teacherName.FieldName = "teacherName";
            this.teacherName.MinWidth = 25;
            this.teacherName.Name = "teacherName";
            this.teacherName.Visible = true;
            this.teacherName.VisibleIndex = 3;
            this.teacherName.Width = 94;
            // 
            // courseName
            // 
            this.courseName.Caption = "Tên Khóa Học";
            this.courseName.FieldName = "courseName";
            this.courseName.MinWidth = 25;
            this.courseName.Name = "courseName";
            this.courseName.Visible = true;
            this.courseName.VisibleIndex = 4;
            this.courseName.Width = 94;
            // 
            // schedule
            // 
            this.schedule.Caption = "Lịch học";
            this.schedule.FieldName = "schedule";
            this.schedule.MinWidth = 25;
            this.schedule.Name = "schedule";
            this.schedule.Visible = true;
            this.schedule.VisibleIndex = 5;
            this.schedule.Width = 94;
            // 
            // startDate
            // 
            this.startDate.Caption = "Ngày bắt đầu";
            this.startDate.DisplayFormat.FormatString = "d";
            this.startDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.startDate.FieldName = "startDate";
            this.startDate.MinWidth = 25;
            this.startDate.Name = "startDate";
            this.startDate.Visible = true;
            this.startDate.VisibleIndex = 6;
            this.startDate.Width = 94;
            // 
            // endDate
            // 
            this.endDate.Caption = "Ngày kết thúc";
            this.endDate.FieldName = "endDate";
            this.endDate.MinWidth = 25;
            this.endDate.Name = "endDate";
            this.endDate.Visible = true;
            this.endDate.VisibleIndex = 7;
            this.endDate.Width = 94;
            // 
            // studentName
            // 
            this.studentName.Caption = "Tên học sinh";
            this.studentName.FieldName = "studentName";
            this.studentName.MinWidth = 25;
            this.studentName.Name = "studentName";
            this.studentName.Visible = true;
            this.studentName.VisibleIndex = 1;
            this.studentName.Width = 66;
            // 
            // ClassUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "ClassUserView";
            this.Size = new System.Drawing.Size(1067, 522);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn teacherName;
        private DevExpress.XtraGrid.Columns.GridColumn courseName;
        private DevExpress.XtraGrid.Columns.GridColumn schedule;
        private DevExpress.XtraGrid.Columns.GridColumn startDate;
        private DevExpress.XtraGrid.Columns.GridColumn endDate;
        private DevExpress.XtraGrid.Columns.GridColumn studentName;
    }
}
