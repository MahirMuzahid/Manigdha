using SharedModal.Other_Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.Model.StaticFolder
{
    static class StaticAddProductImage
    {
        public static string Title { get; set; }
        public static string Description { get; set; }
        public static string Price { get; set; }

        public static string UpperSideImageURL { get; set; }
        public static string LowerSideImageURL { get; set; }
        public static string LeftSideImageURL { get; set; }
        public static string RightSideImageURL { get; set; }
        public static string FrontSideImageURL { get; set; }
        public static string BackSideImageURL { get; set; }

        public static List<ReviewVerificationStatus> Verification { get; set; }
    }
}
