using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameTastyApples.GameFrameWork;

namespace MonoGameTastyApples
{
    class Worm : SpriteObject
    {

        private double _milisecondsSinceLastFrameUpdate = 0;

        public Worm(GameHost game) : base(game)
        {
            SourceRect = new Rectangle(184,0,138,60);
            
        }

        public Worm(GameHost game, Vector2 position) : base(game, position)
        {
        }

        public Worm(GameHost game, Vector2 position, Texture2D texture) : base(game, position, texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            
            if (gameTime.TotalGameTime.TotalMilliseconds > _milisecondsSinceLastFrameUpdate+200)
            {
                SourceRect = new Rectangle(184, 0, 138, 60);
              
                //milisecondsSinceLastFrameUpdate = gameTime.ElapsedGameTime.Milliseconds
            }
            if (gameTime.TotalGameTime.TotalMilliseconds > _milisecondsSinceLastFrameUpdate +400)
            {
                SourceRect = new Rectangle(184,80,138,60);
               
            }
            if (gameTime.TotalGameTime.TotalMilliseconds > _milisecondsSinceLastFrameUpdate + 600)
            {
                SourceRect = new Rectangle(184, 140, 138, 60);
                _milisecondsSinceLastFrameUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }

            //react on gamepad
            PositionY -= GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y*7;

            PositionX += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * 7-1;


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, SourceRect, Color.White);
        }
    }
}
