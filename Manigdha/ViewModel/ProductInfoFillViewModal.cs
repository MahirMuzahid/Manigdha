using CommunityToolkit.Mvvm.ComponentModel;
using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manigdha.Model;
using SharedModal.ClientServerConnection.Product_Catagory;
using SharedModal.ClientServerConnection.Catagory_Type;
using Manigdha.GraphQL_Execution;

namespace Manigdha.ViewModel
{
    public partial class ProductInfoFillViewModal: ObservableObject
    {
        [ObservableProperty]
        bool isSelectGridVisible;
        [ObservableProperty]
        bool isLodaingGridVisible;
        [ObservableProperty]
        bool isPickInfoVisible;
        [ObservableProperty]
        List<string> productCatagoryNameList;

        bool isBusy;
        private ShowSnakeBar showSnake = new ShowSnakeBar();
        private ProductInformationFillViewModalQuery query;
        List<ProductCatagory> PikerProductCatagoryList;
        public ProductInfoFillViewModal()
        {
            CURDCall<ProductCatagory> pc = new CURDCall<ProductCatagory>();
            CURDCall<CatagoryType> ct = new CURDCall<CatagoryType>();
            ProductCatagoryServerConnection pcconn = new ProductCatagoryServerConnection(pc);
            CatagoryTypeServerConnection ctconn= new CatagoryTypeServerConnection(ct);
            query = new ProductInformationFillViewModalQuery(ctconn, pcconn);
            isBusy = false;
            IsSelectGridVisible = true;
            getProductCatagoryList();

        }

        public async Task getProductCatagoryList()
        {
            isBusy = true;
            IsLodaingGridVisible = isBusy;
            IsPickInfoVisible = !isBusy;
            try
            {
                PikerProductCatagoryList = await query.GetAllCatagory();
                ProductCatagoryNameList = PikerProductCatagoryList.Where(c => c.Name != null).Select(c => c.Name).ToList();
            }
            catch (Exception ex) { await showSnake.Show(ex.Message, SharedModal.Enums.SnakeBarType.Type.Danger, SharedModal.Enums.SnakeBarType.Time.LongTime); }
            isBusy = false;
            IsLodaingGridVisible = isBusy;
            IsPickInfoVisible = !isBusy;
        }
    }
}
