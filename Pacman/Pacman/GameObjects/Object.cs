using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Object
    {
        protected Texture2D texture;
        protected Rectangle source_rec;
        public Vector2 position;      
        public Rectangle hitbox;

        public Object(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, source_rec, Color.White);
        }
    }
}
