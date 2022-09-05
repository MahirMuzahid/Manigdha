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
}