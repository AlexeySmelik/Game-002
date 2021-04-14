using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Game002.DirHero;
using Game002.DirMap;
using Game002.Maps;

namespace Game002
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var naruto = new Hero(new Size(64, 64), new Point(100, 100))
            {
                HeroView = new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\MainCharacter\Naruto128x128.png"))
            };
            var testMap = new Map(15, 20)
            {
                BlockMap = SetTestMaps.GetTestMap0(),
                Background = new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\Backgrounds\BackgroundCity.png"))
            };
            var level = new Level(naruto, new List<Map>{ testMap });
            LevelController.CurrentLevel = level;
            LevelController.Run();
        }
    }
}