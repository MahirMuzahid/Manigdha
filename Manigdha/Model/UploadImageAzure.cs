using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.Model
{
    public class UploadImageAzure
    {
        string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=manigdhaimagestorage;AccountKey=qwGujuhIM0bIr2pqrlM/AUg/LKb87AlcOtzFQVBxHKD/+LKNN+6gLr+iAD3GvGJXLsbzsjSlrH1Z+AStmfkc/Q==;EndpointSuffix=core.windows.net";
        string bloblContainerName = "manigdhanondigitalrequitmentimage";
        BlobClient blob;

        public UploadImageAzure()
        {
            var container = new BlobContainerClient(blobStorageConnectionString, bloblContainerName);
            blob = container.GetBlobClient("imageverificationTest");
        }

        public async Task UploadImage(Stream stream)
        {
            try
            {
                await blob.UploadAsync(stream);
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
