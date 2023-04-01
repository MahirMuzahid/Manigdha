using SharedModal.Modals;

namespace PostService.Service
{
    public class Query
    {
        [UseProjection]
        public async Task<List<Product>> GetProducts([Service] DataContext _context)
        {
            return await _context.Products.Include(u => u.User).Include(p => p.CatagoryType).ToListAsync();
        }


    }
}
