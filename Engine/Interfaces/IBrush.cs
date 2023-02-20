namespace Engine
{
    public interface IBrush
    {
        Color GetColor(int x, int y);

        void Paint(Canvas canvas, int x, int y)
        {
            //if (canvas.IsOnBounds(x, y))
            canvas.SetPixel(x, y, GetColor(x, y));
        }
    }
}