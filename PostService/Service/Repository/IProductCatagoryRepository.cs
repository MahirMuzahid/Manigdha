using CommonCalls;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public interface IProductCatagoryRepository
    {
        public Task<ICollection<ProductCatagory>> Get();
        public Task<Response> Set(string name);
        public Task<ProductCatagory> GetByID(int id);
        public Task<Response> Update(ProductCatagory obj);
        public Task<Response> Delete(ProductCatagory obj);
    }
}
