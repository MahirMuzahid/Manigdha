using SharedModal.Modals;

namespace PostService.Service
{
    public interface INonDegitalProductRequirmentsVerificationRepository
    {
        public Task<Response> Set(NonDigitalProductImageVerification nonDigitalProductImageVerification);
        public Task<Response> Update(NonDigitalProductImageVerification nonDigitalProductImageVerification);
        public Task<Response> Delete(int id);
    }
}
