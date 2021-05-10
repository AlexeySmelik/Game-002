using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameModel;
using GameModel.Model;
using GameModel.Model.DirEntity;

namespace TestGame002.Controllers.Drawers
{
    public static class MapDrawer
    {
        private static readonly string PathToBlocks = System.IO.Path.GetFullPath(@"..\..\..\Sprites\StandartBlocks\");
        private static readonly string PathToMobs = System.IO.Path.GetFullPath(@"..\..\..\Sprites\Mobs\");
        private static readonly string PathToBackgrounds = System.IO.Path.GetFullPath(@"..\..\..\Sprites\Backgrounds\");
        private static readonly Dictionary<string, string> MobImageNames =
            new Dictionary<string, string>
            {
                {"Creeper", "CreeperWings 128x128.png"},
                {"Sasuke", "SasukeStand 128x128.png"},
                {"Pudge", "PudgeTest.png"},
                {"Naruto", "Naruto128x128.png"}
            };
        private static readonly Dictionary<int, string> BlockImageNames = 
            new Dictionary<int, string>
            {
                {1, "EarthMiddle.png"},
                {2, "EarthDown.png"},
            };
        private static readonly Action<Map, Graphics, int, int, int> DrawBlock =
            (map, g, p, x, y) =>
            {
                if (p != 0)
                {
                    g.DrawImage(
                        new Bitmap(PathToBlocks + BlockImageNames[p]),
                        new Rectangle(new Point(x, y), new Size(map.CellSize, map.CellSize)),
                        new Rectangle(Point.Empty, new Size(128, 128)),
                        GraphicsUnit.Pixel);
                }
            };

        private static readonly Action<Map, Graphics> DrawBackground =
            (map, g) =>
                g.DrawImage(
                    new Bitmap(PathToBackgrounds + "BackgroundCity.png"),
                    new Rectangle(Point.Empty, map.Size),
                    new Rectangle(Point.Empty, map.Size),
                    GraphicsUnit.Pixel);
            
        public static void DrawMap(Graphics g, Map map)
        {
            DrawBackground(map, g);
            
            for(var i = 0; i < map.BlockMap.GetLength(0); i++)
            for (var j = 0; j < map.BlockMap.GetLength(1); j++)
                DrawBlock(map, g, map.BlockMap[i, j], i * map.CellSize, j * map.CellSize);
            
            map.MobList
                .Where(it => it.IsActive())
                .ForEach(it =>
                {
                    DrawEntity(g, it);
                    DrawHealthBar(
                        g,
                        it,
                        it.Location + new Size(0, -10),
                        new Size(it.Size.Width * it.Health / 100, 20));
                });
        }

        public static void DrawEntity(Graphics graphics, IEntity entity)
        {
            graphics.DrawImage(
                new Bitmap(PathToMobs + MobImageNames[entity.Name]),
                new Rectangle(entity.Location, entity.Size));
        }

        public static void DrawHealthBar(Graphics graphics, ICombat dEntity, Point location, Size size)
        {
            graphics.FillRectangle(
                new SolidBrush(Color.Red),
                new Rectangle(location, size));
            graphics.DrawString(
                Math.Max(0, dEntity.Health).ToString(),
                new Font("Arial", 10),
                new SolidBrush(Color.Black),
                location);
        }
    }
}