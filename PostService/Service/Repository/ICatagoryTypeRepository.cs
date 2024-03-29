﻿using SharedModal.Modals;

namespace PostService.Service.Repository
{
    public interface ICatagoryTypeRepository
    {
        public Task<Response> Set(string name, int id);
        public Task<Response> Update(string name, int id, int productCatagoryId);
        public Task<Response> Delete(int id);
    }
}
