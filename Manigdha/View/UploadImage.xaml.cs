using Manigdha.ViewModel;

namespace Manigdha.View;

public partial class UploadImage : ContentPage
{
	public UploadImage()
	{
		InitializeComponent();
        BindingContext = new UploadNonDigitalImageRequirmentViewModal();

    }

}