using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection.Division_Server_Connection
{
    public class DivisionServerConnection : IDivisioServerConnection
    {
        private ICURDCall<Division> _serverConnection;
        public DivisionServerConnection(ICURDCall<Division> serverConnection)
        {
            _serverConnection = serverConnection;
        }
        public async Task<Response> Delete(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Delete(client, query, queryName);
        }

        public async Task<List<Division>> Get(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Get(client, query, queryName);
        }

        public async Task<Division> GetWithID(HttpClient client, string query, string queryName)
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
    }
}
