﻿using System;

namespace TestGame002.Model.DirPhysic
{
    public class Physics
    {
        private readonly double maxVelocity;
        private readonly Level currentLevel;
        
        private const double G = 9.8;

        public Physics(Level level)
        {
            maxVelocity = level.GetCurrentMap().CellSize;
            currentLevel = level;
        }

        public void MoveHero(double dt = 0.1) //TODO Tests
        {
            if (currentLevel.CurrentHero.IsFall(currentLevel.GetCurrentMap()))
            {
                currentLevel.CurrentHero.DownVelocity = Math.Min(maxVelocity, currentLevel.CurrentHero.DownVelocity + dt / 100 * G);
                currentLevel.CurrentHero.Manipulator.PreDownMove(currentLevel.GetCurrentMap());
            }
            else
            {
                currentLevel.CurrentHero.DownVelocity = 0;
            }

            if (currentLevel.CurrentHero.UpVelocity != 0)
            {
                currentLevel.CurrentHero.UpVelocity = Math.Max(0, currentLevel.CurrentHero.UpVelocity - dt / 100 * G);
                currentLevel.CurrentHero.Manipulator.PreUpMove(currentLevel.GetCurrentMap());
            }
        }
    }
}