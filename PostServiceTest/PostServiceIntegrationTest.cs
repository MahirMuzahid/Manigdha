using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using SharedModal.ClientServerConnection.Product_Catagory;
using SharedModal.ClientServerConnection.Catagory_Type;
using System.Net;
using SharedModal.ClientServerConnection.Product_Server_Connection;

namespace PostServiceTestx
{
    public class PostServiceIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private IProductCatagoryServerConnection _productCatagoryServerConnection;
        private ICatagoryTypeServerConnection _catagoryTypeServerConnection;
        private IProductServerConnection  _productServerConnection;
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
            services.AddScoped<IProductServerConnection, ProductServerConnection>();
            services.AddScoped<ICURDCall<ProductCatagory>, CURDCall<ProductCatagory>>();
            services.AddScoped<ICURDCall<CatagoryType>, CURDCall<CatagoryType>>();

            // Build the ServiceCollection and get the IUserServerConnection implementation
            var serviceProvider = services.BuildServiceProvider();
            _productCatagoryServerConnection = serviceProvider.GetService<IProductCatagoryServerConnection>();
            _catagoryTypeServerConnection = serviceProvider.GetService<ICatagoryTypeServerConnection>();
            _productServerConnection = serviceProvider.GetService<IProductServerConnection>();
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
            var query = "mutation{ updateCatagoryType ( id: 1, name: \"gg\",  productCatagoryId: 1) {     status   }}";
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

        #region Product 

        [Fact]
        public async Task AskProductByID_GetProduct()
        {
            var client = _factory.CreateClient();

            var query = "query{ ProductByID( id: 1) { ProductID, productCatagory { name } } }";
            var responseData = await _productServerConnection.GetWithID(client, query, "ProductByID");

            Assert.Equal(1, responseData.ProductID);
        }

        [Fact]
        public async Task AskProduct_GetProduct()
        {
            var client = _factory.CreateClient();

            var query = "query{ Product() { name, productCatagory { name } } }";
            var responseData = await _productServerConnection.Get(client, query, "Product");

            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task SetProduct_GetResponse()
        {
            var client = _factory.CreateClient();

            var query = "mutation{ setProduct ( name: \"From Test\", productCatagoryId: 1){ status }}";
            var responseData = await _productServerConnection.Set(client, query, "setProduct");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task UpdateProduct_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ updateProduct ( id: 1, name: \"gg\",  productCatagoryId: 1) {     status   }}";
            var responseData = await _productServerConnection.Update(client, query, "updateProduct");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        //[Fact]
        public async Task DeleteProduct_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ deleteProduct ( id: 1){ status }}";
            var responseData = await _productServerConnection.Delete(client, query, "deleteProduct");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        #endregion City
    }
}
