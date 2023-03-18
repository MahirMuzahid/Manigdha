namespace Manigdha.View;

public partial class ProductVerification : ContentPage
{
	public ProductVerification()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoToUploadImage();
    }

    public async Task GoToUploadImage()
    {
        await Navigation.PushModalAsync(new UploadImage());
    }
}