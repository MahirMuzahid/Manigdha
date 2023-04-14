using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using SharedModal.ClientServerConnection.Product_Catagory;
using SharedModal.ClientServerConnection.Catagory_Type;
using System.Net;
using SharedModal.ClientServerConnection.Product_Server_Connection;
using SharedModal.ClientServerConnection.Bid_History_Server_Connection;
using SharedModal.ClientServerConnection.Non_Digital_Product_ImageVerification;

namespace PostServiceTestx
{
    public class PostServiceIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private IProductCatagoryServerConnection _productCatagoryServerConnection;
        private ICatagoryTypeServerConnection _catagoryTypeServerConnection;
        private IProductServerConnection  _productServerConnection;
        private IBidHistoryServerConnection _bidHistoryServerConnection;
        private INonDigitalProductImageVerificationServerConnection _nonDigitalProductImageVerificationServerConnection;

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
            services.AddScoped<IBidHistoryServerConnection, BidHostoryServerConnection>();
            services.AddScoped<INonDigitalProductImageVerificationServerConnection, NonDigitalProductImageVerificationServerConnection>();

            services.AddScoped<ICURDCall<ProductCatagory>, CURDCall<ProductCatagory>>();
            services.AddScoped<ICURDCall<CatagoryType>, CURDCall<CatagoryType>>();
            services.AddScoped<ICURDCall<Product>, CURDCall<Product>>();
            services.AddScoped<ICURDCall<BidHistory>, CURDCall<BidHistory>>();
            services.AddScoped<ICURDCall<NonDigitalProductImageVerification>, CURDCall<NonDigitalProductImageVerification>>();

            // Build the ServiceCollection and get the IUserServerConnection implementation
            var serviceProvider = services.BuildServiceProvider();

            _productCatagoryServerConnection = serviceProvider.GetService<IProductCatagoryServerConnection>();
            _catagoryTypeServerConnection = serviceProvider.GetService<ICatagoryTypeServerConnection>();
            _productServerConnection = serviceProvider.GetService<IProductServerConnection>();
            _bidHistoryServerConnection = serviceProvider.GetService<IBidHistoryServerConnection>();
            _nonDigitalProductImageVerificationServerConnection = serviceProvider.GetService<INonDigitalProductImageVerificationServerConnection>();
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

            var query = "query{ productById( id: 1) { productID, catagoryType { name } } }";
            var responseData = await _productServerConnection.GetWithID(client, query, "productById");

            Assert.Equal(1, responseData.ProductID);
        }

        [Fact]
        public async Task AskProduct_GetProduct()
        {
            var client = _factory.CreateClient();

            var query = "query{ producte() { productID, catagoryType { name } } }";
            var responseData = await _productServerConnection.Get(client, query, "producte");

            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task SetProduct_GetResponse()
        {
            var client = _factory.CreateClient();

            var query = "mutation{ setProduct ( productDTO: { title: \"From Test\", description: \"From Test\" , askingPrice: 1000, userID: 48 ,catagoryTypeID: 1 , isActive: true}){ status }}";
            var responseData = await _productServerConnection.Set(client, query, "setProduct");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task UpdateProduct_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ updateProduct ( productDTO: \r\n{ productID: 1, title: \"From Test Update\", description: \"From Test Update\" , askingPrice: 0,catagoryTypeID: 1 , isActive: true})\r\n{ status }}";
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

        #region BidHistory 

        [Fact]
        public async Task AskBidHistoryByID_GetBidHistory()
        {
            var client = _factory.CreateClient();

            var query = "query{bidHistoryWithID( id: 1) {bidHistoryID}}";
            var responseData = await _bidHistoryServerConnection.GetWithID(client, query, "bidHistoryWithID");

            Assert.Equal(1, responseData.BidHistoryID);
        }

        [Fact]
        public async Task AskBidHistory_GetBidHistory()
        {
            var client = _factory.CreateClient();

            var query = "query{ bidHistory() { bidHistoryID } }";
            var responseData = await _bidHistoryServerConnection.Get(client, query, "bidHistory");

            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task SetBidHistory_GetResponse()
        {
            var client = _factory.CreateClient();
            //int bidAmount, int userId, int productId
            var query = "mutation{ setBidHistory(  bidAmount: 50, productId : 1, userId: 48){ status}}";
            var responseData = await _bidHistoryServerConnection.Set(client, query, "setBidHistory");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task UpdateBidHistory_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ updateBidHistory(  bidAmount: 100, id : 1){ status}}";
            var responseData = await _bidHistoryServerConnection.Update(client, query, "updateBidHistory");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        //[Fact]
        public async Task DeleteBidHistory_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation{ deleteBidHistory ( id: 1){ status }}";
            var responseData = await _bidHistoryServerConnection.Delete(client, query, "deleteBidHistory");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        #endregion City

        #region BidHistory 

        [Fact]
        public async Task AskNonDigitalProductImageVerificationByID_GetNonDigitalProductImageVerification()
        {
            var client = _factory.CreateClient();

            var query = "query {\r\n\tnonDigitalProductImageWithID(id: 1) {\r\n\t\tid\r\n\t}\r\n}";
            var responseData = await _nonDigitalProductImageVerificationServerConnection.GetWithID(client, query, "nonDigitalProductImageWithID");

            Assert.Equal(1, responseData.Id);
        }

        [Fact]
        public async Task AskNonDigitalProductImageVerification_GetNonDigitalProductImageVerification()
        {
            var client = _factory.CreateClient();

            var query = "query {\r\n\tnonDigitalProductImage {\r\n\t\tid\r\n\t}\r\n}";
            var responseData = await _nonDigitalProductImageVerificationServerConnection.Get(client, query, "nonDigitalProductImage");

            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task SetNonDigitalProductImageVerification_GetResponse()
        {
            var client = _factory.CreateClient();
            //int bidAmount, int userId, int productId
            var query = "mutation {\r\n\tsetNonDigitalProductImage(nonDigitalProductImageVerification: " +
                "{id: 0,upperSideImageURL: \"string\", lowerSideImageURL: \"string\", laftSideImageURL: \"string\"," +
                " rightSideImageURL: \"string\", frontSideImageURL: \"string\", backSideImageURL: \"string\", productID: 1 })" +
                " {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            var responseData = await _nonDigitalProductImageVerificationServerConnection.Set(client, query, "setNonDigitalProductImage");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        [Fact]
        public async Task UpdateNonDigitalProductImageVerification_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation {\r\n\tupdateNonDigitalProductImage(nonDigitalProductImageVerification: " +
                "{ id: 1, upperSideImageURL: \"string\", lowerSideImageURL: \"string\", laftSideImageURL: \"string\", rightSideImageURL: \"string\", " +
                "frontSideImageURL: \"string\", backSideImageURL: \"string\", productID: 1 }) " +
                "{\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            var responseData = await _nonDigitalProductImageVerificationServerConnection.Update(client, query, "updateNonDigitalProductImage");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        //[Fact]
        public async Task DeleteNonDigitalProductImageVerification_GetResponse()
        {
            var client = _factory.CreateClient();
            var query = "mutation {\r\n\tdeleteNonDigitalProductImage(id: 1) " +
                "{\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            var responseData = await _nonDigitalProductImageVerificationServerConnection.Delete(client, query, "deleteNonDigitalProductImage");

            Assert.Equal(HttpStatusCode.OK, responseData.Status);
        }

        #endregion City
    }
}
