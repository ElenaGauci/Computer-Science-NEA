namespace TeacherGradingUI_WF.FormViews
{
    partial class StudentView
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
            this.cbTestS = new System.Windows.Forms.ComboBox();
            this.cbClassS = new System.Windows.Forms.ComboBox();
            this.listbTestS = new System.Windows.Forms.ListBox();
            this.listbAllTest = new System.Windows.Forms.ListBox();
            this.tbStudentNotes = new System.Windows.Forms.TextBox();
            this.tbTeacherNotes = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAllTests = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblTeacherComments = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbTestS
            // 
            this.cbTestS.FormattingEnabled = true;
            this.cbTestS.Location = new System.Drawing.Point(148, 28);
            this.cbTestS.Name = "cbTestS";
            this.cbTestS.Size = new System.Drawing.Size(121, 24);
            this.cbTestS.TabIndex = 7;
            this.cbTestS.SelectedIndexChanged += new System.EventHandler(this.cbTestS_SelectedIndexChanged);
            // 
            // cbClassS
            // 
            this.cbClassS.FormattingEnabled = true;
            this.cbClassS.Location = new System.Drawing.Point(12, 28);
            this.cbClassS.Name = "cbClassS";
            this.cbClassS.Size = new System.Drawing.Size(121, 24);
            this.cbClassS.TabIndex = 6;
            this.cbClassS.SelectedIndexChanged += new System.EventHandler(this.cbClassS_SelectedIndexChanged);
            // 
            // listbTestS
            // 
            this.listbTestS.FormattingEnabled = true;
            this.listbTestS.ItemHeight = 16;
            this.listbTestS.Location = new System.Drawing.Point(12, 58);
            this.listbTestS.Name = "listbTestS";
            this.listbTestS.Size = new System.Drawing.Size(1016, 36);
            this.listbTestS.TabIndex = 14;
            this.listbTestS.SelectedIndexChanged += new System.EventHandler(this.lbCurrentTest_SelectedIndexChanged);
            // 
            // listbAllTest
            // 
            this.listbAllTest.FormattingEnabled = true;
            this.listbAllTest.ItemHeight = 16;
            this.listbAllTest.Location = new System.Drawing.Point(12, 116);
            this.listbAllTest.Name = "listbAllTest";
            this.listbAllTest.Size = new System.Drawing.Size(257, 308);
            this.listbAllTest.TabIndex = 15;
            this.listbAllTest.SelectedIndexChanged += new System.EventHandler(this.lbAllTests_SelectedIndexChanged);
            // 
            // tbStudentNotes
            // 
            this.tbStudentNotes.Location = new System.Drawing.Point(278, 116);
            this.tbStudentNotes.Multiline = true;
            this.tbStudentNotes.Name = "tbStudentNotes";
            this.tbStudentNotes.Size = new System.Drawing.Size(360, 278);
            this.tbStudentNotes.TabIndex = 16;
            this.tbStudentNotes.TextChanged += new System.EventHandler(this.tbStudentNotes_TextChanged);
            // 
            // tbTeacherNotes
            // 
            this.tbTeacherNotes.Location = new System.Drawing.Point(644, 116);
            this.tbTeacherNotes.Multiline = true;
            this.tbTeacherNotes.Name = "tbTeacherNotes";
            this.tbTeacherNotes.Size = new System.Drawing.Size(384, 308);
            this.tbTeacherNotes.TabIndex = 17;
            this.tbTeacherNotes.TextChanged += new System.EventHandler(this.tbTeacherNotes_TextChanged);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(278, 400);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(178, 24);
            this.btSave.TabIndex = 18;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(460, 400);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(178, 24);
            this.btClear.TabIndex = 19;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(12, 9);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(41, 16);
            this.lblClass.TabIndex = 20;
            this.lblClass.Text = "Class";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(145, 9);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(34, 16);
            this.lblTest.TabIndex = 21;
            this.lblTest.Text = "Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(934, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Selected Test:";
            this.label1.Click += new System.EventHandler(this.lblSelectedTest_Click);
            // 
            // lblAllTests
            // 
            this.lblAllTests.AutoSize = true;
            this.lblAllTests.Location = new System.Drawing.Point(12, 97);
            this.lblAllTests.Name = "lblAllTests";
            this.lblAllTests.Size = new System.Drawing.Size(133, 16);
            this.lblAllTests.TabIndex = 23;
            this.lblAllTests.Text = "All Tests From Class:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(275, 97);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(46, 16);
            this.lblNotes.TabIndex = 24;
            this.lblNotes.Text = "Notes:";
            // 
            // lblTeacherComments
            // 
            this.lblTeacherComments.AutoSize = true;
            this.lblTeacherComments.Location = new System.Drawing.Point(636, 97);
            this.lblTeacherComments.Name = "lblTeacherComments";
            this.lblTeacherComments.Size = new System.Drawing.Size(128, 16);
            this.lblTeacherComments.TabIndex = 25;
            this.lblTeacherComments.Text = "Teacher Comments:";
            // 
            // StudentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 450);
            this.Controls.Add(this.lblTeacherComments);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblAllTests);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbTeacherNotes);
            this.Controls.Add(this.tbStudentNotes);
            this.Controls.Add(this.listbAllTest);
            this.Controls.Add(this.listbTestS);
            this.Controls.Add(this.cbTestS);
            this.Controls.Add(this.cbClassS);
            this.Name = "StudentView";
            this.Text = "StudentView";
            this.Load += new System.EventHandler(this.StudentView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTestS;
        private System.Windows.Forms.ComboBox cbClassS;
        private System.Windows.Forms.ListBox listbTestS;
        private System.Windows.Forms.ListBox listbAllTest;
        private System.Windows.Forms.TextBox tbStudentNotes;
        private System.Windows.Forms.TextBox tbTeacherNotes;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAllTests;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblTeacherComments;
    }
}