using AutoMapper;
using PostService.Service.Repository;
using SharedModal.DTO;
using SharedModal.Modals;

namespace PostService.Service
{
    public class Mutation
    {
        private IProductCatagoryRepository _productCatagoryRepository;
        public Mutation(IProductCatagoryRepository productCatagoryRepository, IMapper mapper)
        {
            _productCatagoryRepository = productCatagoryRepository;
        }
        public async Task<Response> SetProductCatagory(string name)
        {          
            return await _productCatagoryRepository.Set(name);
        }
        public async Task<Response> UpdateProductCatagory(string name)
        {
            return await _productCatagoryRepository.Update(name);
        }
        public async Task<Response> DeleteProductCatagory(int id)
        {
            return await _productCatagoryRepository.Delete(id);
        }
    }
}
