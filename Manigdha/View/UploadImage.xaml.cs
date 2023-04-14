using Manigdha.ViewModel;

namespace Manigdha.View;

public partial class UploadImage : ContentPage
{
	public UploadImage()
	{
		InitializeComponent();
        this.BindingContext = new UploadNonDigitalImageRequirmentViewModal();

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