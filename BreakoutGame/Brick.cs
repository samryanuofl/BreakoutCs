using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BreakoutGame
{
    class Brick : IRenderable
    {
        Rectangle _geometry;
        bool _isActive;

        public Rectangle Geometry
        {
            get { return _geometry; }
        }

        public Brick(Rectangle Geometry)
        {
            _geometry = Geometry;
            _isActive = true;
        }

        SpriteInfo IRenderable.GetSpriteInfo()
        {
            SpriteInfo si = new SpriteInfo();
            si.SpritePath = @"c:\tmp\breakout\brick.png";
            si.Geometry = _geometry;
            return si;
        }
    }
}
