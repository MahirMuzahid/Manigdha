using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public interface ICatagoryTypeRepository
    {
        public Task<ICollection<CatagoryType>> Get();
        public Task<Response> Set(string name, int id);
        public Task<CatagoryType> GetByID(int id);
        public Task<Response> Update(string name, int id, int productCatagoryId);
        public Task<Response> Delete(int id);
    }
}
