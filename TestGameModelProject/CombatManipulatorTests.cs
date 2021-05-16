using System.Drawing;
using GameModel.Model.Data;
using GameModel.Model.Mobs;
using NUnit.Framework;

namespace TestGameModelProject
{
    [TestFixture]
    public class CombatManipulatorTests
    {
        [Test]
        public void GetDamage_IfTheDamageTakenIsLessThanTheOriginalAmountOfHealth()
        {
            var testEntity = GetTestEntity(Point.Empty);
            testEntity.CombatManipulator.GetDamage(10);
            Assert.AreEqual(90, testEntity.CombatManipulator.Health);
        }
        
        [Test]
        public void GetDamage_IfTheDamageTakenIsMoreThanTheOriginalAmountOfHealth()
        {
            var testEntity = GetTestEntity(Point.Empty);
            testEntity.CombatManipulator.GetDamage(101);
            Assert.AreEqual(0, testEntity.CombatManipulator.Health);
            Assert.AreEqual(false, testEntity.IsActive);
        }

        [Test]
        public void DoDamage_IfTheEntityIsNotPeaceful()
        {
            var testEntityMain = GetTestEntity(Point.Empty);
            var testEntity = GetTestEntity(Point.Empty);
            testEntityMain.CombatManipulator.DoDamage(testEntity, 10);
            Assert.AreEqual(90, testEntity.CombatManipulator.Health);
        }
        
        [Test]
        public void TrySpendAndRestoreStamina()
        {
            var testEntity = GetTestEntity(Point.Empty);
            testEntity.CombatManipulator.TrySpendStamina(10);
            Assert.AreEqual(90, testEntity.CombatManipulator.Stamina);
            testEntity.CombatManipulator.RestoreStamina(10);
            Assert.AreEqual(100, testEntity.CombatManipulator.Stamina);
        }

        [TestCase(100, 0)]
        [TestCase(50, 0)]
        [TestCase(125, 0)]
        public void DoSimpleAttack_TheEnemyIsNear(int x, int y)
        {
            var testEntityMain = GetTestEntity(Point.Empty);
            testEntityMain.CombatManipulator.IsReadyToAttack = true;
            var testEntity = GetTestEntity(new Point(x, y));
            for (var i = 0; i < testEntityMain.CombatManipulator.Cooldown; i++)
                testEntityMain.CombatManipulator.DoSimpleAttack(new [] {testEntity}, 5);
            Assert.AreEqual(90, testEntity.CombatManipulator.Health);
        }
        
        [Test]
        public void DoSimpleAttack_CheckCooldown()
        {
            var testEntityMain = GetTestEntity(Point.Empty);
            var testEntity = GetTestEntity(new Point(100, 0));
            for (var i = 0; i < 3 * testEntityMain.CombatManipulator.Cooldown / 2; i++)
            {
                testEntityMain.CombatManipulator.IsReadyToAttack = true;
                testEntityMain.CombatManipulator.DoSimpleAttack(new[] {testEntity}, 5);
            }
            Assert.AreEqual(80, testEntity.CombatManipulator.Health);
        }
        
        private static IEntity GetTestEntity(Point location) =>
            new Mob("testMob", new Size(100, 100), location);
    }
}