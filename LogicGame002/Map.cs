using System.Drawing;

namespace LogicGame002
{
    public class Map
    {
        public readonly int Height;
        public readonly int Width;
        
        public int[,] BlockMap;
        public int CellSize;
        private Image _background;
        
        public Image Background
        {
            get => _background;
            set
            {
                _background = value;
                CellSize = value.Width / Width;
            }
        }

        public Map(int height, int width)
        {
            Height = height;
            Width = width;
            BlockMap = new int[width, height];
        }

        public bool IsBound(Point entity)
        {
            return entity.X > 0 && entity.X / CellSize < Width && entity.Y > 0 && entity.Y / CellSize < Height;
        }

        public bool IsBlock(Point point)
        {
            return BlockMap[point.X / CellSize, point.Y / CellSize] != 0;
        }
    }
}