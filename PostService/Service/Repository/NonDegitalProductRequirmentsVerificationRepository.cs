using CommonCalls;
using SharedModal.DTO;
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
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.Id == nonDigitalProductImageVerification.Id);
            if (obj == null) { return new Response("Image verification Not Found With ID", System.Net.HttpStatusCode.NotFound); }

            if (nonDigitalProductImageVerification.ProductID != 0) { obj.Id = nonDigitalProductImageVerification.Id; }

            if (nonDigitalProductImageVerification.FrontSideImageURL != obj.FrontSideImageURL && !string.IsNullOrEmpty(nonDigitalProductImageVerification.FrontSideImageURL)) 
            { obj.FrontSideImageURL = nonDigitalProductImageVerification.FrontSideImageURL; }

            if (nonDigitalProductImageVerification.BackSideImageURL != obj.BackSideImageURL && !string.IsNullOrEmpty(nonDigitalProductImageVerification.BackSideImageURL))
            { obj.BackSideImageURL = nonDigitalProductImageVerification.BackSideImageURL; }

            if (nonDigitalProductImageVerification.LaftSideImageURL != obj.LaftSideImageURL && !string.IsNullOrEmpty(nonDigitalProductImageVerification.LaftSideImageURL)) 
            { obj.LaftSideImageURL = nonDigitalProductImageVerification.LaftSideImageURL; }

            if (nonDigitalProductImageVerification.RightSideImageURL != obj.RightSideImageURL && !string.IsNullOrEmpty(nonDigitalProductImageVerification.RightSideImageURL)) 
            { obj.RightSideImageURL = nonDigitalProductImageVerification.RightSideImageURL; }

            if (nonDigitalProductImageVerification.UpperSideImageURL != obj.UpperSideImageURL && !string.IsNullOrEmpty(nonDigitalProductImageVerification.UpperSideImageURL)) 
            { obj.UpperSideImageURL = nonDigitalProductImageVerification.UpperSideImageURL; }

            if (nonDigitalProductImageVerification.LowerSideImageURL != obj.LowerSideImageURL && !string.IsNullOrEmpty(nonDigitalProductImageVerification.LowerSideImageURL))
            { obj.LowerSideImageURL = nonDigitalProductImageVerification.LowerSideImageURL; }



            var result = await _manager.UpdateAsync(obj);
            if (!result)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
    }
}
