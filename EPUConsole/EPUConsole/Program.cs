using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EPUConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkItem wi = new WorkItem() { displayQuestion = "testQuestion", ethereumTransID = "ethtransferID", friendlyDisplayName = "FrendlyDisplayName",
                Id = "id", imageURI = "ImageURI", payeeAddr = "PayeeAddr", payorAddr = "PayorAddr"
            };

            string question = Properties.Settings.Default.displayQuestion;
            //string json = Utilities.EmitJSONDoc(wi);

            //AzureBlobWork abw = new AzureBlobWork();
            //abw.GetBlobList();

            Program p = new Program();
            var myList = p.GetBlobsAndWrapInWokrItem(question);
            var jsonList = Utilities.GetJSONWorkItemList(myList);

            //Now add to CosmosDB
            DocumentDBRepository<WorkItem>.Initialize();
            foreach(var item in myList)
            {
                DocumentDBRepository<WorkItem>.CreateItemAsync(item).Wait();
            }
        }

        public List<WorkItem> GetBlobsAndWrapInWokrItem(string question)
        {
            //First get a list of unclassified work items
            AzureBlobWork awb = new AzureBlobWork();
            List<string> uris = awb.GetBlobList();
            List<WorkItem> workItems = new List<WorkItem>();

            foreach(var item in uris)
            {
                var wi = new WorkItem() { imageURI = item, displayQuestion = question };
                workItems.Add(wi);
            }

            return workItems;
        }
    }
}
