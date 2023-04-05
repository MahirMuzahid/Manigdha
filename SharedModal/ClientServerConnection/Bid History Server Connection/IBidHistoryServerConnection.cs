using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection.Bid_History_Server_Connection
{
    internal interface IBidHistoryServerConnection: ICURDCall<BidHistory>
    {
    }
}
