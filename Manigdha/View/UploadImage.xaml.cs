using Manigdha.ViewModel;

namespace Manigdha.View;

public partial class UploadImage : ContentPage
{
	public UploadImage()
	{
		InitializeComponent();
        this.BindingContext = new UploadNonDigitalImageRequirmentViewModal();

    }

}