namespace Benchmark.Benchmarks.Text;

public class ToXml
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    [Benchmark]
    public void DataContractToText() => DataContractHelper.ToXml(_testModel);

    [Benchmark]
    public void XmlToText() => XmlHelper.ToXml(_testModel);
}