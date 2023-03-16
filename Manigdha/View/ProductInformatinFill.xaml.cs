namespace Manigdha.View;

public partial class ProductInformatinFill : ContentPage
{
	public ProductInformatinFill()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoToVerification();
    }
    public async Task GoToVerification()
    {
        await Navigation.PushModalAsync(new ProductVerification());
    }
}