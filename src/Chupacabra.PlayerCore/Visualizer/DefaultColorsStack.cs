using System.Collections.Generic;
using System.Drawing;

namespace Chupacabra.PlayerCore.Visualizer
{
    public class DefaultColorsStack
    {
        public Brush Pop()
        {
            return _defaultColorsStack.Pop();
        }

        private readonly Stack<Brush> _defaultColorsStack = new Stack<Brush>(new[]
        {
            Brushes.Blue,
            Brushes.Teal,
            Brushes.LightPink,
            Brushes.PaleGoldenrod,
            Brushes.LightSkyBlue,
            Brushes.LightCoral,
            Brushes.LightSeaGreen,
            Brushes.Sienna,
            Brushes.Indigo,
            Brushes.MediumPurple,
            Brushes.Goldenrod,
            Brushes.MediumAquamarine,
            Brushes.Orange,
            Brushes.Violet,
            Brushes.LimeGreen,
            Brushes.Pink,
            Brushes.MediumVioletRed,
            Brushes.Ivory,
            Brushes.SpringGreen,
            Brushes.LemonChiffon,
            Brushes.LightGoldenrodYellow,
            Brushes.SandyBrown,
            Brushes.Honeydew,
            Brushes.PeachPuff,
            Brushes.Aqua,
            Brushes.GreenYellow,
            Brushes.OliveDrab,
            Brushes.Khaki,
            Brushes.DarkGoldenrod,
            Brushes.BlanchedAlmond,
            Brushes.Peru,
            Brushes.LightSteelBlue,
            Brushes.DarkMagenta,
            Brushes.DimGray,
            Brushes.DarkBlue,
            Brushes.Turquoise,
            Brushes.LavenderBlush,
            Brushes.LightGreen,
            Brushes.PaleTurquoise,
            Brushes.DarkOliveGreen,
            Brushes.Snow,
            Brushes.GhostWhite,
            Brushes.Gray,
            Brushes.DarkRed,
            Brushes.RosyBrown,
            Brushes.LightSalmon,
            Brushes.HotPink,
            Brushes.Navy,
            Brushes.OrangeRed,
            Brushes.LightYellow,
            Brushes.Plum,
            Brushes.FloralWhite,
            Brushes.SlateGray,
            Brushes.Chartreuse,
            Brushes.MediumSlateBlue,
            Brushes.DarkTurquoise,
            Brushes.LightGray,
            Brushes.Moccasin,
            Brushes.AntiqueWhite,
            Brushes.Cyan,
            Brushes.Transparent,
            Brushes.DarkGreen,
            Brushes.Green,
            Brushes.PowderBlue,
            Brushes.Olive,
            Brushes.Red,
            Brushes.SeaGreen,
            Brushes.DarkCyan,
            Brushes.Gainsboro,
            Brushes.Maroon,
            Brushes.Gold,
            Brushes.LightBlue,
            Brushes.RoyalBlue,
            Brushes.DarkOrange,
            Brushes.MediumBlue,
            Brushes.Silver,
            Brushes.Tan,
            Brushes.DeepPink,
            Brushes.CornflowerBlue,
            Brushes.WhiteSmoke,
            Brushes.LightSlateGray,
            Brushes.Beige,
            Brushes.Wheat,
            Brushes.MediumOrchid,
            Brushes.MidnightBlue,
            Brushes.Black,
            Brushes.Azure,
            Brushes.MediumTurquoise,
            Brushes.NavajoWhite,
            Brushes.DarkViolet,
            Brushes.Crimson,
            Brushes.Tomato,
            Brushes.MediumSeaGreen,
            Brushes.Lime,
            Brushes.DarkSlateGray,
            Brushes.YellowGreen,
            Brushes.ForestGreen,
            Brushes.PapayaWhip,
            Brushes.BlueViolet,
            Brushes.DarkOrchid,
            Brushes.DarkSeaGreen,
            Brushes.Linen,
            Brushes.DarkGray,
            Brushes.Purple,
            Brushes.DarkKhaki,
            Brushes.MintCream,
            Brushes.DodgerBlue,
            Brushes.Thistle,
            Brushes.OldLace,
            Brushes.LightCyan,
            Brushes.SkyBlue,
            Brushes.AliceBlue,
            Brushes.Yellow,
            Brushes.Cornsilk,
            Brushes.Magenta,
            Brushes.MistyRose,
            Brushes.Firebrick,
            Brushes.Salmon,
            Brushes.LawnGreen,
            Brushes.Orchid,
            Brushes.Fuchsia,
            Brushes.Brown,
            Brushes.SlateBlue,
            Brushes.MediumSpringGreen,
            Brushes.SeaShell,
            Brushes.CadetBlue,
            Brushes.BurlyWood,
            Brushes.IndianRed,
            Brushes.White,
            Brushes.DeepSkyBlue,
            Brushes.Bisque,
            Brushes.PaleVioletRed,
            Brushes.Aquamarine,
            Brushes.DarkSlateBlue,
            Brushes.Coral,
            Brushes.Lavender,
            Brushes.SaddleBrown,
            Brushes.DarkSalmon,
            Brushes.PaleGreen,
            Brushes.Chocolate,
            Brushes.SteelBlue
        });
    }
}