using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection.Product_Server_Connection
{
    public interface IProductServerConnection: ICURDCall<Product>
    {
    }
}
