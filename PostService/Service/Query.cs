using AutoMapper;
using PostService.Service.Repository;
using SharedModal.Modals;

namespace PostService.Service
{
    public class Query
    {
        private IProductCatagoryRepository _productCatagoryRepository;
        private ICatagoryTypeRepository _catagoryTypeRepository;
        public Query(IProductCatagoryRepository productCatagoryRepository, ICatagoryTypeRepository catagoryTypeRepository)
        {
            _productCatagoryRepository = productCatagoryRepository;
            _catagoryTypeRepository = catagoryTypeRepository;
        }

        #region ProductCatagory
        [UseProjection]
        public async Task<ICollection<ProductCatagory>> GetProductCatagory()
        {
            return await _productCatagoryRepository.Get();
        }
        [UseProjection]
        public async Task<ProductCatagory> GetProductCatagoryByID(int id)
        {
            return await _productCatagoryRepository.GetByID(id);
        }
        #endregion

        #region Catagory Type
        [UseProjection]
        public async Task<ICollection<CatagoryType>> GetCatagoryType()
        {
            return await _catagoryTypeRepository.Get();
        }
        [UseProjection]
        public async Task<CatagoryType> GetCatagoryTypeByID(int id)
        {
            return await _catagoryTypeRepository.GetByID(id);
        }
        #endregion

    }
}
