using System.Windows.Forms;
using Game002.Controllers;

namespace Game002
{
    public partial class MainForm : Form
    {
        public MainForm(GameModel.Model.GameModel model)
        {
            DoubleBuffered = true;
            InitializeComponent();
            MainController.Model = model;

            var timer = new Timer{Interval = model.CurrentLevel.TimerInterval};
            timer.Tick += (sender, args) => Invalidate();
            timer.Tick += MainController.TimerTickEvents;
            timer.Start();
            
            KeyDown += MainController.OnKeyDown;
            KeyPress += MainController.OnKeyPress;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            MainController.Draw(graphics);
        }
    }
}