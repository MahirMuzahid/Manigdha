namespace Manigdha.View;

public partial class RequirmentVerification : ContentPage
{
	public RequirmentVerification()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoToPage();
    }
    public async Task GoToPage()
    {
        await Navigation.PushModalAsync(new ReviewProductInfo());
    }
}