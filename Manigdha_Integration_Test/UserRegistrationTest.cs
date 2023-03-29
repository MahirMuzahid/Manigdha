using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SharedModal.ClientServerConnection;
using SharedModal.DTO;
using SharedModal.ReponseModal;
using System.Net;

namespace Manigdha_Integration_Test
{
    public class UserRegistrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private IUserServerConnection _serverConnection;
        private int dltID = 5;

        public UserRegistrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;

            // Create HttpClient using CreateClient method
            var client = _factory.CreateClient();

            // Create a new instance of ServiceCollection for dependency injection
            var services = new ServiceCollection();

            // Add scoped IUserServerConnection implementation to ServiceCollection
            services.AddScoped<IUserServerConnection, UserServerConnection>();

            // Build the ServiceCollection and get the IUserServerConnection implementation
            var serviceProvider = services.BuildServiceProvider();
            _serverConnection = serviceProvider.GetService<IUserServerConnection>();
        }

        [Fact]
        public async Task Register_ValidData_ReturnsNewUserFromServer()
        {
            // Create HttpClient using CreateClient method
            var client = _factory.CreateClient();

            // GraphQL mutation query to register a new user
            //var query = @"mutation { register(studentDto: { email: ""user3@mail.com"", name: ""User 6"", password: ""123"", phoneNumber: ""13"", cityID: 1 }) { userID, passwordHash, passwordSalt } }";
            var userDTO = new UserDTO
            {
                CityID = 1,
                Name = "User",
                Password = "123",
                Email = "gg123@gmail.com",
                PhoneNumber = "789"
            };
            var response = new RegTestReponse();
            var query = GraphQLCodeGenerator<UserDTO, RegTestReponse>.Parameter_Multiple_Return_Object("register", "userDTO", userDTO);

            // Call RegisterAndGetUser method of IUserServerConnection and get response data
            var responseData = await _serverConnection.RegisterAndGetUser(client, query);

            // Assert response data has expected values
            Assert.Equal(HttpStatusCode.OK, responseData.ResponseCode);
            Assert.NotNull(responseData.PasswordHash);
            Assert.NotNull(responseData.PasswordSalt);
            Assert.NotEqual(0, responseData.UserID);
            dltID = responseData.UserID;
            await UserID_DeleteFromDatabase_Reponse();
        }
        public class RegTestReponse
        {
            public string userID { get; set; }
            public string passwordHash { get; set; }
            public string passwordSalt { get; set; }
        }

        [Fact] 
        public async Task UserID_DeleteFromDatabase_Reponse()
        {
            var client = _factory.CreateClient();

            var response = new SharedModal.ReponseModal.Response();
            var query = GraphQLCodeGenerator<int, Response>.Parameter_Single_Return_Object("deleteUser", "userID", dltID, response);

            // Call RegisterAndGetUser method of IUserServerConnection and get response data
            var responseData = await _serverConnection.DeleteUser(client, query, "deleteUser");

            // Assert response data has expected values
            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        public async Task ClearUserTable()
        {
            var client = _factory.CreateClient();
            for(int i = 14; i < 40; i++)
            {
                dltID = i;
               await  UserID_DeleteFromDatabase_Reponse();
            }

        }

      
    }

}