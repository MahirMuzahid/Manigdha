using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.ClientServerConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Manigdha.Model;
using SharedModal.ClientServerConnection.Product_Server_Connection;
using SharedModal.ClientServerConnection.Product_Catagory;
using SharedModal.Modals;
using System.Xml.Linq;
using SharedModal.ClientServerConnection.Catagory_Type;

namespace Manigdha.GraphQL_Execution
{
    public class ProductInformationFillViewModalQuery
    {
        private HttpClient client = new HttpClient();
        private ICatagoryTypeServerConnection _catagoryTypeServerConnection;
        private IProductCatagoryServerConnection _productCatagoryServerConnection;
        ShowSnakeBar showSnakeBar = new ShowSnakeBar();

        public ProductInformationFillViewModalQuery(
            ICatagoryTypeServerConnection catagoryTypeServerConnection,
            IProductCatagoryServerConnection productCatagoryServerConnection)
        {
            client.BaseAddress = new Uri(StaticInfo.PostServiceBaseAddress);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticInfo.JWTToken);
            _catagoryTypeServerConnection = catagoryTypeServerConnection;
            _productCatagoryServerConnection = productCatagoryServerConnection;
        }
        public async Task<CatagoryType> GetAllCatagoryTypeByID(int id)
        {
            var result = StaticInfo.CheckNetAndJWTToken();
            if (!result.Item1) { return new CatagoryType(); }
            if (!result.Item2) { await RefreshTokenOnExpired.RefreshTokenNow(); return new CatagoryType(); }
            try
            {
                var query = "query{ catagoryTypeByID( id: "+id+") { catagoryTypeID, productCatagory { name } } }";
                var responseData = await _catagoryTypeServerConnection.GetWithID(client, query, "catagoryTypeByID");
                return responseData;
            }
            catch (Exception ex) 
            {
                await showSnakeBar.Show(ex.Message, SharedModal.Enums.SnakeBarType.Type.Danger, SharedModal.Enums.SnakeBarType.Time.LongTime );
                return new CatagoryType();
            }
            
        }
        public async Task<List<ProductCatagory>> GetAllCatagory()
        {
            var result = StaticInfo.CheckNetAndJWTToken();
            if (!result.Item1) { return new List<ProductCatagory>(); }
            if (result.Item2) { await RefreshTokenOnExpired.RefreshTokenNow(); return new List<ProductCatagory>(); }
            try
            {
                var query = "query{ productCatagory() { name  } }";
                var responseData = await _productCatagoryServerConnection.Get(client, query, "productCatagory");
                return responseData;
            }
            catch (Exception ex)
            {
                await showSnakeBar.Show(ex.Message, SharedModal.Enums.SnakeBarType.Type.Danger, SharedModal.Enums.SnakeBarType.Time.LongTime);
                return new List<ProductCatagory>();
            }
           
        }

    }
}
