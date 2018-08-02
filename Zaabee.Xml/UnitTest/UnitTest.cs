using System;
using System.Text;
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
            var xml1 = _testModel.ToXml();
            var deserializeModel1 = xml1.FromXml<TestModel>();

            Assert.Equal(deserializeModel1.Id, _testModel.Id);
            Assert.Equal(deserializeModel1.Age, _testModel.Age);
            Assert.Equal(deserializeModel1.CreateTime, _testModel.CreateTime);
            Assert.Equal(deserializeModel1.Name, _testModel.Name);
            Assert.Equal(deserializeModel1.Gender, _testModel.Gender);

            var xml2 = _testModel.ToXml();
            var deserializeModel2 = xml2.FromXml(typeof(TestModel)) as TestModel;

            Assert.Equal(deserializeModel2.Id, _testModel.Id);
            Assert.Equal(deserializeModel2.Age, _testModel.Age);
            Assert.Equal(deserializeModel2.CreateTime, _testModel.CreateTime);
            Assert.Equal(deserializeModel2.Name, _testModel.Name);
            Assert.Equal(deserializeModel2.Gender, _testModel.Gender);
        }

        [Fact]
        public void ExtensionMethodWithEncodingTest()
        {
            var xml1 = _testModel.ToXml(Encoding.UTF32);
            var deserializeModel1 = xml1.FromXml<TestModel>(Encoding.UTF32);

            Assert.Equal(deserializeModel1.Id, _testModel.Id);
            Assert.Equal(deserializeModel1.Age, _testModel.Age);
            Assert.Equal(deserializeModel1.CreateTime, _testModel.CreateTime);
            Assert.Equal(deserializeModel1.Name, _testModel.Name);
            Assert.Equal(deserializeModel1.Gender, _testModel.Gender);

            var xml2 = _testModel.ToXml(Encoding.UTF32);
            var deserializeModel2 = xml2.FromXml(typeof(TestModel), Encoding.UTF32) as TestModel;

            Assert.Equal(deserializeModel2.Id, _testModel.Id);
            Assert.Equal(deserializeModel2.Age, _testModel.Age);
            Assert.Equal(deserializeModel2.CreateTime, _testModel.CreateTime);
            Assert.Equal(deserializeModel2.Name, _testModel.Name);
            Assert.Equal(deserializeModel2.Gender, _testModel.Gender);
        }
    }
}