using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InterviewDemo
{
    public class QueueMessage
    {
        [JsonProperty("order")]
        public Order Order { get; set; }
    }

    public  class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("jobsiteId")]
        public string JobsiteId { get; set; }

        [JsonProperty("problemDescription")]
        public string ProblemDescription { get; set; }

        [JsonProperty("priority")]
        public long Priority { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public  class Item
    {
        [JsonProperty("serialNo")]
        public string SerialNo { get; set; }
    }
}
