using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BreakoutGame
{
    class Paddle : IRenderable
    {
        Rectangle _geometry;

        public Rectangle Geometry
        {
            get { return _geometry; }
        }

        public Paddle(Rectangle Geometry)
        {
            _geometry = Geometry;
        }
        
        public void SetLocation(int x)
        {
            _geometry = new Rectangle(x, _geometry.Location.Y, _geometry.Size.Width, _geometry.Size.Height);
        }

        public SpriteInfo GetSpriteInfo()
        {
            SpriteInfo si = new SpriteInfo();
            si.Geometry = _geometry;
            si.SpritePath = @"c:\tmp\breakout\paddle.png";
            return si;
        }
    }
}
