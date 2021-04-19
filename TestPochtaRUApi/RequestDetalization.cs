using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPochtaRUApi
{
    public class RequestDetalization
    {
        public string id { get; set; }

        [JsonProperty("original-address")]
        public string OriginalAddress { get; set; }
    }
}
