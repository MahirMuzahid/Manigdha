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
        List<ProductCatagory> pikerProductCatagoryList;

        private ShowSnakeBar showSnake = new ShowSnakeBar();
        private ProductInformationFillViewModalQuery query;

        public ProductInfoFillViewModal()
        {
            CURDCall<ProductCatagory> pc = new CURDCall<ProductCatagory>();
            CURDCall<CatagoryType> ct = new CURDCall<CatagoryType>();
            ProductCatagoryServerConnection pcconn = new ProductCatagoryServerConnection(pc);
            CatagoryTypeServerConnection ctconn= new CatagoryTypeServerConnection(ct);
            query = new ProductInformationFillViewModalQuery(ctconn, pcconn);
            IsSelectGridVisible = true;
            getProductCatagoryList();

        }

        public async Task getProductCatagoryList()
        {
            PikerProductCatagoryList = await query.GetAllCatagory();
        }
    }
}
