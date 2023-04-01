using AutoMapper;
using PostService.Service.Repository;
using SharedModal.DTO;
using SharedModal.Modals;

namespace PostService.Service
{
    public class Mutation
    {
        private IProductCatagoryRepository _productCatagoryRepository;
        private IMapper _mapper;
        public Mutation(IProductCatagoryRepository productCatagoryRepository, IMapper mapper)
        {
            _productCatagoryRepository = productCatagoryRepository;
            _mapper = mapper;
        }
        public Response Test( string s)
        {
            return new Response(s, System.Net.HttpStatusCode.OK);
        }


        public async Task<Response> SetProductCatagory(ProductCatagory product)
        {
            var obj = _mapper.Map<Response>(await _productCatagoryRepository.Set(product));
            return obj;
        }
    }
}
