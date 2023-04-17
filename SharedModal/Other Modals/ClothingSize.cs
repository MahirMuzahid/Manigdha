using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Other_Modals
{
    public class ClothingSize
    {
        public enum MenClothingType
        {
            Blazers,
            JacketsAndCoats,
            JeansAndTrousers,
            Shirts,
            TShirtsAndPoloShirts,
        }
        public enum WomenClothingType
        {
            CoatsAndJackets,
            Jeans,
            Trousers,
            Leggings,
            Shorts,
            Skirts,
            Tshirts,
            Tops,
            Saree,
            Blouse,

        }
        public enum SizeType
        {
            Numeric,
            Word
        }

        public enum Gender
        {
            Male,
            Female
        }

        public static List<string> GetMenSizes( Gender gender, MenClothingType clothingType)
        {
            List<string> sizes = new List<string>();
            switch (clothingType)
            {
                case MenClothingType.Blazers:
                    sizes = GetWordSizes();
                    break;
                case MenClothingType.JacketsAndCoats:
                    sizes = GetWordSizes();
                    break;
                case MenClothingType.JeansAndTrousers:
                    sizes = GetNumericSizes(gender).ConvertAll(size => size.ToString());
                    break;
                case MenClothingType.Shirts:
                    sizes = GetWordSizes();
                    break;
                case MenClothingType.TShirtsAndPoloShirts:
                    sizes = GetWordSizes();
                    break;
                default:
                    break;
            }
            return sizes;
        }

        public static List<string> GetWomenSizes(Gender gender, WomenClothingType clothingType)
        {
            List<string> sizes = new List<string>();
            switch (clothingType)
            {
                case WomenClothingType.CoatsAndJackets:
                    sizes = GetWordSizes();
                    break;
                case WomenClothingType.Jeans:
                    sizes = GetNumericWomenWaistSizes().ConvertAll(size => size.ToString());
                    break;
                case WomenClothingType.Trousers:
                    sizes = GetNumericWomenWaistSizes().ConvertAll(size => size.ToString());
                    break;
                case WomenClothingType.Leggings:
                    sizes = GetNumericWomenWaistSizes().ConvertAll(size => size.ToString());
                    break;
                case WomenClothingType.Shorts:
                    sizes = GetNumericWomenWaistSizes().ConvertAll(size => size.ToString());
                    break;
                case WomenClothingType.Skirts:
                    sizes = GetWordSizes();
                    break;
                case WomenClothingType.Tshirts:
                    sizes = GetNumericWomenWaistSizes().ConvertAll(size => size.ToString());
                    break;
                case WomenClothingType.Tops:
                    sizes = GetWordSizes();
                    break;
                case WomenClothingType.Saree:
                    sizes = GetWordSizes();
                    break;
                case WomenClothingType.Blouse:
                    sizes = GetNumericWomenWaistSizes().ConvertAll(size => size.ToString());
                    break;
                default:
                    break;
            }
            return sizes;
        }


        private static List<int> GetNumericSizes(Gender gender)
        {
            List<int> sizes = new List<int>();
            if(Gender.Male == gender) { sizes.AddRange(new int[] { 34, 36, 38, 40, 42, 44, 46 }); }
            if (Gender.Female == gender) { sizes.AddRange(new int[] { 34, 36, 38, 40, 42, 44, 46 }); }
            return sizes;
        }

        private static List<int> GetNumericWomenWaistSizes()
        {
            List<int> sizes = new List<int>();
            sizes.AddRange(new int[] { 24, 25, 26, 28, 30, 31, 33, 36 });
            return sizes;
        }

        private static List<string> GetWordSizes()
        {
            List<string> sizes = new List<string>();
            sizes.AddRange(new string[] { "XS", "S", "M", "L", "XL", "XXL", "XXXL" });
            return sizes;
        }
     
        private static string ConvertToWordSize(int numericSize)
        {
            if (numericSize < 28) return "XS";
            if (numericSize < 32) return "S";
            if (numericSize < 36) return "M";
            if (numericSize < 40) return "L";
            if (numericSize < 44) return "XL";
            if (numericSize < 48) return "XXL";
            if (numericSize < 52) return "XXXL";
            return "XXXXL";
        }

    }
}
