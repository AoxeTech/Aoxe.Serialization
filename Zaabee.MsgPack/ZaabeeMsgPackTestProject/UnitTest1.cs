using System;
using Xunit;
using Zaabee.MsgPack;

namespace ZaabeeMsgPackTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            var testModel = GetTestModel();
            var bytes = testModel.ToMsgPack();
            var result = bytes.FromMsgPak<TestModel>();

            Assert.Equal(testModel.Id, result.Id);
            Assert.Equal(testModel.Age, result.Age);
            Assert.Equal(testModel.CreateTime, result.CreateTime);
            Assert.Equal(testModel.Name, result.Name);
            Assert.Equal(testModel.Gender, result.Gender);
        }

        private TestModel GetTestModel()
        {
            return new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1).ToUniversalTime(),
                Name = "apple",
                Gender = Gender.Female
            };
        }
    }
}