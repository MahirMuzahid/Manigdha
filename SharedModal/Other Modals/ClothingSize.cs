using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Other_Modals
{
    public class ClothingSize
    {
        public enum ClothingType
        {
            Blazers,
            Footwear,
            JacketsAndCoats,
            JeansAndTrousers,
            Shirts,
            TShirtsAndPoloShirts,
            UnderwearLoungewearAndSocks,
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

        public static List<string> GetSizes(SizeType sizeType, Gender gender, ClothingType clothingType)
        {
            List<string> sizes = new List<string>();
            switch (clothingType)
            {
                case ClothingType.Blazers:
                    sizes = GetNumericSizes(gender, 32, 56);
                    break;
                case ClothingType.Footwear:
                    sizes = GetNumericSizes(gender, 6, 12);
                    break;
                case ClothingType.JacketsAndCoats:
                    sizes = GetNumericSizes(gender, 32, 60);
                    break;
                case ClothingType.JeansAndTrousers:
                    sizes = GetNumericSizes(gender, 28, 40);
                    break;
                case ClothingType.Shirts:
                    sizes = GetNumericSizes(gender, 14, 20);
                    break;
                case ClothingType.TShirtsAndPoloShirts:
                    sizes = GetWordSizes(gender).ConvertAll(size => size.ToString());
                    break;
                case ClothingType.UnderwearLoungewearAndSocks:
                    sizes = GetWaistSizes(gender);
                    break;
                default:
                    break;
            }

            if (sizeType == SizeType.Word)
            {
                sizes = sizes.Select(size => ConvertToWordSize(int.Parse(size))).ToList();
            }

            return sizes;
        }
       







        private static List<string> GetNumericSizes(Gender gender, int minSize, int maxSize)
        {
            List<string> sizes = new List<string>();
            for (int i = minSize; i <= maxSize; i++)
            {
                sizes.Add(i.ToString());
            }

            if (gender == Gender.Female)
            {
                sizes.RemoveAll(size => int.Parse(size) % 2 != 0);
            }

            return sizes;
        }

        private static List<int> GetWordSizes(Gender gender)
        {
            List<int> sizes = new List<int>();
            if (gender == Gender.Female)
            {
                sizes.AddRange(new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24 });
            }
            else if (gender == Gender.Male)
            {
                sizes.AddRange(new int[] { 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60 });
            }
            return sizes;
        }

        private static List<string> GetWaistSizes(Gender gender)
        {
            return GetNumericSizes(gender, 24, 40);
        }

        private static List<string> GetInseamSizes(Gender gender)
        {
            return GetNumericSizes(gender, 28, 36);
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
