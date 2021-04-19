using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPochtaRUApi
{
    public class RequestRate
    {
        [JsonProperty("completeness-checking")]
        public bool CompletenessChecking { get; set; } = false;
        public bool courier { get; set; } = true;

        [JsonProperty("declared-value")]
        public int DeclaredValue { get; set; } = 1500;
        public Dimension dimension { get; set; }

        [JsonProperty("entries-type")]
        public string EntriesType { get; set; } = "SALE_OF_GOODS";
        public bool fragile { get; set; } = false;

        [JsonProperty("index-from")]
        public string IndexFrom { get; set; } = "109052";

        [JsonProperty("index-to")]
        public string IndexTo { get; set; } = "214000";

        [JsonProperty("mail-category")]
        public string MailCategory { get; set; } = "WITH_DECLARED_VALUE";

        [JsonProperty("mail-direct")]
        public int MailDirect { get; set; } = 643;

        [JsonProperty("mail-type")]
        public string MailType { get; set; } = "EMS";
        public int mass { get; set; } = 500;

        [JsonProperty("notice-payment-method")]
        public string NoticePaymentMethod { get; set; } = "CASHLESS";

        [JsonProperty("payment-method")]
        public string PaymentMethod { get; set; } = "CASHLESS";

        [JsonProperty("sms-notice-recipient")]
        public int SmsNoticeRecipient { get; set; } = 0;

        [JsonProperty("transport-type")]
        public string TransportType { get; set; } = "SURFACE";

        [JsonProperty("with-order-of-notice")]
        public bool WithOrderOfNotice { get; set; } = true;

        [JsonProperty("with-simple-notice")]
        public bool WithSimpleNotice { get; set; } = true;

        public class Dimension
        {
            public int height { get; set; } = 50;
            public int length { get; set; } = 30;
            public int width { get; set; } = 20;
        }
    }
}
