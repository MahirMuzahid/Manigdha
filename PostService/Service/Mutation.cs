using AutoMapper;
using PostService.Service.Repository;
using SharedModal.DTO;
using SharedModal.Modals;

namespace PostService.Service
{
    public class Mutation
    {
        private IProductCatagoryRepository _productCatagoryRepository;
        private ICatagoryTypeRepository _catagoryTypeRepository;
        public Mutation(IProductCatagoryRepository productCatagoryRepository , ICatagoryTypeRepository catagoryTypeRepository)
        {
            _productCatagoryRepository = productCatagoryRepository;
            _catagoryTypeRepository = catagoryTypeRepository;
        }

        #region ProductCatagory
        public async Task<Response> SetProductCatagory(string name)
        {          
            return await _productCatagoryRepository.Set(name);
        }
        public async Task<Response> UpdateProductCatagory(string name, int id)
        {
            return await _productCatagoryRepository.Update(name, id);
        }
        public async Task<Response> DeleteProductCatagory(int id)
        {
            return await _productCatagoryRepository.Delete(id);
        }
        #endregion

        #region Catagory Type
        public async Task<Response> SetCatagoryType(string name, int productCatagoryId)
        {
            return await _catagoryTypeRepository.Set(name, productCatagoryId);
        }
        public async Task<Response> UpdateCatagoryType(string name, int id, int productCatagoryId)
        {
            return await _catagoryTypeRepository.Update(name, id, productCatagoryId);
        }
        public async Task<Response> DeleteCatagoryType(int id)
        {
            return await _catagoryTypeRepository.Delete(id);
        }
        #endregion
    }
}
