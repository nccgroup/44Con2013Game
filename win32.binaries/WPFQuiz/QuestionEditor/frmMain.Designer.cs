namespace QuestionEditor
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.richQuestion = new System.Windows.Forms.RichTextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.listQuestions = new System.Windows.Forms.ListView();
            this.richAnswerA = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richAnswerB = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richAnswerC = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richAnswerD = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbAnswer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richQuestion
            // 
            this.richQuestion.Location = new System.Drawing.Point(175, 43);
            this.richQuestion.Name = "richQuestion";
            this.richQuestion.Size = new System.Drawing.Size(403, 210);
            this.richQuestion.TabIndex = 2;
            this.richQuestion.Text = "";
            this.richQuestion.TextChanged += new System.EventHandler(this.richQuestion_TextChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(426, 530);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(123, 28);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "&Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // listQuestions
            // 
            this.listQuestions.FullRowSelect = true;
            this.listQuestions.LabelWrap = false;
            this.listQuestions.Location = new System.Drawing.Point(12, 12);
            this.listQuestions.MultiSelect = false;
            this.listQuestions.Name = "listQuestions";
            this.listQuestions.ShowItemToolTips = true;
            this.listQuestions.Size = new System.Drawing.Size(150, 536);
            this.listQuestions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listQuestions.TabIndex = 0;
            this.listQuestions.UseCompatibleStateImageBehavior = false;
            this.listQuestions.View = System.Windows.Forms.View.List;
            this.listQuestions.SelectedIndexChanged += new System.EventHandler(this.listQuestions_SelectedIndexChanged);
            this.listQuestions.DoubleClick += new System.EventHandler(this.listQuestions_DoubleClick);
            // 
            // richAnswerA
            // 
            this.richAnswerA.Location = new System.Drawing.Point(6, 16);
            this.richAnswerA.Name = "richAnswerA";
            this.richAnswerA.Size = new System.Drawing.Size(188, 78);
            this.richAnswerA.TabIndex = 3;
            this.richAnswerA.Text = "";
            this.richAnswerA.TextChanged += new System.EventHandler(this.richAnswerA_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richAnswerA);
            this.groupBox1.Location = new System.Drawing.Point(169, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Answer A";
            // 
            // richAnswerB
            // 
            this.richAnswerB.Location = new System.Drawing.Point(6, 16);
            this.richAnswerB.Name = "richAnswerB";
            this.richAnswerB.Size = new System.Drawing.Size(188, 78);
            this.richAnswerB.TabIndex = 4;
            this.richAnswerB.Text = "";
            this.richAnswerB.TextChanged += new System.EventHandler(this.richAnswerB_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richAnswerB);
            this.groupBox2.Location = new System.Drawing.Point(384, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Answer B";
            // 
            // richAnswerC
            // 
            this.richAnswerC.Location = new System.Drawing.Point(6, 16);
            this.richAnswerC.Name = "richAnswerC";
            this.richAnswerC.Size = new System.Drawing.Size(188, 78);
            this.richAnswerC.TabIndex = 5;
            this.richAnswerC.Text = "";
            this.richAnswerC.TextChanged += new System.EventHandler(this.richAnswerC_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richAnswerC);
            this.groupBox3.Location = new System.Drawing.Point(169, 366);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Answer C";
            // 
            // richAnswerD
            // 
            this.richAnswerD.Location = new System.Drawing.Point(6, 16);
            this.richAnswerD.Name = "richAnswerD";
            this.richAnswerD.Size = new System.Drawing.Size(188, 78);
            this.richAnswerD.TabIndex = 6;
            this.richAnswerD.Text = "";
            this.richAnswerD.TextChanged += new System.EventHandler(this.richAnswerD_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richAnswerD);
            this.groupBox4.Location = new System.Drawing.Point(384, 366);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Answer D";
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(211, 530);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(123, 28);
            this.cmdNew.TabIndex = 9;
            this.cmdNew.Text = "&New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmbLevel
            // 
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new System.Drawing.Point(211, 503);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(152, 21);
            this.cmbLevel.TabIndex = 7;
            this.cmbLevel.SelectedIndexChanged += new System.EventHandler(this.cmbLevel_SelectedIndexChanged);
            this.cmbLevel.SelectionChangeCommitted += new System.EventHandler(this.cmbLevel_SelectionChangeCommitted);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(172, 503);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(33, 13);
            this.lblQuestion.TabIndex = 10;
            this.lblQuestion.Text = "Level";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(390, 503);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 12;
            this.lblTime.Text = "Time";
            // 
            // cmbTime
            // 
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(426, 503);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(152, 21);
            this.cmbTime.TabIndex = 8;
            this.cmbTime.SelectedIndexChanged += new System.EventHandler(this.cmbTime_SelectedIndexChanged);
            this.cmbTime.SelectionChangeCommitted += new System.EventHandler(this.cmbTime_SelectionChangeCommitted);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(234, 12);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(344, 20);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(168, 15);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Description";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblAction
            // 
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(55, 17);
            this.lblAction.Text = "lblAction";
            // 
            // cmbAnswer
            // 
            this.cmbAnswer.FormattingEnabled = true;
            this.cmbAnswer.Location = new System.Drawing.Point(271, 473);
            this.cmbAnswer.Name = "cmbAnswer";
            this.cmbAnswer.Size = new System.Drawing.Size(307, 21);
            this.cmbAnswer.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Correct Answer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 646);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAnswer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.cmbLevel);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listQuestions);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.richQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCC Question Editor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richQuestion;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ListView listQuestions;
        private System.Windows.Forms.RichTextBox richAnswerA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richAnswerB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richAnswerC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richAnswerD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblAction;
        private System.Windows.Forms.ComboBox cmbAnswer;
        private System.Windows.Forms.Label label1;
    }
}

