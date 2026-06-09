namespace DesignPatternsApp.Q1_DependencyInjection;

// Egypt VAT = 14%
public class EgyptTaxService : ITaxService
{
    private const double TaxRate = 0.14;

    public double CalculateTax(double amount) => amount * TaxRate;
    public string CurrencySymbol => "EGP";
    public string TaxLabel => "Tax (14%)";
}
