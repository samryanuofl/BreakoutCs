using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BreakoutGame
{
    class Renderer
    {
        Rectangle _canvas;
        Dictionary<string, Image> _images;

        public Renderer(Rectangle canvas)
        {
            _canvas = canvas;
            _images = new Dictionary<string, Image>();
        }

        public void Render(Graphics g, IRenderable renderable)
        {
            SpriteInfo si = renderable.GetSpriteInfo();
            Image image;
            if (_images.ContainsKey(si.SpritePath))
            {
                image = _images[si.SpritePath];
            }
            else
            {
                image = Image.FromFile(si.SpritePath);
                _images[si.SpritePath] = image;
            }

            g.DrawImage(image, si.Geometry);
            g.DrawRectangle(Pens.Red, si.Geometry);
        }

        public void RenderLayers(Graphics g, Queue<IRenderable> renderables)
        {
            while (renderables.Count != 0)
            {
                this.Render(g, renderables.Dequeue());
            }
        }
    }
}
