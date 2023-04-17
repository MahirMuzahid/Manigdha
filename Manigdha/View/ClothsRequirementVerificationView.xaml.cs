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
        fabricSizePicker.IsVisible = false;
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
    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        fabricSizePicker.IsVisible = true;
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            selectedType = (string)picker.ItemsSource[selectedIndex];
        }
        PopulateSizePicker();
    }
    public void PopulateSizePicker()
    {
        if (string.IsNullOrEmpty(selectedType) || string.IsNullOrEmpty(selectedGender) || string.IsNullOrEmpty(selectedCloth)) { return; }
        SizeType sizeType = (SizeType)Enum.Parse(typeof(SizeType), selectedType);
        Gender gender = (Gender)Enum.Parse(typeof(Gender), selectedGender);
        ClothingType cloth = (ClothingType)Enum.Parse(typeof(ClothingType), selectedCloth);
        fabricSizePicker.ItemsSource = ClothingSize.GetSizes(sizeType, gender, cloth);
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
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            selectedGender = (string)picker.ItemsSource[selectedIndex];
        }
        PopulateSizePicker();
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