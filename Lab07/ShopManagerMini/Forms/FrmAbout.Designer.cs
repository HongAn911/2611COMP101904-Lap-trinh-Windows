namespace ShopManagerMini.Forms
{
    partial class FrmAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblAppName
            //
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppName.Location = new System.Drawing.Point(20, 20);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(420, 38);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "ShopManagerMini";
            //
            // lblDescription
            //
            this.lblDescription.Location = new System.Drawing.Point(22, 62);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(420, 20);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Ứng dụng quản lý cửa hàng mini (SDI / MDI, nhiều Form).";
            //
            // lblVersion
            //
            this.lblVersion.Location = new System.Drawing.Point(22, 95);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(420, 20);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Phiên bản: 1.0 (dữ liệu lưu trong bộ nhớ)";
            //
            // lblCourse
            //
            this.lblCourse.Location = new System.Drawing.Point(22, 120);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(420, 20);
            this.lblCourse.TabIndex = 3;
            this.lblCourse.Text = "Học phần: COMP1019 - Lập trình trên Windows (Lab 07)";
            //
            // lblStudent
            //
            this.lblStudent.Location = new System.Drawing.Point(22, 155);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(420, 20);
            this.lblStudent.TabIndex = 4;
            this.lblStudent.Text = "Sinh viên thực hiện: Huỳnh Thị Hồng Ân";
            //
            // lblStudentId
            //
            this.lblStudentId.Location = new System.Drawing.Point(22, 180);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(420, 20);
            this.lblStudentId.TabIndex = 5;
            this.lblStudentId.Text = "MSSV: 49.01.103.006";
            //
            // lblClass
            //
            this.lblClass.Location = new System.Drawing.Point(22, 205);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(420, 20);
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "Lớp: 49.01.SPTIN.A";
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(350, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // FrmAbout
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 295);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblStudentId);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAppName);
            this.MaximizeBox = false;
            this.Name = "FrmAbout";
            this.Text = "Giới thiệu";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Button btnClose;
    }
}
