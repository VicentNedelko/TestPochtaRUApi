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

            var builder = new UriBuilder("https://otpravka-api.pochta.ru/postoffice/1.0/by-address")
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
            Console.WriteLine($"postoffices = {index.postoffices.Count}");
            if(index.postoffices != null)
            {
                foreach(var p in index.postoffices)
                {
                    Console.WriteLine($"index = {p}");
                }
            }

            //

            var addressToDetailed_1 = new RequestDetalization
            {
                id = "adr 1",
                OriginalAddress = "Загородное ш., 7а, Москва",
            };

            var addressToDetailed_2 = new RequestDetalization
            {
                id = "adr 2",
                OriginalAddress = "г. Новосибирск, ул. Жуковского, 100/4",
            };

            var listAddresses = new List<RequestDetalization>();
            listAddresses.Add(addressToDetailed_1);

            var serializedRequest = JsonConvert.SerializeObject(listAddresses);
            var content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            var requestDetailes = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://otpravka-api.pochta.ru/1.0/clean/address"),
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
            Console.ReadKey();
        }

    }
}
