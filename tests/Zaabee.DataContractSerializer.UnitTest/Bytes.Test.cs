using System;
using System.IO;
using System.Xml;
using TestModels;
using Xunit;

namespace Zaabee.DataContractSerializer.UnitTest
{
    public partial class XmlUnitTest
    {
        [Fact]
        public void BytesTest()
        {
            var testModel = TestModelFactory.Create();
            var bytes = testModel.ToBytes();
            var result = bytes.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
            
            Assert.Empty(DataContractHelper.ToBytes(typeof(TestModel),null));
            Assert.Null(DataContractHelper.FromBytes<TestModel>((byte[])null));
            Assert.Null(DataContractHelper.Deserialize<TestModel>((XmlReader)null));
        }
    }
}