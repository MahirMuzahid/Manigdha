using EF.Core.Repository.Interface.Repository;

namespace CommonCalls
{
    public interface IRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
