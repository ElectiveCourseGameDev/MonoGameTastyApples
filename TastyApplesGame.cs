#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MonoGameTastyApples.GameFrameWork;

#endregion

namespace MonoGameTastyApples
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TastyApplesGame : GameHost
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private Texture2D _spritesheet;
        private SpriteFont _font;
        private Worm _worm;
        private SpriteFont _fontGameOver;


        public TastyApplesGame()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
          
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spritesheet = Content.Load<Texture2D>("TastyApplesSpritesheet.png");
            _font = Content.Load<SpriteFont>("MonoLog");
            _fontGameOver = Content.Load<SpriteFont>("handwriting64");
            for (int i = 0; i < 250; i++)
            {
                AddGrass();
            }

            Bird bird = new Bird(this);
            bird.SpriteTexture = _spritesheet;
            bird.Position = new Vector2(2000,200);
            GameObjects.Add(bird);

            _worm = new Worm(this);
            _worm.SpriteTexture = _spritesheet;
            _worm.Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2);
            GameObjects.Add(_worm);

            Apple apple = new Apple(this);
            apple.SpriteTexture = _spritesheet;
            apple.Position = new Vector2(2000,200);
            GameObjects.Add(apple);

            BenchmarkObject benchmark = new BenchmarkObject(this, _font, new Vector2(10,10), Color.Black );
            GameObjects.Add(benchmark);
        }

        private void AddGrass()
        {
            Grass grass = new Grass(this);
            grass.SpriteTexture = _spritesheet;
            GameObjects.Add(grass);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            for (int i = 0; i < GameObjects.Count-1; i++)
            {
                GameObjects[i].Update(gameTime);

                if (GameObjects[i].GetType() == typeof (Apple))
                {
                    Apple apple = (Apple) GameObjects[i];
                    if (_worm.BoundingBox.Intersects(apple.BoundingBox))
                    {
                        GameObjects.Remove(GameObjects[i]);
                    }
                }

                if (GameObjects[i].GetType() == typeof (Bird))
                {
                    Bird b = (Bird) GameObjects[i];
                    if (b.BoundingBox.Intersects(_worm.BoundingBox))
                    {
                        GameObjects.Remove(_worm);
                        TextObject gameover =
                            new TextObject(this, _fontGameOver,
                                new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2,
                                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2), "Game Over");
                        gameover.SpriteColor = Color.RoyalBlue;
                        GameObjects.Add(gameover);

                    }
                }
            }

            //spawn apples
            if (GameHelper.RandomNext(100) == 1)
            {
                Apple a = new Apple(this);
                a.SpriteTexture = _spritesheet;
                a.PositionX = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + 100;
                a.PositionY = GameHelper.RandomNext(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
                GameObjects.Add(a);
            }

            //spawn birds
            if (GameHelper.RandomNext(200) == 1)
            {
                Bird b = new Bird(this);
                b.SpriteTexture = _spritesheet;
                b.PositionX = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + 100;
                b.PositionY = GameHelper.RandomNext(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
                GameObjects.Add(b);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            foreach (SpriteObject gameObject in GameObjects)
            {
                gameObject.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
