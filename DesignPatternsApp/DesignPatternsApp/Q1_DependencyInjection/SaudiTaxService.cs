namespace DesignPatternsApp.Q1_DependencyInjection;

// Saudi VAT = 15%
public class SaudiTaxService : ITaxService
{
    private const double TaxRate = 0.15;

    public double CalculateTax(double amount) => amount * TaxRate;
    public string CurrencySymbol => "SAR";
    public string TaxLabel => "Tax (15%)";
}
