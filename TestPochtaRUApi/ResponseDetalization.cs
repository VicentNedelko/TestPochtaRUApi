using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPochtaRUApi
{
    public class ResponseDetalization
    {
        [JsonProperty("address-guid")]
        public string AddressGuid { get; set; }

        [JsonProperty("address-type")]
        public string AddressType { get; set; }
        public string house { get; set; }
        public string id { get; set; }
        public string index { get; set; }

        [JsonProperty("original-address")]
        public string OriginalAddress { get; set; }
        public string place { get; set; }

        [JsonProperty("place-guid")]
        public string PlaceGuid { get; set; }

        [JsonProperty("quality-code")]
        public string QualityCode { get; set; }
        public string region { get; set; }

        [JsonProperty("region-guid")]
        public string RegionGuid { get; set; }
        public string street { get; set; }

        [JsonProperty("street-guid")]
        public string StreetGuid { get; set; }

        [JsonProperty("validation-code")]
        public string ValidationCode { get; set; }
        public string room { get; set; }
    }
}
