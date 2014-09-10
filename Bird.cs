using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameTastyApples.GameFrameWork;

namespace MonoGameTastyApples
{
    class Bird : SpriteObject
    {
        public Bird(GameHost game) : base(game)
        {
            SourceRect = new Rectangle(0,0,184,132);
        }

        public Bird(GameHost game, Vector2 position) : base(game, position)
        {
        }

        public Bird(GameHost game, Vector2 position, Texture2D texture) : base(game, position, texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            PositionX -= 10;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, SourceRect, Color.White);
           // spriteBatch.Draw(SpriteTexture, Position, SourceRect, Color.White, 0f, Origin, 0f,
              //  SpriteEffects.FlipVertically, 0f);
        }
    }
}
