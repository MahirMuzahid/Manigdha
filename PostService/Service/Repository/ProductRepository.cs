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
            var obj = _mapper.Map<Product>(productDTO);
            if (obj == null) { return new Response(System.Net.HttpStatusCode.OK); }
            var result = await _manager.UpdateAsync(obj);
            if (!result)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
    }
}
