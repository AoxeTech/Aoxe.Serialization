namespace CodeTimer.Runner;

public partial class Runner
{
    public void FromText(int iteration)
    {
        var dataContractXml = DataContractHelper.ToXml(_testModel);
        var jilJson = JilHelper.ToJson(_testModel);
        var newtonsoftJsonJson = NewtonsoftJsonHelper.ToJson(_testModel);
        var sharpYamlText = SharpYamlHelper.ToYaml(_testModel);
        var systemTextJsonJson = SystemTextJsonHelper.ToJson(_testModel);
        var utf8JsonJson = Utf8JsonHelper.ToJson(_testModel);
        var xml = XmlHelper.ToXml(_testModel);
        var yamlDotNetText = YamlDotNetHelper.ToYaml(_testModel);

        Console.WriteLine("FromText go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper FromText", iteration,
            () => DataContractHelper.FromXml<TestModel>(dataContractXml)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper FromText", iteration,
            () => JilHelper.FromJson<TestModel>(jilJson)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper FromText", iteration,
            () => NewtonsoftJsonHelper.FromJson<TestModel>(newtonsoftJsonJson)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper FromText", iteration,
            () => SharpYamlHelper.FromYaml<TestModel>(sharpYamlText)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper FromText", iteration,
            () => SystemTextJsonHelper.FromJson<TestModel>(systemTextJsonJson)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper FromText", iteration,
            () => Utf8JsonHelper.FromJson<TestModel>(utf8JsonJson)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("XmlHelper FromText", iteration,
            () => XmlHelper.FromXml<TestModel>(xml)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper FromText", iteration,
            () => YamlDotNetHelper.FromYaml<TestModel>(yamlDotNetText)));

        Console.WriteLine("\r\nFromText complete!\r\n");
    }
}