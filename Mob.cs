using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace Mob
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Mob : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PercentCounter percentCounter;
        SpriteFont font;

        float i = 0.0f;
        float factor = 0.005f;

        public Mob()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            percentCounter = new PercentCounter(Content, spriteBatch);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("sans");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Add your drawing code here   
            percentCounter.DrawPercent(new Vector2(80.0f, 80.0f), new Vector2(1.0f, 1.0f), (ushort)i);

            if (i < 100)
            {
                i = Math.Min(i + i * factor, 100);
            }

            if (i == 0) i += 1;

            if (i == 100)
            {
                spriteBatch.DrawString(font, "I shidded.", new Vector2(100.0f, 300.0f), Color.Green);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
