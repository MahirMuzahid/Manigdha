using CommunityToolkit.Maui.Views;
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
        CURDCall<City> curd = new CURDCall<City>();
        UserServerConnection userServerConnection = new UserServerConnection();
        CityServerConnection cityServerConnection = new CityServerConnection(curd);
        ProfileViewModal profileViewModel = new ProfileViewModal(userServerConnection, cityServerConnection);
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
        LoginButtonGrid.TranslateTo(-800, 0, 1400, Easing.SinOut);
        RegisterCard.IsVisible = false;
        LoginCard.IsVisible = true;
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        LoginButtonGrid.TranslateTo(0, 0, 1400, Easing.SinOut);
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        LoginButtonGrid.TranslateTo(-800, 0, 1400, Easing.SinOut);
        RegisterCard.IsVisible = true;
        LoginCard.IsVisible = false;
    }
}