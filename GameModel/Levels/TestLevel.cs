using System.Collections.Generic;
using System.Drawing;
using GameModel.Model;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;
using GameModel.Model.Mobs;

namespace Game002.Levels
{
    public static class TestLevel
    {
        public static Level GetTestLevel0()
        {
            var naruto = 
                new Hero(
                    "Naruto",
                    new Size(64, 64),
                    new Point(0, 100),
                    100,
                    10,
                    10);
            var mobTest1List = new List<Mob>
            {
                new Mob(
                    "Creeper",
                    new Size(128, 128),
                    new Point(100, 100),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\CreeperWings 128x128.png"),
                new Mob(
                    "Creeper",
                    new Size(64, 64),
                    new Point(400, 150),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\CreeperWings 128x128.png"),
                new Mob(
                    "Creeper",
                    new Size(96, 96),
                    new Point(0, 50),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\CreeperWings 128x128.png")
            };
            var testMap1 = new Map(15, 20, mobTest1List)
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
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 2, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}
                }
            };
            var mobTest2List = new List<Mob>
            {
                new Mob(
                    "Pudge",
                    new Size(64, 64),
                    new Point(136, 200),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\PudgeTest.png"),
                new Mob(
                    "Pudge",
                    new Size(64, 64),
                    new Point(72, 200),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\PudgeTest.png"),
                new Mob(
                    "Pudge",
                    new Size(64, 64),
                    new Point(8, 200),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\PudgeTest.png"),
                new Mob(
                    "Pudge",
                    new Size(64, 64),
                    new Point(264, 200),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\PudgeTest.png"),
                new Mob(
                    "Pudge",
                    new Size(64, 64),
                    new Point(328, 200),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\PudgeTest.png"),
                new Mob(
                    "Pudge",
                    new Size(64, 64),
                    new Point(396, 200),
                    10,
                    10,
                    @"..\..\..\Sprites\Mobs\PudgeTest.png"),
                new Mob(
                    "Pudge",
                    new Size(256, 256),
                    new Point(460, 200),
                    100,
                    10,
                    @"..\..\..\Sprites\Mobs\PudgeTest.png")
            };
            var testMap2 = new Map(15, 20, mobTest2List)
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
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}
                }
            };
            return new Level(naruto, new List<Map> {testMap1, testMap2}, 5);
        }
    }
}