using SharedModal.ClientServerConnection;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public interface IProductRepository
    {
        public Task<ICollection<Product>> Get();
        public Task<Response> Set(string name, int id);
        public Task<Product> GetByID(int id);
        public Task<Response> Update(string name, int id, int productCatagoryId);
        public Task<Response> Delete(int id);
    }
}
