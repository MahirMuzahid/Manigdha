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
}