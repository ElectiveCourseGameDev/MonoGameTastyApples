using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameTastyApples.GameFrameWork;

namespace MonoGameTastyApples
{

    class Grass : SpriteObject
    {
        private Rectangle _sourceRectangle = new Rectangle(336,7,45,53);


        public Grass(GameHost game) : base(game)
        {
            SetRandomPosition();
            setRandomGrassSprite();
        }

        public Grass(GameHost game, Vector2 position) : base(game, position)
        {
            
        }

        public Grass(GameHost game, Vector2 position, Texture2D texture) : base(game, position, texture)
        {
            
        }

        private void SetRandomPosition()
        {
            //PositionX = 100;
            //PositionY = 100;
            Position = new Vector2(GameHelper.RandomNext(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width),
                GameHelper.RandomNext(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height));
        }

        private void setRandomGrassSprite()
        {
            //switch between different grass sprites
        }

        public override void Update(GameTime gameTime)
        {
            PositionX-=3;
            if (PositionX+100 < 0) PositionX += GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width+100;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, _sourceRectangle, Color.White);
        }
    }
}
