using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameModel.Model.Data;

namespace GameModel.Model.Manipulators
{
    public class CombatManipulator : ICombat
    {
        public int Health { get; private set; }
        public int Attack { get; }
        public bool IsReadyToAttack { get; set; }
        public int Stamina { get; private set; }
        public int StaminaLimit { get; }
        public int Cooldown { get; }
        
        private readonly IEntity _entity;

        public CombatManipulator(
            IEntity entity,
            int health,
            int attack,
            int stamina,
            int cooldown)
        {
            _entity = entity;
            Health = health;
            Attack = attack;
            StaminaLimit = stamina;
            Cooldown = cooldown;
            Stamina = StaminaLimit;
        }

        public void GetDamage(int damage)
        {
            Health = Math.Max(Health - damage, 0);
            if (Health == 0)
                _entity.IsActive = false;
        }

        public void DoDamage(IEntity enemy, int damage)
        {
            if (!enemy.IsPeaceful())
                enemy.CombatManipulator.GetDamage(damage);
        }

        public void RestoreStamina(int stamina)
        {
            Stamina = Math.Min(Stamina + stamina, StaminaLimit);
        }

        public bool TrySpendStamina(int stamina)
        {
            if (Stamina < stamina)
            {
                Stamina = 0;
                return false;
            }

            Stamina -= stamina;
            return true;
        }

        private int _ticks;

        private bool CheckCooldown()
        {
            _ticks %= Cooldown;
            return ++_ticks == Cooldown / 2;
        }

        public void DoSimpleAttack(IEnumerable<IEntity> enemies, int cost)
        {
            if (IsReadyToAttack && CheckCooldown() && TrySpendStamina(cost))
            {
                foreach (var it in enemies.Where(it => it.IsActive && !it.IsPeaceful()))
                {
                    var r1 = new Rectangle(it.Location, it.Size);
                    var r2 = new Rectangle(
                        new Point(
                            _entity.Location.X + (int) _entity.Direction * _entity.Size.Width / 2,
                            _entity.Location.Y),
                        _entity.Size);
                    if (IsReadyToAttack && Rectangle.Intersect(r1, r2) != Rectangle.Empty)
                    {
                        DoDamage(it, Attack);
                        IsReadyToAttack = false;
                    } else if (!IsReadyToAttack) break;
                }
                IsReadyToAttack = false;
                _ticks = 0;
            }
        }
    }
}