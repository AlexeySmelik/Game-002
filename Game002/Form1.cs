using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Game002.DirHero;
using Game002.DirMap;

namespace Game002
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();

            var timer = new Timer {Interval = 100};
            timer.Tick += (sender, args) => Invalidate();
            timer.Start();
            KeyDown += HeroController.OnPressKey;
            
            Init();
        }

        private static void Init()
        {
            
            var naruto = new Hero(new Size(64, 64), new Point(100, 100))
            {
                HeroView = new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\MainCharacter\Naruto128x128.png"))
            };
            HeroController.Hero = naruto;
            
            var testMap = new Map(15, 20)
            {
                BlockMap = MapController.GetTestMap(),
                Background = new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\Backgrounds\BackgroundCity.png"))
            };
            MapController.Map = testMap;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Text = $"Window: {Width} x {Height} Background: {MapController.Map.Background.Width} x {MapController.Map.Background.Height}" +
                   $" MapCellSize = {MapController.Map.CellSize}";

            var graphics = e.Graphics;
            MapController.DrawMap(graphics);
            //MapController.DrawMapSheet(graphics);
            
            HeroController.DrawHero(graphics);
            //HeroController.DrawHeroSheet(graphics);
        }
    }
}