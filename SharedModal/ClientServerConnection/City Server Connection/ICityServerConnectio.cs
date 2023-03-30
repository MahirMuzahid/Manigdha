using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection.City_Server_Connection
{
    public interface ICityServerConnectio
    {
        public Task<Response> SetCity(HttpClient client, string query, string queryName);
        public Task<List<City>> GetCity(HttpClient client, string query, string queryName);
        public Task<City> GetCityWithID(HttpClient client, string query, string queryName);
    }
}
