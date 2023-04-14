using Azure.Storage.Blobs;

namespace PostService.UploadImage
{
    public class UploadImageInAzure
    {
        string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=manigdhaimagestorage;AccountKey=qwGujuhIM0bIr2pqrlM/AUg/LKb87AlcOtzFQVBxHKD/+LKNN+6gLr+iAD3GvGJXLsbzsjSlrH1Z+AStmfkc/Q==;EndpointSuffix=core.windows.net";
        string bloblContainerName = "manigdhanondigitalrequitmentimage";
        BlobClient blob;

        public UploadImageInAzure()
        {
            var container = new BlobContainerClient(blobStorageConnectionString, bloblContainerName);
            blob = container.GetBlobClient("");         
        }

        public async Task UploadImage()
        {
            var stream = File.OpenRead(blobStorageConnectionString);
            await blob.UploadAsync(stream);  
        }

        
    }
}
