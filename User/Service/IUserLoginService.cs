using SharedModal.ReponseModal;

namespace UserService.Service
{
    public interface IUserLoginService
    {
        public Response Login(SharedModal.Modals.User user);
        public Response RefreshToken(SharedModal.Modals.User user, string refreshtoken);
    
    }
}
