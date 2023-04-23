using Azure.Storage.Blobs;
using Manigdha.Model.StaticFolder;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.Model
{
    public class UploadImageAzure
    {
        private string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=manigdhaimagestorage;AccountKey=qwGujuhIM0bIr2pqrlM/AUg/LKb87AlcOtzFQVBxHKD/+LKNN+6gLr+iAD3GvGJXLsbzsjSlrH1Z+AStmfkc/Q==;EndpointSuffix=core.windows.net";
        private string bloblContainerName = "manigdhanondigitalrequitmentimage";
        private string blobUserphotoImageContainerName = "manigdhauserphotoimage";
        BlobContainerClient container;
        BlobClient blob;

        public UploadImageAzure()
        {
            container = new BlobContainerClient(blobStorageConnectionString, bloblContainerName);
            
        }

        public async Task<string> UploadProductImage(Stream stream)
        {
            var fileName =  StaticInfo.GenerateRandomString(20, StaticInfo.UploadImageType.ImageVerification) + ".jpg";
            blob = container.GetBlobClient(fileName );
            
            try
            {
                await blob.UploadAsync(stream);
            }
            catch (Exception ex)
            {
                ShowSnakeBar showSnakeBar = new ShowSnakeBar();
                await showSnakeBar.Show(ex.Message, SharedModal.Enums.SnakeBarType.Type.Danger);
            }
            return "https://manigdhaimagestorage.blob.core.windows.net/manigdhanondigitalrequitmentimage/" + fileName; 

        }

        public async Task DeleteImage(string fileURL)
        {
            string imageName = fileURL.Split('/').Last();
            blob = container.GetBlobClient(imageName);
            var res = blob.Delete();
            
        }
    }
}
