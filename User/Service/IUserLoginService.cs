namespace UserService.Service
{
    public interface IUserLoginService
    {
        public SharedModal.ReponseModal.Response Login(SharedModal.Modals.User user);
    }
}
