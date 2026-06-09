namespace Lab8
{
    partial class ExaminationSystem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.couToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeExamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.newToolStripMenuItem,
                this.takeExamToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.questionToolStripMenuItem,
                this.exaToolStripMenuItem,
                this.couToolStripMenuItem });
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.newToolStripMenuItem.Text = "New";

            this.questionToolStripMenuItem.Name = "questionToolStripMenuItem";
            this.questionToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.questionToolStripMenuItem.Text = "Question";
            this.questionToolStripMenuItem.Click += new System.EventHandler(this.questionToolStripMenuItem_Click);

            this.exaToolStripMenuItem.Name = "exaToolStripMenuItem";
            this.exaToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.exaToolStripMenuItem.Text = "Exam";
            this.exaToolStripMenuItem.Click += new System.EventHandler(this.exaToolStripMenuItem_Click);

            this.couToolStripMenuItem.Name = "couToolStripMenuItem";
            this.couToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.couToolStripMenuItem.Text = "Course";
            this.couToolStripMenuItem.Click += new System.EventHandler(this.couToolStripMenuItem_Click);

            this.takeExamToolStripMenuItem.Name = "takeExamToolStripMenuItem";
            this.takeExamToolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.takeExamToolStripMenuItem.Text = "Take Exam";
            this.takeExamToolStripMenuItem.Click += new System.EventHandler(this.takeExamToolStripMenuItem_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExaminationSystem";
            this.Text = "ExaminationSystem";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeExamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem couToolStripMenuItem;
    }
}