namespace DesignPatternsApp.Q2_Singleton;

public class PrinterManager
{
    // ── Singleton mechanics ──────────────────────────────────────────────
    private static PrinterManager? _instance;

    // Private constructor → nobody can do "new PrinterManager()" from outside
    private PrinterManager()
    {
        Console.WriteLine("Printer initialized.");
    }

    // The one and only access point
    public static PrinterManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new PrinterManager();

            return _instance;
        }
    }

    // ── Printer logic ────────────────────────────────────────────────────
    private int _printedCount = 0;

    public void PrintDocument(string documentName)
    {
        _printedCount++;
        Console.WriteLine($"Printing: {documentName} (Total printed: {_printedCount})");
    }
}
