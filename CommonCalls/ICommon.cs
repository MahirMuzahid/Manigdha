using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCalls
{
    public interface ICommon<T>
    {
        Task<ICollection<T>> Get();
        Task<Response> Set(T obj);
        Task<T> GetByID(int id);
        Task<Response> Update(T obj);
        Task<Response> Delete(T obj);
    }
}
