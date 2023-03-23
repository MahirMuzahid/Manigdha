using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.ViewModel
{
    public partial class BuyPostViewModal : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<int> cList;
        public BuyPostViewModal()
        {
            cList= new ObservableCollection<int>();
            cList.Add(0);
            cList.Add(1);
            cList.Add(2);
            cList.Add(3);
            cList.Add(4);
        }
    }
}
