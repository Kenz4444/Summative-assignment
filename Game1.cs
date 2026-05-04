using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Summative_assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D supermanTexture, skyTexture, kryptoniteTexture, supermanIntrotexture, endTexture, gameOvertexture;

        Rectangle window;
        Rectangle supermanRect;
        Rectangle gameOverRect;

        SpriteFont introFont;
        SpriteFont gameFont;
        SpriteFont endFont;
        
        

        SpriteEffects supermanEffect;

        Vector2 supermanSpeed;
        Vector2 cursorPosition;

        MouseState mouseState;

        bool dead;


        enum Screen
        {
            Intro,
            supermanGame,
            End
        }
        Screen screen;


        Random generator = new Random();

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            supermanEffect = SpriteEffects.FlipHorizontally;
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            supermanRect = new Rectangle(300, 10, 200, 100);
            gameOverRect = new Rectangle(300, 10, 400, 200);
           


            supermanSpeed = new Vector2(10, 7);

            
            dead = false;

            screen = Screen.Intro;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            supermanTexture = Content.Load<Texture2D>("supermanFlying");
            kryptoniteTexture = Content.Load<Texture2D>("kryptonite");
            skyTexture = Content.Load<Texture2D>("sky2");
            supermanIntrotexture = Content.Load<Texture2D>("lexCorp");
            gameOvertexture = Content.Load<Texture2D>("gameOver");
            introFont = Content.Load<SpriteFont>("Intro");


           

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here



            mouseState = Mouse.GetState();
            cursorPosition = new Vector2(mouseState.X, mouseState.Y);
            if (screen == Screen.Intro)
            {
                
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    screen = Screen.supermanGame;
                    

                }


            }


            else if ( screen == Screen.supermanGame)
            {
                supermanRect.X += (int)supermanSpeed.X;
                if (supermanRect.Left > window.Width)
                {

                    supermanRect.X = -supermanRect.Width;
                    supermanSpeed = new Vector2(generator.Next(6, 11), generator.Next(6, 11));


                }


                supermanRect.Y += (int)supermanSpeed.Y;

                if (supermanRect.Top > window.Height)
                {

                    supermanRect.Y = -supermanRect.Height;
                    supermanSpeed = new Vector2(generator.Next(6, 11), generator.Next(6, 11));


                }


                if (dead == true)
                {

                    supermanEffect = SpriteEffects.FlipVertically;
                    supermanSpeed = new Vector2(0, 3);
                    if (supermanRect.Bottom > window.Height)
                    {
                        supermanSpeed = new Vector2(0, 0);
                        

                    }





                }

                if (mouseState.LeftButton == ButtonState.Pressed && supermanRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, kryptoniteTexture.Width, kryptoniteTexture.Height)))
                {

                    dead = true;

                }
            }
                



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(supermanIntrotexture, new Rectangle(0, 0, 800, 600), Color.White);
                _spriteBatch.DrawString(introFont, "Welcome to LexCorp! Today your task is to KILL Superman! Click left on him to poison!" +
                    "Click ENTER to begin", new Vector2(100, 500), Color.Green);


            }
            else if (screen == Screen.supermanGame)
            {
                _spriteBatch.Draw(skyTexture, window, Color.White);
                _spriteBatch.Draw(supermanTexture, supermanRect, null, Color.White, 0f, Vector2.Zero, supermanEffect, 1f);
                _spriteBatch.Draw(kryptoniteTexture, cursorPosition, Color.White);

                if ( supermanSpeed == Vector2.Zero)
                {
                    _spriteBatch.Draw(gameOvertexture, gameOverRect, Color.White);
                }
                
            }


               




            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
