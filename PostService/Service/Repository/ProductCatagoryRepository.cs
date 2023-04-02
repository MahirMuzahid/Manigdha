using CommonCalls;
using Microsoft.IdentityModel.Tokens;
using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public class ProductCatagoryRepository : IProductCatagoryRepository
    {
        private IManager<ProductCatagory> _manager;

        public ProductCatagoryRepository(IManager<ProductCatagory> manager)
        {
            _manager = manager;
        }


        public async Task<Response> Delete(int id)
        {
            var obj = await _manager.GetFirstOrDefaultAsync(p => p.ProductCatagoryID == id);
            var isDlt = await _manager.DeleteAsync(obj);
            if (!isDlt)
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
        public async Task<ICollection<ProductCatagory>> Get()
        {
            return  _manager.GetAll();   
        }
        public async Task<ProductCatagory> GetByID(int id)
        {
            return await _manager.GetFirstOrDefaultAsync(p => p.ProductCatagoryID == id);
        }
        public async Task<Response> Set(string name)
        {
            var obj = new ProductCatagory() { Name = name};
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
                return new Response( "Update no done",System.Net.HttpStatusCode.NotFound);
            }
            return new Response(System.Net.HttpStatusCode.OK);
        }
    }
}