using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameModel;
using GameModel.Model;
using GameModel.Model.Data;

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
                {"Naruto", "Naruto128x128.png"},
                {"Pear", "pngegg.png"}
            };
        private static readonly Dictionary<int, string> BlockImageNames = 
            new Dictionary<int, string>
            {
                {1, "EarthMiddle.png"},
                {2, "EarthDown.png"},
                {-1, "Info.png"},
                {3, "Cake.png"}
            };
        private static readonly Action<Map, Graphics, int, int, int> DrawBlock =
            (map, g, p, x, y) =>
            {
                if (p != 0)
                {
                    var destSize = p == -1 ? new Size(256, 256) : new Size(map.CellSize, map.CellSize);
                    var srcSize = p == -1 ? destSize : new Size(128, 128);
                    g.DrawImage(
                        new Bitmap(PathToBlocks + BlockImageNames[p]),
                        new Rectangle(new Point(x, y), destSize),
                        new Rectangle(Point.Empty, srcSize),
                        GraphicsUnit.Pixel);
                }
            };
        
        private static readonly Random Random = new Random(993); 

        private static readonly Action<Map, Graphics> DrawBackground =
            (map, g) =>
                g.DrawImage(
                    new Bitmap(PathToBackgrounds + $"BackgroundCity{Random.Next(1, 4)}.png"),
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
                .Where(it => it.IsActive)
                .ForEach(it =>
                {
                    DrawEntity(g, it);
                    DrawHealthBar(
                        g,
                        it.CombatManipulator,
                        it.Location + new Size(0, -30),
                        new Size(it.Size.Width * it.CombatManipulator.Health / 100, 20));
                    DrawStaminaBar(
                        g,
                        it.CombatManipulator,
                        it.Location + new Size(0, -10),
                        new Size(it.Size.Width * it.CombatManipulator.Stamina / 100, 20));
                });
        }

        public static void DrawEntity(Graphics graphics, IEntity entity)
        {
            graphics.DrawImage(
                new Bitmap(PathToMobs + MobImageNames[entity.Name]),
                new Rectangle(entity.Location, entity.Size));
        }

        public static void DrawHealthBar(Graphics graphics, ICombat info, Point location, Size size)
        {
            graphics.FillRectangle(
                new SolidBrush(Color.Red),
                new Rectangle(location, size));
            graphics.DrawString(
                Math.Max(0, info.Health).ToString(),
                new Font("Arial", 10),
                new SolidBrush(Color.Black),
                location);
        }
        
        public static void DrawStaminaBar(Graphics graphics, ICombat info, Point location, Size size)
        {
            graphics.FillRectangle(
                new SolidBrush(Color.Blue),
                new Rectangle(location, size));
            graphics.DrawString(
                Math.Max(0, info.Stamina).ToString(),
                new Font("Arial", 10),
                new SolidBrush(Color.Black),
                location);
        }
    }
}