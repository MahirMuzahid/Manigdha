using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Manigdha.Model;
using Manigdha.Model.StaticFolder;
using Manigdha.View;
using SharedModal.Enums;
using SharedModal.Modals;
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
        [ObservableProperty]
        bool isBusy;

        ShowSnakeBar showSnakeBar = new ShowSnakeBar();

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
            IsBusy = true;
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();
                try
                {
                    if (photo != null)
                    {
                        // save the file into local storage
                        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                        UploadImageAzure uploadImage = new UploadImageAzure();
                        Stream sourceStream = await photo.OpenReadAsync();
                        var flileLink =  await uploadImage.UploadProductImage(sourceStream);
                        if (i == 1)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.FrontSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.FrontSideImageURL); }
                            StaticAddProductImage.FrontSideImageURL = flileLink;
                            FrontImageURl = flileLink;
                            FrontImageVerificationStatus = "verified.svg";
                        }
                        if (i == 2)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.BackSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.BackSideImageURL); }
                            StaticAddProductImage.BackSideImageURL = flileLink;
                            BackImageURl = flileLink;
                            BackImageVerificationStatus = "verified.svg";
                        }
                        if (i == 3)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.UpperSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.UpperSideImageURL); }
                            UpperImageURl = flileLink;
                            StaticAddProductImage.UpperSideImageURL = flileLink;
                            UpperImageVerificationStatus = "verified.svg";
                        }
                        if (i == 4)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.LowerSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.LowerSideImageURL); }
                            LowerImageURl = flileLink;
                            StaticAddProductImage.LowerSideImageURL = flileLink;
                            LowerImageVerificationStatus = "verified.svg";
                        }
                        if (i == 5)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.LeftSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.LeftSideImageURL); }
                            LeftImageURl = flileLink;
                            StaticAddProductImage.LeftSideImageURL = flileLink;
                            LeftImageVerificationStatus = "verified.svg";
                        }
                        if (i == 6)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.RightSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.RightSideImageURL); }
                            RightImageURl = flileLink;
                            StaticAddProductImage.RightSideImageURL = flileLink;
                            RightImageVerificationStatus = "verified.svg";
                        }
                        IsBusy = false;
                    }
                }
                catch (Exception ex) {                   
                    await showSnakeBar.Show(ex.Message, SnakeBarType.Type.Danger);
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
            //ErrorText = "";
            //if ( FrontImageURl == null ||
            //    BackImageURl == null ||
            //    UpperImageURl == null ||
            //    LowerImageURl == null ||
            //    LeftImageURl == null ||
            //    RightImageURl == null)
            //{
            //    ErrorText = "Please upload all type of image";
            //    return;
            //}
            await Shell.Current.GoToAsync(nameof(ClothsRequirementVerificationView));

        }
    }
}
