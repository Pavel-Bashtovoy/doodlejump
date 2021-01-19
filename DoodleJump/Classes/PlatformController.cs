using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class PlatformController
    {
        //для создания новых платформ или отчиски старых 
        public static List<Platform> platforms;//хранение платформ на карте 
        public static int startPlatformPosY = 400;//начальная позиция
        public static int score = 0;//очки
        //добавление платформы 
        public static void AddPlatform(PointF position)
        {
            //создаем пл и добавляем в лист 
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }
        //генерируем количество платформ и их позиции в начале
        public static void GenerateStartSequence()
        {
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                int x = r.Next(0, 290);
                int y = r.Next(50, 70);
                startPlatformPosY -= y;//смещаем по у относ предыдущей
                PointF position = new PointF(x, startPlatformPosY);
                Platform platform = new Platform(position);
                //кладем платформу в лист
                platforms.Add(platform);
            }
            startPlatformPosY -= 25;
        }
        //добавляем новые платформы
        public static void GenerateRandomPlatform()
        {
            Random r = new Random();
            //генерируем х
            int x = r.Next(0, 270);
            PointF position = new PointF(x, startPlatformPosY);
            Platform platform = new Platform(position);
            //кладем платформу в лист
            platforms.Add(platform);
        }
        //очистка формы от платформ если они далеко от персонажа
        public static void ClearPlatforms()
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (platforms[i].transform.position.Y >= 700)
                    platforms.RemoveAt(i);
            }
        }
    }
}
