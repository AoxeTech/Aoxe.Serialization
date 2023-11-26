namespace Benchmark.Benchmarks.Text;

public class FromXml
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    private readonly string _dataContract;
    private readonly string _xml;

    public FromXml()
    {
        _dataContract = DataContractHelper.ToXml(_testModel);
        _xml = XmlHelper.ToXml(_testModel);
    }

    [Benchmark]
    public void DataContractFromText() => DataContractHelper.FromXml<TestModel>(_dataContract);

    [Benchmark]
    public void XmlFromText() => XmlHelper.FromXml<TestModel>(_xml);
}
