using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakoutGame
{
    class Board : IRenderable
    {
        System.Drawing.Rectangle _geometry;

        public System.Drawing.Rectangle Geometry
        {
            get { return _geometry; }
        }

        public Board(System.Drawing.Rectangle geometry)
        {
            _geometry = geometry;
        }

        SpriteInfo IRenderable.GetSpriteInfo()
        {
            SpriteInfo si = new SpriteInfo();
            si.Geometry = _geometry;
            si.SpritePath = @"c:\tmp\breakout\board.png";
            return si;
        }
    }
}
