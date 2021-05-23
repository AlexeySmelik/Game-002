using System.Windows.Forms;
using TestGame002.Controllers;

namespace TestGame002
{
    public sealed partial class MainForm : Form
    {
        public MainForm(GameModel.Model.GameModel model)
        {
            DoubleBuffered = true;
            InitializeComponent();
            MainController.Model = model;
            model.GenerateCurrentLevel();

            var timer = new Timer{Interval = model.CurrentLevel.TimerInterval};
            timer.Tick += (sender, args) => Invalidate();
            timer.Tick += MainController.TimerTickEvents;
            timer.Start();
            
            KeyDown += MainController.OnKeyDown;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            MainController.Draw(graphics);
        }
    }
}