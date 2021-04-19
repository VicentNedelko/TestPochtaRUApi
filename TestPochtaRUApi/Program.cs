using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;

namespace TestPochtaRUApi
{
    class Program
    {
        
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.Write("Enter address : ");
            string address = Console.ReadLine();
            Uri baseURI = new Uri("https://otpravka-api.pochta.ru");
            Uri uri = new Uri(baseURI, "postoffice/1.0/by-address");


            //

            var builder = new UriBuilder(uri)
            {
                Port = -1
            };
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["address"] = address;
            builder.Query = query.ToString();
            string url = builder.ToString();

            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "Authorization", "AccessToken x9nATG1tt3do9ud8QgHcFp2JdyZP8RyL" },
                    { "X-User-Authorization","Basic  eS1rdW5hc2hAeWFuZGV4LnJ1OjFxYXohUUFa" },
                }
            };

            using var response = await client.SendAsync(request);
            var index = JsonConvert.DeserializeObject<IndexResponse>(
                response.Content.ReadAsStringAsync().Result);
            
            if(index.postoffices != null)
            {
                foreach(var p in index.postoffices)
                {
                    Console.WriteLine($"index = {p}");
                }
            }

            //


            var listAddresses = new List<RequestDetalization>
            {
                new RequestDetalization
                {
                    id = "adr 1",
                    OriginalAddress = "Загородное шоссе, 7а, Москва",
                },
                new RequestDetalization
                {
                    id = "adr 2",
                    OriginalAddress = "Москва, корп. 1, Севастопольский пр., 42",
                },
            };

            var serializedRequest = JsonConvert.SerializeObject(listAddresses);
            var content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            var requestDetailes = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseURI, "1.0/clean/address"),
                Headers =
                {
                    { "Authorization", "AccessToken x9nATG1tt3do9ud8QgHcFp2JdyZP8RyL" },
                    { "X-User-Authorization","Basic  eS1rdW5hc2hAeWFuZGV4LnJ1OjFxYXohUUFa" },
                },
                Content = content,
            };

            using var responseDetalization = await client.SendAsync(requestDetailes);
            var detalization = JsonConvert.DeserializeObject<List<ResponseDetalization>>(
                responseDetalization.Content.ReadAsStringAsync().Result);



            //

            var rateRequest = new RequestRate();
            var jsonRate = JsonConvert.SerializeObject(rateRequest);
            var contentRate = new StringContent(jsonRate, Encoding.UTF8, "application/json");

            var requestRate = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseURI, "1.0/tariff"),
                Headers =
                {
                    { "Authorization", "AccessToken x9nATG1tt3do9ud8QgHcFp2JdyZP8RyL" },
                    { "X-User-Authorization","Basic  eS1rdW5hc2hAeWFuZGV4LnJ1OjFxYXohUUFa" },
                },
                Content = contentRate,
            };

            using var responseRate = await client.SendAsync(requestRate);
            var rate = JsonConvert.DeserializeObject<ResponseRate>(
                responseRate.Content.ReadAsStringAsync().Result);
            Console.ReadKey();
        }

    }
}
