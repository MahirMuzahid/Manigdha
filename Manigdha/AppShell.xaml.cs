using Manigdha.View;

namespace Manigdha;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
        Routing.RegisterRoute(nameof(ProductInformatinFill), typeof(ProductInformatinFill));

    }
}
