namespace Datatable.UnitTest;

public class UnitTest1
{
    [Fact]
    public void DatatableJsonTest()
    {
        var models = TestModelHelper.Create(100);
        var dt = models.ConvertToDataTable();
        var json = NewtonsoftJsonHelper.ToJson(dt);
        var results = NewtonsoftJsonHelper.FromJson<List<TestModel>>(json)!;
        Assert.True(TestModelHelper.CompareTestModels(models, results));
    }
}