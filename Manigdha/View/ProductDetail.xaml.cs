namespace Manigdha.View;

public partial class ProductDetail : ContentPage
{
	public ProductDetail()
	{
		InitializeComponent();
        Routing.RegisterRoute("ProductDetail", typeof(ProductDetail));
    }
}