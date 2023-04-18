﻿using System;
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

        public static Stream UpperSideImageURL { get; set; }
        public static Stream LowerSideImageURL { get; set; }
        public static Stream LeftSideImageURL { get; set; }
        public static Stream RightSideImageURL { get; set; }
        public static Stream FrontSideImageURL { get; set; }
        public static Stream BackSideImageURL { get; set; }

        public static List<Tuple<string, bool>> Verification { get; set; }
    }
}
