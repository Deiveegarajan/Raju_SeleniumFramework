using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API.GetEndPoint
{
    [TestFixture]
    public class TestClassEndPoint
    {
        private string getUrl = "https://openweathermap.org/current";
        [Test]
        public void GetAllEndPoint()
        {
            HttpClient hc = new HttpClient();
            hc.GetAsync(getUrl); // Type 1

            Uri getUri = new Uri(getUrl); // Type 2
            //Close the connection
            hc.Dispose();
        }

        [Test]
        public void GetAllEndPointWithUrl()
        {
            //Create HTTP Client
            HttpClient hc = new HttpClient();
            Task<HttpResponseMessage> httpResponse = hc.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code : {0}",statusCode);
            Console.WriteLine("Status Code : {0}", (int)statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            //Close the connection
            hc.Dispose();
        }
        [Test]
        public void GetAllEndPointWithInvalidUrl()
        {
            //Create HTTP Client
            HttpClient hc = new HttpClient();
            Task<HttpResponseMessage> httpResponse = hc.GetAsync(getUrl +"/");
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code : {0}", statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            //Close the connection
            hc.Dispose();
        }
        [Test]
        public void GetAllEndPontInJsonFormat()
        {
            //Create HTTP Client
            HttpClient hc = new HttpClient();
            HttpRequestHeaders requestHeader = hc.DefaultRequestHeaders;
            requestHeader.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponse = hc.GetAsync(getUrl + "/");
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code : {0}", statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);
        }

        [Test]
        [TestCase("application/xml")]
        [TestCase("application/Json")]
        public void GetAllEndPontInXmlAndJsonFormat(string outputFormat)
        {
            //Create HTTP Client
            HttpClient hc = new HttpClient();
            HttpRequestHeaders requestHeader = hc.DefaultRequestHeaders;

            //Type 1
            requestHeader.Add("Accept",outputFormat);

            //Type 2
            //MediaTypeHeaderValue jsonHeader = new MediaTypeHeaderValue(outputFormat);
            //requestHeader.Accept.Add(jsonHeader);

            Task<HttpResponseMessage> httpResponse = hc.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code : {0}", statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);
        }

        [Test]
        public void GetEndPointUsingSendAsync()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "applicaton/GetAllEndPontInJsonFormat");

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code : {0}", statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);
        }

        [Test]
        //reference will be applicable for only within using statement
        public void GetEndPointUsingStatement()
        {
            // No need to use diposal, framework will handle it
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "applicaton/GetAllEndPontInJsonFormat");

                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        //Status Code
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        //Console.WriteLine("Status Code : {0}", statusCode);


                        //Response Data
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        //Console.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, data);
                        Console.WriteLine(restResponse.ToString());
                    }
                }
            }            
        }
    }
}
