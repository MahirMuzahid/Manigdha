using Manigdha.Model;

namespace Manigdha.View;

public partial class BuyPost : ContentPage
{
	public BuyPost()
	{
		InitializeComponent();
		List<BuyMockList> mlist = new List<BuyMockList>()
		{
			 new BuyMockList(),
			 new BuyMockList(),
			 new BuyMockList(),
			 new BuyMockList()
		};
		mockList.ItemsSource = mlist;

	}

	private void Button_Clicked(object sender, EventArgs e)
	{

	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
		GOToPD();
	}

	public async void  GOToPD()
	{
		await Navigation.PushAsync(new ProductDetail());
	}
}