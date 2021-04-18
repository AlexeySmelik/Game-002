using System.Drawing;
using Game002.Model;
using NUnit.Framework;

namespace TestGame002.DirTests
{
    [TestFixture]
    public class MapMethodsTests
    {
        [SetUp]
        public void Setup()
        {
            var emptyBlockMap = new int[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 1}
            };
            testMap = new Map(3, 3){ BlockMap = emptyBlockMap, CellSize = 1};
        }

        private Map testMap;

        [Test]
        public void IfThePointIsOutsideTheBorder()
        {
            Assert.AreEqual(false, testMap.IsBound(new Point(-1, -1)));
        }
        
        [Test]
        public void IfThePointOnTheBorder()
        {
            Assert.AreEqual(true, testMap.IsBound(new Point(3, 3)));
        }
        
        [Test]
        public void IfThePointIsInsideMap()
        {
            Assert.AreEqual(true, testMap.IsBound(new Point(1, 1)));
        }
    }
}