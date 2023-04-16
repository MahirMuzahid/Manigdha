using CommunityToolkit.Mvvm.ComponentModel;
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
        string selectedFabricType;
        [ObservableProperty]
        List<string> fabricTypeList;

        [ObservableProperty]
        string selectedSizeType;
        [ObservableProperty]
        string selectedSize;

        [ObservableProperty]
        DateTime selectedDate;

        [ObservableProperty]
        bool isReceiptAvailableNoChecked;
        [ObservableProperty]
        bool isReceiptAvailableYesChecked;
        [ObservableProperty]
        Stream receiptPhoto;


        public ClothsRequirementVerificationViewModal()
        {
            
        }

        public async Task GetInitInfo()
        {

        }

    }
}
