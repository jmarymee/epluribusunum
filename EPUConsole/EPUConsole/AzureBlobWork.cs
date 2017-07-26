using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPUConsole
{
    class AzureBlobWork
    {
        public List<string> GetBlobList()
        {
            var connStr = Properties.Settings.Default.blobConnStr;
            CloudStorageAccount csa = CloudStorageAccount.Parse(connStr);
            var cloudBlockClient = csa.CreateCloudBlobClient();
            var container = cloudBlockClient.GetContainerReference("imagelabelstore");
            var list = container.ListBlobs(useFlatBlobListing: true);

            var listOfURIs = new List<string>();

            foreach (var blob in list)
            {
                //var blobFileName = blob.Uri.Segments.Last();
                var blobAbsoluteUri = blob.Uri.AbsoluteUri;
                listOfURIs.Add(blobAbsoluteUri);
            }

            return listOfURIs;
        }
    }
}
