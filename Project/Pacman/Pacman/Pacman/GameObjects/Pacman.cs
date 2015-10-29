using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Pacman : Character
    {
        int health = 3;
        double death_timer = 800;
        bool is_hit = false;
        bool run_once = true;
        Vector2 start_position;
        public Pacman(Texture2D texture, Vector2 position, List<string> level_data, Vector2 startpos)
            : base(texture, position, level_data)
        {
            start_position = startpos;
            sheet_pos_X = 176;
            sheet_pos_Y = 16;
            source_rec = new Rectangle(sheet_pos_X, sheet_pos_Y, 16, 16);
            nr_of_frames = 3;
        }

        public int Health()
        {
            return health;
        }

        public bool HitByGhost
        {
            get { return is_hit; }
            set { is_hit = value; }
        }

        private void Animation()
        {
            nr_of_frames = 3;
            if (current_direction.X == 0 && current_direction.Y == -1) //Up
            {
                sheet_pos_X = 128;
                sheet_pos_Y = 0;
            }
            else if (current_direction.X == 0 && current_direction.Y == 1) //Down
            {
                sheet_pos_X = 176;
                sheet_pos_Y = 0;
            }
            else if (current_direction.X == -1 && current_direction.Y == 0) //Left
            {
                sheet_pos_X = 128;
                sheet_pos_Y = 16;
            }
            else if (current_direction.X == 1 && current_direction.Y == 0) //Right
            {
                sheet_pos_X = 176;
                sheet_pos_Y = 16;
            }
        }

        public override void Update(GameTime gameTime)
        {

            if (is_hit != true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    wanted_direction = new Vector2(0, 1);
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    wanted_direction = new Vector2(1, 0);
                else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    wanted_direction = new Vector2(0, -1);
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    wanted_direction = new Vector2(-1, 0);

                Animation();
            }
            else
            {
                sheet_pos_X = 0;
                sheet_pos_Y = 64;
                nr_of_frames = 8;
                target = null;
                wanted_direction = new Vector2(0, 0);

                if (run_once == true)
                {
                    health -= 1;
                    run_once = false;
                }

                death_timer -= gameTime.ElapsedGameTime.TotalMilliseconds;

                if (death_timer <= 0)
                {
                    death_timer = 800;
                    sheet_pos_X = 128;
                    sheet_pos_Y = 0;
                    position = start_position;
                    is_hit = false;
                    run_once = true;
                }
            }

            base.Update(gameTime);      
        }
    }
}
