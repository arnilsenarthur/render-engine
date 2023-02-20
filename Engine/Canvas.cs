using System.Drawing;
using System.Drawing.Imaging;
using SColor = System.Drawing.Color;

namespace Engine
{
    public class Canvas : ICanvas
    {
        public Bitmap bitmap;

        public int width => bitmap.Width;
        public int height => bitmap.Height;

        public Canvas(int width, int height)
        {
            this.bitmap = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
        }

        public void SetPixel(int x, int y, Color color)
        {
            bitmap.SetPixel(x, y, SColor.FromArgb(color.value));
        }

        public Color GetPixel(int x, int y)
        {
            return new Color(bitmap.GetPixel(x, y).ToArgb());
        }

        public void Fill(Polygon polygon, IBrush brush)
        {
            polygon.Fill(this, brush);
        }

        public void Fill(Color color)
        {
            using (Graphics gfx = Graphics.FromImage(bitmap))
            {
                Console.WriteLine(color + " " + SColor.FromArgb(color.value));
                gfx.Clear(SColor.FromArgb(color.value));
            }
        }

        public void Save(string path)
        {
            bitmap.Save(path, ImageFormat.Png);
        }

        public void Draw(IShape shape, IBrush brush)
        {
            shape.Draw(this, brush);
        }

        public bool IsOnBounds(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
    }
}