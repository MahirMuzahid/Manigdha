using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Manigdha.Model;
using Manigdha.Model.StaticFolder;
using Manigdha.View;
using SharedModal.Enums;
using SharedModal.Other_Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.ViewModel
{
    public partial class ClothsRequirementVerificationViewModal : ObservableObject
    {


        [ObservableProperty]
        bool isTearingInfoNoChecked;
        [ObservableProperty]
        bool isTearingInfoYesChecked;
        [ObservableProperty]
        string tearingInfoText;

        [ObservableProperty]
        List<string> genderList;
        [ObservableProperty]
        string selectedGender;

        [ObservableProperty]
        string selectedFabricType;
        [ObservableProperty]
        List<string> fabricTypeList;

        [ObservableProperty]
        string selectedClothType;
        [ObservableProperty]
        List<string> clothTypeList;

        [ObservableProperty]
        string selectedSizeType;
        [ObservableProperty]
        string selectedSize;
        [ObservableProperty]
        List<string> sizeTypeList;
        [ObservableProperty]
        List<string> sizeList;

        [ObservableProperty]
        DateTime selectedDate;

        [ObservableProperty]
        bool isReceiptAvailableNoChecked;
        [ObservableProperty]
        bool isReceiptAvailableYesChecked;
        [ObservableProperty]
        Stream receiptPhoto;

        [ObservableProperty]
        string tearError;
        [ObservableProperty]
        string genderError;
        [ObservableProperty]
        string fabricError;
        [ObservableProperty]
        string clothTypeError;
        [ObservableProperty]
        string sizeError;
        [ObservableProperty]
        string buyError;
        [ObservableProperty]
        string receiptError;

        [ObservableProperty]
        string tearVerificationStatus;
        [ObservableProperty]
        string genderVerificationStatus;
        [ObservableProperty]
        string fabricVerificationStatus;
        [ObservableProperty]
        string clothTypeVerificationStatus;
        [ObservableProperty]
        string sizeVerificationStatus;
        [ObservableProperty]
        string buyVerificationStatus;
        [ObservableProperty]
        string receiptVerificationStatus;


        List<ReviewVerificationStatus> verify = new List<ReviewVerificationStatus>();
        public ClothsRequirementVerificationViewModal()
        {
            GetInitInfo();
        }

        public void GetInitInfo()
        {
            TearError = "";
            GenderError = "";
            FabricError = "";
            ClothTypeError = "";
            SizeError = "";
            BuyError = "";
            ReceiptError = "";

            GenderList = Enum.GetNames(typeof(ClothingSize.Gender)).ToList();
            FabricTypeList = Enum.GetNames(typeof(FabricEnum.FabricType)).ToList();
            SizeTypeList = Enum.GetNames(typeof(ClothingSize.SizeType)).ToList();
            SelectedDate = DateTime.Now;


        }

        [RelayCommand]
        public async Task GoToReview()
        {
            TearError = "";
            GenderError = "";
            FabricError = "";
            ClothTypeError = "";
            SizeError = "";
            BuyError = "";
            ReceiptError = "";
            if(!IsTearingInfoNoChecked && !IsTearingInfoYesChecked) { TearError = "Select Tearing Info"; TearVerificationStatus = "notverified.png"; return; }
            TearVerificationStatus = "verified.svg";
            if (string.IsNullOrEmpty(SelectedGender)) { GenderError = "Select Gender Info"; GenderVerificationStatus = "notverified.png"; return; }
            GenderVerificationStatus = "verified.png";
            if (string.IsNullOrEmpty(SelectedFabricType)) { FabricError = "Select Fabric Type"; FabricVerificationStatus = "notverified.png"; return; }
            FabricVerificationStatus = "verified.png";
            if (string.IsNullOrEmpty(SelectedClothType)) { ClothTypeError = "Select Cloth Type"; ClothTypeVerificationStatus = "notverified.png"; return; }
            ClothTypeVerificationStatus = "verified.png";
            if (string.IsNullOrEmpty(SelectedSize)) { SizeError = "Select Size"; SizeVerificationStatus = "notverified.png"; return; }
            SizeVerificationStatus = "verified.png";
            if (SelectedDate >= DateTime.Now) { BuyError = "Select Buying Date Info"; BuyVerificationStatus = "notverified.png"; return; }
            BuyVerificationStatus = "verified.png";
            if (!IsReceiptAvailableNoChecked && !IsReceiptAvailableYesChecked) { ReceiptError = "Select Receipt Info"; ReceiptVerificationStatus = "notverified.png"; return; }
            ReceiptVerificationStatus = "verified.png";

            List<ReviewVerificationStatus> listReview = new List<ReviewVerificationStatus>()
            {
                new ReviewVerificationStatus(){ Name = "Tearing Info", IsVerified = true , Info = TearingInfoText, verificationStatus = "verified.png"},
                new ReviewVerificationStatus(){ Name = "Gender Info", IsVerified = true , Info = SelectedGender, verificationStatus = "verified.png"},
                new ReviewVerificationStatus(){ Name = "Fabric Info", IsVerified = true , Info = SelectedFabricType, verificationStatus = "verified.png"},
                new ReviewVerificationStatus(){ Name = "Cloth Type Info", IsVerified = true , Info = SelectedClothType, verificationStatus = "verified.png"},
                new ReviewVerificationStatus(){ Name = "Size Info", IsVerified = true , Info = SelectedSizeType, verificationStatus = "verified.png"},
                new ReviewVerificationStatus(){ Name = "Buy Time Info", IsVerified = true , Info = SelectedDate.ToString(), verificationStatus = "verified.png"},
                new ReviewVerificationStatus(){ Name = "Receipt Info", IsVerified = true , Info = "", verificationStatus = "verified.png"}
            };

            StaticAddProductImage.Verification = listReview;

            await Shell.Current.GoToAsync(nameof(ReviewProductInfo));
        }
    }
}
