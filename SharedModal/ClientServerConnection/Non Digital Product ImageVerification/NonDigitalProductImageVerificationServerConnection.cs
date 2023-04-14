using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection.Non_Digital_Product_ImageVerification
{
    public class NonDigitalProductImageVerificationServerConnection : INonDigitalProductImageVerificationServerConnection
    {
        private ICURDCall<NonDigitalProductImageVerification> _serverConnection;

        public NonDigitalProductImageVerificationServerConnection(ICURDCall<NonDigitalProductImageVerification> serverConnection)
        {
            _serverConnection = serverConnection;
        }
        public async Task<Response> Delete(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Delete(client, query, queryName);
        }

        public async Task<List<NonDigitalProductImageVerification>> Get(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Get(client, query, queryName);
        }

        public async Task<NonDigitalProductImageVerification> GetWithID(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.GetWithID(client, query, queryName);
        }

        public Task<List<NonDigitalProductImageVerification>> GetWithIDList(HttpClient client, string query, string queryName)
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
