using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Lab8
{
    public partial class ExaminationSystem : Form
    {
        public List<string> Courses = new List<string>();
        public List<string[]> Questions = new List<string[]>();
        public List<List<string[]>> Exams = new List<List<string[]>>();

        public ExaminationSystem()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            Courses.Add("Math");
            Courses.Add("english");
            Courses.Add("ai");
        }

        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewQ form = new AddNewQ(Courses, Questions);
            form.MdiParent = this;
            form.Show();
        }

        private void exaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewExam form = new NewExam(Courses, Questions, Exams);
            form.MdiParent = this;
            form.Show();
        }

        private void couToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = ShowDialog("Enter Course Name:", "New Course");

            if (!string.IsNullOrWhiteSpace(name))
            {
                Courses.Add(name.Trim());
                MessageBox.Show("Course added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400 };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void takeExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeExam form = new TakeExam(Exams);
            form.MdiParent = this;
            form.Show();
        }
    }
}