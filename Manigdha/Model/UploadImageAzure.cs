using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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

        public async Task<string> UploadImage(Stream stream)
        {
            var fileName =  StaticInfo.GenerateRandomString(20, StaticInfo.UploadImageType.ImageVerification);
            blob = container.GetBlobClient(fileName + ".jpg");
            
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
            BlobClient blobClient = blobServiceClient.GetBlobContainerClient(bloblContainerName).GetBlobClient(fileName + ".jpg");


            // Get the file path of the blob.
            var path = blobClient.Uri.AbsoluteUri;

            return path;

        }
    }
}
