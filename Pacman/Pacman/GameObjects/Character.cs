using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Character : Object
    {
        protected List<string> level_data;
        protected int sheet_pos_X = 0;
        protected int sheet_pos_Y = 0;
        protected int frame;
        protected double frame_timer;
        protected double frame_interval;
        protected int nr_of_frames;
        protected const float Speed = 32;
        protected Vector2 current_direction;
        protected Vector2 wanted_direction = new Vector2(0, 0);      
        protected Vector2? target;

        public Character(Texture2D texture, Vector2 position, List<string> level_data)
            : base(texture, position)
        {
            this.texture = texture;
            this.position = position;
            this.level_data = level_data;
            frame_timer = 100;
            frame_interval = 100;          
        }

        private bool CanMoveInDirection(Vector2 position, Vector2 direction)
        {
            int nx = (int)(position.X / 16) + (int)direction.X;
            int ny = (int)(position.Y / 16) + (int)direction.Y;
            return level_data[ny][nx] != 'x';
        }

        protected bool MoveTowardsPoint(Vector2 goal, float elapsed)
        {
            if (position == goal) return true;

            Vector2 direction = Vector2.Normalize(goal - position);

            position += direction * Speed * elapsed;

            current_direction = direction;

            if (Math.Abs(Vector2.Dot(direction, Vector2.Normalize(goal - position)) + 1) < 0.1f)
                position = goal;

            return position == goal;
        }

        public override void Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)position.X + 3, (int)position.Y + 3, 10, 10);

            if (target == null)
                if (CanMoveInDirection(position, wanted_direction))
                    target = position + wanted_direction * 16;

            if (target != null)
                if (MoveTowardsPoint(target.Value, (float)gameTime.ElapsedGameTime.TotalSeconds))
                    target = null;

            frame_timer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frame_timer <= 0)
            {
                frame_timer = frame_interval;
                frame++;
                source_rec.X = sheet_pos_X + (frame % nr_of_frames) * 16;
                source_rec.Y = sheet_pos_Y;
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}