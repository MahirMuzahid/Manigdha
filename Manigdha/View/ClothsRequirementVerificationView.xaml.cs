using Manigdha.ViewModel;
using SharedModal.Other_Modals;
using static SharedModal.Other_Modals.ClothingSize;

namespace Manigdha.View;

public partial class ClothsRequirementVerificationView : ContentPage
{
    string selectedGender = "", selectedCloth = "", selectedType = "";
	public ClothsRequirementVerificationView()
	{
		InitializeComponent();
        this.BindingContext = new ClothsRequirementVerificationViewModal();
        tearingInfoEditor.IsVisible = false;
        uploadReceiptImage.IsVisible = false;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        CheckTearingCheck(true);
    }

    private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
    {
        CheckTearingCheck(false);
    }
    public void CheckTearingCheck(bool isYesChecked)
    {
        if (isYesChecked)
        {
            if (tearCheckYes.IsChecked)
            {
                tearingInfoEditor.IsVisible = true;
                if (tearCheckNo.IsChecked) { tearCheckNo.IsChecked = false; }
                
            }
            if (!tearCheckYes.IsChecked)
            {
                tearingInfoEditor.IsVisible = false;
            }
            return;
        }
        

        if (tearCheckNo.IsChecked)
        {
            tearingInfoEditor.IsVisible = false;
            if(tearCheckYes.IsChecked){ tearCheckYes.IsChecked = false; }
        }
    }
    
    public void PopulateSizePicker()
    {
        if ( string.IsNullOrEmpty(selectedGender) || string.IsNullOrEmpty(selectedCloth)) { return; }
        Gender gender = (Gender)Enum.Parse(typeof(Gender), selectedGender);
        if(gender == Gender.Male) {
            MenClothingType cloth = (MenClothingType)Enum.Parse(typeof(MenClothingType), selectedCloth);
            fabricSizePicker.ItemsSource = ClothingSize.GetMenSizes(gender, cloth);
        }
        if (gender == Gender.Female) { 
            WomenClothingType cloth = (WomenClothingType)Enum.Parse(typeof(WomenClothingType), selectedCloth);
            fabricSizePicker.ItemsSource = ClothingSize.GetWomenSizes( gender, cloth);
        }
      
    }
    private void CheckBox_CheckedChanged_2(object sender, CheckedChangedEventArgs e)
    {
        CheckReceiptCheck(true);
    }

    private void CheckBox_CheckedChanged_3(object sender, CheckedChangedEventArgs e)
    {
        CheckReceiptCheck(false);
    }

    public void CheckReceiptCheck(bool isYesChecked)
    {
        if (isYesChecked)
        {
            if (receiptCheckYes.IsChecked)
            {
                uploadReceiptImage.IsVisible = true;
                if (receiptCheckNo.IsChecked) { receiptCheckNo.IsChecked = false; }

            }
            if (!receiptCheckYes.IsChecked)
            {
                uploadReceiptImage.IsVisible = false;
            }
            return;
        }


        if (receiptCheckNo.IsChecked)
        {
            uploadReceiptImage.IsVisible = false;
            if (receiptCheckYes.IsChecked) { receiptCheckYes.IsChecked = false; }
        }
    }

    private void Picker_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        selectedCloth = "";
        fabricSizePicker.ItemsSource = null;
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            selectedGender = (string)picker.ItemsSource[selectedIndex];
        }
        Gender gender = (Gender)Enum.Parse(typeof(Gender), selectedGender);
        if (gender == Gender.Male) { clothTypepicker.ItemsSource = Enum.GetNames(typeof(ClothingSize.MenClothingType)).ToList(); }
        if (gender == Gender.Female) { clothTypepicker.ItemsSource = Enum.GetNames(typeof(ClothingSize.WomenClothingType)).ToList(); }
    }

    private void Picker_SelectedIndexChanged_2(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            selectedCloth = (string)picker.ItemsSource[selectedIndex];
        }
        
        PopulateSizePicker();
    }
}