using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Manigdha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.ViewModel
{
    public partial class UploadNonDigitalImageRequirmentViewModal: ObservableObject
    {
        [ObservableProperty]
        string imageURl;


        [RelayCommand]
        public async Task TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();

                    UploadImageAzure uploadImageAzure = new UploadImageAzure();

                    ImageURl = await uploadImageAzure.UploadImage(sourceStream);
                }
            }
        }
    }
}
