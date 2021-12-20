namespace CodeTimer.Runner;

public partial class Runner
{
    public void FromText(int iteration)
    {
        var dataContractXml = DataContractHelper.ToXml(_testModel);
        var jilJson = JilHelper.ToJson(_testModel);
        var newtonsoftJsonJson = NewtonsoftJsonHelper.ToJson(_testModel);
        var systemTextJsonJson = SystemTextJsonHelper.ToJson(_testModel);
        var utf8JsonJson = Utf8JsonHelper.ToJson(_testModel);
        var xml = XmlHelper.ToXml(_testModel);
        
        Console.WriteLine("FromText go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.FromXml<TestModel>(dataContractXml));
        Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.FromJson<TestModel>(jilJson));
        Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.FromJson<TestModel>(newtonsoftJsonJson));
        Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.FromJson<TestModel>(systemTextJsonJson));
        Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.FromJson<TestModel>(utf8JsonJson));
        Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.FromXml<TestModel>(xml));
        
        Console.WriteLine("FromText complete!");
    }
}