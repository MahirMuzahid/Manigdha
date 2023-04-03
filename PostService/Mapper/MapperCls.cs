using AutoMapper;
using SharedModal.DTO;
using SharedModal.Modals;
using SharedModal.ReponseModal;

namespace PostService.Mapper
{
    public class MapperCls: Profile
    {
        public MapperCls()
        {
           CreateMap<ProductDTO, Product>();
        }
    }
}
