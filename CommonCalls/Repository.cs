using DataAccess;
using EF.Core.Repository.Repository;

namespace CommonCalls
{
    public class Repository<T> : CommonRepository<T>, IRepository<T> where T : class
    {
        public Repository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
