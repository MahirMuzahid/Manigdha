
using AutoMapper;
using SharedModal.DTO;

namespace UserService.Mapper
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<UserDTO, SharedModal.Modals.User>();
        }
    }
}
