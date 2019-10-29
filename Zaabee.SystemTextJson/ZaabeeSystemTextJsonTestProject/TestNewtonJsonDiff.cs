using System.ComponentModel;
using Xunit;
using Zaabee.SystemTextJson;

namespace ZaabeeSystemTextJsonTestProject
{
    public class TestNewtonJsonDiff
    {
        public TestNewtonJsonDiff()
        {
            SystemTextJsonHelper.DefaultJsonSerializerOptions =
                new System.Text.Json.JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
        }

        [Fact]
        [Description("测试数字序列化")]
        public void TestNumber()
        {
            object jsonObject = new {number = 123.456};
            var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
            var bJsonString = SystemTextJsonHelper.SerializeToJson(jsonObject);

            Assert.Equal(aJsonString, bJsonString);
        }

        [Fact]
        [Description("测试英文序列化")]
        public void TestEnglish()
        {
            object jsonObject = new {english = "bla bla"};
            var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
            var bJsonString = SystemTextJsonHelper.SerializeToJson(jsonObject);

            Assert.Equal(aJsonString, bJsonString);
        }

        [Fact]
        [Description("测试中文序列化")]
        public void TestChinese()
        {
            object jsonObject = new {chinese = "灰长标准的布咚发"};
            var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
            var bJsonString = SystemTextJsonHelper.SerializeToJson(jsonObject);

            Assert.Equal(aJsonString, bJsonString);
        }

        [Fact]
        [Description("测试英文符号")]
        public void TestEnglishSymbol()
        {
            object jsonObject = new {symbol = @"~`!@#$%^&*()_-+={}[]:;'<>,.?/ "};
            var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
            var bJsonString = SystemTextJsonHelper.SerializeToJson(jsonObject);

            Assert.Equal(aJsonString, bJsonString);
        }

        [Fact]
        [Description("测试中文符号")]
        public void TestChineseSymbol()
        {
            object jsonObject = new {chinese_symbol = @"~·@#￥%……&*（）—-+=｛｝【】；：“”‘’《》，。？、"};
            var aJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
            var bJsonString = SystemTextJsonHelper.SerializeToJson(jsonObject);

            Assert.Equal(aJsonString, bJsonString);
        }

        [Fact]
        [Description("测试反序列化数值字符串隐式转换为数值类型")]
        public void TestDeserializeNumber()
        {
            var ajsonString = "{\"Number\":\"123\"}";

            var aJsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<TestClass>(ajsonString);

            // 报错，The JSON value could not be converted to System.Int32. Path: $.number | LineNumber: 0 | BytePositionInLine: 15
            var bJsonObject =
                System.Text.Json.JsonSerializer.Deserialize<TestClass>(ajsonString);

            Assert.Equal(aJsonObject.Number, bJsonObject.Number);
        }

        public class TestClass
        {
            public int Number { get; set; }
        }
    }
}