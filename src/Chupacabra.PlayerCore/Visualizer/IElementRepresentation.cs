using System.Drawing;

namespace Chupacabra.PlayerCore.Visualizer
{
    public interface IElementRepresentation
    {
        Image Bitmap(int scale);
    }
}