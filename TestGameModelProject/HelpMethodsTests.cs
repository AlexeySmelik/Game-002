using System.Collections.Generic;
using System.Drawing;
using GameModel;
using GameModel.Model;
using GameModel.Model.DirEntity;
using GameModel.Model.Mobs;
using NUnit.Framework;

namespace TestGameModelProject
{
    [TestFixture]
    public class HelpMethodsTests
    {
        [Test]
        public void AreIntersected_IfTheyAreNotIntersected()
        {
            var r1 = new Rectangle(Point.Empty, new Size(1,1));
            var r2 = new Rectangle(new Point(2,1), new Size(1, 1));

            Assert.AreEqual(false, HelpMethods.AreIntersected(r1, r2));
        }

        [Test]
        public void AreIntersected_IfFirstRectangleInSecondRectangle()
        {
            var r1 = new Rectangle(Point.Empty, new Size(20,20));
            var r2 = new Rectangle(new Point(2,2), new Size(1,1));

            Assert.AreEqual(true, HelpMethods.AreIntersected(r1, r2));
        }

        private static List<(Point, Point, Size, Size)> characteristicsOfRectangles = new List<(Point, Point, Size, Size)>
        {
            (new Point(0, 0), new Point(1, 1), new Size(1, 1), new Size(1, 1)),
            (new Point(0, 0), new Point(0, 0), new Size(1, 1), new Size(2, 2)),
            (new Point(1, 1), new Point(2, 2), new Size(3, 3), new Size(1, 1)),
            (new Point(1, 1), new Point(1, 1), new Size(1, 1), new Size(1, 1)),
        };

        [Test, TestCaseSource("characteristicsOfRectangles")]
        public void AreIntersected_IfTheyAreIntersected((Point, Point, Size, Size) case1)
        {
            var r1 = new Rectangle(case1.Item1, case1.Item3);
            var r2 = new Rectangle(case1.Item2, case1.Item4);

            Assert.AreEqual(true, HelpMethods.AreIntersected(r1, r2));
        }
    }
}