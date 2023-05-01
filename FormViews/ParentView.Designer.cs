namespace TeacherGradingUI_WF.FormViews
{
    partial class ParentView
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
            this.cbStudent = new System.Windows.Forms.ComboBox();
            this.lbTests = new System.Windows.Forms.ListBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblClassTests = new System.Windows.Forms.Label();
            this.lblTeacherNotes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbStudent
            // 
            this.cbStudent.FormattingEnabled = true;
            this.cbStudent.Location = new System.Drawing.Point(12, 28);
            this.cbStudent.Name = "cbStudent";
            this.cbStudent.Size = new System.Drawing.Size(121, 24);
            this.cbStudent.TabIndex = 2;
            this.cbStudent.SelectedIndexChanged += new System.EventHandler(this.cbStudent_SelectedIndexChanged);
            // 
            // lbTests
            // 
            this.lbTests.FormattingEnabled = true;
            this.lbTests.ItemHeight = 16;
            this.lbTests.Location = new System.Drawing.Point(12, 74);
            this.lbTests.Name = "lbTests";
            this.lbTests.Size = new System.Drawing.Size(248, 356);
            this.lbTests.TabIndex = 4;
            this.lbTests.SelectedIndexChanged += new System.EventHandler(this.lbTests_SelectedIndexChanged);
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(266, 74);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(522, 356);
            this.tbNotes.TabIndex = 5;
            this.tbNotes.TextChanged += new System.EventHandler(this.tbNotes_TextChanged);
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(139, 28);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(121, 24);
            this.cbClass.TabIndex = 6;
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(12, 9);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(52, 16);
            this.lblStudent.TabIndex = 7;
            this.lblStudent.Text = "Student";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(136, 9);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(41, 16);
            this.lblClass.TabIndex = 8;
            this.lblClass.Text = "Class";
            // 
            // lblClassTests
            // 
            this.lblClassTests.AutoSize = true;
            this.lblClassTests.Location = new System.Drawing.Point(12, 55);
            this.lblClassTests.Name = "lblClassTests";
            this.lblClassTests.Size = new System.Drawing.Size(81, 16);
            this.lblClassTests.TabIndex = 9;
            this.lblClassTests.Text = "Class Tests:";
            // 
            // lblTeacherNotes
            // 
            this.lblTeacherNotes.AutoSize = true;
            this.lblTeacherNotes.Location = new System.Drawing.Point(263, 55);
            this.lblTeacherNotes.Name = "lblTeacherNotes";
            this.lblTeacherNotes.Size = new System.Drawing.Size(100, 16);
            this.lblTeacherNotes.TabIndex = 10;
            this.lblTeacherNotes.Text = "Teacher Notes:";
            // 
            // ParentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 437);
            this.Controls.Add(this.lblTeacherNotes);
            this.Controls.Add(this.lblClassTests);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.lbTests);
            this.Controls.Add(this.cbStudent);
            this.Name = "ParentView";
            this.Text = "ParentView";
            this.Load += new System.EventHandler(this.ParentView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbStudent;
        private System.Windows.Forms.ListBox lbTests;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblClassTests;
        private System.Windows.Forms.Label lblTeacherNotes;
    }
}