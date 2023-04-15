using Manigdha.View;
using SharedModal.Modals;

namespace Manigdha;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
        Routing.RegisterRoute(nameof(ProductInformatinFill), typeof(ProductInformatinFill));
        Routing.RegisterRoute(nameof(ProductVerification), typeof(ProductVerification));
        Routing.RegisterRoute(nameof(UploadImage), typeof(UploadImage));
        Routing.RegisterRoute(nameof(ClothsRequirementVerificationView), typeof(ClothsRequirementVerificationView));

    }
}
