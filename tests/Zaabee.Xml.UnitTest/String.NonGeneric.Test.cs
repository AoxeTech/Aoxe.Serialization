using System;
using TestModels;
using Xunit;

namespace Zaabee.Xml.UnitTest
{
    public partial class XmlUnitTest
    {
        [Fact]
        public void StringNonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = TestModelFactory.Create();
            var xml = testModel.ToXml(type);
            var result = (TestModel) xml.FromXml(type);
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));

            string str = null;
            Assert.Null(str.FromXml(typeof(TestModel)));
        }
    }
}