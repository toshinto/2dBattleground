using BattleEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleForms
{
    public partial class Form1 : Form
    {
        Game mainGame;
        Player ourPlayer;


        bool inGame
        {
            get { return mainGame != null;  }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            mainGame = new Game(name);
            ourPlayer = mainGame.HostingPlayer;

            gameMap1.OurPlayer = ourPlayer;

            timer1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        Point speed = new Point(0,0);


        protected override void OnKeyDown(KeyEventArgs e)
        {

            Console.WriteLine(e.KeyCode.ToString());
            switch (e.KeyCode)
            {
                case Keys.W: speed.Y -= 1;
                    break;
                case Keys.D: speed.X += 1;
                    break;
                case Keys.A: speed.X -= 1;
                    break;
                case Keys.S: speed.Y += 1;
                    break;
                default: return;
            }
            UpdatePlayerMove();


        }
        protected override void OnKeyUp(KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    speed.Y += 1;
                    break;
                case Keys.D:
                    speed.X -= 1;
                    break;
                case Keys.A:
                    speed.X += 1;
                    break;
                case Keys.S:
                    speed.Y -= 1;
                    break;
                default: return;
            }
            UpdatePlayerMove();
        }

        void UpdatePlayerMove()
        {
            if (ourPlayer == null) return;

            var isMoving = speed.X != 0 || speed.Y != 0;
            var angle = new Vector(speed.X, speed.Y).Angle;

            ourPlayer.UpdateMovement(isMoving, angle);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mainGame.Update(timer1.Interval);
            gameMap1.Invalidate();

            Keyboard.Update();

            if (Keyboard.GetKeyState(Keys.F))
                Console.WriteLine("F");
        }
    }
}
