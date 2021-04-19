using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPochtaRUApi
{
    public class ResponseRate
    {
        [JsonProperty("avia-rate")]
        public AviaRate aviaRate { get; set; }

        [JsonProperty("completeness-checking-rate")]
        public CompletenessCheckingRate completenessCheckingRate { get; set; }

        [JsonProperty("delivery-time")]
        public DeliveryTime deliveryTime { get; set; }

        [JsonProperty("fragile-rate")]
        public FragileRate fragileRate { get; set; }

        [JsonProperty("ground-rate")]
        public GroundRate groundRate { get; set; }

        [JsonProperty("insurance-rate")]
        public InsuranceRate insuranceRate { get; set; }

        [JsonProperty("notice-payment-method")]
        public string NoticePaymentMethod { get; set; }

        [JsonProperty("notice-rate")]
        public NoticeRate noticeRate { get; set; }

        [JsonProperty("oversize-rate")]
        public OversizeRate oversizeRate { get; set; }

        [JsonProperty("payment-method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("sms-notice-recipient-rate")]
        public SmsNoticeRecipientRate smsNoticeRecipientRate { get; set; }

        [JsonProperty("total-rate")]
        public int TotalRate { get; set; }

        [JsonProperty("total-vat")]
        public int TotalVat { get; set; }

        public class AviaRate
        {
            public int rate { get; set; }
            public int vat { get; set; }
        }

        public class CompletenessCheckingRate
        {
            public int rate { get; set; }
            public int vat { get; set; }
        }

        public class DeliveryTime
        {
            [JsonProperty("max-days")]
            public int MaxDays { get; set; }

            [JsonProperty("min-days")]
            public int MinDays { get; set; }
        }

        public class FragileRate
        {
            public int rate { get; set; }
            public int vat { get; set; }
        }

        public class GroundRate
        {
            public int rate { get; set; }
            public int vat { get; set; }
        }

        public class InsuranceRate
        {
            public int rate { get; set; }
            public int vat { get; set; }
        }

        public class NoticeRate
        {
            public int rate { get; set; }
            public int vat { get; set; }
        }

        public class OversizeRate
        {
            public int rate { get; set; }
            public int vat { get; set; }
        }

        public class SmsNoticeRecipientRate
        {
            public int rate { get; set; }
            public int vat { get; set; }
        }
    }
}
