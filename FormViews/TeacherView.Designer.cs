namespace TeacherGradingUI_WF.FormViews
{
    partial class TeacherView
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
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.cbTest = new System.Windows.Forms.ComboBox();
            this.ClassTestTable = new System.Windows.Forms.ListBox();
            this.listbAverages = new System.Windows.Forms.ListBox();
            this.cbAverages = new System.Windows.Forms.ComboBox();
            this.lbAverages = new System.Windows.Forms.Label();
            this.tbTeacherNotes = new System.Windows.Forms.TextBox();
            this.cbStudent = new System.Windows.Forms.ComboBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(12, 22);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(121, 24);
            this.cbClass.TabIndex = 1;
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
            // 
            // cbTest
            // 
            this.cbTest.FormattingEnabled = true;
            this.cbTest.Location = new System.Drawing.Point(139, 22);
            this.cbTest.Name = "cbTest";
            this.cbTest.Size = new System.Drawing.Size(121, 24);
            this.cbTest.TabIndex = 2;
            this.cbTest.SelectedIndexChanged += new System.EventHandler(this.cbTest_SelectedIndexChanged);
            // 
            // ClassTestTable
            // 
            this.ClassTestTable.FormattingEnabled = true;
            this.ClassTestTable.ItemHeight = 16;
            this.ClassTestTable.Location = new System.Drawing.Point(12, 52);
            this.ClassTestTable.Name = "ClassTestTable";
            this.ClassTestTable.Size = new System.Drawing.Size(1188, 180);
            this.ClassTestTable.TabIndex = 6;
            this.ClassTestTable.SelectedIndexChanged += new System.EventHandler(this.lbClassTestTable_SelectedIndexChanged_1);
            // 
            // listbAverages
            // 
            this.listbAverages.FormattingEnabled = true;
            this.listbAverages.ItemHeight = 16;
            this.listbAverages.Location = new System.Drawing.Point(398, 242);
            this.listbAverages.Name = "listbAverages";
            this.listbAverages.Size = new System.Drawing.Size(802, 52);
            this.listbAverages.TabIndex = 7;
            this.listbAverages.SelectedIndexChanged += new System.EventHandler(this.lbAverages_SelectedIndexChanged);
            // 
            // cbAverages
            // 
            this.cbAverages.FormattingEnabled = true;
            this.cbAverages.Items.AddRange(new object[] {
            "Mean",
            "Median",
            "Mode"});
            this.cbAverages.Location = new System.Drawing.Point(286, 266);
            this.cbAverages.Name = "cbAverages";
            this.cbAverages.Size = new System.Drawing.Size(106, 24);
            this.cbAverages.TabIndex = 8;
            this.cbAverages.SelectedIndexChanged += new System.EventHandler(this.cbAverages_SelectedIndexChanged);
            // 
            // lbAverages
            // 
            this.lbAverages.AutoSize = true;
            this.lbAverages.Location = new System.Drawing.Point(310, 247);
            this.lbAverages.Name = "lbAverages";
            this.lbAverages.Size = new System.Drawing.Size(66, 16);
            this.lbAverages.TabIndex = 9;
            this.lbAverages.Text = "Averages";
            // 
            // tbTeacherNotes
            // 
            this.tbTeacherNotes.Location = new System.Drawing.Point(12, 300);
            this.tbTeacherNotes.Multiline = true;
            this.tbTeacherNotes.Name = "tbTeacherNotes";
            this.tbTeacherNotes.Size = new System.Drawing.Size(1188, 138);
            this.tbTeacherNotes.TabIndex = 11;
            this.tbTeacherNotes.TextChanged += new System.EventHandler(this.tbTeacherNotes_TextChanged);
            // 
            // cbStudent
            // 
            this.cbStudent.FormattingEnabled = true;
            this.cbStudent.Location = new System.Drawing.Point(12, 238);
            this.cbStudent.Name = "cbStudent";
            this.cbStudent.Size = new System.Drawing.Size(121, 24);
            this.cbStudent.TabIndex = 12;
            this.cbStudent.SelectedIndexChanged += new System.EventHandler(this.cbStudent_SelectedIndexChanged);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(139, 237);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(121, 24);
            this.btSave.TabIndex = 13;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(12, 266);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(121, 24);
            this.btLoad.TabIndex = 14;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(139, 265);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(121, 24);
            this.btClear.TabIndex = 15;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // TeacherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 450);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.cbStudent);
            this.Controls.Add(this.tbTeacherNotes);
            this.Controls.Add(this.lbAverages);
            this.Controls.Add(this.cbAverages);
            this.Controls.Add(this.listbAverages);
            this.Controls.Add(this.ClassTestTable);
            this.Controls.Add(this.cbTest);
            this.Controls.Add(this.cbClass);
            this.Name = "TeacherView";
            this.Text = "TeacherView";
            this.Load += new System.EventHandler(this.TeacherView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.ComboBox cbTest;
        private System.Windows.Forms.ListBox ClassTestTable;
        private System.Windows.Forms.ListBox listbAverages;
        private System.Windows.Forms.ComboBox cbAverages;
        private System.Windows.Forms.Label lbAverages;
        private System.Windows.Forms.TextBox tbTeacherNotes;
        private System.Windows.Forms.ComboBox cbStudent;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btClear;
    }
}