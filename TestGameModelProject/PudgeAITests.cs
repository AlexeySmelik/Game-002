using System.Drawing;
using GameModel.Model.DirHero;
using GameModel.Model.Mobs;
using NUnit.Framework;

namespace TestGameModelProject
{
    [TestFixture]
    public class PudgeAITests
    {
        private Hero GetHero(Point location) => 
            new Hero("testHero", new Size(64, 64), location, 100, 1, 1);
        
        private Mob GetPudge(Point location) =>
            new Mob("testHero", new Size(64, 64), location, 100, 1, 1);

        
        [Test]
        public void SetVelocity_TrySetVelocity()
        {
            var pudge = GetPudge(Point.Empty);
            var hero = GetHero(new Point(PudgeAI.PudgeStep * 2, 0));
            PudgeAI.SetVelocity(hero, pudge);
            Assert.AreEqual(PudgeAI.PudgeStep, pudge.HorizontalVelocity);
            hero.Move(new Point(-PudgeAI.PudgeStep * 2, 0));
            PudgeAI.SetVelocity(hero, pudge);
            Assert.AreEqual(-PudgeAI.PudgeStep, pudge.HorizontalVelocity);
        }
        
        [Test]
        public void DoRot_CheckOnCooldown() //TODO
        {
            var pudge = GetPudge(Point.Empty);
            var hero = GetHero(Point.Empty);
            for (var i = 1; i < 5; i++)
            {
                PudgeAI.DoRot(hero, pudge);
            }
        }
    }
}