using System;
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
        [TestCase(9,0, 0, Description = "If there is a block to the right of the mob and step is long")]
        [TestCase(-9,0, -1, Description = "If there is a block to the left of the mob and step is long")]
        [TestCase(2,0, 0, Description = "If there is a block to the right of the mob and step is short")]
        [TestCase(-2,0, -1, Description = "If there is a block to the left of the mob and step is short")]
        public void PreRightOrLeftMove_GoToBlockIfTheLocationOfTheEntityIsOnBlock(int x, int y, int expectedDx)
        {
            var map = GetTestMap(
                new[,]
                {
                    {0, 1, 0},
                    {1, 0, 1},
                    {0, 1, 0}
                });
            var mob = GetTestEntity(new Point(11, 11));
            for (var dy = -mob.Size.Height; dy < mob.Size.Height; dy++)
            {
                mob.Move(new Point(0, dy));
                var dX = mob.Manipulator.PreRightOrLeftMove(new Point(x, y), map).X;
                Assert.AreEqual(expectedDx, dX);
                mob.Move(new Point(0, -dy));
            }
        }
        
        [TestCase(9,0, 0)]
        [TestCase(-9,0, -1)]
        public void PreRightOrLeftMove_GoToEndOfTheMapIfTheLocationOfTheEntityIsOutOfMap(int x, int y, int expectedDx)
        {
            var map = GetTestMap(new[,] {{0}});
            var mob = GetTestEntity(new Point(1, 0));
            var dX = mob.Manipulator.PreRightOrLeftMove(new Point(x, y), map).X;
            Assert.AreEqual(expectedDx, dX);
        }
        
        [TestCase(9,0, 9)]
        [TestCase(-9,0, -9)]
        public void PreRightOrLeftMove_GoToIfThereAreNoBlocksAndEnds(int x, int y, int expectedDx)
        {
            var map = GetTestMap(new[,] {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}});
            var mob = GetTestEntity(new Point(9, 9));
            var dX = mob.Manipulator.PreRightOrLeftMove(new Point(x, y), map).X;
            Assert.AreEqual(expectedDx, dX);
        }
        
        [Test]
        public void PreRightOrLeftMove_ThrowExceptionIfStepIsTooMuch()
        {
            var map = GetTestMap(new [,]{{0, 1, 1}, {1, 1, 1}, {1, 1, 1}});
            var (x, y) = (map.CellSize + 1, 0);
            var mob = GetTestEntity(Point.Empty);
            Assert.Throws<ArgumentException>(() => mob.Manipulator.PreRightOrLeftMove(new Point(x, y), map));
        }
        
        [Test]
        public void PreRightOrLeftMove_ThrowExceptionIfYCoordinateIsNotZero()
        {
            var (x, y) = (1, 1);
            var map = GetTestMap(new int[,]{});
            var mob = GetTestEntity(Point.Empty);
            Assert.Throws<ArgumentException>(() => mob.Manipulator.PreRightOrLeftMove(new Point(x, y), map));
        }

        [TestCase(0,9, 0, Description = "If there is a block under the mob and step is long")]
        [TestCase(0,-9, -1, Description = "If there is a block over the mob and step is long")]
        [TestCase(0,2, 0, Description = "If there is a block under the mob and step is short")]
        [TestCase(0,-2, -1, Description = "If there is a block over the mob and step is short")]
        public void PreDownOrUpMove_GoToBlockIfTheLocationOfTheEntityIsOnBlock(int x, int y, int expectedDy)
        {
            var map = GetTestMap(
                new[,]
                {
                    {0, 1, 0},
                    {1, 0, 1},
                    {0, 1, 0}
                });
            var mob = GetTestEntity(new Point(11, 11));
            for (var dx = -mob.Size.Width; dx < mob.Size.Width; dx++)
            {
                mob.Move(new Point(dx, 0));
                var dY = mob.Manipulator.PreDownOrUpMove(new Point(x, y), map).Y;
                Assert.AreEqual(expectedDy, dY);
                mob.Move(new Point(-dx, 0));
            }
        }
        
        [TestCase(0,9, 0)]
        [TestCase(0,-9, -1)]
        public void PreDownOrUpMove_GoToEndOfTheMapIfTheLocationOfTheEntityIsOutOfMap(int x, int y, int expectedDy)
        {
            var map = GetTestMap(new[,] {{0}});
            var mob = GetTestEntity(new Point(0, 1));
            var dY = mob.Manipulator.PreDownOrUpMove(new Point(x, y), map).Y;
            Assert.AreEqual(expectedDy, dY);
        }
        
        [TestCase(0,9, 9)]
        [TestCase(0,-9, -9)]
        public void PreDownOrUpMove_GoToIfThereAreNoBlocksAndEnds(int x, int y, int expectedDy)
        {
            var map = GetTestMap(new[,] {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}});
            var mob = GetTestEntity(new Point(9, 9));
            var dY = mob.Manipulator.PreDownOrUpMove(new Point(x, y), map).Y;
            Assert.AreEqual(expectedDy, dY);
        }
        
        [Test]
        public void PreDownOrUpMove_ThrowExceptionIfXCoordinateIsNotZero()
        {
            var (x, y) = (1, 1);
            var map = GetTestMap(new int[,]{});
            var mob = GetTestEntity(Point.Empty);
            Assert.Throws<ArgumentException>(() => mob.Manipulator.PreDownOrUpMove(new Point(x, y), map));
        }
        
        [Test]
        public void PreDownOrUpMove_ThrowExceptionIfStepIsTooMuch()
        {
            var map = GetTestMap(new [,]{{0, 1, 1}, {1, 1, 1}, {1, 1, 1}});
            var (x, y) = (0, map.CellSize + 1);
            var mob = GetTestEntity(Point.Empty);
            Assert.Throws<ArgumentException>(() => mob.Manipulator.PreDownOrUpMove(new Point(x, y), map));
        }
        
        private static Map GetTestMap(int [,] blockMap) => new Map(blockMap,new List<Mob>(), 10);
        
        private static IEntity GetTestEntity(Point location) =>
            new Mob("test", new Size(9, 9), location, 10, 10);
    }
}