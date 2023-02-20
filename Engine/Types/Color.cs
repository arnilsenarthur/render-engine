namespace Engine
{
    public struct Color
    {
        public static Color Black => new Color(0, 0, 0, 255);
        public static Color White => new Color(255, 255, 255, 255);
        public static Color Red => new Color(255, 0, 0);
        public static Color Green => new Color(0, 255, 0);
        public static Color Blue => new Color(0, 0, 255);
        public static Color Yellow => new Color(255, 255, 0);
        public static Color Magenta => new Color(255, 0, 255);
        public static Color Aqua => new Color(0, 255, 255);

        public int value;

        public byte r => (byte) (value >> 16);
        public byte g => (byte) (value >> 8);
        public byte b => (byte) (value);
        public byte a => (byte) (value >> 24);

        public Color(int value)
        {
            this.value = value;
        }

        public Color(byte r, byte g, byte b, byte a = 255)
        {
            value = b | g << 8 | r << 16 | a << 24;
        }

        public override string ToString()
        {
            return $"({r}, {g}, {b}, {a})";
        }
    }
}