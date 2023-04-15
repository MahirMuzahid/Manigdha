using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Manigdha.Model;
using Manigdha.Model.StaticFolder;
using Manigdha.View;
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
        ImageSource backImageURl;
        [ObservableProperty]
        ImageSource upperImageURl;
        [ObservableProperty]
        ImageSource lowerImageURl;
        [ObservableProperty]
        ImageSource leftImageURl;
        [ObservableProperty]
        ImageSource rightImageURl;
        [ObservableProperty]
        string frontImageVerificationStatus;
        [ObservableProperty]
        string backImageVerificationStatus;
        [ObservableProperty]
        string upperImageVerificationStatus;
        [ObservableProperty]
        string lowerImageVerificationStatus;
        [ObservableProperty]
        string leftImageVerificationStatus;
        [ObservableProperty]
        string rightImageVerificationStatus;
        [ObservableProperty]
        string errorText;

        public UploadNonDigitalImageRequirmentViewModal()
        {
            //verified.svg
            //notverified.png
            FrontImageVerificationStatus = "notverified.png";
            BackImageVerificationStatus = "notverified.png";
            UpperImageVerificationStatus = "notverified.png";
            LowerImageVerificationStatus = "notverified.png";
            LeftImageVerificationStatus = "notverified.png";
            RightImageVerificationStatus = "notverified.png";
        }

        [RelayCommand]
        public async Task ExecuteTakingPhot(string index)
        {
            int i = int.Parse(index);

            await TakePhoto(i);

           
        }
        public async Task TakePhoto(int i)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);


                    Stream sourceStream = await photo.OpenReadAsync();
                    if (i == 1) { FrontImageURl = ImageSource.FromStream(() => sourceStream); 
                        StaticAddProductImage.FrontSideImageURL = sourceStream; FrontImageVerificationStatus = "verified.svg";}
                    if (i == 2) { BackImageURl = ImageSource.FromStream(() => sourceStream);  
                        StaticAddProductImage.BackSideImageURL = sourceStream; BackImageVerificationStatus = "verified.svg";}
                    if (i == 3) { UpperImageURl = ImageSource.FromStream(() => sourceStream); 
                        StaticAddProductImage.UpperSideImageURL = sourceStream; UpperImageVerificationStatus = "verified.svg";}
                    if (i == 4) { LowerImageURl = ImageSource.FromStream(() => sourceStream); 
                        StaticAddProductImage.LowerSideImageURL = sourceStream; LowerImageVerificationStatus = "verified.svg";}
                    if (i == 5) { LeftImageURl = ImageSource.FromStream(() => sourceStream);  
                        StaticAddProductImage.LeftSideImageURL = sourceStream; LeftImageVerificationStatus = "verified.svg";}
                    if (i == 6) { RightImageURl = ImageSource.FromStream(() => sourceStream); 
                        StaticAddProductImage.RightSideImageURL = sourceStream; RightImageVerificationStatus = "verified.svg";}
                }
                return ;
            }
            return ;
        }

        [RelayCommand]
        public void GoNext()
        {

        }


        [RelayCommand]
        public async Task CheckImage()
        {
            ErrorText = "";
            if ( FrontImageURl == null ||
                BackImageURl == null ||
                UpperImageURl == null ||
                LowerImageURl == null ||
                LeftImageURl == null ||
                RightImageURl == null)
            {
                ErrorText = "Please upload all type of image";
                return;
            }
            await Shell.Current.GoToAsync(nameof(RequirmentVerification));

        }
    }
}
