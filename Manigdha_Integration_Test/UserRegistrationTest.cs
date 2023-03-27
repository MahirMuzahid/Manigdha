using Newtonsoft.Json;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;

using Newtonsoft.Json.Linq;

namespace Manigdha_Integration_Test
{
    public class UserRegistrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UserRegistrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
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
    password,
     phoneNumber
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
            var responseJson = JObject.Parse(responseContent);
            var dataJson = responseJson["data"].ToString();
            var responseData = JsonConvert.DeserializeObject<SharedModal.Modals.User>(dataJson);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(responseData);
            Assert.NotNull(responseData.PasswordHash);
            Assert.NotNull(responseData.PasswordSalt);
            Assert.Equal("John Doe", responseData.Name);
            // Add other assertions as needed
        }
    }
}