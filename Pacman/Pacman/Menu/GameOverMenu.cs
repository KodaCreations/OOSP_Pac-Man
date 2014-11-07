using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class GameOverMenu:Menu
    {
        Vector2 main_pos, restart_pos;
        bool main_menu;
        bool restart_game;

        public GameOverMenu(ContentManager content, GraphicsDeviceManager graphics):base(content, graphics)
        {
            for (int i = 0; i < 3; i++)
            {
                Button b = new Button(menu_sheet, new Vector2((menu_width / 2) - (menu_sheet.Width / 2), i * 75 + 125));
                buttons.Add(b);
            }
        }

        public bool MainMenu()
        {
            return main_menu;
        }
        public bool RestartGame()
        {
            return restart_game;
        }

        private void TextPositions()
        {
            main_pos = new Vector2(buttons[0].position.X + (menu_sheet.Width / 2) - (int)button_font.MeasureString("Main Menu").Length() / 2, buttons[0].position.Y + 15);
            restart_pos = new Vector2(buttons[1].position.X + (menu_sheet.Width / 2) - (int)button_font.MeasureString("Restart").Length() / 2, buttons[1].position.Y + 15);
            exit_pos = new Vector2(buttons[2].position.X + (menu_sheet.Width / 2) - (int)button_font.MeasureString("Exit").Length() / 2, buttons[2].position.Y + 15);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            TextPositions();
            main_menu = false;
            restart_game = false;       

            if (buttons[0].pressed == true)
                main_menu = true;
            else if (buttons[1].pressed == true)
                restart_game = true;
            else if (buttons[2].pressed == true)
                exit_game = true;          
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(button_font, "Main Menu", main_pos, new Color(255, 222, 0));
            spriteBatch.DrawString(button_font, "Restart", restart_pos, new Color(255, 222, 0));
            spriteBatch.DrawString(button_font, "Exit", exit_pos, new Color(255, 222, 0));
        }
    }
}
