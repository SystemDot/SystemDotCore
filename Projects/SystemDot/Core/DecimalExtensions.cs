using System;

namespace SystemDot.Core
{
    public static class DecimalExtensions
    {
        public static decimal RoundTo(this decimal toRound, int places)
        {
            return Math.Round(toRound, places);
        }
    }
}