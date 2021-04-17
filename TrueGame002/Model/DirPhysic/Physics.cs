using System;

namespace Game002.Model.DirPhysic
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
            Console.WriteLine($"IS JUMP {currentLevel.CurrentHero.IsJump} {DateTime.Now}");
            if (currentLevel.CurrentHero.IsJump) //Jump
            {
                currentLevel.CurrentHero.UpVelocity = Math.Max(0, currentLevel.CurrentHero.UpVelocity - dt / 100 * G);
                currentLevel.CurrentHero.Manipulator.PreUpMove(currentLevel.GetCurrentMap());
            }
            else
            {
                currentLevel.CurrentHero.UpVelocity = 0;
            }
            
            if (currentLevel.CurrentHero.IsFall(currentLevel.GetCurrentMap())) //Fall
            {
                currentLevel.CurrentHero.DownVelocity = Math.Min(maxVelocity, currentLevel.CurrentHero.DownVelocity + dt / 100 * 2 * G);
                currentLevel.CurrentHero.Manipulator.PreDownMove(currentLevel.GetCurrentMap());
            }
            else
            {
                currentLevel.CurrentHero.DownVelocity = 0;
                currentLevel.CurrentHero.UpVelocity = 0; // без амортизации
            }
        }
    }
}