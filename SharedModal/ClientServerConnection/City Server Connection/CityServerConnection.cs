using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection.City_Server_Connection
{
    public class CityServerConnection : ICityServerConnectio
    {
        private ICURDCall<City> _serverConnection;
        public CityServerConnection(ICURDCall<City> serverConnection) 
        {
            _serverConnection = serverConnection;
        }

        public async Task<Response> DeleteCity(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Delete(client, query, queryName);
        }

        public async Task<List<City>> GetCity(HttpClient client, string query, string queryName)
        {
           return await _serverConnection.Get(client, query, queryName);           
        }

        public async Task<City> GetCityWithID(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.GetWithID(client, query, queryName);
        }

        public async Task<Response> SetCity(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Set(client, query, queryName);
        }

        public async Task<Response> UpdateCity(HttpClient client, string query, string queryName)
        {
            return await _serverConnection.Update(client, query, queryName);
        }
    }
}
