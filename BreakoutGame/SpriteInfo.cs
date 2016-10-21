using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BreakoutGame
{
    class SpriteInfo
    {
        string _spritePath;
        Rectangle _geometry;

        public string SpritePath
        {
            get { return _spritePath; }
            set { _spritePath = value; }
        }

        public Rectangle Geometry
        {
            get { return _geometry; }
            set { _geometry = value; }
        }

    }
}
