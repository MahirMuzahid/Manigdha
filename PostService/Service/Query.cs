using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IQueryable<ProductCatagory>> GetProductCatagory([Service] DataContext _context)
        {
            return _context.ProductCatagories.Include(u => u.CatagoryTypes).AsQueryable();
        }
        [UseProjection]
        public async Task<ProductCatagory> GetProductCatagoryByID([Service] DataContext _context, int id)
        {
            var result = await _context.ProductCatagories.Include(u => u.CatagoryTypes).FirstOrDefaultAsync(u => u.ProductCatagoryID == id);

            if (result == null) { return new ProductCatagory(); }
            return result;
        }
        #endregion

        #region Catagory Type
        [UseProjection]
        public async Task<IQueryable<CatagoryType>> GetCatagoryType([Service] DataContext _context)
        {
            return _context.CatagoryTypes.Include(u => u.ProductCatagory).AsQueryable();
        }
        [UseProjection]
        public async Task<CatagoryType> GetCatagoryTypeByID([Service] DataContext _context, int id)
        {
            var result = await _context.CatagoryTypes.Include(u => u.ProductCatagory).FirstOrDefaultAsync(u => u.CatagoryTypeID == id);

            if (result == null) { return new CatagoryType(); }
            return result;
        }
        #endregion
    }
}
