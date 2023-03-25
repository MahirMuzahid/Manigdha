using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace UserService.Service
{
    public class Query
    {

        [UseProjection]
        public async Task<List<SharedModal.Modals.User>> GetUser([Service] DataContext _context)
        {
            return  await _context.Users.Include(u => u.City).ToListAsync();          
        }

        [UseProjection]
        public async Task<SharedModal.Modals.User> GetUserByID([Service] DataContext _context, int UserID)
        {
            var result = await _context.Users.Include(u => u.City).FirstOrDefaultAsync(u => u.UserID == UserID);

            if (result == null) { return new SharedModal.Modals.User(); }
            return result;


        }
    }
}
