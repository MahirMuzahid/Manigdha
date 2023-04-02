using AutoMapper;
using SharedModal.DTO;
using SharedModal.ReponseModal;

namespace PostService.Mapper
{
    public class ReponseMapper: Profile
    {
        public ReponseMapper()
        {
           CreateMap<Response, Response>();
        }
    }
}
