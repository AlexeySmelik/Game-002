using System.Drawing;
using System.Windows.Forms;

namespace Game002
{
    public static class LevelController
    {
        internal static Level CurrentLevel;

        public static void Run()
        {
            var form = new LevelForm(CurrentLevel)
            {
                ClientSize = new Size(800, 600),
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.Fixed3D,
            };
            Application.Run(form);
        }
    }
}