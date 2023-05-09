using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutSystem
{
    internal class InventoryItem
    {
            [JsonProperty("id")]
            public int id { get; set; }
            [JsonProperty("name")]
            public string? name { get; set; }
            [JsonProperty("description")]
            public string? description { get; set; }
            [JsonProperty("cost")]
            public float cost { get; set; }
            [JsonProperty("quantity")]
            public int quantity { get; set; }
    }
}
