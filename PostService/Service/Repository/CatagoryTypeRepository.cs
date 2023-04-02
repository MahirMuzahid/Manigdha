using CommonCalls;
using Microsoft.IdentityModel.Tokens;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public class CatagoryTypeRepository : ICatagoryTypeRepository
    {
        private IManager<CatagoryType> _manager;

        public CatagoryTypeRepository(IManager<CatagoryType> manager)
        {
            _manager = manager;
        }
        public async Task<Response> Delete(int id)
        {
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.CatagoryTypeID == id);
            var isDlt = await _manager.DeleteAsync(obj);
            if (!isDlt)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
        public async Task<ICollection<CatagoryType>> Get()
        {
            return await _manager.GetAllAsync();
        }
        public async Task<CatagoryType> GetByID(int id)
        {
            return await _manager.GetFirstOrDefaultAsync(p => p.CatagoryTypeID == id);
        }
        public async Task<Response> Set(string name, int id)
        {
            var obj = new CatagoryType() { Name = name, ProductCatagoryID = id };
            var isDlt = await _manager.AddAsync(obj);
            if (!isDlt)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
        public async Task<Response> Update(string name, int id, int productCatagoryId)
        {
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.ProductCatagoryID == productCatagoryId);

            if (!name.IsNullOrEmpty()) { return new Response(System.Net.HttpStatusCode.NotFound); }
            obj.Name = name;

            if (productCatagoryId == 0) { return new Response(System.Net.HttpStatusCode.NotFound); }
            obj.ProductCatagoryID = productCatagoryId;

            var isUpdate = await _manager.UpdateAsync(obj);
            if (!isUpdate)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
    }
}
