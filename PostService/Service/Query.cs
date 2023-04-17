using AutoMapper;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using PostService.Service.Repository;
using SharedModal.Enums;
using SharedModal.Modals;
using System.Data;

namespace PostService.Service
{
    public class Query
    {

        #region ProductCatagory
#if DEBUG
#else
[Authorize(Roles = new string[] { "User" })]
#endif
        [UseProjection]
        public async Task<IQueryable<ProductCatagory>> GetProductCatagory([Service] DataContext _context)
        {
            return _context.ProductCatagories.Include(u => u.CatagoryTypes).AsQueryable();
        }
#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif
        [UseProjection]
        public async Task<ProductCatagory> GetProductCatagoryByID([Service] DataContext _context, int id)
        {
            var result = await _context.ProductCatagories.Include(u => u.CatagoryTypes).FirstOrDefaultAsync(u => u.ProductCatagoryID == id);

            if (result == null) { return new ProductCatagory(); }
            return result;
        }
        #endregion

        #region Catagory Type
#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif
        [UseProjection]
        public async Task<IQueryable<CatagoryType>> GetProduct([Service] DataContext _context)
        {
            return _context.CatagoryTypes.Include(u => u.ProductCatagory).AsQueryable();
        }
#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif
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
        public IQueryable<Product> GetProducte([Service] DataContext _context)
        {
            return _context.Products.Include(u => u.User).Include(c => c.CatagoryType).AsQueryable();
        }
        [UseProjection]
        public async Task<Product> GetProductById([Service] DataContext _context, int id)
        {
            var result = await _context.Products.Include(u => u.User).Include(c => c.CatagoryType).FirstOrDefaultAsync(u => u.ProductID == id);

            if (result == null) { return new Product(); }
            return result;
        }
        [UseProjection]
        public async Task<List<Product>> GetProductByUserId([Service] DataContext _context, int id)
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

        #region Bid History
        [UseProjection]
        public IQueryable<BidHistory> GetBidHistory([Service] DataContext _context)
        {
            return _context.BidHistories.Include(u => u.User).Include(c => c.Product).AsQueryable();
        }
        [UseProjection]
        public async Task<BidHistory> GetBidHistoryWithID([Service] DataContext _context, int id)
        {
            var result = await _context.BidHistories.Include(u => u.User).Include(c => c.Product).FirstOrDefaultAsync(u => u.BidHistoryID == id);

            if (result == null) { return new BidHistory(); }
            return result;
        }

        #endregion

        #region NonDigitalProductImageRepository
        [UseProjection]
        public IQueryable<NonDigitalProductImageVerification> GetNonDigitalProductImage([Service] DataContext _context)
        {
            return _context.NonDigitalProductImageVerifications.Include(c => c.Product).AsQueryable();
        }
        [UseProjection]
        public async Task<NonDigitalProductImageVerification> GetNonDigitalProductImageWithID([Service] DataContext _context, int id)
        {
            var result = await _context.NonDigitalProductImageVerifications.Include(c => c.Product).FirstOrDefaultAsync(u => u.Id == id);

            if (result == null) { return new NonDigitalProductImageVerification(); }
            return result;
        }

        #endregion


    }
}
