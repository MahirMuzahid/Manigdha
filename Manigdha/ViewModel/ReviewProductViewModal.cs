using CommunityToolkit.Mvvm.ComponentModel;
using Manigdha.Model.StaticFolder;
using SharedModal.Other_Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.ViewModel
{
    public partial class ReviewProductViewModal: ObservableObject
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        string price;
        [ObservableProperty]
        ImageSource upperSideImageURL;
        [ObservableProperty]
        ImageSource lowerSideImageURL;
        [ObservableProperty]
        ImageSource leftSideImageURL;
        [ObservableProperty]
        ImageSource rightSideImageURL;
        [ObservableProperty]
        ImageSource frontSideImageURL;
        [ObservableProperty]
        ImageSource backSideImageURL;
        [ObservableProperty]
        List<ReviewVerificationStatus> verification;
        public ReviewProductViewModal()
        {
            Title = StaticAddProductImage.Title;
            Description = StaticAddProductImage.Description;
            Price = StaticAddProductImage.Price;
            UpperSideImageURL = ImageSource.FromStream(() => StaticAddProductImage.UpperSideImageURL);
            LowerSideImageURL = ImageSource.FromStream(() => StaticAddProductImage.LowerSideImageURL);
            LeftSideImageURL  = ImageSource.FromStream(() => StaticAddProductImage.LeftSideImageURL);
            RightSideImageURL = ImageSource.FromStream(() => StaticAddProductImage.RightSideImageURL);
            FrontSideImageURL = ImageSource.FromStream(() => StaticAddProductImage.FrontSideImageURL);
            BackSideImageURL  = ImageSource.FromStream(() => StaticAddProductImage.BackSideImageURL);
            Verification = StaticAddProductImage.Verification;            
        }
    }
}
