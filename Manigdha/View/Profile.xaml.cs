using CommunityToolkit.Maui.Views;
using Manigdha.Model;
using Manigdha.ViewModel;
using SharedModal.ClientServerConnection;
using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.Modals;

namespace Manigdha.View;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
        ProfileViewModal profileViewModel = new ProfileViewModal();
        this.BindingContext = profileViewModel;
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

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        LoginButtonGrid.TranslateTo(-800, 0, 1000, Easing.SinOut);
        RegisterCard.IsVisible = false;

    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        LoginButtonGrid.TranslateTo(0, 0, 1000, Easing.SinOut);
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        LoginButtonGrid.TranslateTo(-800, 0, 1400, Easing.SinOut);
        RegisterCard.IsVisible = true;

    }

    private void Button_Clicked_5(object sender, EventArgs e)
    {
        RegisterCard.TranslateTo(0, 0, 1400, Easing.SinOut);
    }

    private void Button_Clicked_6(object sender, EventArgs e)
    {
        if (StaticInfo.ShouldGoOTPView) { RegisterCard.TranslateTo(-800, 0, 1400, Easing.SinOut); }
        
    }
}