using System.Linq;

namespace Engine
{
    public class Polygon : IShape
    {
        protected Vector2i[] points = null!;

        public static Polygon FromRegularPolygon(int x, int y, int sides, int radius)
        {
            Vector2i[] points = new Vector2i[sides];

            for(int i = 0; i < sides; i ++)
            {
                float angle = 360f/sides * i;
                
                double ox = Math.Sin(angle * Math.PI/180) * radius; 
                double oy = Math.Cos(angle * Math.PI/180) * radius; 

                points[i] = new Vector2i((int) (x + ox), (int) (y + oy));
            }

            return new Polygon(points);
        }

        public Polygon() 
        {
            points = new Vector2i[0];
        }

        public Polygon(params Vector2i[] points)
        {
            this.points = points;
        }

        public virtual Vector2i GetLowerBound()
        {
            Vector2i v = new Vector2i(int.MaxValue, int.MaxValue);

            foreach (Vector2i p in points)
            {
                if (p.x < v.x) v.x = p.x;
                if (p.y < v.y) v.y = p.y;
            }

            return v;
        }

        public virtual Vector2i GetUpperBound()
        {
            Vector2i v = new Vector2i(int.MinValue, int.MinValue);

            foreach (Vector2i p in points)
            {
                if (p.x > v.x) v.x = p.x;
                if (p.y > v.y) v.y = p.y;
            }

            return v;
        }

        public void Draw(Canvas canvas, IBrush brush)
        {
            foreach (Line line in GetLines())
                canvas.Draw(line, brush);
        }

        public IEnumerable<Line> GetLines()
        {
            for (int i = 0; i < points.Length; i++)
                yield return new Line(points[i], points[(i + 1) % points.Length]);
        }

        public void Fill(Canvas canvas, IBrush brush)
        {
            Vector2i l = GetLowerBound();
            Vector2i u = GetUpperBound();

            for (int y = l.y; y <= u.y; y++)
            {
                List<int> collisions = new List<int>();

                foreach (Line line in GetLines())
                {
                    int x = line.GetX(y);

                    if(x != -1)
                        collisions.Add(x);
                }

                collisions = collisions.Distinct().ToList();
                collisions.Sort();

                for(int i = 0; i + 1 < collisions.Count; i += 2)
                {
                    for(int x = collisions[i]; x < collisions[i + 1]; x ++)
                        brush.Paint(canvas, x, y);
                }
            }
        }
    }
}