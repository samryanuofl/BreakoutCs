using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakoutGame
{ 
    public partial class Form1 : Form
    {
        Rectangle _rectBoard;
        Renderer _renderer;
        Timer _frameTimer;
        BreakoutState _gameState;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            int boardHeight = this.Height - 100;
            int boardWidth = this.Width - 100;
            _rectBoard = new Rectangle(50, 50, boardWidth, boardHeight);
            _renderer = new Renderer(_rectBoard);
            _gameState = new BreakoutState(800, 600);

            _frameTimer = new Timer();
            _frameTimer.Interval = 33;
            _frameTimer.Tick += new EventHandler(TimerTick);
            _frameTimer.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _frameTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _gameState.Tick();
            _renderer.RenderLayers(e.Graphics, _gameState.GetRenderables());
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _gameState.Tick();
            this.Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            _gameState.setPaddlePos(e.X);

        }
    }
}
