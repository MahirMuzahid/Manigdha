namespace Manigdha.View;

public partial class UploadImage : ContentPage
{
	public UploadImage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoToPage();
    }
    public async Task GoToPage()
    {
        await Navigation.PushModalAsync(new RequirmentVerification());
    }
}