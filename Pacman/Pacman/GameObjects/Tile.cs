using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Tile : Object
    {
        public Vector2 pos;

        public Tile(Texture2D texture, Vector2 position, Rectangle source_rec)
            : base(texture, position)
        {
            this.texture = texture;
            this.pos = position;
            this.source_rec = source_rec;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}