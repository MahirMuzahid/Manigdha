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
        string frontImageURl;
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
        [ObservableProperty]
        bool isFrontdltvisible;
        [ObservableProperty]
        bool isbackdltvisible;
        [ObservableProperty]
        bool isUpperdltvisible;
        [ObservableProperty]
        bool isLowerdltvisible;
        [ObservableProperty]
        bool isLeftdltvisible;
        [ObservableProperty]
        bool isRightdltvisible;
        UploadImageAzure uploadImage = new UploadImageAzure();
        ShowSnakeBar showSnakeBar = new ShowSnakeBar();

        public UploadNonDigitalImageRequirmentViewModal()
        {
            DoInit(); 
            getOldUploadedImage();
        }


        public void DoInit()
        {
            FrontImageVerificationStatus = "notverified.png";
            BackImageVerificationStatus = "notverified.png";
            UpperImageVerificationStatus = "notverified.png";
            LowerImageVerificationStatus = "notverified.png";
            LeftImageVerificationStatus = "notverified.png";
            RightImageVerificationStatus = "notverified.png";
            IsFrontdltvisible = false;
            Isbackdltvisible = false;
            IsUpperdltvisible = false;
            IsLowerdltvisible = false;
            IsLeftdltvisible = false;
            IsRightdltvisible = false;
        }

        [RelayCommand]
        public async Task ExecuteTakingPhot(string index)
        {
            int i = int.Parse(index);

            await TakePhoto(i);

           
        }
        public void getOldUploadedImage()
        {
            FrontImageURl = StaticAddProductImage.FrontSideImageURL;
            BackImageURl = StaticAddProductImage.BackSideImageURL;
            UpperImageURl = StaticAddProductImage.UpperSideImageURL;
            LowerImageURl = StaticAddProductImage.LowerSideImageURL;
            LeftImageURl = StaticAddProductImage.LeftSideImageURL;
            RightImageURl = StaticAddProductImage.RightSideImageURL;

        }

        [RelayCommand]
        public async Task DeletePhoto(string index)
        {
            int i = int.Parse(index);
            if(i == 1)
            {
                await uploadImage.DeleteImage(StaticAddProductImage.FrontSideImageURL);
                StaticAddProductImage.FrontSideImageURL = "";
                FrontImageURl = "";
                IsFrontdltvisible = false;
                FrontImageVerificationStatus = "notverified.png";
            }
            if (i == 2)
            {
                await uploadImage.DeleteImage(StaticAddProductImage.BackSideImageURL);
                StaticAddProductImage.BackSideImageURL = "";
                BackImageURl = "";
                Isbackdltvisible = false;
                BackImageVerificationStatus = "notverified.png";
            }
            if (i == 3)
            {
                await uploadImage.DeleteImage(StaticAddProductImage.UpperSideImageURL);
                StaticAddProductImage.UpperSideImageURL = "";
                UpperImageURl = "";
                IsUpperdltvisible = false;
                UpperImageVerificationStatus = "notverified.png";
            }
            if (i == 4)
            {
                await uploadImage.DeleteImage(StaticAddProductImage.LowerSideImageURL);
                StaticAddProductImage.LowerSideImageURL = "";
                LowerImageURl = "";
                IsLowerdltvisible = false;
                LowerImageVerificationStatus = "notverified.png";
            }
            if (i == 5)
            {
                await uploadImage.DeleteImage(StaticAddProductImage.LeftSideImageURL);
                StaticAddProductImage.LeftSideImageURL = "";
                LeftImageURl = "";
                IsLeftdltvisible = false;
                LeftImageVerificationStatus = "notverified.png";
            }
            if (i == 6)
            {
                await uploadImage.DeleteImage(StaticAddProductImage.RightSideImageURL);
                StaticAddProductImage.RightSideImageURL = "";
                RightImageURl = "";
                IsRightdltvisible = false;
                RightImageVerificationStatus = "notverified.png";
            }
        }
        public async Task TakePhoto(int i)
        {
           
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();
                try
                {
                    if (photo != null)
                    {
                        // save the file into local storage
                        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName); 


                        Stream sourceStream = await photo.OpenReadAsync();
                        var flileLink =  await uploadImage.UploadProductImage(sourceStream);
                        if (i == 1)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.FrontSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.FrontSideImageURL); }
                            StaticAddProductImage.FrontSideImageURL = flileLink;
                            FrontImageURl = flileLink;
                            FrontImageVerificationStatus = "verified.svg";
                            IsFrontdltvisible = true;
                        }
                        if (i == 2)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.BackSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.BackSideImageURL); }
                            StaticAddProductImage.BackSideImageURL = flileLink;
                            BackImageURl = flileLink;
                            BackImageVerificationStatus = "verified.svg";
                            Isbackdltvisible = true;
                        }
                        if (i == 3)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.UpperSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.UpperSideImageURL); }
                            UpperImageURl = flileLink;
                            StaticAddProductImage.UpperSideImageURL = flileLink;
                            UpperImageVerificationStatus = "verified.svg";
                            IsUpperdltvisible = true;
                        }
                        if (i == 4)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.LowerSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.LowerSideImageURL); }
                            LowerImageURl = flileLink;
                            StaticAddProductImage.LowerSideImageURL = flileLink;
                            LowerImageVerificationStatus = "verified.svg";
                            IsLowerdltvisible = true;
                        }
                        if (i == 5)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.LeftSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.LeftSideImageURL); }
                            LeftImageURl = flileLink;
                            StaticAddProductImage.LeftSideImageURL = flileLink;
                            LeftImageVerificationStatus = "verified.svg";
                            IsLeftdltvisible = true;
                        }
                        if (i == 6)
                        {
                            if (!string.IsNullOrEmpty(StaticAddProductImage.RightSideImageURL)) { await uploadImage.DeleteImage(StaticAddProductImage.RightSideImageURL); }
                            RightImageURl = flileLink;
                            StaticAddProductImage.RightSideImageURL = flileLink;
                            RightImageVerificationStatus = "verified.svg";
                            IsRightdltvisible = true;
                        }
                        
                    }
                }
                catch (Exception ex) {                   
                    await showSnakeBar.Show(ex.Message, SnakeBarType.Type.Danger);
                }
               
                return ;
            }
            IsBusy = false;
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
