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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
