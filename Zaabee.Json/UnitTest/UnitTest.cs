using System;
using System.Collections.Generic;
using Xunit;
using Zaabee.Json;

namespace UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void ToJson()
        {
            var id = Guid.NewGuid();
            var age = new Random().Next(0, 100);
            var time = DateTime.Now;
            var offset = DateTimeOffset.Now;
            var name = "banana";

            var testModel = new TestModel
            {
                Id = id,
                Age = age,
                CreateTime = time,
                CreateTimeOffset = offset,
                Name = name
            };

            var jsonStr1 = testModel.ToJson();

            var jsonStr2 = testModel.ToJson(new List<string> {"Id", "Name"});

            var jsonStr3 = testModel.ToJson(null, true, "yyyy-MM-dd HH:mm:ss");

            Assert.Equal(jsonStr1,
                $"{{\"Id\":\"{id}\",\"Age\":{age},\"Name\":\"{name}\",\"CreateTime\":\"{time:yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK}\",\"CreateTimeOffset\":\"{offset:yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK}\"}}");
            Assert.Equal(jsonStr2,
                $"{{\"Id\":\"{id}\",\"Name\":\"{name}\"}}");
            Assert.Equal(jsonStr3,
                $"{{\"id\":\"{id}\",\"age\":{age},\"name\":\"{name}\",\"createTime\":\"{time:yyyy-MM-dd HH:mm:ss}\",\"createTimeOffset\":\"{offset:yyyy-MM-dd HH:mm:ss}\"}}");
        }

        [Fact]
        public void FromJson()
        {
            var id = Guid.NewGuid();
            var age = new Random().Next(0, 100);
            var time = DateTime.Now;
            var name = "banana";

            var testModel = new TestModel
            {
                Id = id,
                Age = age,
                CreateTime = time,
                Name = name
            };

            var jsonStr =
                $"{{\"Id\":\"{id}\",\"Age\":{age},\"Name\":\"{name}\",\"CreateTime\":\"{time:yyyy-MM-dd HH:mm:ss}\"}}";
            
            var deserializeModel1 = jsonStr.FromJson<TestModel>();
            var deserializeModel2 = jsonStr.FromJson(typeof(TestModel)) as TestModel;

            Assert.Equal(deserializeModel1.Id, deserializeModel2.Id);
            Assert.Equal(deserializeModel1.Age, deserializeModel2.Age);
            Assert.Equal(deserializeModel1.CreateTime, deserializeModel2.CreateTime);
            Assert.Equal(deserializeModel1.Name, deserializeModel2.Name);
        }

        [Fact]
        public void TestEmail()
        {
            var json =
                "{\"Host\":null,\"Port\":null,\"FromAccount\":null,\"FromPassword\":null,\"FromEmail\":null,\"Attachments\":[{\"Item1\":\"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\",\"Item2\":\"【59883_汪玲芳】客户 电子账单(2018年08月06日 至 2018年08月07日).xlsx\"}],\"ToEmails\":[\"526133624@qq.com\"],\"CcEmails\":[],\"BccEmails\":[],\"Subject\":\"【59883_汪玲芳】客户 电子账单(2018年08月06日 至 2018年08月07日)\",\"Body\":\"<!DOCTYPE html><html lang=\\\"en\\\" xmlns=\\\"http://www.w3.org/1999/xhtml\\\"><head>    <meta charset=\\\"utf-8\\\" />    <title>客户账单报表</title></head><body>    <div id=\\\"dv\\\" style=\\\"width: 1024px;\\\">        <div align=\\\"left\\\">            尊敬的<b>59883_汪玲芳</b> :<br/>            您好，2018年8月6日至2018年8月7日的账单费用总额详情如下，请查阅 !<br/>        </div>        <br/>        <div align=\\\"left\\\">            <table style='border-collapse: collapse;border: solid 1px;border-color: black;width: 700px;text-align: center;vertical-align: middle; '><tr><td colspan='4' style='font-size: 22px;font-weight: bold;text-align: left;padding-top: 5px;padding-bottom: 5px;padding-left: 10px;'> 账户币种  CNY </td></tr><tr style='height: 18px;'><td style='border: solid 1px;border-color: black;font-size: 16px;padding-top: 5px;padding-bottom: 5px;padding-left: 5px;'>扣费 总额 :</td><td style='border: solid 1px;border-color: black;font-size: 16px;padding-top: 5px;padding-bottom: 5px;padding-left: 5px;'>122.75</td><td style='border: solid 1px;border-color: black;font-size: 16px;padding-top: 5px;padding-bottom: 5px;padding-left: 5px;'></td><td style='border: solid 1px;border-color: black;font-size: 16px;padding-top: 5px;padding-bottom: 5px;padding-left: 5px;'></td></tr></table><br>        </div>        <div>            *如您需要查看账单明细，请下载邮件附件。<br />            *注:该邮件服务由【客户账单详情服务】推送，如有疑问，请联系财务员&nbsp;邮件地址:liminhua@flytexpress.com 。        </div></div></body></html>\"}";
            var i = json.FromJson<EmailCommand>();
            var i1 = i.ToEmails.Count;
        }
        
        public class EmailCommand
        {
            private List<Tuple<byte[], string>> _attachments;
            public List<Tuple<byte[], string>> Attachments
            {
                get => _attachments ?? (_attachments = new List<Tuple<byte[], string>>());
                set => _attachments = value;
            }

            private List<string> _toEmails;
            public List<string> ToEmails
            {
                get => _toEmails ?? (_toEmails = new List<string>());
                set => _toEmails = value;
            }

            private List<string> _ccEmails;
            public List<string> CcEmails
            {
                get => _ccEmails ?? (_ccEmails = new List<string>());
                set => _ccEmails = value;
            }

            private List<string> _bccEmails;
            public List<string> BccEmails
            {
                get => _bccEmails ?? (_bccEmails = new List<string>());
                set => _bccEmails = value;
            }
            public string Subject { get; set; }
            public string Body { get; set; }
            public string Version { get; set; }
        }
    }
}