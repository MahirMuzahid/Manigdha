using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.Model
{
    public class BuyMockList
    {
        public List<int> carsalMockList { get; set; }

        public BuyMockList()
        {
            carsalMockList = new List<int>() { 1, 2, 3, 4 };
        }
    }
}
