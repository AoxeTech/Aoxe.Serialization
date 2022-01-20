namespace CodeTimer.Runner;

public partial class Runner
{
     public void ToText(int iteration)
     {
          Console.WriteLine("ToText go!");

          Zaabee.CodeTimer.CodeTimer.Initialize();

          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper ToText", iteration,
               () => DataContractHelper.ToXml(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper ToText", iteration,
               () => JilHelper.ToJson(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper ToText", iteration,
               () => NewtonsoftJsonHelper.ToJson(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper ToText", iteration,
               () => SharpYamlHelper.ToYaml(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper ToText", iteration,
               () => SystemTextJsonHelper.ToJson(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper ToText", iteration,
               () => Utf8JsonHelper.ToJson(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("XmlHelper ToText", iteration,
               () => XmlHelper.ToXml(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper ToText", iteration,
               () => YamlDotNetHelper.ToYaml(_testModel)));

          Console.WriteLine("\r\nToText complete!\r\n");
     }
}