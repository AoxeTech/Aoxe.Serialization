namespace CodeTimer.Cases;

public partial class Case
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

        Runner.Initialize();

        Console.WriteLine(
            Runner.Time(
                "DataContractHelper FromText",
                iteration,
                () => DataContractHelper.FromXml<TestModel>(dataContractXml)
            )
        );
        Console.WriteLine(
            Runner.Time(
                "JilHelper FromText",
                iteration,
                () => JilHelper.FromJson<TestModel>(jilJson)
            )
        );
        Console.WriteLine(
            Runner.Time(
                "NewtonsoftJsonHelper FromText",
                iteration,
                () => NewtonsoftJsonHelper.FromJson<TestModel>(newtonsoftJsonJson)
            )
        );
        Console.WriteLine(
            Runner.Time(
                "SharpYamlHelper FromText",
                iteration,
                () => SharpYamlHelper.FromYaml<TestModel>(sharpYamlText)
            )
        );
        Console.WriteLine(
            Runner.Time(
                "SystemTextJsonHelper FromText",
                iteration,
                () => SystemTextJsonHelper.FromJson<TestModel>(systemTextJsonJson)
            )
        );
        Console.WriteLine(
            Runner.Time(
                "Utf8JsonHelper FromText",
                iteration,
                () => Utf8JsonHelper.FromJson<TestModel>(utf8JsonJson)
            )
        );
        Console.WriteLine(
            Runner.Time("XmlHelper FromText", iteration, () => XmlHelper.FromXml<TestModel>(xml))
        );
        Console.WriteLine(
            Runner.Time(
                "YamlDotNetHelper FromText",
                iteration,
                () => YamlDotNetHelper.FromYaml<TestModel>(yamlDotNetText)
            )
        );

        Console.WriteLine("\r\nFromText complete!\r\n");
    }
}
