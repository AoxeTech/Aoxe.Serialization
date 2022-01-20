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

        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.FromXml<TestModel>(dataContractXml)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.FromJson<TestModel>(jilJson)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.FromJson<TestModel>(newtonsoftJsonJson)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper", iteration,
            () => SharpYamlHelper.FromYaml<TestModel>(sharpYamlText)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.FromJson<TestModel>(systemTextJsonJson)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.FromJson<TestModel>(utf8JsonJson)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.FromXml<TestModel>(xml)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper", iteration,
            () => YamlDotNetHelper.FromYaml<TestModel>(yamlDotNetText)));

        Console.WriteLine("\r\nFromText complete!\r\n");
    }
}