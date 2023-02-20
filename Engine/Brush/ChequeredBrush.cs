namespace Engine
{
    public struct ChequeredBrush : IBrush
    {
        public Color a;
        public Color b;

        int size = 5;

        public ChequeredBrush(Color a, Color b, int size)
        {
            this.a = a;
            this.b = b;
            this.size = size;
        }

        public Color GetColor(int x,int y)
        {
            int cx = x / size;
            int cy = y / size;

            return ((cx + cy % 2) % 2 == 0) ? a : b;
        }
    }
}