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
        private IProductRepository _productRepository;
        public Mutation(IProductCatagoryRepository productCatagoryRepository , ICatagoryTypeRepository catagoryTypeRepository, IProductRepository productRepository)
        {
            _productCatagoryRepository = productCatagoryRepository;
            _catagoryTypeRepository = catagoryTypeRepository;
            _productRepository = productRepository;

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

        #region Product
        public async Task<Response> SetProduct(ProductDTO productDTO)
        {
            return await _productRepository.Set(productDTO);
        }
        public async Task<Response> UpdateProduct(ProductDTO productDTO)
        {
            return await _productRepository.Update(productDTO);
        }
        public async Task<Response> DeleteProduct(int id)
        {
            return await _productRepository.Delete(id);
        }
        #endregion
    }
}
