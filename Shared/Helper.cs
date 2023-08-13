using MKANTajneedSystem.Enum;

namespace MKANTajneedSystem.Shared
{
    public static class Helper
    {
        public static string GenerateCode(int id)
        {
            return $"MKAGH-{id.ToString("0000")}";
        }

        public static int SelectEnum(string screenMessage, int validStart, int validEnd)
        {
            int outValue;

            do
            {
                Console.Write(screenMessage);

            } while (!(int.TryParse(Console.ReadLine(), out outValue) && IsValidRange(outValue, validStart, validEnd)));

            return outValue;
        }

        /// <summary>
        ///     Check if the value passed is within the valid range provided
        /// </summary>
        /// <param name="outValue">Value selected from option</param>
        /// <param name="start">Valid start value</param>
        /// <param name="end">Valid end value</param>
        /// <returns>boolean (t/f)</returns>
        public static bool IsValidRange(int outValue, int start, int end)
        {
            return outValue >= start && outValue <= end;
        }

        public static DateOnly TryParseDateOnly(string dateOnlyString)
        {
            if (!DateOnly.TryParse(dateOnlyString, out DateOnly result))
            {
                throw new FormatException("Bad dateOnly format provided!");
            }

            return result;
        }

        public static int AgeCalculator(int year)
        {
            return DateTime.Now.Year - year;
        }

        public static AgeGroup SetAgeGroup()
        {
            int year;
            var age = AgeCalculator(year);

            if (age >= 7 && age <= 15)
            {
                return AgeGroup.Atfal;
            }
            else if (age >= 16 && age <= 40)
            {
                return AgeGroup.Khuddam;
            }
        }
    }
}