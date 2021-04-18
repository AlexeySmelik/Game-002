using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Game002.Model;
using Game002.Model.DirHero;

namespace Game002.Levels
{
    public static class TestLevel
    {
        public static Level GetTestLevel0()
        {
            var naruto = new Hero(new Size(64, 64), new Point(0, 100))
            {
                HeroView = new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\MainCharacter\Naruto128x128.png"))
            };
            var testMap = new Map(15, 20)
            {
                BlockMap = new [,] {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}
                },
                Background = new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\Backgrounds\BackgroundCity.png"))
            };
            return new Level(naruto, new List<Map> {testMap});
        }
    }
}