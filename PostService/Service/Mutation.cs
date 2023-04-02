using AutoMapper;
using PostService.Service.Repository;
using SharedModal.DTO;
using SharedModal.Modals;

namespace PostService.Service
{
    public class Mutation
    {
        private IProductCatagoryRepository _productCatagoryRepository;
        public Mutation(IProductCatagoryRepository productCatagoryRepository, IMapper mapper)
        {
            _productCatagoryRepository = productCatagoryRepository;
        }
        public Response Test( string s)
        {
            return new Response(s, System.Net.HttpStatusCode.OK);
        }


        public async Task<Response> SetProductCatagory(string name)
        {          
            return await _productCatagoryRepository.Set(name);
        }
    }
}
