using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Manigdha.Model;
using Manigdha.Model.StaticFolder;
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
        ImageSource frontImageURl;
        [ObservableProperty]
        string backImageURl;
        [ObservableProperty]
        string upperImageURl;
        [ObservableProperty]
        string lowerImageURl;
        [ObservableProperty]
        string leftImageURl;
        [ObservableProperty]
        string rightImageURl;

        [RelayCommand]
        public async Task ExecuteTakingPhot(string index)
        {
            int i = int.Parse(index);
            if (i == 1) 
            { 
                StaticAddProductImage.FrontSideImageURL = await TakePhoto();
                //FrontImageURl = ImageSource.FromStream(() => StaticAddProductImage.FrontSideImageURL).ToString(); 
            }
            if (i == 2) { StaticAddProductImage.BackSideImageURL = await TakePhoto(); }
            if (i == 3) { StaticAddProductImage.UpperSideImageURL = await TakePhoto(); }
            if (i == 4) { StaticAddProductImage.LowerSideImageURL = await TakePhoto(); }
            if (i == 5) { StaticAddProductImage.LaftSideImageURL = await TakePhoto(); }
            if (i == 6) { StaticAddProductImage.RightSideImageURL = await TakePhoto(); }

           
        }
        public async Task<Stream> TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);


                    Stream sourceStream = await photo.OpenReadAsync();
                    FrontImageURl = ImageSource.FromStream(() => sourceStream);
                    return sourceStream;


                }
                return null;
            }
            return null;
        }
    }
}
