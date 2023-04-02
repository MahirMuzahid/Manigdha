using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection
{
    public interface ICURDCall<T>
    {
        public Task<Response> Set(HttpClient client, string query, string queryName);
        public Task<Response> Update(HttpClient client, string query, string queryName);
        public Task<List<T>> Get(HttpClient client, string query, string queryName);
        public Task<T> GetWithID(HttpClient client, string query, string queryName);
        public Task<List<T>> GetWithIDList(HttpClient client, string query, string queryName);
        public Task<Response> Delete(HttpClient client, string query, string queryName);
    }
}
