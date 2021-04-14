using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Game002.DirMap
{
    public static class MapDrawer
    {
        public static Map Map;

        private static readonly Dictionary<int, Action<Graphics, int, int>> DrawingObjects = new Dictionary<int, Action<Graphics, int, int>>
        {
            {-2, (g, x, y) => g.DrawRectangle(new Pen(Color.Chartreuse), x, y, Map.CellSize, Map.CellSize)}, // CellSheet
            {-1, (g, x, y) => 
                g.DrawImage(
                    Map.Background,
                    new Rectangle(new Point(x, y), Map.Background.Size),
                    0, 0, 800, 600,
                    GraphicsUnit.Pixel)}, // Background
            {0, (g, x, y) => {}}, // Empty area
            {1, (g, x, y) => 
                g.DrawImage(
                    new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\StandartBlocks\EarthMiddle.png")),
                    new Rectangle(new Point(x, y), new Size(Map.CellSize, Map.CellSize)),
                    0, 0, 128, 128,
                        GraphicsUnit.Pixel)}, // EarthMiddle.png
            {2, (g, x, y) => 
                g.DrawImage(new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\StandartBlocks\EarthDown.png")),
                    new Rectangle(new Point(x, y), new Size(Map.CellSize, Map.CellSize)),
                    0, 0, 128, 128,
                        GraphicsUnit.Pixel)}, // EarthDown
            {3, (g, x, y) => 
                g.DrawImage(new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\StandartBlocks\RightPlatform.png")),
                    new Rectangle(new Point(x, y), new Size(Map.CellSize, Map.CellSize)),
                    0, 0, 128, 128,
                    GraphicsUnit.Pixel)}, // RightPlatform
            {4, (g, x, y) => 
                g.DrawImage(new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\StandartBlocks\MiddlePlatform.png")),
                    new Rectangle(new Point(x, y), new Size(Map.CellSize, Map.CellSize)),
                    0, 0, 128, 128,
                    GraphicsUnit.Pixel)}, // MiddlePlatform,
            {5, (g, x, y) => 
                g.DrawImage(new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\StandartBlocks\LeftPlatform.png")),
                    new Rectangle(new Point(x, y), new Size(Map.CellSize, Map.CellSize)),
                    0, 0, 96, 128,
                    GraphicsUnit.Pixel)} // LeftPlatform
        };

        public static void DrawMap(Graphics g)
        {
            DrawingObjects[-1](g, 0, 0);
            for(var i = 0; i < Map.Width / Map.CellSize; i++)
                for (var j = 0; j < Map.Height / Map.CellSize; j++)
                    DrawingObjects[Map.BlockMap[i, j]](g, i * Map.CellSize, j * Map.CellSize);
        }

        public static void DrawMapSheet(Graphics g)
        {
            for (var i = 0; i < Map.Width / Map.CellSize; i++)
            for (var j = 0; j < Map.Height / Map.CellSize; j++)
                DrawingObjects[-2](g, i * Map.CellSize, j * Map.CellSize);
        }
    }
}