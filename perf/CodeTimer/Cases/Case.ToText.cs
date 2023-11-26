namespace CodeTimer.Cases;

public partial class Case
{
    public void ToText(int iteration)
    {
        Console.WriteLine("ToText go!");

        Runner.Initialize();

        Console.WriteLine(
            Runner.Time(
                "DataContractHelper ToText",
                iteration,
                () => DataContractHelper.ToXml(_testModel)
            )
        );
        Console.WriteLine(
            Runner.Time("JilHelper ToText", iteration, () => JilHelper.ToJson(_testModel))
        );
        Console.WriteLine(
            Runner.Time(
                "NewtonsoftJsonHelper ToText",
                iteration,
                () => NewtonsoftJsonHelper.ToJson(_testModel)
            )
        );
        Console.WriteLine(
            Runner.Time(
                "SharpYamlHelper ToText",
                iteration,
                () => SharpYamlHelper.ToYaml(_testModel)
            )
        );
        Console.WriteLine(
            Runner.Time(
                "SystemTextJsonHelper ToText",
                iteration,
                () => SystemTextJsonHelper.ToJson(_testModel)
            )
        );
        Console.WriteLine(
            Runner.Time("Utf8JsonHelper ToText", iteration, () => Utf8JsonHelper.ToJson(_testModel))
        );
        Console.WriteLine(
            Runner.Time("XmlHelper ToText", iteration, () => XmlHelper.ToXml(_testModel))
        );
        Console.WriteLine(
            Runner.Time(
                "YamlDotNetHelper ToText",
                iteration,
                () => YamlDotNetHelper.ToYaml(_testModel)
            )
        );

        Console.WriteLine("\r\nToText complete!\r\n");
    }
}
