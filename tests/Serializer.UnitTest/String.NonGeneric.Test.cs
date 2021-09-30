using System;
using TestModels;
using Xunit;
using Zaabee.Serializer.Abstractions;

namespace Serializer.UnitTest
{
    public partial class SerializerTest
    {
        [Fact]
        public void JilStringNonGenericTest() =>
            StringNonGenericTest(new Zaabee.Jil.ZaabeeSerializer());

        [Fact]
        public void NewtonsoftJsonStringNonGenericTest() =>
            StringNonGenericTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

        [Fact]
        public void SystemTextJsonStringNonGenericTest() =>
            StringNonGenericTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

        [Fact]
        public void Utf8JsonStringNonGenericTest() =>
            StringNonGenericTest(new Zaabee.Utf8Json.ZaabeeSerializer());

        [Fact]
        public void XmlStringNonGenericTest() =>
            StringNonGenericTest(new Zaabee.Xml.ZaabeeSerializer());

        private static void StringNonGenericTest(ITextSerializer serializer)
        {
            var model = TestModelFactory.Create();
            var type = typeof(TestModel);
            var bytes = serializer.SerializeToString(type, model);
            var deserializeModel = (TestModel)serializer.DeserializeFromString(type, bytes);

            Assert.Equal(
                Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
                Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                    deserializeModel.Name, deserializeModel.Gender));
        }
    }
}