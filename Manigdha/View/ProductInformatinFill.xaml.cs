using Manigdha.Model;
using Manigdha.ViewModel;

namespace Manigdha.View;

public partial class ProductInformatinFill : ContentPage
{
	public ProductInformatinFill()
	{
		InitializeComponent();
        ProductInfoFillViewModal productInfoFillViewModal = new ProductInfoFillViewModal();
        this.BindingContext = productInfoFillViewModal;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoToVerification();
    }
    public async Task GoToVerification()
    {
        await Navigation.PushModalAsync(new ProductVerification());
        //await Shell.Current.GoToAsync(nameof(ProductVerification));
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            TemporaryStaticInfo.SelectedProductCatagoryName = picker.Items[selectedIndex];
            var selectedCatagoryTypeList = TemporaryStaticInfo.PikerProductCatagoryList.FirstOrDefault(p => p.Name == picker.Items[selectedIndex]).CatagoryTypes.ToList();
            CatagoryTypePicker.ItemsSource = selectedCatagoryTypeList.Where(c => c.Name != null).Select(c => c.Name).ToList();


        }
    }
}