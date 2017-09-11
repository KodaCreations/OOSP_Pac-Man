using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pacman
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameField[] game = new GameField[1];
        MainMenu main_menu;
        GameOverMenu game_over_menu;
        public static Random rnd;

        enum GameState { Menu, Game, GameOver};
        GameState currentGameState = GameState.Menu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        { base.Initialize(); }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            main_menu = new MainMenu(this.Content, this.graphics);
            game_over_menu = new GameOverMenu(this.Content, this.graphics);
            rnd = new Random();
        }

        protected override void UnloadContent()
        { }

        private void CreateLevel()
        {
            Array.Clear(game, 0, game.Length);
            for (int i = 0; i < game.Length; i++)
            {                
                game[i] = new GameField(this.Content, this.graphics, this.Window);
            }     
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            switch (currentGameState)
            {
                case GameState.Menu:
                    main_menu.Update(gameTime);
                    if (main_menu.StartGame() == true)
                    {
                        CreateLevel();
                        currentGameState = GameState.Game;
                    }
                    else if (main_menu.ExitGame() == true)
                        this.Exit();                    
                    break;

                case GameState.Game:
                    game[0].Update(gameTime);
                    if (game[0].GameWon() == true || game[0].GameLost() == true)
                        currentGameState = GameState.GameOver;
                    break;

                case GameState.GameOver:
                    game_over_menu.Update(gameTime);
                    if (game_over_menu.MainMenu() == true)                     
                        currentGameState = GameState.Menu;
                    else if (game_over_menu.RestartGame() == true)
                    {
                        CreateLevel();
                        currentGameState = GameState.Game;
                    }
                    else if (game_over_menu.ExitGame() == true)
                        this.Exit();              
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(5, 10, 15));
            spriteBatch.Begin();

            switch (currentGameState)
            {
                case GameState.Menu:
                    main_menu.Draw(spriteBatch);
                    break;
                case GameState.Game:
                    game[0].Draw(spriteBatch);
                    break;
                case GameState.GameOver:
                    game[0].Draw(spriteBatch);
                    game_over_menu.Draw(spriteBatch);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
