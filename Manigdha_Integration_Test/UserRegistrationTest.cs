using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SharedModal.ClientServerConnection;
using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.ClientServerConnection.Division_Server_Connection;
using SharedModal.DTO;
using SharedModal.Modals;
using System.Net;
using Response = SharedModal.ReponseModal.Response;

namespace Manigdha_Integration_Test
{
    public class UserRegistrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private IUserServerConnection _serverConnection;
        private ICityServerConnectio _cityServerConnection;
        private IDivisioServerConnection _divisionServerConnection;
        private int dltID = 8;
        private int cityID = 1;

        public UserRegistrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;

            // Create HttpClient using CreateClient method
            var client = _factory.CreateClient();

            // Create a new instance of ServiceCollection for dependency injection
            var services = new ServiceCollection();

            // Add scoped IUserServerConnection implementation to ServiceCollection
            services.AddScoped<IUserServerConnection, UserServerConnection>();
            services.AddScoped<ICityServerConnectio, CityServerConnection>();
            services.AddScoped<IDivisioServerConnection, DivisionServerConnection>();
            services.AddScoped<ICURDCall<City>, CURDCall<City>>();
            services.AddScoped<ICURDCall<Division>, CURDCall<Division>>();

            // Build the ServiceCollection and get the IUserServerConnection implementation
            var serviceProvider = services.BuildServiceProvider();
            _serverConnection = serviceProvider.GetService<IUserServerConnection>();
            _cityServerConnection = serviceProvider.GetService<ICityServerConnectio>();
            _divisionServerConnection = serviceProvider.GetService<IDivisioServerConnection>();
        }

        [Fact]
        public async Task Register_ValidData_ReturnsNewUserFromServer()
        {
            // Create HttpClient using CreateClient method
            var client = _factory.CreateClient();
            Random r = new Random();

            // GraphQL mutation query to register a new user
            var userDTO = new UserDTO
            {
                CityID = 3,
                Name = "User",
                Password = "123",
                Email = "gg123@gmail.com",
                PhoneNumber = "" + r.Next(1, 100)
            };
            var query = GraphQLCodeGenerator<UserDTO, RegTestReponse>.Parameter_Multiple_Return_Object("register", "userDTO", userDTO);

            // Call RegisterAndGetUser method of IUserServerConnection and get response data
            var responseData = await _serverConnection.RegisterAndGetUser(client, query);

            // Assert response data has expected values
            Assert.Equal(HttpStatusCode.OK, responseData.ResponseCode);
            Assert.NotNull(responseData.PasswordHash);
            Assert.NotNull(responseData.PasswordSalt);
            Assert.NotEqual(0, responseData.UserID);
            dltID = responseData.UserID;
            //await UserID_DeleteFromDatabase_Reponse();
        }

        [Fact]
        public async Task UserID_DeleteFromDatabase_Reponse()
        {
            var client = _factory.CreateClient();

            var response = new Response();
            var query = GraphQLCodeGenerator<int, Response>.Parameter_Single_Return_Object("deleteUser", "userID", 45, response);

            // Call RegisterAndGetUser method of IUserServerConnection and get response data
            var responseData = await _serverConnection.DeleteUser(client, query, "deleteUser");

            // Assert response data has expected values
            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        //[Fact]
        public async Task ClearUserTable()
        {
            for (int i = 0; i < 0; i++)
            {
                dltID = i;
                await UserID_DeleteFromDatabase_Reponse();
            }
            Assert.True(true);
        }

        [Fact]
        public async Task UserLogin_GetLoginToken()
        {
            var client = _factory.CreateClient();

            var userDTO = new UserLoginDTO()
            {
                LoginInfo = "01",
                Password = "123"
            };
            var query = GraphQLCodeGenerator<UserLoginDTO, Response>.Parameter_Multiple_Return_Object("login", "userLoginDTO", userDTO);

            // Call RegisterAndGetUser method of IUserServerConnection and get response data
            var responseData = await _serverConnection.LoginUser(client, query, "login");

            // Assert response data has expected values
            Assert.Equal(HttpStatusCode.OK, responseData.Status);
            Assert.NotNull(responseData.ReturnString);
            Assert.NotNull(responseData.ReturnStringTwo);
            Assert.NotNull(responseData.ReturnStringThree);
        }

        [Fact]
        public async Task UserLogout_ReturnOK()
        {
            var client = _factory.CreateClient();
            var response = new Response();
            var query = GraphQLCodeGenerator<int, Response>.Parameter_Single_Return_Object("logout", "userID", dltID, response);

            // Call RegisterAndGetUser method of IUserServerConnection and get response data
            var responseData = await _serverConnection.LogoutUser(client, query, "logout");

            // Assert response data has expected values
            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task AskForRefreshToken_NewRefreshTokenAndJWTToken()
        {
            var client = _factory.CreateClient();
            var rtp = new RefreshTokenParameter()
            {
                userID = 44,
                refreshToken = "EpbcWhPvQwx28doJdmfw2yEH3YDATx0yzBwxn8GzJOINkU+jzE2QeM5PvC4u63GPJ3YmToxWeWuqmB9SwjoRjw=="
            };

            var query = GraphQLCodeGenerator<RefreshTokenParameter, Response>.Parameter_Multiple_Return_Object("refreshToken", rtp);

            // Call RegisterAndGetUser method of IUserServerConnection and get response data
            var responseData = await _serverConnection.RefreshToken(client, query, "refreshToken");

            // Assert response data has expected values
            Assert.Equal(HttpStatusCode.OK, responseData.Status);
            Assert.NotNull(responseData.ReturnString);
            Assert.NotNull(responseData.ReturnStringTwo);
        }

        public class RefreshTokenParameter
        {
            public int userID { get; set; }
            public string? refreshToken { get; set; }
        }

        public class RegTestReponse
        {
            public string userID { get; set; }
            public string passwordHash { get; set; }
            public string passwordSalt { get; set; }
        }

        [Fact]
        public async Task AskCityByID_GetCity()
        {
            var client = _factory.CreateClient();

            var query = "query{ cityByID( cityID: " + cityID + ") { cityID, name, divisionID, division { divisionName } } }";
            var responseData = await _cityServerConnection.GetCityWithID(client, query, "cityByID");

            Assert.Equal(cityID, responseData.CityID);
        }

        [Fact]
        public async Task AskCity_GetCity()
        {
            var client = _factory.CreateClient();

            var query = "query{ city() { cityID, name, divisionID, division { divisionName } } }";
            var responseData = await _cityServerConnection.GetCity(client, query, "city");

            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task SetCity_GetResponse()
        {
            var client = _factory.CreateClient();

            var query = "mutation{\r\n setCity ( name: \"From Test\", divisionID: 1){\r\n     status\r\n   }\r\n}";
            var responseData = await _cityServerConnection.SetCity(client, query, "setCity");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task UpdateCity_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ updateCity ( cityID: 1, name: \" Changed Name \", divisionID : 2){    status  }}";
            var responseData = await _cityServerConnection.UpdateCity(client, query, "updateCity");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task DeleteCity_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ deleteCity ( cityID: 2){ status }}";
            var responseData = await _cityServerConnection.DeleteCity(client, query, "deleteCity");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task AskDivisionByID_GetDivision()
        {
            var client = _factory.CreateClient();

            var query = "query{ divisionByID( divisionID: " + 1 + ") { divisionID, divisionName, cities { name } } }";
            var responseData = await _divisionServerConnection.GetWithID(client, query, "divisionByID");

            Assert.Equal(1, responseData.DivisionID);
        }

        [Fact]
        public async Task AskDivision_GetDivision()
        {
            var client = _factory.CreateClient();

            var query = "query{ division() { divisionID, divisionName, cities { name } } }";
            var responseData = await _divisionServerConnection.Get(client, query, "division");

            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task SetDivision_GetResponse()
        {
            var client = _factory.CreateClient();

            var query = "mutation{ setDivision ( name: \"From Test\"){ status }}";
            var responseData = await _divisionServerConnection.Set(client, query, "setDivision");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task UpdateDivision_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ updateDivision ( name: \" Changed Name \", divisionID: 1){    status  }}";
            var responseData = await _divisionServerConnection.Update(client, query, "updateDivision");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        //[Fact]
        public async Task DeleteDivision_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ deleteDivision ( divisionID: 1){ status }}";
            var responseData = await _divisionServerConnection.Delete(client, query, "divisionID");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }
    }
}