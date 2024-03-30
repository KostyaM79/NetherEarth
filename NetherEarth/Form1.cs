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
        private Game game = new Game();
        private int width = Screen.PrimaryScreen.Bounds.Width;
        private int height = Screen.PrimaryScreen.Bounds.Height;
        Bitmap bitmap;

        public Form1()
        {
            bitmap = new Bitmap(width, height);
            g = Graphics.FromImage(bitmap);
            //g = CreateGraphics();

            InitializeComponent();

            GameObjectFactory objectFactory = new GameObjectFactory();
            objectFactory.CreateObject(game);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            BackgroundImage = bitmap;
            gameRenderer.RenderMap(game, g);
        }
    }
}
