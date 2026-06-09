namespace DesignPatternsApp.Q1_DependencyInjection;

// Interface that any tax service must implement
public interface ITaxService
{
    double CalculateTax(double amount);
    string CurrencySymbol { get; }
    string TaxLabel { get; }
}
