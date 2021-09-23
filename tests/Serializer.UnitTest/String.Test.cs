using System;
using TestModels;
using Xunit;
using Zaabee.Serializer.Abstractions;

namespace Serializer.UnitTest
{
    public partial class SerializerTest
    {
        [Fact]
        public void JilStringTest() =>
            StringTest(new Zaabee.Jil.ZaabeeSerializer());

        [Fact]
        public void NewtonsoftJsonStringTest() =>
            StringTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

        [Fact]
        public void SystemTextJsonStringTest() =>
            StringTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

        [Fact]
        public void Utf8JsonStringTest() =>
            StringTest(new Zaabee.Utf8Json.ZaabeeSerializer());

        [Fact]
        public void XmlStringTest() =>
            StringTest(new Zaabee.Xml.ZaabeeSerializer());

        private static void StringTest(ITextSerializer serializer)
        {
            var model = TestModelFactory.Create();
            var bytes = serializer.SerializeToString(model);
            var deserializeModel = serializer.DeserializeFromString<TestModel>(bytes);

            Assert.Equal(
                Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
                Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                    deserializeModel.Name, deserializeModel.Gender));
        }
    }
}