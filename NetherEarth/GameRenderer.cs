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
        private int offset = 0;

        public void RenderMap(Game game, Graphics graphics)
        {
            Pen buildingPen = new Pen(Color.Red);
            Pen robotPen = new Pen(Color.BlueViolet);

            graphics.Clear(Color.FromArgb(16, 16, 16));

            // Отображаем постройки
            foreach (GameObject o in game.GameObjects)
            {
                foreach (NetherEarthGame.Point p in o.Points)
                {
                    graphics.DrawRectangle(buildingPen, (p.X + o.X - offset) * squareSide, (p.Y + o.Y) * squareSide, squareSide, squareSide);
                }
            }

            // Отображаем роботов
            foreach (Robot r in game.Robots)
            {
                foreach (NetherEarthGame.Point p in r.Points)
                {
                    graphics.DrawRectangle(robotPen, (p.X + r.X - offset) * squareSide, (p.Y + r.Y) * squareSide, squareSide, squareSide);
                }
            }

            graphics.DrawLine(buildingPen, 0, squareSide * 32 + 1, 1920, squareSide * 32 + 1);
        }

        public void OffsetLeft()
        {
            if (offset >= 100) offset -= 100;
        }

        public void OffsetRight()
        {
            if (offset <= 700) offset += 100;
        }
    }
}
