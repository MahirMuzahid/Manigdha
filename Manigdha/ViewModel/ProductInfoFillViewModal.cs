using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.ViewModel
{
    public partial class ProductInfoFillViewModal: ObservableObject
    {
        [ObservableProperty]
        bool isSelectGridVisible;

        public ProductInfoFillViewModal()
        {
            IsSelectGridVisible = false;
        }
    }
}
