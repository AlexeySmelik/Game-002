using System.Drawing;

namespace Game002.Model
{
    public class Map
    {
        public readonly int Height;
        public readonly int Width;
        
        public int[,] BlockMap;
        public int CellSize = 40;
        
        public Map(int height, int width)
        {
            Height = height * CellSize;
            Width = width * CellSize;
            BlockMap = new int[width / CellSize, height / CellSize];
        }

        public bool IsBound(Point p) => p.X >= 0 && p.X < Width && p.Y >= 0 && p.Y < Height; //TODO Tests

        public bool IsBlock(Point p) => BlockMap[p.X / CellSize, p.Y / CellSize] != 0; //TODO Tests
    }
}