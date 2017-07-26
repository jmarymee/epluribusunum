using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPUConsole
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

    public class Utilities
    {
        public static string EmitJSONDoc(WorkItem wi)
        {

            return JsonConvert.SerializeObject(wi);
        }

        public static List<string> GetJSONWorkItemList(List<WorkItem> wiList)
        {
            List<string> jsonList = new List<string>();

            foreach(var item in wiList)
            {
                jsonList.Add(JsonConvert.SerializeObject(item));
            }

            return jsonList;
        }
    }

}
