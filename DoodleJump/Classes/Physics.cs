using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Physics
    {
        //размер и позиция
        public Transform transform;
        //реализация прыжка
        float gravity;
        //ускорение 
        float a;
        //движение право/лево
        public float dx;

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            a = 0.3f;
            dx = 0;
        }

        public void ApplyPhysics()
        {
            CalculatePhysics();
        }

        //передвижение и прыжок
        public void CalculatePhysics()
        {
            if (dx != 0)
            {
                //двигаем по dx
                transform.position.X += dx;
            }
            if (transform.position.Y < 700)
            {
                //по dy
                transform.position.Y += gravity;
                gravity += a;
                Collide();
            }
        }
        //просмотр платформ из списка
        public void Collide()
        {
            //перебор платформ
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                //игрок находится ли игрок на платформе по х
                if (transform.position.X + transform.size.Width / 2 >= platform.transform.position.X && transform.position.X + transform.size.Width / 2 <= platform.transform.position.X + platform.transform.size.Width)
                {
                    //игрок находится ли игрок на платформе по у
                    if (transform.position.Y + transform.size.Height >= platform.transform.position.Y && transform.position.Y + transform.size.Height <= platform.transform.position.Y + platform.transform.size.Height)
                    {
                        //перелетел ли на нее
                        if (gravity > 0)
                        {
                            //касание
                            if (!platform.isTouchedByPlayer)
                            {
                                AddForce();
                                PlatformController.score += 10;
                                //генерируем платформу
                                PlatformController.GenerateRandomPlatform();
                                platform.isTouchedByPlayer = true;
                            }
                        }
                    }
                }
            }
        }
        
        public void AddForce()
        {
            gravity = -10;
        }

    }
}
