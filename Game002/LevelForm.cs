using System.Windows.Forms;
using Game002.DirHero;
using Game002.DirMap;

namespace Game002
{
    public partial class LevelForm : Form
    {
        private Level CurrentLevel;
        
        public LevelForm(Level level)
        {
            CurrentLevel = level;
            DoubleBuffered = true;
            InitializeComponent();
            
            var timer = new Timer {Interval = 100};
            timer.Tick += (sender, args) => Invalidate();
            timer.Start();

            KeyDown += HeroObserver.SetKeyDown;
            
            InitializeDefaultLevelComponents();
        }

        private void InitializeDefaultLevelComponents()
        {
            HeroObserver.Hero = CurrentLevel.CurrentHero;
            MapDrawer.Map = CurrentLevel.GetCurrentMap();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            MapDrawer.DrawMap(graphics);
            HeroObserver.Draw(graphics);
        }
    }
}