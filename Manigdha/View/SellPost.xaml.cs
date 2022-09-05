using Manigdha.Model;

namespace Manigdha.View;

public partial class SellPost : ContentPage
{
	public SellPost()
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