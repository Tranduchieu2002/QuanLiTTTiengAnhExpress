namespace H3CExpress.FormSchema
{
    partial class PurchaseCourse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.addHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaryLabel = new System.Windows.Forms.Label();
            this.usersGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.courseNameL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.courseIdL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1261, 189);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(164, 56);
            this.guna2Button1.TabIndex = 74;
            this.guna2Button1.Text = "Xuất thông tin khóa học";
            // 
            // addHoaDon
            // 
            this.addHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addHoaDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.addHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addHoaDon.ForeColor = System.Drawing.Color.White;
            this.addHoaDon.Location = new System.Drawing.Point(1261, 109);
            this.addHoaDon.Name = "addHoaDon";
            this.addHoaDon.Size = new System.Drawing.Size(164, 56);
            this.addHoaDon.TabIndex = 73;
            this.addHoaDon.Text = "Tạo hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1257, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 71;
            this.label2.Text = "Tổng tiền";
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "Giới tính";
            this.gender.MinimumWidth = 6;
            this.gender.Name = "gender";
            // 
            // studentName
            // 
            this.studentName.DataPropertyName = "studentName";
            this.studentName.HeaderText = "Tên học sinh";
            this.studentName.MinimumWidth = 6;
            this.studentName.Name = "studentName";
            // 
            // studentId
            // 
            this.studentId.DataPropertyName = "studentId";
            this.studentId.HeaderText = "Mã học sinh";
            this.studentId.MinimumWidth = 6;
            this.studentId.Name = "studentId";
            // 
            // salaryLabel
            // 
            this.salaryLabel.AutoSize = true;
            this.salaryLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salaryLabel.Location = new System.Drawing.Point(1376, 453);
            this.salaryLabel.Name = "salaryLabel";
            this.salaryLabel.Size = new System.Drawing.Size(21, 24);
            this.salaryLabel.TabIndex = 72;
            this.salaryLabel.Text = "0";
            // 
            // usersGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.usersGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usersGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.usersGridView.ColumnHeadersHeight = 22;
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.usersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentId,
            this.studentName,
            this.gender,
            this.email});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.usersGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.usersGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.usersGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.usersGridView.Location = new System.Drawing.Point(0, 0);
            this.usersGridView.MultiSelect = false;
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.RowHeadersVisible = false;
            this.usersGridView.RowHeadersWidth = 32;
            this.usersGridView.RowTemplate.Height = 28;
            this.usersGridView.Size = new System.Drawing.Size(501, 542);
            this.usersGridView.TabIndex = 70;
            this.usersGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.usersGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.usersGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.usersGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.usersGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.usersGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.usersGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.usersGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.usersGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.usersGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.usersGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.usersGridView.ThemeStyle.HeaderStyle.Height = 22;
            this.usersGridView.ThemeStyle.ReadOnly = false;
            this.usersGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.usersGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.usersGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.usersGridView.ThemeStyle.RowsStyle.Height = 28;
            this.usersGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.usersGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dg
            // 
            this.dg.Text = "Đơn vị";
            this.dg.Width = 80;
            // 
            // courseNameL
            // 
            this.courseNameL.Text = "Tên khóa học";
            this.courseNameL.Width = 120;
            // 
            // courseIdL
            // 
            this.courseIdL.Text = "Mã khóa học";
            this.courseIdL.Width = 100;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.courseIdL,
            this.courseNameL,
            this.total,
            this.dg});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(549, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(638, 464);
            this.listView1.TabIndex = 69;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // total
            // 
            this.total.Text = "Giá trị khóa học";
            this.total.Width = 180;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "Giá khóa học";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            // 
            // mota
            // 
            this.mota.DataPropertyName = "mota";
            this.mota.HeaderText = "Mô tả";
            this.mota.MinimumWidth = 6;
            this.mota.Name = "mota";
            // 
            // courseName
            // 
            this.courseName.DataPropertyName = "courseName";
            this.courseName.HeaderText = "Tên khóa học";
            this.courseName.MinimumWidth = 6;
            this.courseName.Name = "courseName";
            // 
            // courseId
            // 
            this.courseId.DataPropertyName = "courseId";
            this.courseId.HeaderText = "Mã Khóa học";
            this.courseId.MinimumWidth = 6;
            this.courseId.Name = "courseId";
            // 
            // courseDataGridView
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.courseDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.courseDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.courseDataGridView.ColumnHeadersHeight = 32;
            this.courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.courseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.courseId,
            this.courseName,
            this.mota,
            this.amount});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.courseDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.courseDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.courseDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.courseDataGridView.Location = new System.Drawing.Point(0, 542);
            this.courseDataGridView.Name = "courseDataGridView";
            this.courseDataGridView.RowHeadersVisible = false;
            this.courseDataGridView.RowHeadersWidth = 51;
            this.courseDataGridView.RowTemplate.Height = 28;
            this.courseDataGridView.Size = new System.Drawing.Size(1515, 301);
            this.courseDataGridView.TabIndex = 68;
            this.courseDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.courseDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.courseDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.courseDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.courseDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.courseDataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.courseDataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.courseDataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.courseDataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.courseDataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseDataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.courseDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.courseDataGridView.ThemeStyle.HeaderStyle.Height = 32;
            this.courseDataGridView.ThemeStyle.ReadOnly = false;
            this.courseDataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.courseDataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.courseDataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseDataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.courseDataGridView.ThemeStyle.RowsStyle.Height = 28;
            this.courseDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.courseDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // PurchaseCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.addHoaDon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.salaryLabel);
            this.Controls.Add(this.usersGridView);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.courseDataGridView);
            this.Name = "PurchaseCourse";
            this.Size = new System.Drawing.Size(1515, 843);
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button addHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentId;
        private System.Windows.Forms.Label salaryLabel;
        private Guna.UI2.WinForms.Guna2DataGridView usersGridView;
        private System.Windows.Forms.ColumnHeader dg;
        private System.Windows.Forms.ColumnHeader courseNameL;
        private System.Windows.Forms.ColumnHeader courseIdL;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn mota;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseId;
        private Guna.UI2.WinForms.Guna2DataGridView courseDataGridView;
    }
}
