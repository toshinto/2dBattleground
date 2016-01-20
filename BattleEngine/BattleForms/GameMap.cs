using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleEngine;
namespace BattleForms
{
    public partial class GameMap : UserControl
    {
        Player _ourPlayer;
        Bitmap TerrainImage;

        public Player OurPlayer
        {
            get { return _ourPlayer; }
            set
            {
                _ourPlayer = value;
                onPlayerChanged();
            }
        }


        public GameMap()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }


        private void onPlayerChanged()
        {
            var map = OurPlayer.Map.GetTerrain();
            var mapSize = OurPlayer.Map.TerrainBounds;
            TerrainImage = new Bitmap((int)mapSize.Width, (int)mapSize.Height);
            for(int x=0;x<mapSize.Width;x++)
            {
                for(int y=0;y<mapSize.Height;y++)
                {
                    var t = map[x, y];
                    TerrainImage.SetPixel(x, y, Color.White);

                      
                }
            }

            timer1.Enabled = (map != null); 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            if (OurPlayer == null) return;
            g.DrawImage(TerrainImage, Point.Empty);

            var objects = OurPlayer.Map.Objects;

            foreach(var o in objects)
            {
                switch(o.Type)
                {
                    case ObjectType.Unit:
                        drawUnit(g,o);
                        break;
                    case ObjectType.Projectile:
                        drawProjectile(g,o);
                        break; 
                }
            }
        }

        private void drawProjectile(Graphics g,IGameObject o)
        {
            const double circleRadius = 3;
            var br = Brushes.Red;
            var circlePos = o.Position - circleRadius;

            g.FillEllipse(br, (float)circlePos.X, (float)circlePos.Y, (float)circleRadius * 2, (float)circleRadius * 2);
        }

        private void drawUnit(Graphics g, IGameObject o)
        {
            const double circleRadius = 5;
            var br = Brushes.Blue;
            var circlePos = o.Position - circleRadius;

            g.FillEllipse(br, (float)circlePos.X, (float)circlePos.Y, (float)circleRadius * 2, (float)circleRadius * 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate(); 
        }
    }
}
