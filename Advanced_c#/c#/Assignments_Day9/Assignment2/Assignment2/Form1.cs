namespace Assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        //\ Converter Func
        async Task<double> MeterToFeet(double meter)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return meter * 3.28084;
            });
        }

        async Task<double> GramToPound(double gram)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return gram * 0.00220462;
            });
        }

        async Task<double> FahrenheitToCelsius(double fahrenheit)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return (fahrenheit - 32) * 5.0 / 9.0;
            });
        }

        // Butts

        private async void btnMeterConvert_Click(object sender, EventArgs e)
        {
            double input = double.Parse(txtMeter.Text);
            lblMeterResult.Text = "Converting...";
            double result = await MeterToFeet(input);
            lblMeterResult.Text = $"{result:F4} ft";
        }

        private async void btnGramConvert_Click(object sender, EventArgs e)
        {
            double input = double.Parse(txtGram.Text);
            lblGramResult.Text = "Converting...";
            double result = await GramToPound(input);
            lblGramResult.Text = $"{result:F4} lb";
        }

        private async void btnFahrenheitConvert_Click(object sender, EventArgs e)
        {
            double input = double.Parse(txtFahrenheit.Text);
            lblFahrenheitResult.Text = "Converting...";
            double result = await FahrenheitToCelsius(input);
            lblFahrenheitResult.Text = $"{result:F4} \u00b0C";
        }
    }
}
