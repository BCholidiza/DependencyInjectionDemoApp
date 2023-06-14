namespace DependencyInjectionDemo.Logic;

public class DemoLogic : IDemoLogic
{
    private readonly ILogger<DemoLogic> logger;

    public int Value1 { get; private set; }
    public int Value2 { get; private set; }

    public DemoLogic(ILogger<DemoLogic> logger)
    {
        Value1 = Random.Shared.Next(1, 1001);
        Value2 = Random.Shared.Next(1, 1001);
        this.logger = logger;
    }
}
