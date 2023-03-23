namespace Manigdha.View;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoToNewProductPostPage();
    }

	public async Task GoToNewProductPostPage()
	{
        //await Shell.Current.GoToAsync(nameof(ProductPage));
        await Navigation.PushAsync(new ProductPage());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        GoToBid();
    }
    public async Task GoToBid()
    {
        //await Shell.Current.GoToAsync(nameof(ProductPage));
        await Navigation.PushAsync(new BidHistory());
    }
}