using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SharedModal.ClientServerConnection;
using SharedModal.DTO;
using System.Net;

namespace Manigdha_Integration_Test
{
    public class UserRegistrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private IUserServerConnection _serverConnection;

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
            var queryFromGenerator = GraphQLCodeGenerator<UserDTO, RegTestReponse>.GenerateMutationQuery("register", "userDTO", userDTO,response );

            // Call RegisterAndGetUser method of IUserServerConnection and get response data
            var responseData = await _serverConnection.RegisterAndGetUser(queryFromGenerator, client);

            // Assert response data has expected values
            Assert.Equal(HttpStatusCode.OK, responseData.ResponseCode);
            Assert.NotNull(responseData.PasswordHash);
            Assert.NotNull(responseData.PasswordSalt);
            Assert.NotEqual(0, responseData.UserID);
        }
        public class RegTestReponse
        {
            public string userID { get; set; }
            public string passwordHash { get; set; }
            public string passwordSalt { get; set; }
        }
    }

}