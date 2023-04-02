using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using SharedModal.ClientServerConnection.Product_Catagory;
using SharedModal.ClientServerConnection.Catagory_Type;
using System.Net;

namespace PostServiceTestx
{
    public class PostServiceIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private IProductCatagoryServerConnection _productCatagoryServerConnection;
        private ICatagoryTypeServerConnection _catagoryTypeServerConnection;
        private int dltID = 8;
        private int cityID = 1;

        public PostServiceIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;

            // Create HttpClient using CreateClient method
            var client = _factory.CreateClient();

            // Create a new instance of ServiceCollection for dependency injection
            var services = new ServiceCollection();

            // Add scoped IUserServerConnection implementation to ServiceCollection

            services.AddScoped<IProductCatagoryServerConnection, ProductCatagoryServerConnection>();
            services.AddScoped<ICatagoryTypeServerConnection, CatagoryTypeServerConnection>();
            services.AddScoped<ICURDCall<ProductCatagory>, CURDCall<ProductCatagory>>();
            services.AddScoped<ICURDCall<CatagoryType>, CURDCall<CatagoryType>>();

            // Build the ServiceCollection and get the IUserServerConnection implementation
            var serviceProvider = services.BuildServiceProvider();
            _productCatagoryServerConnection = serviceProvider.GetService<IProductCatagoryServerConnection>();
            _catagoryTypeServerConnection = serviceProvider.GetService<ICatagoryTypeServerConnection>();
        }

        #region ProductCatagory 

        [Fact]
        public async Task AskProductCatagoryByID_GetProductCatagory()
        {
            var client = _factory.CreateClient();
            var query = "query{ productCatagoryByID( id: 1) { productCatagoryID, catagoryTypes { name } } }";
            var responseData = await _productCatagoryServerConnection.GetWithID(client, query, "productCatagoryByID");

            Assert.Equal(1, responseData.ProductCatagoryID);
        }

        [Fact]
        public async Task AskProductCatagory_GetProductCatagory()
        {
            var client = _factory.CreateClient();
            var query = "query{ productCatagory() { name, catagoryTypes { name }  } }";
            var responseData = await _productCatagoryServerConnection.Get(client, query, "productCatagory");

            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task SetProductCatagory_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ setProductCatagory ( name: \"From Test\"){ status }}";
            var responseData = await _productCatagoryServerConnection.Set(client, query, "setProductCatagory");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task UpdateProductCatagory_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ updateProductCatagory ( name: \" Changed Name \", id: 1){    status  }}";
            var responseData = await _productCatagoryServerConnection.Update(client, query, "updateProductCatagory");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        //[Fact]
        public async Task DeleteProductCatagory_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ deleteProductCatagory ( id: 1){ status }}";
            var responseData = await _productCatagoryServerConnection.Delete(client, query, "deleteProductCatagory");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        #endregion City

        #region CatagoryType 

        [Fact]
        public async Task AskCatagoryTypeByID_GetCatagoryType()
        {
            var client = _factory.CreateClient();

            var query = "query{ catagoryTypeByID( id: 1) { catagoryTypeID, productCatagory { name } } }";
            var responseData = await _catagoryTypeServerConnection.GetWithID(client, query, "catagoryTypeByID");

            Assert.Equal(1, responseData.CatagoryTypeID);
        }

        [Fact]
        public async Task AskCatagoryType_GetCatagoryType()
        {
            var client = _factory.CreateClient();

            var query = "query{ catagoryType() { name, productCatagory { name } } }";
            var responseData = await _catagoryTypeServerConnection.Get(client, query, "catagoryType");

            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task SetCatagoryType_GetResponse()
        {
            var client = _factory.CreateClient();

            var query = "mutation{ setCatagoryType ( name: \"From Test\", productCatagoryId: 1){ status }}";
            var responseData = await _catagoryTypeServerConnection.Set(client, query, "setCatagoryType");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task UpdateCatagoryType_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{\r\n   updateCatagoryType ( id: 1, name: \"ss\",  productCatagoryId: 1) {\r\n     status\r\n   }\r\n}";
            var responseData = await _catagoryTypeServerConnection.Update(client, query, "updateCatagoryType");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        //[Fact]
        public async Task DeleteCatagoryType_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ deleteCatagoryType ( id: 1){ status }}";
            var responseData = await _catagoryTypeServerConnection.Delete(client, query, "deleteCatagoryType");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        #endregion City
    }
}
