namespace CodeTimer.Runner;

public partial class Runner
{
     public void ToText(int iteration)
     {
          Console.WriteLine("ToText go!");

          Zaabee.CodeTimer.CodeTimer.Initialize();

          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
               () => DataContractHelper.ToXml(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
               () => JilHelper.ToJson(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
               () => NewtonsoftJsonHelper.ToJson(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper", iteration,
               () => SharpYamlHelper.ToYaml(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
               () => SystemTextJsonHelper.ToJson(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
               () => Utf8JsonHelper.ToJson(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
               () => XmlHelper.ToXml(_testModel)));
          Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper", iteration,
               () => YamlDotNetHelper.ToYaml(_testModel)));

          Console.WriteLine("\r\nToText complete!\r\n");
     }
}