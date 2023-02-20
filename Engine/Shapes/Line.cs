using System;

namespace Engine
{
    public struct Line : IShape
    {
        public Vector2i a;
        public Vector2i b;

        public Vector2i lowerBounds => new Vector2i(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
        public Vector2i upperBounds => new Vector2i(Math.Max(a.x, b.x), Math.Max(a.y, b.y));

        public Line(Vector2i a, Vector2i b)
        {
            this.a = a;
            this.b = b;
        }

        public unsafe void Draw(Canvas canvas, IBrush brush)
        {
            int x = a.x;
            int y = a.y;

            int dx = Math.Abs(b.x - x);
            int dy = Math.Abs(b.y - y);
            int sx = (x < b.x) ? 1 : -1;
            int sy = (y < b.y) ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                brush.Paint(canvas, x, y);

                if ((x == b.x) && (y == b.y)) break;

                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x += sx; }
                if (e2 < dx) { err += dx; y += sy; }
            }
        }

        public int GetX(int py)
        {
            if(py == a.y) return a.x;
            if(py == b.y) return b.x;

            int x = a.x;
            int y = a.y;

            int dx = Math.Abs(b.x - x);
            int dy = Math.Abs(b.y - y);
            int sx = (x < b.x) ? 1 : -1;
            int sy = (y < b.y) ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                if (y == py) return x;

                if ((x == b.x) && (y == b.y)) break;

                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x += sx; }
                if (e2 < dx) { err += dx; y += sy; }
            }

            return -1;
        }
    }
}