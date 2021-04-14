using System.Drawing;

namespace TestGame002.Model
{
    public class Map
    {
        public readonly int Height;
        public readonly int Width;
        
        public int[,] BlockMap;
        public int CellSize = 40;
        public Image Background;
        
        public Map(int height, int width)
        {
            Height = height * CellSize;
            Width = width * CellSize;
            BlockMap = new int[width / CellSize, height / CellSize];
        }

        public bool IsBound(Point p) => p.X > 0 && p.X < Width && p.Y > 0 && p.Y < Height;

        public bool IsBlock(Point point) => BlockMap[point.X / CellSize, point.Y / CellSize] != 0;
    }
}