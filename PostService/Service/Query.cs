using AutoMapper;
using PostService.Service.Repository;
using SharedModal.Modals;

namespace PostService.Service
{
    public class Query
    {
        private IProductCatagoryRepository _productCatagoryRepository;
        public Query(IProductCatagoryRepository productCatagoryRepository, IMapper mapper)
        {
            _productCatagoryRepository = productCatagoryRepository;
        }
        [UseProjection]
        public async Task<List<Product>> GetProducts([Service] DataContext _context)
        {
            return await _context.Products.Include(u => u.User).Include(p => p.CatagoryType).ToListAsync();
        }


    }
}
