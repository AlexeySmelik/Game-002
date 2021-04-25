using System.Drawing;
using GameModel.Model.DirEntity;

namespace GameModel
{
    public static class HelpMethods
    {
        public static bool AreIntersected(Rectangle r1, Rectangle r2) //TODO Tests
        {
            return r1.Bottom >= r2.Top &&
                   r1.Right >= r2.Left &&
                   r2.Bottom >= r1.Top &&
                   r2.Right >= r1.Left;
        }
    }
}