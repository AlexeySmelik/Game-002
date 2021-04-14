using System.Windows.Forms;
using TestGame002.Controllers;
using TestGame002.Model;

namespace TestGame002
{
    public partial class MainForm : Form
    {
        public MainForm(GameModel model)
        {
            DoubleBuffered = true;
            InitializeComponent();
            MainController.Model = model;
            
            var timer = new Timer {Interval = 100};
            timer.Tick += (sender, args) => Invalidate();
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