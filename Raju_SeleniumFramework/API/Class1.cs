using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    [TestFixture]
    public class RestSharp
    {
        [Test]
        public void HttpClient1()
        {
            // Create http client
            RestClient client = new RestClient("http://localhost:3000/");

            RestRequest restRequest = new RestRequest("posts/{postid}", Method.GET);
            restRequest.AddUrlSegment("postid", 1);

            var content = client.Execute(restRequest).Content;

            Console.WriteLine(content);
            
            //hc.Dispose();// close the connection
        }
        [Test]
        public void HttpClient2()
        {
            // Create http client
            RestClient client = new RestClient("http://localhost:3000/");

            RestRequest restRequest = new RestRequest("posts/{postid}", Method.GET);
            restRequest.AddUrlSegment("postid", 1);

            var response = client.Execute(restRequest);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["author"];
            Assert.That(result, Is.EqualTo("Karthik"), "Author is not correct");

            // JObject obs = JObject.Parse(response.Content);
            //  Assert.That(obs["author"].ToString(), Is.EqualTo("Karthik"),"Author is not correct");
        }
    }
}
