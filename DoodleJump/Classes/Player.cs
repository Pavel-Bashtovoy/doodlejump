using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Player
    {
        public Physics physics;
        public Image sprite;

        public Player()
        {
            //подгрузим картинку
            sprite = Properties.Resources.man;
            physics = new Physics(new PointF(80, 250), new Size(60, 50));
        }
        //отрисовка персонажа
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
