using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameTastyApples.GameFrameWork;

namespace MonoGameTastyApples
{
    class Apple :SpriteObject
    {
        
        public Apple(GameHost game) : base(game)
        {
            SourceRect = new Rectangle(0,150,100,104);
        }

        public Apple(GameHost game, Vector2 position) : base(game, position)
        {
        }

        public Apple(GameHost game, Vector2 position, Texture2D texture) : base(game, position, texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            PositionX--;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, SourceRect, Color.White);
        }
    }
}
