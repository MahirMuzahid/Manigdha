using Manigdha.Model;
using Manigdha.ViewModel;

namespace Manigdha.View;

public partial class BuyPost : ContentPage
{
	public BuyPost( BuyPostViewModal vm)
	{
		InitializeComponent();
		BindingContext= vm;
		List<BuyMockList> mlist = new List<BuyMockList>()
		{
			 new BuyMockList(),
			 new BuyMockList(),
			 new BuyMockList(),
			 new BuyMockList()
		};
       
		List<int> clist  = new List<int> { 1, 2, 3 };
        mockList.ItemsSource = mlist;
        //carosalMock.ItemsSource= clist;


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