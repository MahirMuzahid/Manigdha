using SharedModal.Modals;
using System.Diagnostics.Metrics;


namespace UserService.Service
{
    public class Query
    {
        [UseProjection]
        public async Task<List<SharedModal.Modals.User>> GetUser([Service] DataContext _context)
        {
            return  await _context.Users.Include(u => u.City).ToListAsync();          
        }


    }
}
