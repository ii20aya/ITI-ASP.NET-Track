namespace Assignment2
{
    partial class Form1
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
            // --- Meter to Feet ---
            lblMeterTitle        = new Label();
            txtMeter             = new TextBox();
            btnMeterConvert      = new Button();
            lblMeterResult       = new Label();

            // --- Gram to Pound ---
            lblGramTitle         = new Label();
            txtGram              = new TextBox();
            btnGramConvert       = new Button();
            lblGramResult        = new Label();

            // --- Fahrenheit to Celsius ---
            lblFahrenheitTitle   = new Label();
            txtFahrenheit        = new TextBox();
            btnFahrenheitConvert = new Button();
            lblFahrenheitResult  = new Label();

            SuspendLayout();

            // ===== Meter to Feet =====
            lblMeterTitle.Text      = "Meter \u2192 Feet";
            lblMeterTitle.Font      = new Font("Segoe UI", 10, FontStyle.Bold);
            lblMeterTitle.Location  = new Point(20, 20);
            lblMeterTitle.Size      = new Size(150, 25);

            txtMeter.Location = new Point(20, 50);
            txtMeter.Size     = new Size(150, 25);
            txtMeter.Text     = "1";

            btnMeterConvert.Text      = "Convert";
            btnMeterConvert.Location  = new Point(180, 50);
            btnMeterConvert.Size      = new Size(100, 25);
            btnMeterConvert.Click    += btnMeterConvert_Click;

            lblMeterResult.Text      = "Result: ---";
            lblMeterResult.Location  = new Point(300, 53);
            lblMeterResult.Size      = new Size(220, 25);

            // ===== Gram to Pound =====
            lblGramTitle.Text     = "Gram \u2192 Pound";
            lblGramTitle.Font     = new Font("Segoe UI", 10, FontStyle.Bold);
            lblGramTitle.Location = new Point(20, 100);
            lblGramTitle.Size     = new Size(150, 25);

            txtGram.Location = new Point(20, 130);
            txtGram.Size     = new Size(150, 25);
            txtGram.Text     = "100";

            btnGramConvert.Text     = "Convert";
            btnGramConvert.Location = new Point(180, 130);
            btnGramConvert.Size     = new Size(100, 25);
            btnGramConvert.Click   += btnGramConvert_Click;

            lblGramResult.Text     = "Result: ---";
            lblGramResult.Location = new Point(300, 133);
            lblGramResult.Size     = new Size(220, 25);

            // ===== Fahrenheit to Celsius =====
            lblFahrenheitTitle.Text     = "Fahrenheit \u2192 Celsius";
            lblFahrenheitTitle.Font     = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFahrenheitTitle.Location = new Point(20, 180);
            lblFahrenheitTitle.Size     = new Size(200, 25);

            txtFahrenheit.Location = new Point(20, 210);
            txtFahrenheit.Size     = new Size(150, 25);
            txtFahrenheit.Text     = "32";

            btnFahrenheitConvert.Text     = "Convert";
            btnFahrenheitConvert.Location = new Point(180, 210);
            btnFahrenheitConvert.Size     = new Size(100, 25);
            btnFahrenheitConvert.Click   += btnFahrenheitConvert_Click;

            lblFahrenheitResult.Text     = "Result: ---";
            lblFahrenheitResult.Location = new Point(300, 213);
            lblFahrenheitResult.Size     = new Size(220, 25);

            // ===== Form =====
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(560, 270);
            Text                = "Unit Converters - Async/Await";

            Controls.Add(lblMeterTitle);
            Controls.Add(txtMeter);
            Controls.Add(btnMeterConvert);
            Controls.Add(lblMeterResult);

            Controls.Add(lblGramTitle);
            Controls.Add(txtGram);
            Controls.Add(btnGramConvert);
            Controls.Add(lblGramResult);

            Controls.Add(lblFahrenheitTitle);
            Controls.Add(txtFahrenheit);
            Controls.Add(btnFahrenheitConvert);
            Controls.Add(lblFahrenheitResult);

            ResumeLayout(false);
            PerformLayout();
        }

        private Label   lblMeterTitle, lblGramTitle, lblFahrenheitTitle;
        private TextBox txtMeter, txtGram, txtFahrenheit;
        private Button  btnMeterConvert, btnGramConvert, btnFahrenheitConvert;
        private Label   lblMeterResult, lblGramResult, lblFahrenheitResult;
    }
}
