using System;

namespace PocketNET.Core.Math
{
    public class PocketMath
    {
        public static double Round(double d, int precision)
        {
            return ((double)MathF.Round((float)(d * MathF.Pow(10, precision)))) / MathF.Pow(10, precision);
        }
    }
}
