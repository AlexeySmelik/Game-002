using System.Collections.Generic;
using System.Drawing;
using GameModel.Model;
using GameModel.Model.DirEntity;
using GameModel.Model.Mobs;
using NUnit.Framework;

namespace TestGameModelProject
{
    [TestFixture]
    public class ManipulatorTests
    {
        [TestCase(9,0, 10, 10, Description = "If there is a block to the right of the mob")]
        [TestCase(-9,0, 10, 10, Description = "If there is a block to the left of the mob")]
        public void PreRightOrLeftMove_IfTheLocationOfTheEntityIsOnBlock(int x, int y, int expectedX, int expectedY)
        {
            var map = GetTestMap(
                new[,]
                {
                    {0, 1, 0},
                    {1, 0, 1},
                    {0, 1, 0}
                });
            var mob = GetTestEntity(new Point(10, 10));
            mob.Manipulator.PreRightOrLeftMove(new Point(x, y), map);
            Assert.AreEqual(new Point(expectedX, expectedY), mob.Location);
        }

        [TestCase(0,9, 10, 10, Description = "If there is a block under the mob")]
        [TestCase(0,-9, 10, 10, Description = "If there is a block over the mob")]
        public void PreDownOrUpMove_IfTheLocationOfTheEntityIsOnBlock(int x, int y, int expectedX, int expectedY)
        {
            var map = GetTestMap(
                new[,]
                {
                    {0, 1, 0},
                    {1, 0, 1},
                    {0, 1, 0}
                });
            var mob = GetTestEntity(new Point(10, 10));
            mob.Manipulator.PreDownOrUpMove(new Point(x, y), map); 
            Assert.AreEqual(new Point(expectedX, expectedY), mob.Location);
        }
        
        private Map GetTestMap(int [,] blockMap) =>
            new Map(3, 3, new List<Mob>(), 10) {BlockMap = blockMap};
        
        private IEntity GetTestEntity(Point location) =>
            new Mob("test", new Size(10, 10), location, 10, 10);
    }
}