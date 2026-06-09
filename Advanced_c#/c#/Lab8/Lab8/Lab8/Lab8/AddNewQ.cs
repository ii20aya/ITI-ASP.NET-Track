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
    public partial class AddNewQ : Form
    {
        private List<string> courses;
        private List<string[]> questions;
        private List<string> possibleAnswers = new List<string>();
        public AddNewQ(List<string> courses, List<string[]> questions)
        {
            InitializeComponent();
            this.courses = courses;
            this.questions = questions;

            foreach (var c in courses)
                comboBox1.Items.Add(c);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            
            for (int i = 1; i <= 10; i++)
                comboBox2.Items.Add(i);
            comboBox2.SelectedIndex = 0;
            
            button1.Click += button1_Click;
            SubmitBtn.Click += SubmitBtn_Click;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string ans = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(ans))
            {
                MessageBox.Show("Enter an answer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            possibleAnswers.Add(ans);
            comboBox3.Items.Add(ans);
            if (comboBox3.Items.Count == 1)
                comboBox3.SelectedIndex = 0;
            textBox2.Clear();
            textBox2.Focus();
        }

        // Submit
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            { MessageBox.Show("Select a course!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            { MessageBox.Show("Enter question content!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (possibleAnswers.Count < 2)
            { MessageBox.Show("Add at least 2 answers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (comboBox3.SelectedItem == null)
            { MessageBox.Show("Select the correct answer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // [0]course [1]degree [2]content [3]type [4]answers [5]correct
            string[] q = new string[]
            {
                comboBox1.SelectedItem.ToString(),
                comboBox2.SelectedItem.ToString(),
                textBox1.Text.Trim(),
                "MCQ",
                string.Join(",", possibleAnswers),
                comboBox3.SelectedItem.ToString()
            };

            questions.Add(q);
            MessageBox.Show("Question added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset
            textBox1.Clear();
            textBox2.Clear();
            possibleAnswers.Clear();
            comboBox3.Items.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void AddNewQ_Load(object sender, EventArgs e)
        {

        }
    }
}