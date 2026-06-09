using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab8
{
    public partial class TakeExam : Form
    {
        private List<List<string[]>> exams;
        private List<string[]> currentExam;
        private int currentIndex = 0;
        private Dictionary<int, string> userAnswers = new Dictionary<int, string>();

        public TakeExam(List<List<string[]>> exams)
        {
            InitializeComponent();
            this.exams = exams;

            // تحميل الامتحانات في الـ ComboBox
            for (int i = 0; i < exams.Count; i++)
                examComboBox.Items.Add($"Exam {i + 1}  ({exams[i].Count} questions)");

            if (examComboBox.Items.Count > 0)
                examComboBox.SelectedIndex = 0;
            else
                MessageBox.Show("No exams available. Please create an exam first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            startBtn.Click += startBtn_Click;
            nextBtn.Click += nextBtn_Click;
            prevBtn.Click += prevBtn_Click;
            finishBtn.Click += finishBtn_Click;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (examComboBox.SelectedIndex < 0) return;
            currentExam = exams[examComboBox.SelectedIndex];
            currentIndex = 0;
            userAnswers.Clear();
            selectionPanel.Visible = false;
            questionPanel.Visible = true;
            ShowQuestion(0);
        }

        private void ShowQuestion(int idx)
        {
            if (currentExam == null || idx >= currentExam.Count) return;

            var q = currentExam[idx];
            counterLabel.Text = $"Question {idx + 1} / {currentExam.Count}";
            degreeLabel.Text = $"{q[1]} pts";
            questionLabel.Text = q[2];
            answersPanel.Controls.Clear();

            // التأكد من وجود إجابات مقسمة بفاصلة
            if (!string.IsNullOrEmpty(q[4]))
            {
                string[] answers = q[4].Split(',');
                int y = 8;
                foreach (var ans in answers)
                {
                    RadioButton rb = new RadioButton
                    {
                        Text = ans.Trim(),
                        Location = new Point(8, y),
                        Width = answersPanel.Width - 20,
                        Font = new Font("Microsoft Sans Serif", 11F),
                        Tag = ans.Trim(),
                        AutoSize = true // أفضل عشان الكلام ميبقاش مقصوص
                    };
                    if (userAnswers.ContainsKey(idx) && userAnswers[idx] == ans.Trim())
                        rb.Checked = true;
                    answersPanel.Controls.Add(rb);
                    y += 40;
                }
            }

            prevBtn.Enabled = idx > 0;
            nextBtn.Visible = idx < currentExam.Count - 1;
            finishBtn.Visible = idx == currentExam.Count - 1;
        }

        private void SaveAnswer()
        {
            foreach (Control c in answersPanel.Controls)
                if (c is RadioButton rb && rb.Checked)
                { userAnswers[currentIndex] = rb.Tag.ToString(); return; }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            currentIndex++;
            ShowQuestion(currentIndex);
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            currentIndex--;
            ShowQuestion(currentIndex);
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            SaveAnswer();

            int score = 0, total = 0;
            for (int i = 0; i < currentExam.Count; i++)
            {
                total += int.Parse(currentExam[i][1]);
                if (userAnswers.ContainsKey(i) && userAnswers[i] == currentExam[i][5])
                    score += int.Parse(currentExam[i][1]);
            }

            double pct = total > 0 ? (double)score / total * 100 : 0;
            MessageBox.Show(
                $"Score: {score} / {total}\nPercentage: {pct:F1}%\n\n{(pct >= 50 ? "PASSED ✓" : "Failed ✗")}",
                "Result", MessageBoxButtons.OK,
                pct >= 50 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            questionPanel.Visible = false;
            selectionPanel.Visible = true;
        }

        private void TakeExam_Load(object sender, EventArgs e)
        {

        }
    }
}