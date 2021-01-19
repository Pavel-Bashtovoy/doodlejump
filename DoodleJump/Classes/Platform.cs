using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Platform
    {
        Image sprite;
        //СОХРАНЯЕМ РАЗМЕР И ПОЗИЦИЮ 
        public Transform transform;
        //задаем размер платформы
        public int sizeX;
        public int sizeY;
        //коснулся платформы или нет
        public bool isTouchedByPlayer;
        public Platform(PointF pos)
        {
            //подгрузили спрайты
            sprite =Properties.Resources.platform;
            //размеры платформы 
            sizeX = 60;
            sizeY = 12;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            isTouchedByPlayer = false;
        }
        //отрисовка текущей платформы
        public void DrawSprite(Graphics g)
        {
            //картинка/позиция/размеры
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }

    }
}
