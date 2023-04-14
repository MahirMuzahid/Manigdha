using CommonCalls;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public class NonDegitalProductRequirmentsVerificationRepository : INonDegitalProductRequirmentsVerificationRepository
    {
        private IManager<NonDigitalProductImageVerification> _manager;

        public NonDegitalProductRequirmentsVerificationRepository( IManager<NonDigitalProductImageVerification> manager)
        {
            _manager = manager;
        }
        public async Task<Response> Delete(int id)
        {
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.Id == id);
            var result = await _manager.DeleteAsync(obj);
            if (!result)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }

        public async Task<Response> Set(NonDigitalProductImageVerification nonDigitalProductImageVerification)
        {
            try
            {
                var result = await _manager.AddAsync(nonDigitalProductImageVerification);
                if (!result)
                {
                    return new Response(System.Net.HttpStatusCode.NotFound);
                }
                return new Response(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex) 
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
           
            
        }

        public async Task<Response> Update(NonDigitalProductImageVerification nonDigitalProductImageVerification)
        {
            var result = await _manager.UpdateAsync(nonDigitalProductImageVerification);
            if (!result)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
    }
}
