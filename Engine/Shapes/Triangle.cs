namespace Engine
{
    public class Triangle : Polygon
    {
        public Triangle(Vector2i a, Vector2i b, Vector2i c)
        {
            this.points = new Vector2i[] { a, b, c };
        }

        public override Vector2i GetLowerBound()
        {
            Vector2i a = points[0];
            Vector2i b = points[1];
            Vector2i c = points[2];

            return new Vector2i(Math.Min(a.x, Math.Min(b.x, c.x)), Math.Min(a.y, Math.Min(b.y, c.y)));
        }

        public override Vector2i GetUpperBound()
        {
            Vector2i a = points[0];
            Vector2i b = points[1];
            Vector2i c = points[2];
            
            return new Vector2i(Math.Max(a.x, Math.Max(b.x, c.x)), Math.Max(a.y, Math.Max(b.y, c.y)));
        }

    }
}