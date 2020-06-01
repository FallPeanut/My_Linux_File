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
            return "ceshi";
        }
        [HttpGet]
        public HttpResponseMessage Get4()
        {
            test test = new test();
            test.a = "这是  ";
            test.b = "我的  ";
            test.b = "第一次！  ";
            string aa = JsonConvert.SerializeObject(test);
            return GetResponseMessage(aa);

        }

 
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPost]
        public HttpResponseMessage Put([FromBody]dynamic input)
        {

            string result = string.Empty;
            try
            {
              
                //var a = JsonConvert.DeserializeObject(input);
                string deviceType = input;
                string data = input.data;


               
                switch (deviceType)
                {
                    case "SMT":
                        result = data.ToString();
                        break;
                    case "LP":
                        result = data.ToString();
                        break;
                    case "SPP":
                        result = data.ToString();
                        break;
                    case "AUTO":
                        result = data.ToString();
                        break;
                    default:
                        break;
                }
                //if (string.IsNullOrEmpty(deviceType) || string.IsNullOrWhiteSpace(result))
                //{
                //    return null;
                //}
                //else
                //{
                return GetResponseMessage(result);
                //}
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
