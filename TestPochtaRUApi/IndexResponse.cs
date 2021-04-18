using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPochtaRUApi
{
    public class IndexResponse
    {
        [JsonProperty("is-matched")]
        public bool IsMatched { get; set; }
        public List<string> postoffices { get; set; }
    }
}
