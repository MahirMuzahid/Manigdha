using EF.Core.Repository.Interface.Manager;

namespace CommonCalls
{
    public interface IManager<T> : ICommonManager<T> where T : class
    {
    }
}
