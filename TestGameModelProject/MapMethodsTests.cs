using System.Collections.Generic;
using System.Drawing;
using GameModel.Model;
using GameModel.Model.DirEntity;
using GameModel.Model.Mobs;
using NUnit.Framework;

namespace TestGameModelProject
{
    [TestFixture]
    public class MapTests
    {
        [SetUp]
        public void Setup()
        {
            _testMap = new Map(3, 3, new List<Mob>(), 3)
            {
                BlockMap = new [,]
                {
                    {1, 1, 1},
                    {0, 0, 0},
                    {1, 1, 1}
                }
            };
        }

        private Map _testMap;
        
        [Test]
        public void IsBound_IfThePointIsOutsideTheMap()
        {
            Assert.AreEqual(false, _testMap.IsBound(new Point(-1, -1)));
        }
        
        [TestCase(0, 0, Description = "Border point")]
        [TestCase(1, 1, Description = "No border point")]
        public void IsBound_IfThePointIsOnTheMap(int x, int y)
        {
            Assert.AreEqual(true, _testMap.IsBound(new Point(x, y)));
        }

        [Test]
        public void IsBlock_IfItIsOutsideTheMap()
        {
            Assert.AreEqual(false, _testMap.IsBlock(new Point(-1, -1)));
        }
        
        [TestCase(0, 0,true, Description = "Border point")]
        [TestCase(1, 1,true, Description = "No border point")]
        [TestCase(4, 4,false, Description = "No border point")]
        [TestCase(3, 3,false, Description = "Maybe(no) border point")]
        public void IsBlock_IfThePointIsOnTheMap(int x, int y, bool exceptedResult)
        {
            Assert.AreEqual(exceptedResult, _testMap.IsBlock(new Point(x, y)));
        }
    }
}