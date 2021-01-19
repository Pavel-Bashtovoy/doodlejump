using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Transform
    {
        //позиция обьекта 
        public PointF position;
        //координаты обьекта
        public Size size;
        //конструктор позиции и координат
        public Transform(PointF position, Size size)
        {
            this.position = position;
            this.size = size;
        }
    }
}
