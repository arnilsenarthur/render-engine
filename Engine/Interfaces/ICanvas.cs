namespace Engine
{
    public interface ICanvas
    {
        int width {get;}
        int height {get;}

        void SetPixel(int x, int y, Color color);
        Color GetPixel(int x, int y);
        void Fill(Color color);

        void Save(string path);

        bool IsOnBounds(int x, int y);
    }
}