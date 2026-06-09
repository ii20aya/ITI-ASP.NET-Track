namespace DesignPatternsApp.Q1_DependencyInjection;

// Depends on ITaxService interface — NOT on a concrete class (this is Dependency Injection)
public class InvoiceService
{
    private readonly ITaxService _taxService;

    // Tax service is INJECTED through the constructor
    public InvoiceService(ITaxService taxService)
    {
        _taxService = taxService;
    }

    public void PrintInvoice(double subtotal)
    {
        double tax   = _taxService.CalculateTax(subtotal);
        double total = subtotal + tax;

        string cur = _taxService.CurrencySymbol;

        Console.WriteLine($"Subtotal : {subtotal} {cur}");
        Console.WriteLine($"{_taxService.TaxLabel,-10}: {tax} {cur}");
        Console.WriteLine($"Total    : {total} {cur}");
    }
}
