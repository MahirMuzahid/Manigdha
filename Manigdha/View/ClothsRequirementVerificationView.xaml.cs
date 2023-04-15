using Manigdha.ViewModel;

namespace Manigdha.View;

public partial class ClothsRequirementVerificationView : ContentPage
{
	public ClothsRequirementVerificationView()
	{
		InitializeComponent();
        this.BindingContext = new ClothsRequirementVerificationViewModal();
	}

}