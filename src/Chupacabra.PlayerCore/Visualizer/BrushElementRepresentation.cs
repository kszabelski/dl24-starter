using System;
using System.Drawing;

namespace Chupacabra.PlayerCore.Visualizer
{
    public class BrushElementRepresentation : IElementRepresentation
    {
        private readonly Brush _brush;

        public BrushElementRepresentation(Brush brush)
        {
            _brush = brush;
        }

        public Image Bitmap(int scale)
        {
            var sprite = new Bitmap(scale, scale);
            using (var g = Graphics.FromImage(sprite))
            {
                g.FillRectangle(_brush, 0, 0, scale, scale);
            }

            return sprite;
        }
    }
}