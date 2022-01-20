namespace CodeTimer.Runner;

public partial class Runner
{
    public void ToText(int iteration)
    {
        Console.WriteLine("ToText go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.ToXml(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.ToJson(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.ToJson(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper", iteration,
            () => SharpYamlHelper.ToYaml(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.ToJson(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.ToJson(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.ToXml(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper", iteration,
            () => YamlDotNetHelper.ToYaml(_testModel));

        Console.WriteLine("ToText complete!");
    }
}