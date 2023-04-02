using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostService.Service.Repository;
using SharedModal.Modals;

namespace PostService.Service
{
    public class Query
    {

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
        public async Task<IQueryable<CatagoryType>> GetProduct([Service] DataContext _context)
        {
            return _context.CatagoryTypes.Include(u => u.ProductCatagory).AsQueryable();
        }
        [UseProjection]
        public async Task<CatagoryType> GetProductByID([Service] DataContext _context, int id)
        {
            var result = await _context.CatagoryTypes.Include(u => u.ProductCatagory).FirstOrDefaultAsync(u => u.CatagoryTypeID == id);

            if (result == null) { return new CatagoryType(); }
            return result;
        }
        #endregion

        #region Product
        [UseProjection]
        public  IQueryable<Product> GetProducte([Service] DataContext _context)
        {
            return  _context.Products.Include(u => u.User).Include(c => c.CatagoryType).AsQueryable();
        }
        [UseProjection]
        public async Task<Product> GetProductById([Service] DataContext _context, int id)
        {
            var result = await _context.Products.Include(u => u.User).Include(c => c.CatagoryType).FirstOrDefaultAsync(u => u.ProductID == id);

            if (result == null) { return new Product(); }
            return result;
        }
        [UseProjection]
        public  async Task<List<Product>> GetProductByUserId([Service] DataContext _context, int id)
        {
            var result = await _context.Products.Include(u => u.User).Include(c => c.CatagoryType).Where(u => u.UserID == id).ToListAsync();

            if (result == null) { return new List<Product>(); }
            return result;
        }
        [UseProjection]
        public async Task<List<Product>> GetProductProductId([Service] DataContext _context, int id)
        {
            var result = await _context.Products.Include(u => u.User).Include(c => c.CatagoryType).Where(u => u.CatagoryTypeID == id).ToListAsync();

            if (result == null) { return new List<Product>(); }
            return result;
        }
        #endregion
    }
}
