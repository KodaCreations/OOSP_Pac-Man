using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Food : Object
    {
        public Food(Texture2D texture, Vector2 position, Rectangle source_rec)
            : base(texture, position)
        {
            this.texture = texture;
            this.position = position;
            this.source_rec = source_rec;
        }

        public override void Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)position.X + 6, (int)position.Y + 6, 4, 4);
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
