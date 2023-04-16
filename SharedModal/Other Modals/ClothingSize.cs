using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Other_Modals
{
    public class ClothingSize
    {
        public enum SizeType
        {
            Numeric,
            Alpha,
            Pants
        }

        public enum Gender
        {
            Male,
            Female
        }

        public static List<string> GetSizes(SizeType sizeType, Gender gender)
        {
            List<string> sizes = new List<string>();
            if (sizeType == SizeType.Numeric)
            {
                sizes = GetNumericSizes(gender);
            }
            else if (sizeType == SizeType.Alpha)
            {
                sizes = GetAlphaSizes(gender);
            }
            else if (sizeType == SizeType.Pants)
            {
                sizes.AddRange(GetWaistSizes(gender));
                sizes.AddRange(GetInseamSizes(gender));
            }
            return sizes;
        }

        private static List<string> GetNumericSizes(Gender gender)
        {
            List<string> sizes = new List<string>();
            if (gender == Gender.Female)
            {
                for (int i = 0; i <= 30; i++)
                {
                    sizes.Add(i.ToString());
                }
            }
            else if (gender == Gender.Male)
            {
                for (int i = 28; i <= 60; i++)
                {
                    sizes.Add(i.ToString());
                }
            }
            return sizes;
        }

        private static List<string> GetAlphaSizes(Gender gender)
        {
            List<string> sizes = new List<string>();
            if (gender == Gender.Female)
            {
                sizes.AddRange(new string[] { "XXS", "XS", "S", "M", "L", "XL", "XXL", "XXXL" });
            }
            else if (gender == Gender.Male)
            {
                sizes.AddRange(new string[] { "XS", "S", "M", "L", "XL", "XXL", "XXXL", "XXXXL" });
            }
            return sizes;
        }

        private static List<string> GetWaistSizes(Gender gender)
        {
            List<string> sizes = new List<string>();
            if (gender == Gender.Female)
            {
                for (int i = 24; i <= 40; i += 2)
                {
                    sizes.Add(i.ToString());
                }
            }
            else if (gender == Gender.Male)
            {
                for (int i = 28; i <= 60; i += 2)
                {
                    sizes.Add(i.ToString());
                }
            }
            return sizes;
        }

        private static List<string> GetInseamSizes(Gender gender)
        {
            List<string> sizes = new List<string>();
            if (gender == Gender.Female)
            {
                for (int i = 28; i <= 36; i += 2)
                {
                    sizes.Add(i.ToString());
                }
            }
            else if (gender == Gender.Male)
            {
                for (int i = 28; i <= 36; i += 2)
                {
                    sizes.Add(i.ToString());
                }
            }
            return sizes;
        }
    }
}
