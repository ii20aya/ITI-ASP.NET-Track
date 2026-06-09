using System.Drawing;

namespace Lab8
{
    partial class TakeExam
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.examComboBox = new System.Windows.Forms.ComboBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.questionPanel = new System.Windows.Forms.Panel();
            this.counterLabel = new System.Windows.Forms.Label();
            this.degreeLabel = new System.Windows.Forms.Label();
            this.questionLabel = new System.Windows.Forms.Label();
            this.answersPanel = new System.Windows.Forms.Panel();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.finishBtn = new System.Windows.Forms.Button();
            this.selectionPanel.SuspendLayout();
            this.questionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectionPanel
            // 
            this.selectionPanel.Controls.Add(this.examComboBox);
            this.selectionPanel.Controls.Add(this.startBtn);
            this.selectionPanel.Location = new System.Drawing.Point(12, 12);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(622, 100);
            this.selectionPanel.TabIndex = 0;
            // 
            // examComboBox
            // 
            this.examComboBox.Location = new System.Drawing.Point(20, 20);
            this.examComboBox.Name = "examComboBox";
            this.examComboBox.Size = new System.Drawing.Size(400, 28);
            this.examComboBox.TabIndex = 0;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(430, 18);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(150, 35);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start Exam";
            // 
            // questionPanel
            // 
            this.questionPanel.Controls.Add(this.counterLabel);
            this.questionPanel.Controls.Add(this.degreeLabel);
            this.questionPanel.Controls.Add(this.questionLabel);
            this.questionPanel.Controls.Add(this.answersPanel);
            this.questionPanel.Controls.Add(this.nextBtn);
            this.questionPanel.Controls.Add(this.prevBtn);
            this.questionPanel.Controls.Add(this.finishBtn);
            this.questionPanel.Location = new System.Drawing.Point(12, 120);
            this.questionPanel.Name = "questionPanel";
            this.questionPanel.Size = new System.Drawing.Size(622, 300);
            this.questionPanel.TabIndex = 1;
            this.questionPanel.Visible = false;
            // 
            // counterLabel
            // 
            this.counterLabel.Location = new System.Drawing.Point(20, 10);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(100, 23);
            this.counterLabel.TabIndex = 0;
            this.counterLabel.Text = "Question 0/0";
            // 
            // degreeLabel
            // 
            this.degreeLabel.Location = new System.Drawing.Point(500, 10);
            this.degreeLabel.Name = "degreeLabel";
            this.degreeLabel.Size = new System.Drawing.Size(100, 23);
            this.degreeLabel.TabIndex = 1;
            this.degreeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // questionLabel
            // 
            this.questionLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.questionLabel.Location = new System.Drawing.Point(20, 40);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(580, 50);
            this.questionLabel.TabIndex = 2;
            // 
            // answersPanel
            // 
            this.answersPanel.Location = new System.Drawing.Point(20, 100);
            this.answersPanel.Name = "answersPanel";
            this.answersPanel.Size = new System.Drawing.Size(580, 150);
            this.answersPanel.TabIndex = 3;
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(430, 260);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 4;
            this.nextBtn.Text = "Next";
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(20, 260);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(75, 23);
            this.prevBtn.TabIndex = 5;
            this.prevBtn.Text = "Previous";
            // 
            // finishBtn
            // 
            this.finishBtn.Location = new System.Drawing.Point(430, 260);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(75, 23);
            this.finishBtn.TabIndex = 6;
            this.finishBtn.Text = "Finish";
            this.finishBtn.Visible = false;
            // 
            // TakeExam
            // 
            this.ClientSize = new System.Drawing.Size(646, 432);
            this.Controls.Add(this.selectionPanel);
            this.Controls.Add(this.questionPanel);
            this.Name = "TakeExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Exam";
            this.Load += new System.EventHandler(this.TakeExam_Load);
            this.selectionPanel.ResumeLayout(false);
            this.questionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel selectionPanel, questionPanel, answersPanel;
        private System.Windows.Forms.ComboBox examComboBox;
        private System.Windows.Forms.Button startBtn, nextBtn, prevBtn, finishBtn;
        private System.Windows.Forms.Label counterLabel, degreeLabel, questionLabel;
    }
}