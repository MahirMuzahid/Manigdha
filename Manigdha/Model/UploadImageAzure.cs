using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
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
        BlobContainerClient container;
        BlobClient blob;

        public UploadImageAzure()
        {
            container = new BlobContainerClient(blobStorageConnectionString, bloblContainerName);
            
        }

        public async Task UploadImage(Stream stream)
        {
            var fileName =  StaticInfo.GenerateRandomString(20, StaticInfo.UploadImageType.ImageVerification);
            
            blob = container.GetBlobClient(fileName);
            try
            {
                await blob.UploadAsync(stream);
            }
            catch (Exception ex)
            {
                ShowSnakeBar showSnakeBar = new ShowSnakeBar();
                await showSnakeBar.Show(ex.Message, SharedModal.Enums.SnakeBarType.Type.Danger);
            }

            BlobServiceClient blobServiceClient = new BlobServiceClient(blobStorageConnectionString);
            BlobClient blobClient = blobServiceClient.GetBlobContainerClient(bloblContainerName).GetBlobClient(fileName);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(blobStorageConnectionString);

            // Create the blob client.
            CloudBlobClient blobClients = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer containerw = blobClients.GetContainerReference(bloblContainerName);

            // Retrieve reference to a blob with given name.
            CloudBlockBlob blockBlob = containerw.GetBlockBlobReference(fileName);

            // Get the file path of the blob.
            string filePath = blockBlob.Uri.ToString();
            var path = blobClient.Uri.AbsoluteUri;

        }
    }
}
