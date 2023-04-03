using SharedModal.Modals;
using SharedModal.ReponseModal;

namespace SharedModal.ClientServerConnection.Catagory_Type
{
    public class CatagoryTypeServerConnection : ICatagoryTypeServerConnection
    {
        private ICURDCall<CatagoryType> _serverConnection;

        public CatagoryTypeServerConnection(ICURDCall<CatagoryType> serverConnection)
        {
            _serverConnection = serverConnection;
        }

        public async Task<Response> Delete(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Delete(client, query, queryName);
        }

        public async Task<List<CatagoryType>> Get(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Get(client, query, queryName);
        }

        public async Task<CatagoryType> GetWithID(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.GetWithID(client, query, queryName);
        }

        public Task<List<CatagoryType>> GetWithIDList(HttpClient client, string query, string queryName)
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