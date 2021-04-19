using System;
using System.Drawing;

namespace Game002.Model
{
    public class Map
    {
        public readonly int Height;
        public readonly int Width;
        
        public int[,] BlockMap;
        public readonly int CellSize;

        public Map(int numStrings, int numColumns, int cellSize = 40)
        {
            CellSize = cellSize;
            Height = numStrings * CellSize;
            Width = numColumns * CellSize;
            BlockMap = new int[numColumns / CellSize, numStrings / CellSize];
        }

        public bool IsBound(Point p) => p.X >= 0 && p.X < Width && p.Y >= 0 && p.Y < Height;

        public bool IsBlock(Point p) => IsBound(new Point(p.X, p.Y)) && 
                                        BlockMap[p.X / CellSize, p.Y / CellSize] != 0;  
    }
}