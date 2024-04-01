using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetherEarthGame;

namespace NetherEarth
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private Graphics g;
        private GameRenderer gameRenderer = new GameRenderer();
        private Game game = new Game();

        public Form1()
        {
            InitializeComponent();
            game.GameUpdated += OnGameUpdated;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = game.Height + 2;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void OnGameUpdated(Game game)
        {
            gameRenderer.RenderMap(game, g);
            pictureBox1.Refresh();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer.Interval = 250;
            timer.Tick += Timer_Tick;
            game.Start();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            game.GameUpdate();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            gameRenderer.OffsetLeft();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            gameRenderer.OffsetRight();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            game.CreateRobot();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
