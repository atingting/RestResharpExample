using Communcation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Request<List<Person>> request = new Request<List<Person>>("http://localhost:10414");
            //var result =request.ExecutePostJsonAsync("Home/ResharpPostRequest", new Person{ Name = "ztt1111", Age = 2, WifeName = "hl" }).Result;

            //Request<List<Person>> request3 = new Request<List<Person>>("http://localhost:10414");
            //var result3 = request.ExecutePostJson("Home/ResharpPostRequest", new Person { Name = "ztt1111", Age = 2, WifeName = "hl" });

            //Request<Person> request2 = new Request<Person>("http://localhost:10414");
            //var result2 = request.GetAsync("Home/ResharpGetRequest").Result;

            //Request<List<Person>> request1 = new Request<List<Person>>("http://localhost:10414");
            //var result1 = request.Get("Home/ResharpGetRequest");
            var temp = new { };
            Request<object> request1 = new Request<object>("http://localhost:10414");
            var result1 = request1.Get("Home/ResharpGetRequest");

        }
    }
}
