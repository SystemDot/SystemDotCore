using System;

namespace SystemDot.Core
{
    public static class DecimalExtensions
    {
        public static decimal RoundUpTo(this decimal toRound, int places)
        {
            return Math.Round(toRound, places);
        }

        public static decimal RoundDownTo(this decimal toRound, int places)
        {
            var tenToPowerOfDecimalPlaces = (decimal)Math.Pow(10, places);
            return Math.Floor(tenToPowerOfDecimalPlaces * toRound) / tenToPowerOfDecimalPlaces;
        }

        public static bool HasPrecision(this decimal number)
        {
            return number.GetPrecision() == 1M;
        }

        public static string ToFifteenPrecisionString(this decimal number)
        {
            return number.ToString("0.###############");
        }

        public static decimal GetPrecision(this decimal number)
        {
            decimal precision = 1;

            string[] numberParts = number.ToFifteenPrecisionString().Split('.');
            if (numberParts.Length == 1) return precision;

            for (int multiplier = 0; multiplier < numberParts.Length; multiplier++)
                precision /= 10;

            return precision;
        }
    }
}