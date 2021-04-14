using System.Drawing;
using System.Windows.Forms;

namespace Game002.DirHero
{
    public static class HeroObserver
    {
        public static Hero Hero;

        public static void Draw(Graphics g) => HeroDrawer.DrawHero(g, Hero);

        public static void SetKeyDown(object sender, KeyEventArgs args)
        {
            HeroController.Hero = Hero;
            HeroController.OnPressKey(sender, args);
        }
    }
}