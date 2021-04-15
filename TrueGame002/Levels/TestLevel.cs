using System.Collections.Generic;
using System.Drawing;
using System.IO;
using TestGame002.Model;
using TestGame002.Model.DirHero;

namespace TestGame002.Levels
{
    public static class TestLevel
    {
        public static Level GetTestLevel0()
        {
            var naruto = new Hero(new Size(64, 64), new Point(100, 100))
            {
                HeroView = new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\MainCharacter\Naruto128x128.png"))
            };
            var testMap = new Map(15, 20)
            {
                BlockMap = new [,] {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}
                },
                Background = new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\Backgrounds\BackgroundCity.png"))
            };
            return new Level(naruto, new List<Map> {testMap});
        }
    }
}