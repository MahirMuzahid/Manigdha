using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Manigdha.Model;
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
        string clothTearingInfoVerificationStatus;
        [ObservableProperty]
        string fabricIfoVerificationStatus;
        [ObservableProperty]
        string clothSizeInfoVerificationStatus;
        [ObservableProperty]
        string buyingTimeVerificationStatus;
        [ObservableProperty]
        string receiptInfoVerificationStatus;

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
            var gg = DateTime.Now.ToString("dd/M/yyyy");
            SelectedDate = DateTime.Parse(gg);


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
            if(!IsTearingInfoNoChecked && !IsTearingInfoYesChecked) { TearError = "Select Tearing Info"; return; }
            if (string.IsNullOrEmpty(SelectedGender)) { GenderError = "Select Gender Info"; return; }
            if (string.IsNullOrEmpty(SelectedFabricType)) { FabricError = "Select Fabric Type"; return; }
            if (string.IsNullOrEmpty(SelectedClothType)) { ClothTypeError = "Select Cloth Type"; return; }
            if (string.IsNullOrEmpty(SelectedSize)) { SizeError = "Select Size";  return; }            
            if (SelectedDate >= DateTime.Now) { ReceiptError = "Select Buying Date Info";   return; }
            if (!IsReceiptAvailableNoChecked || !IsReceiptAvailableYesChecked) { BuyError = "Select Receipt Info"; return; }


            await Shell.Current.GoToAsync(nameof(ReviewProductInfo));
        }
    }
}
