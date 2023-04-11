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
}