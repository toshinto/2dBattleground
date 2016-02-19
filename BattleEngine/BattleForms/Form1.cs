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
      

        void UpdatePlayerMove()
        {
            if (ourPlayer == null) return;

            var isMoving = speed.X != 0 || speed.Y != 0;
            var angle = new Vector(speed.X, speed.Y).Angle;

            ourPlayer.SetMovement(isMoving, angle);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mainGame.Update(timer1.Interval);
            gameMap1.Invalidate();

            Keyboard.Update();

            var x = 0;
            var y = 0;
            if (Keyboard.GetKeyState(Keys.D)) x++;
            if (Keyboard.GetKeyState(Keys.A)) x--;
            if (Keyboard.GetKeyState(Keys.W)) y--;
            if (Keyboard.GetKeyState(Keys.S)) y++;
            speed   = new Point(x, y);

            UpdatePlayerMove();

        }
    }
}
