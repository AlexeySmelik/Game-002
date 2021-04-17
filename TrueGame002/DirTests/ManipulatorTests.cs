using System.Drawing;
using Game002.Model.DirHero;
using NUnit.Framework;

namespace TestGame002.DirTests
{
    [TestFixture]
    public class ManipulatorTests
    {
        [SetUp]
        public void Setup() // TODO
        {
            var hero = new Hero(new Size(64, 64), new Point(100, 100));
            Manipulator = new Manipulator(hero);
        }

        private Manipulator Manipulator;
    }
}