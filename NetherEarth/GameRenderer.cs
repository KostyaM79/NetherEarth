using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetherEarthGame;
using System.Drawing;

namespace NetherEarth
{
    public class GameRenderer
    {
        private int squareSide = 8;
        private int offset = 100;

        public void RenderMap(Game game, Graphics graphics)
        {
            Pen pen = new Pen(Color.Red);

            foreach (GameObject o in game.GameObjects)
            {
                foreach (NetherEarthGame.Point p in o.Points)
                {
                    graphics.DrawRectangle(pen, (p.X + o.X - offset) * squareSide, (p.Y + o.Y) * squareSide, squareSide, squareSide);
                }
            }
        }
    }
}
