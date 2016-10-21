using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BreakoutGame
{
    class Ball : IRenderable
    {
        System.Drawing.Rectangle _location;
        Vector2 _velocity;

        readonly int _width = 15;
        readonly int _height = 15;

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public System.Drawing.Rectangle Geometry
        {
            get { return _location; }
        }


        public Ball(int x, int y, int vX, int vY)
        {
            _velocity = new Vector2((float)vX, (float)vY);
            _location = new System.Drawing.Rectangle(x, y, _width, _height);
        }

        public void Tick(TimeSpan t)
        {
            _location.X += (int)((double)_velocity.X * ((double)t.TotalMilliseconds / 1000.0));
            _location.Y += (int)((double)_velocity.Y * ((double)t.TotalMilliseconds / 1000.0));
        }

        SpriteInfo IRenderable.GetSpriteInfo()
        {
            SpriteInfo si = new SpriteInfo();
            si.SpritePath = @"c:\tmp\breakout\ball.png";
            si.Geometry = _location;
            return si;
        }
    }
}
