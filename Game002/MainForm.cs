using System.Windows.Forms;
using Game002.Controllers;
using Game002.Model;

namespace Game002
{
    public partial class MainForm : Form
    {
        public MainForm(GameModel model)
        {
            DoubleBuffered = true;
            InitializeComponent();
            MainController.Model = model;
            
            var timer = new Timer{Interval = 5};
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