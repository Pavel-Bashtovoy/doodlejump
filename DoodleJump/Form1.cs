using DoodleJump.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoodleJump
{
    public partial class Form1 : Form
    {
        Player player;
        Timer timer1;
        public Form1() 
        {
            //не трогать!!
     
            InitializeComponent();
            Init();
            timer1 = new Timer();
            //задает время
            timer1.Interval = 15;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            //нажата или нет
            this.MouseDown += new MouseEventHandler(OnKeyboardPressed);
            this.MouseClick += new MouseEventHandler(OnKeyboardUp);
            //this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            //this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            //добавляем фон
            this.BackgroundImage = Properties.Resources.back;
            //размер фомы
            this.Height = 600;
            this.Width = 350;
            this.Paint += new PaintEventHandler(OnRepaint);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //инициализация классов
        public void game_over()
        {
            timer1.Stop();
            DialogResult result = MessageBox.Show("Игра окончена!\nВаш результат: "+ PlatformController.score.ToString()+" очков", "Doodle Jump", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Retry) //Если нажал нет
            {
                
                Init();
                timer1.Start();
            }

            if (result == DialogResult.Cancel) //Если нажал Да
            {
                Close();
            }

        }
        public void Init()
        {
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            //стартовая платформа
            PlatformController.AddPlatform(new System.Drawing.PointF(100, 400));
            //начальные значения параметрам
            PlatformController.startPlatformPosY = 400;
            PlatformController.score = 0;
            //генерируем 10 платформ
            PlatformController.GenerateStartSequence();
            //создаем игрока
            player = new Player();
        }
        //при отпускании клавиш-остановка
        private void OnKeyboardUp(object sender, MouseEventArgs e)
        {
            player.physics.dx = 0;
        }
        //управление
        //private void OnKeyboardPressed(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode.ToString())
        //    {
        //        case "Right":
        //            player.physics.dx = 8;
        //            break;
        //        case "Left":
        //            player.physics.dx = -8;
        //            break;
        //    }
        //}

        private void OnKeyboardPressed(object sender, MouseEventArgs e)
        {
            switch (e.Button.ToString())
            {
                case "Right":
                    player.physics.dx = 6;
                    break;
                case "Left":
                    player.physics.dx = -6;
                    break;
            }
        }
        private void Update(object sender, EventArgs e)
        {
            this.Text = "Doodle Jump: Score - " + PlatformController.score;
            //поражение и начать заново
            if (player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 200)
            {
                game_over();
            }
                
                //Init();
            player.physics.ApplyPhysics();
            FollowPlayer();

            Invalidate();
        }
        //смещаем игрока и платформы
        public void FollowPlayer()
        {
            int offset = 300 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.position.Y += offset;
            }
        }
        //перерисовка
        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //если список платформ не пуст-отрисовываем
            if (PlatformController.platforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                    PlatformController.platforms[i].DrawSprite(g);
            }
            player.DrawSprite(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
