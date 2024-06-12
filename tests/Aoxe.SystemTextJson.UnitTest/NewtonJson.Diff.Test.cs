namespace Aoxe.SystemTextJson.UnitTest;

public class TestNewtonJsonDiff
{
    private readonly JsonSerializerOptions _jsonSerializerOptions =
        new() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

    [Fact]
    [Description("测试数字序列化")]
    public void TestNumber()
    {
        object jsonObject = new { number = 123.456 };
        var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
        var bJsonString = SystemTextJsonHelper.ToJson(jsonObject, _jsonSerializerOptions);

        Assert.Equal(aJsonString, bJsonString);
    }

    [Fact]
    [Description("测试英文序列化")]
    public void TestEnglish()
    {
        object jsonObject = new { English = "bla bla" };
        var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
        var bJsonString = SystemTextJsonHelper.ToJson(jsonObject, _jsonSerializerOptions);

        Assert.Equal(aJsonString, bJsonString);
    }

    [Fact]
    [Description("测试中文序列化")]
    public void TestChinese()
    {
        object jsonObject = new { chinese = "灰长标准的布咚发" };
        var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
        var bJsonString = SystemTextJsonHelper.ToJson(jsonObject, _jsonSerializerOptions);

        Assert.Equal(aJsonString, bJsonString);
    }

    [Fact]
    [Description("测试英文符号")]
    public void TestEnglishSymbol()
    {
        object jsonObject = new { symbol = @"~`!@#$%^&*()_-+={}[]:;'<>,.?/ " };
        var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
        var bJsonString = SystemTextJsonHelper.ToJson(jsonObject, _jsonSerializerOptions);

        Assert.Equal(aJsonString, bJsonString);
    }

    [Fact]
    [Description("测试中文符号")]
    public void TestChineseSymbol()
    {
        object jsonObject = new { chinese_symbol = @"~·@#￥%……&*（）—-+=｛｝【】；：“”‘’《》，。？、" };
        var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
        var bJsonString = SystemTextJsonHelper.ToJson(jsonObject, _jsonSerializerOptions);

        Assert.Equal(aJsonString, bJsonString);
    }

    [Fact]
    [Description("测试反序列化数值字符串隐式转换为数值类型")]
    public void TestDeserializeNumber()
    {
        const string jsonString = "{\"Number\":\"123\"}";

        Newtonsoft.Json.JsonConvert.DeserializeObject<TestClass>(jsonString);

        // 报错，The JSON value could not be converted to System.Int32. Path: $.number | LineNumber: 0 | BytePositionInLine: 15
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TestClass>(jsonString));
    }

    public class TestClass
    {
        public int Number { get; set; }
    }
}
