using DesignPatternsApp.Q1_DependencyInjection;
using DesignPatternsApp.Q2_Singleton;
using DesignPatternsApp.Q3_Builder;


//  Question 1 —


Console.WriteLine(" Q1 — Dependency Injection           ");

Console.WriteLine();
var egyptInvoice = new InvoiceService(new EgyptTaxService());
Console.WriteLine("--- Egypt Tax System ---");
egyptInvoice.PrintInvoice(1000);

Console.WriteLine();
var saudiInvoice = new InvoiceService(new SaudiTaxService());
Console.WriteLine("--- Saudi Tax System ---");
saudiInvoice.PrintInvoice(1000);


//  Question 2 — Singleton 

Console.WriteLine();

Console.WriteLine("  Q2 — Singleton                     " );
Console.WriteLine();

var printer1 = PrinterManager.Instance;   
var printer2 = PrinterManager.Instance;  
var printer3 = PrinterManager.Instance;   

printer1.PrintDocument("Report.pdf");
printer2.PrintDocument("Invoice.docx");
printer3.PrintDocument("Contract.pdf");

Console.WriteLine();
Console.WriteLine("Testing if same instance:");
Console.WriteLine($"printer1 == printer2 : {ReferenceEquals(printer1, printer2)}");
Console.WriteLine($"printer1 == printer3 : {ReferenceEquals(printer1, printer3)}");


//  Question 3 
Console.WriteLine();

Console.WriteLine(" Q3 — Builder                        ");

Console.WriteLine();


var gamingPC = new ComputerBuilder()
    .SetProcessor("Intel i9")
    .SetRAM(32)
    .SetStorage(1000)
    .SetGraphicsCard(true)
    .SetOperatingSystem("Windows 11")
    .Build();

Console.WriteLine("--- Gaming Computer ---");
gamingPC.PrintSpecs();

Console.WriteLine();

// Office PC
var officePC = new ComputerBuilder()
    .SetProcessor("Intel i5")
    .SetRAM(8)
    .SetStorage(256)
    .SetGraphicsCard(false)
    .SetOperatingSystem("Windows 10")
    .Build();

Console.WriteLine("--- Office Computer ---");
officePC.PrintSpecs();
