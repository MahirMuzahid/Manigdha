namespace Manigdha.View;

public partial class ProductPage : ContentPage
{
	public ProductPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoToPostNewProductPage();
    }

	public async Task GoToPostNewProductPage()
	{
        await Navigation.PushModalAsync(new PostNewProduct());
    }
}