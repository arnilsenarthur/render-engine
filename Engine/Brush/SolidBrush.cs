namespace Engine
{
    public struct SolidBrush : IBrush
    {
        public Color color;

        public SolidBrush(Color color)
        {
            this.color = color;
        }

        public Color GetColor(int x,int y)
        {
            return color;
        }
    }
}