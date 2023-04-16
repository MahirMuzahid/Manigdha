using Manigdha.ViewModel;

namespace Manigdha.View;

public partial class ClothsRequirementVerificationView : ContentPage
{
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
                //if (tearCheckNo.IsChecked) { tearCheckNo.IsChecked = false; }
            }
            return;
        }
        

        if (tearCheckNo.IsChecked)
        {
            tearingInfoEditor.IsVisible = false;
            if(tearCheckYes.IsChecked){ tearCheckYes.IsChecked = false; }
        }
        if (!tearCheckNo.IsChecked)
        {
            //if (tearingInfoEditor.IsVisible) { tearingInfoEditor.IsVisible = false; }
            //if (tearCheckYes.IsChecked) { tearCheckYes.IsChecked = false; }

        }
    }
    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        fabricSizePicker.IsVisible = true;
    }

    private void CheckBox_CheckedChanged_2(object sender, CheckedChangedEventArgs e)
    {
        receiptCheckNo.IsChecked = false;
        if (receiptCheckYes.IsChecked) { uploadReceiptImage.IsVisible = true; return; }
        uploadReceiptImage.IsVisible = false;
    }

    private void CheckBox_CheckedChanged_3(object sender, CheckedChangedEventArgs e)
    {
        receiptCheckYes.IsChecked = false;
        if (receiptCheckYes.IsChecked) { uploadReceiptImage.IsVisible = true; return; }
        uploadReceiptImage.IsVisible = false;
    }
}