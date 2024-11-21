using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorApp
{
    public static class ColorConversion
    {
        public static Color ColorFromHsl(float hue, float saturation, float lightness)
        {
            var a = CalculateA(saturation, lightness);

            int r = CalculateColorValue(0, a, lightness, hue);
            int g = CalculateColorValue(8, a, lightness, hue);
            int b = CalculateColorValue(4, a, lightness, hue);
            return Color.FromArgb(r, g, b);
        }

        private static float CalculateK(float n, float hue) => (n + hue / 30.0f) % 12.0f;
        private static float CalculateA(float saturation, float lightness) => saturation * Math.Min(lightness, 1 - lightness);
        private static int CalculateColorValue(float n, float a, float lightness, float hue)
        {
            var k = CalculateK(n, hue);

            var val = lightness - a * Math.Max(-1, Math.Min(Math.Min(k - 3, 9 - k), 1));

            return (int) Math.Round(val*255);
        }
    }
}
