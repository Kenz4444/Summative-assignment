using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Summative_assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D supermanTexture, skyTexture, kryptoniteTexture;

        Rectangle window;
        Rectangle supermanRect;

        SpriteEffects supermanEffect;

        Vector2 supermanSpeed;


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


            supermanSpeed = new Vector2(6, generator.Next(-2, 3));



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            supermanTexture = Content.Load<Texture2D>("supermanFlying");
            kryptoniteTexture = Content.Load<Texture2D>("kryptonite");
            skyTexture = Content.Load<Texture2D>("sky2");


           

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            supermanRect.X += (int)supermanSpeed.X;
            if (supermanRect.Left > window.Width)
            {
                
                supermanRect.X = -supermanRect.Width;


            }
           

                supermanRect.Y += (int)supermanSpeed.Y;

            if (supermanRect.Top > window.Height)
            {

                supermanRect.Y = -supermanRect.Height;


            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();


            _spriteBatch.Draw(skyTexture, window, Color.White);
            _spriteBatch.Draw(supermanTexture, supermanRect, null, Color.White, 0f, Vector2.Zero, supermanEffect, 1f);





            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
