using DataAccess;
using EF.Core.Repository.Manager;

namespace CommonCalls
{
    public class Manager<T> : CommonManager<T>, IManager<T> where T : class
    {
        public Manager(DataContext dbContext) : base(new Repository<T>(dbContext))
        {

        }
    }
}
