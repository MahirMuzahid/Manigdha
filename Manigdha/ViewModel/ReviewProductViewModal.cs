using CommunityToolkit.Mvvm.ComponentModel;
using Manigdha.Model.StaticFolder;


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
            FrontSideImageURL = StaticAddProductImage.FrontSideImageURL;
            UpperSideImageURL = StaticAddProductImage.UpperSideImageURL;
            LowerSideImageURL = StaticAddProductImage.LowerSideImageURL;
            LeftSideImageURL  = StaticAddProductImage.LeftSideImageURL;
            RightSideImageURL = StaticAddProductImage.RightSideImageURL;
            BackSideImageURL  = StaticAddProductImage.BackSideImageURL;
            Verification = StaticAddProductImage.Verification;            
        }
    }
}
