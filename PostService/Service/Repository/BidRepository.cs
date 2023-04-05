using CommonCalls;
using Microsoft.IdentityModel.Tokens;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public class BidRepository : IBidRepository
    {
        private IManager<BidHistory> _manager;

        public BidRepository(IManager<BidHistory> manager)
        {
            _manager = manager;
        }
       
        public async Task<Response> Delete(int id)
        {
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.BidHistoryID == id);
            var isDlt = await _manager.DeleteAsync(obj);
            if (!isDlt)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
        public async Task<Response> Set(int BidAmount, int UserId, int ProductId)
        {
            var obj = new BidHistory() { BidAmount = BidAmount, UserID = UserId, ProductID = ProductId };
            var isDlt = await _manager.AddAsync(obj);
            if (!isDlt)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
        public async Task<Response> Update(string name, int id)
        {
            if (name.IsNullOrEmpty()) { return new Response("Name Not Found", System.Net.HttpStatusCode.NotFound); }
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.ProductCatagoryID == id);
            if (obj == null) { return new Response("User Not Found With ID", System.Net.HttpStatusCode.NotFound); }
            obj.Name = name;
            var isUpdate = await _manager.UpdateAsync(obj);
            if (!isUpdate)
            {
                return new Response("Update no done", System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
    }
}
