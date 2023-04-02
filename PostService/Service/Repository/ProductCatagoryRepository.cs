using CommonCalls;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public class ProductCatagoryRepository : IProductCatagoryRepository
    {
        private IManager<ProductCatagory> _manager;

        public ProductCatagoryRepository(IManager<ProductCatagory> manager)
        {
            _manager = manager;
        }

        public async Task<Response> Delete(ProductCatagory obj)
        {
            var isDlt = await _manager.DeleteAsync(obj);
            if (!isDlt)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }

        public Task<ICollection<ProductCatagory>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCatagory> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Set(string name)
        {
            var obj = new ProductCatagory() { Name = name};
            var isDlt = await _manager.AddAsync(obj);
            if (!isDlt)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }

        public Task<Response> Update(ProductCatagory obj)
        {
            throw new NotImplementedException();
        }
    }
}