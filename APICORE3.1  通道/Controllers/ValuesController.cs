using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APICore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //https://localhost:44393/api/Values/get
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

      //  https://localhost:44393/api/Values/Get2?id=55555
        // GET api/values/5
       // [HttpGet("{id}")] 这种有问题
        [HttpGet]
        public ActionResult<string> Get2(string id)
        {
           return "我的第一个程序：  " +id.ToString();
         
        }
        [HttpGet]
        public string Get3()
        {
            return "测试！！！！！！！！！！";
        }
        //[HttpGet]
        //public HttpResponseMessage Get4()
        //{
        //    test test = new test();
        //    test.a = "这是";
        //    test.b = "我的";
        //    test.c = "第一次";
        //    List<test> tt = new List<test>();
        //    tt.Add(test);
        //    string aa = JsonConvert.SerializeObject(tt);

        //    return GetResponseMessage(aa);

        //}
        [HttpGet]
        public string  Get5()
        {
            test test = new test();
            test.a = "这是";
            test.b = "我的";
            test.c = "第一次";
            List<test> tt = new List<test>();
            tt.Add(test);
            string aa = JsonConvert.SerializeObject(tt);

            return aa;

        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        public System.Text.Json.JsonValueKind ValueKind { get; }
        // https://localhost:44393/api/Values/Put
        [HttpPost]
        public HttpResponseMessage Put(dynamic jObject)
        {//[HttpPost("ValueKind")]
         //https://localhost:44393/api/Values/Put/ValueKind

            //请求地址：https://localhost:44393/api/Values/Put
            //请求内容 { "DeviceType": "LP","data": [{"PRODUCT_TYPE": "P", "PRODUCT_NUMBER": "test001"   }]}
            //得到内容：：：：：ValueKind = Object : "{ "DeviceType": "LP","data": [{"PRODUCT_TYPE": "P", "PRODUCT_NUMBER": "test001"   }]}
            string result = string.Empty;
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(jObject);//JSON 文档转为 JSON串
                string DeviceType2 = "";
                //方法1
                using JsonDocument jsondocument = JsonDocument.Parse(json);
                JsonElement jsonElement = jsondocument.RootElement;
                JsonElement DeviceType0 = jsonElement.GetProperty("DeviceType");
                //方法2
                dynamic DYC = JsonConvert.DeserializeObject<dynamic>(json); //解析JSON
                if (DYC.ContainsKey("DeviceType"))
                {
                    //子方法1
                    var DeviceType1 = DYC.DeviceType.ToString();
                    //子方法1
                     DeviceType2 = DYC["DeviceType"].ToString();
                }
                
                test test = new test();


                switch (DeviceType2)
                {
                    case "SMT":
                        result = json.ToString();
                        break;
                    case "LP":
                        test test1 = new test();
                        test1.a = "aa";
                        test1.b = "bb";
                        test1.c = "cc";
                        result = JsonConvert.SerializeObject(test1);
                        break;
                    case "SPP":
                        result = json.ToString();
                        break;
                    case "AUTO":
                        result = json.ToString();
                        break;
                    default:
                        break;
                }
                //https://blog.csdn.net/qq_38890412/article/details/94314281
                //再newget 里面获取  ：Microsoft.AspNetCore.Mvc.WebApiCompatShim
                //再Startup 添加   services.AddMvc().AddWebApiConventions();
                return GetResponseMessage(result);
            }
            catch (Exception ex)
            {
               
                return GetResponseMessage(JsonConvert.SerializeObject(result));
            }


        }
       
        public static HttpResponseMessage GetResponseMessage(string jsonContent)
        {
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(jsonContent, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

       

    }
    public class test
    {
        public string  a { get; set; }
        public string b { get; set; }
        public string c { get; set; }

    }
   
}
