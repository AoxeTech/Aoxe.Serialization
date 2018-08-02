using System;
using Xunit;
using Zaabee.Xml;

namespace UnitTest
{
    public class UnitTest
    {
        private static TestModel _testModel;

        public UnitTest()
        {
            _testModel = new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1),
                Name = "banana",
                Gender = Gender.Female
            };
        }
        
        [Fact]
        public void ExtensionMethodTest()
        {
            var xml = _testModel.ToXml();
            var deserializeModel = xml.FromXml<TestModel>();

            Assert.Equal(deserializeModel.Id, _testModel.Id);
            Assert.Equal(deserializeModel.Age, _testModel.Age);
            Assert.Equal(deserializeModel.CreateTime, _testModel.CreateTime);
            Assert.Equal(deserializeModel.Name, _testModel.Name);
            Assert.Equal(deserializeModel.Gender, _testModel.Gender);
        }
    }
}