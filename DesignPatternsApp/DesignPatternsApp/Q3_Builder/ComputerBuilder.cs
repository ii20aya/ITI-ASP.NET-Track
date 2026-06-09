namespace DesignPatternsApp.Q3_Builder;

public class ComputerBuilder
{
    // Each builder holds one Computer being assembled
    private readonly Computer _computer = new Computer();

    // Fluent setters — each returns "this" so calls can be chained
    public ComputerBuilder SetProcessor(string processor)
    {
        _computer.Processor = processor;
        return this;
    }

    public ComputerBuilder SetRAM(int ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public ComputerBuilder SetStorage(int storage)
    {
        _computer.Storage = storage;
        return this;
    }

    public ComputerBuilder SetGraphicsCard(bool hasGPU)
    {
        _computer.HasGraphicsCard = hasGPU;
        return this;
    }

    public ComputerBuilder SetOperatingSystem(string os)
    {
        _computer.OperatingSystem = os;
        return this;
    }

    // Final step: returns the fully-built Computer
    public Computer Build() => _computer;
}
