using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection.Product_Server_Connection
{
    public class ProductServerConnection : IProductServerConnection
    {
        private ICURDCall<Product> _serverConnection;

        public ProductServerConnection(ICURDCall<Product> serverConnection)
        {
            _serverConnection = serverConnection;
        }

        public async Task<Response> Delete(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Delete(client, query, queryName);
        }

        public async Task<List<Product>> Get(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Get(client, query, queryName);
        }

        public async Task<Product> GetWithID(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.GetWithID(client, query, queryName);
        }

        public async Task<Response> Set(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Set(client, query, queryName);
        }

        public async Task<Response> Update(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Update(client, query, queryName);
        }

        public async Task<List<Product>> GetWithIDList(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.GetWithIDList(client, query, queryName);
        }
    }
}
