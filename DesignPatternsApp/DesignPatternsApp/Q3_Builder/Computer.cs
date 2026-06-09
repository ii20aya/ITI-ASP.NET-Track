namespace DesignPatternsApp.Q3_Builder;

public class Computer
{
    public string Processor      { get; set; } = "Unknown";
    public int    RAM            { get; set; }
    public int    Storage        { get; set; }
    public bool   HasGraphicsCard{ get; set; }
    public string OperatingSystem{ get; set; } = "Unknown";

    public void PrintSpecs()
    {
        Console.WriteLine($"Processor    : {Processor}");
        Console.WriteLine($"RAM          : {RAM} GB");
        Console.WriteLine($"Storage      : {Storage} GB");
        Console.WriteLine($"Graphics Card: {(HasGraphicsCard ? "Yes" : "No")}");
        Console.WriteLine($"OS           : {OperatingSystem}");
    }
}
