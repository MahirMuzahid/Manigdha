using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.Model.StaticFolder
{
    public class TemporaryStaticInfo
    {
        public static List<string> SelectedCataroryTypeNameList { get; set; }
        public static List<ProductCatagory> PikerProductCatagoryList;
        public static string SelectedProductCatagoryName { get; set; }

        public static string SelectedSizeType { get; set; }
    }
}
