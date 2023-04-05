namespace PostService.Service.Repository
{
    public interface IBidRepository
    {
        public Task<Response> Set(int BidAmount, int UserId, int ProductId);
        public Task<Response> Update(int BidAmount, int id);
        public Task<Response> Delete(int id);
    }
}
