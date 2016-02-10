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
            if (OurPlayer == null) return;
            // izgrajdame Bitmap s kartata
            // zashtoto ochakvame che mapa se smenq s pleyara
            var map = OurPlayer.Map.GetTerrain();  
            var mapSize = OurPlayer.Map.TerrainBounds;

            TerrainImage = new Bitmap((int)mapSize.Width, (int)mapSize.Height);
            for(int x=0;x<mapSize.Width;x++)
            {
                for(int y=0;y<mapSize.Height;y++)
                {
                    var c = Color.Black;
                    var t = map[x, y];
                    switch(t)
                    {
                        // izbirame cveta na air i water
                        case TerrainMap.Air:
                            c = Color.Green;
                            break;
                        case TerrainMap.Water:
                            c = Color.Blue;
                            break;
        

                    }
                    // na x i y setvame cvqt
                    TerrainImage.SetPixel(x, y, c);

                      
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // izchisti background-a 
            var g = e.Graphics;
            g.Clear(Color.Black);

            if (OurPlayer == null) return;

            // risuvame terena 
            g.DrawImage(TerrainImage, Point.Empty);

            // risuvame objects
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
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (OurPlayer == null) return;

            int id = 1;
            if (e.Button == MouseButtons.Left)
                id = 0;
            OurPlayer.FireSpell(id, new Vector(e.X, e.Y));
            base.OnMouseDown(e);
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
            const double circleRadius = 6;
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
