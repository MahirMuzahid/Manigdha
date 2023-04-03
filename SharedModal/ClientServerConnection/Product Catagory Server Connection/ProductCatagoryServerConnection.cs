using SharedModal.Modals;
using SharedModal.ReponseModal;

namespace SharedModal.ClientServerConnection.Product_Catagory
{
    public class ProductCatagoryServerConnection : IProductCatagoryServerConnection
    {
        private ICURDCall<ProductCatagory> _serverConnection;

        public ProductCatagoryServerConnection(ICURDCall<ProductCatagory> serverConnection)
        {
            _serverConnection = serverConnection;
        }

        public async Task<Response> Delete(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Delete(client, query, queryName);
        }

        public async Task<List<ProductCatagory>> Get(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Get(client, query, queryName);
        }

        public async Task<ProductCatagory> GetWithID(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.GetWithID(client, query, queryName);
        }

        public Task<List<ProductCatagory>> GetWithIDList(HttpClient client, string query, string queryName)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Set(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Set(client, query, queryName);
        }

        public async Task<Response> Update(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Update(client, query, queryName);
        }
    }
}