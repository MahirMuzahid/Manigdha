using CommonCalls;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public class ProductCatagoryRepository : IProductCatagoryRepository
    {
        private IManager<ProductCatagory> _manager;

        public ProductCatagoryRepository(Manager<ProductCatagory> manager)
        {
            _manager = manager;
        }

        public async Task<CommonCalls.Response> Delete(ProductCatagory obj)
        {
            var isDlt = await _manager.DeleteAsync(obj);
            if (!isDlt)
            {
                return new CommonCalls.Response(System.Net.HttpStatusCode.NotFound);
            }
            return new CommonCalls.Response(System.Net.HttpStatusCode.OK);
        }

        public Task<ICollection<ProductCatagory>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCatagory> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CommonCalls.Response> Set(ProductCatagory obj)
        {
            var isDlt = await _manager.AddAsync(obj);
            if (!isDlt)
            {
                return new CommonCalls.Response(System.Net.HttpStatusCode.NotFound);
            }
            return new CommonCalls.Response(System.Net.HttpStatusCode.OK);
        }

        public Task<CommonCalls.Response> Update(ProductCatagory obj)
        {
            throw new NotImplementedException();
        }
    }
}