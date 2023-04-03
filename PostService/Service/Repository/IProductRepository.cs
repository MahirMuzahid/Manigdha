using SharedModal.ClientServerConnection;
using SharedModal.DTO;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public interface IProductRepository
    {
        public Task<Response> Set(ProductDTO productDTO);
        public Task<Response> Update(ProductDTO productDTO);
        public Task<Response> Delete(int id);
    }
}
