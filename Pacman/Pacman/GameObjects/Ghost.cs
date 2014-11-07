using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Ghost : Character
    {
        public Ghost(Texture2D texture, Vector2 position, List<string> level_data)
            : base(texture, position, level_data)
        {
            source_rec = new Rectangle(sheet_pos_X, sheet_pos_Y, 16, 16);
            nr_of_frames = 2;
            current_direction = new Vector2(0, -1);
        }

        private void Animation()
        {
            if (current_direction.X == 0 && current_direction.Y == -1) //Up
                sheet_pos_X = 0;
            else if (current_direction.X == 0 && current_direction.Y == 1) //Down            
                sheet_pos_X = 32;
            else if (current_direction.X == -1 && current_direction.Y == 0) //Left          
                sheet_pos_X = 64;
            else if (current_direction.X == 1 && current_direction.Y == 0) //Right            
                sheet_pos_X = 96;
        }

        public override void Update(GameTime gameTime)
        {
            if (target == null)
            {
                int i = Game1.rnd.Next(1, 5);
                if (i == 1) //Up  
                    if (current_direction.X == 0 && current_direction.Y == 1) { }
                    else
                        wanted_direction = new Vector2(0, -1);
                else if (i == 2) //Down  
                    if (current_direction.X == 0 && current_direction.Y == -1) { }
                    else
                        wanted_direction = new Vector2(0, 1);
                else if (i == 3) //Left  
                    if (current_direction.X == 1 && current_direction.Y == 0) { }
                    else
                        wanted_direction = new Vector2(-1, 0);
                else if (i == 4) //Right  
                    if (current_direction.X == -1 && current_direction.Y == 0) { }
                    else
                        wanted_direction = new Vector2(1, 0);
            }

            Animation();
            base.Update(gameTime);
        }
    }
}