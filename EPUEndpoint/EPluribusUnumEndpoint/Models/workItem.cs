using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace EPluribusUnumEndpoint.Models
{
 
    public class WorkItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "imageURI")]
        public string imageURI { get; set; }

        [JsonProperty(PropertyName = "displayQuestion")]
        public string displayQuestion { get; set; }

        [JsonProperty(PropertyName = "payorAddr")]
        public string payorAddr { get; set; }

        [JsonProperty(PropertyName = "payeeAddr")]
        public string payeeAddr { get; set; }

        [JsonProperty(PropertyName = "ethereumTransID")]
        public string ethereumTransID { get; set; }

        [JsonProperty(PropertyName = "friendlyDisplayName")]
        public string friendlyDisplayName { get; set; }

        [JsonProperty(PropertyName = "isComplete")]
        public bool Completed { get; set; }

        [JsonProperty(PropertyName = "answer")]
        public string Answer { get; set; }

    }
}