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
        private Graphics g;
        private GameRenderer gameRenderer = new GameRenderer();
        private GameRunner gameRunner;
        private delegate void RefreshPictire();
        RefreshPictire refreshPictire;

        public Form1()
        {
            InitializeComponent();
            gameRunner = new GameRunner(new Game());
            gameRunner.GameUpdated += OnGameUpdated;
            refreshPictire = new RefreshPictire(pictureBox1.Refresh);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = gameRunner.Game.Height + 2;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void OnGameUpdated(Game game)
        {
            gameRenderer.RenderMap(game, g);
            Invoke(refreshPictire);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameRunner.Start();
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
            gameRunner.CreateRobot();
        }
    }
}
