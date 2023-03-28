using Newtonsoft.Json;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using GraphQL.Client;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using GraphQL.Client.Http;
using GraphQL;
using GraphQL.Client.Abstractions.Websocket;
using GraphQL.Client.Abstractions;
using SharedModal.ClientServerConnection;

namespace Manigdha_Integration_Test
{
    public class UserRegistrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
       
        private readonly WebApplicationFactory<Program> _factory;
        private IUserServerConnection _serverConnection;

        public UserRegistrationTest(WebApplicationFactory<Program> factory, IUserServerConnection serverConnection)
        {
            _factory = factory;
            _serverConnection = serverConnection;
        }

        [Fact]
        public async Task Register_ValidData_ReturnsNewUser()
        {
            // Arrange
            var client = _factory.CreateClient();
            var query = @"
            mutation{
  register ( studentDto: {
     email: ""user3@mail.com"",
      name: ""User 6"",
       password: ""123"",
       phoneNumber : ""13"",
       cityID: 1
  }){
name,
    passwordHash,
     passwordSalt
  }
}
            ";


            
        // Act

        var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var s = content.ToString();
            // Act
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseJson = JObject.Parse(responseContent)["data"].ToString();
            var responseJson2 = JObject.Parse(responseJson)["register"].ToString();
            var responseData = JsonConvert.DeserializeObject<SharedModal.Modals.User>(responseJson2);

            var result = (SharedModal.Modals.User)responseData;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(responseData);
            Assert.NotNull(responseData.PasswordHash);
            Assert.NotNull(responseData.PasswordSalt);
            Assert.Equal("User 6", responseData.Name);
            //Add other assertions as needed
        }
        [Fact]
        public async Task Register_ValidData_ReturnsNewUserFromServer()
        {
            // Arrange
            var client = _factory.CreateClient();
            var query = @" mutation{ register ( studentDto: { email: ""user3@mail.com"", name: ""User 6"", password: ""123"", phoneNumber : ""13"", cityID: 1 }){ name, passwordHash, passwordSalt } } ";
            var responseData = _serverConnection.RegisterAndGetUser(query, client);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(responseData);
            Assert.NotNull(responseData.PasswordHash);
            Assert.NotNull(responseData.PasswordSalt);
            Assert.Equal("User 6", responseData.Name);
            //Add other assertions as needed
        }




    }

}