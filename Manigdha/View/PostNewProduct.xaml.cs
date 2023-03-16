namespace Manigdha.View;

public partial class PostNewProduct : ContentPage
{
	public PostNewProduct()
	{
		InitializeComponent();
	}

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }
    public async Task GoToInfoFill()
    {
        await Navigation.PushModalAsync(new ProductInformatinFill());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoToInfoFill();
    }
}