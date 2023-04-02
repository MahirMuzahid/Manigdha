using CommonCalls;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public interface IProductCatagoryRepository
    {
        public Task<ICollection<ProductCatagory>> Get();
        public Task<Response> Set(string name);
        public Task<ProductCatagory> GetByID(int id);
        public Task<Response> Update(string name, int id);
        public Task<Response> Delete(int id);
    }
}
