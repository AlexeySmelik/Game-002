using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameModel.Model.Mobs;

namespace GameModel.Model
{
    public class Map
    {
        public readonly List<Mob> MobList;
        public readonly Size Size;
        
        public int[,] BlockMap;
        public readonly int CellSize;

        public Map(int numStrings, int numColumns, List<Mob> mobs, int cellSize = 40)
        {
            CellSize = cellSize;
            Size = new Size(numColumns * CellSize, numStrings * CellSize);
            MobList = mobs;
            BlockMap = new int[numColumns / CellSize, numStrings / CellSize];
        }

        public List<Mob> GetActiveMobs() => MobList.Where(it => it.IsActive()).ToList();

        public bool IsBound(Point p) => p.X >= 0 && p.X < Size.Width && p.Y >= 0 && p.Y < Size.Height;

        public bool IsBlock(Point p) => IsBound(new Point(p.X, p.Y)) && 
                                        BlockMap[p.X / CellSize, p.Y / CellSize] != 0;
    }
}