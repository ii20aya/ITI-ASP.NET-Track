using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class NewExam : Form
    {
        private List<string> courses;
        private List<string[]> questions;
        private List<List<string[]>> exams;

        private List<CheckBox> checkBoxes = new List<CheckBox>();

        // CourseNameComboBox = اختيار الكورس
        // panel1             = هيتملا بـ CheckBoxes للأسئلة
        // SubmitBtn          = إنشاء الامتحان

        public NewExam(List<string> courses, List<string[]> questions, List<List<string[]>> exams)
        {
            InitializeComponent();
            this.courses = courses;
            this.questions = questions;
            this.exams = exams;

            // تحميل الكورسات
            foreach (var c in courses)
                CourseNameComboBox.Items.Add(c);
            if (CourseNameComboBox.Items.Count > 0)
                CourseNameComboBox.SelectedIndex = 0;

            CourseNameComboBox.SelectedIndexChanged += (s, e) => LoadQuestions();
            SubmitBtn.Click += SubmitBtn_Click;

            LoadQuestions();
        }

        private void LoadQuestions()
        {
            panel1.Controls.Clear();
            checkBoxes.Clear();

            string course = CourseNameComboBox.SelectedItem?.ToString();
            if (course == null) return;

            var filtered = questions.Where(q => q[0] == course).ToList();

            if (filtered.Count == 0)
            {
                panel1.Controls.Add(new Label
                {
                    Text = "No questions for this course yet.",
                    Location = new Point(10, 10),
                    AutoSize = true,
                    ForeColor = Color.Gray
                });
                return;
            }

            int y = 5;
            foreach (var q in filtered)
            {
                CheckBox cb = new CheckBox
                {
                    Text = $"[{q[1]} pts]  {q[2]}",
                    Location = new Point(5, y),
                    Width = panel1.Width - 15,
                    Tag = q
                };
                checkBoxes.Add(cb);
                panel1.Controls.Add(cb);
                y += 28;
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (CourseNameComboBox.SelectedItem == null)
            { MessageBox.Show("Select a course!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            var selected = checkBoxes
                .Where(cb => cb.Checked)
                .Select(cb => cb.Tag as string[])
                .ToList();

            if (selected.Count == 0)
            { MessageBox.Show("Select at least one question!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            exams.Add(selected);

            int total = selected.Sum(q => int.Parse(q[1]));
            MessageBox.Show($"Exam created!\nQuestions: {selected.Count}\nTotal Degree: {total} pts",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void NewExam_Load(object sender, EventArgs e)
        {

        }
    }
}