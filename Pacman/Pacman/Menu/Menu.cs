using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Menu
    {
        protected Texture2D menu_sheet;
        protected Vector2 exit_pos;
        protected SpriteFont button_font;
        protected List<Button> buttons = new List<Button>();
        protected int menu_width = 300;
        protected int menu_height = 400;
        protected bool exit_game;
        GraphicsDeviceManager graphics;

        public Menu(ContentManager content, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            menu_sheet = content.Load<Texture2D>("menu");
            button_font = content.Load<SpriteFont>("ButtonFont");
        }

        public bool ExitGame()
        {
            return exit_game;
        }

        private void SetResolution()
        {
            graphics.PreferredBackBufferWidth = menu_width;
            graphics.PreferredBackBufferHeight = menu_height;
            graphics.ApplyChanges();
        }

        public virtual void Update(GameTime gameTime)
        {
            SetResolution();
            exit_game = false;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw(spriteBatch);
            }
        }
    }
}
