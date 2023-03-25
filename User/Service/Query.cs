using SharedModal.Modals;
using System.Diagnostics.Metrics;


namespace UserService.Service
{
    public class Query
    {
        [UseProjection]
        public IQueryable<Division> GetDivision([Service] DataContext _context)
        {
            var a = _context.Divisions?.AsQueryable();
            return a;
        }

        public string Hello()
        {
            return "Hello, world!";
        }
    }
}
