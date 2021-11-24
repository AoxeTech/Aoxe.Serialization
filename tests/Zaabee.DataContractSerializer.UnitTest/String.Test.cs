using System;
using TestModels;
using Xunit;

namespace Zaabee.DataContractSerializer.UnitTest
{
    public partial class XmlUnitTest
    {
        [Fact]
        public void StringTest()
        {
            var testModel = TestModelFactory.Create();
            var xml = testModel.ToXml();
            var result = xml.FromXml<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }
    }
}