using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Class1
    {
        [Test]
        public void HttpClient1()
        {
            // Create http client
            HttpClient hc = new HttpClient();

            string getUrl = "website";
            
            hc.Dispose();// close the connection
        }
    }
}
