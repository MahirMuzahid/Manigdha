using AutoMapper;
using CommonCalls;
using Microsoft.IdentityModel.Tokens;
using SharedModal.DTO;
using SharedModal.Modals;
using System.Collections.Generic;

namespace PostService.Service.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IManager<Product> _manager;
        private IMapper _mapper;

        public ProductRepository(IManager<Product> manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<Response> Delete(int id)
        {
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.ProductID == id);
            var isDlt = await _manager.DeleteAsync(obj);
            if (!isDlt)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
        public async Task<Response> Set(ProductDTO productDTO)
        {
            var obj = _mapper.Map<Product>(productDTO);
            if (obj == null) { return new Response(System.Net.HttpStatusCode.OK); }
            var result = await _manager.AddAsync(obj);
            if (!result)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
        public async Task<Response> Update(ProductDTO productDTO)
        {          
            if (productDTO == null) { return new Response(System.Net.HttpStatusCode.NotFound); }
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.ProductID == productDTO.ProductID);
            if (obj == null) { return new Response("Product Not Found With ID", System.Net.HttpStatusCode.NotFound); }
            if(productDTO.CatagoryTypeID != 0) { obj.CatagoryTypeID = productDTO.CatagoryTypeID; }
            if (productDTO.AskingPrice != 0) { obj.AskingPrice = productDTO.AskingPrice; }
            if (productDTO.IsActive != obj.IsActive) { obj.IsActive = productDTO.IsActive; }
            if (productDTO.Description != obj.Description && !productDTO.Description.IsNullOrEmpty()) { obj.Description = productDTO.Description; }
            if (productDTO.Title != obj.Title && !productDTO.Title.IsNullOrEmpty()) { obj.Title = productDTO.Title; }

            var result = await _manager.UpdateAsync(obj);
            if (!result)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
    }
}
