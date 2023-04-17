﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        Stream receiptPhoto;

        public ClothsRequirementVerificationViewModal()
        {
            GetInitInfo();
        }

        public void GetInitInfo()
        {
            GenderList = Enum.GetNames(typeof(ClothingSize.Gender)).ToList();
            FabricTypeList = Enum.GetNames(typeof(FabricEnum.FabricType)).ToList();
            SizeTypeList = Enum.GetNames(typeof(ClothingSize.SizeType)).ToList();
        }

        [RelayCommand]
        public async Task GoToReview()
        {
            await Shell.Current.GoToAsync(nameof(ReviewProductInfo));
        }
    }
}
