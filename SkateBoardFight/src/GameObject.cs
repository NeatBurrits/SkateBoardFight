using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System;

namespace SkateBoardFight.src
{
    abstract class GameObject
    {
        protected Texture2D sprite;
        protected Rectangle spriteBounds;

        protected Color color = Color.White;

        public Vector2 Position, Velocity;
        public float Rotation = 0;

        public Vector2 Size;

        protected Vector2 Orgin = new Vector2(0, 0);

        public float Scale = 1;

        public abstract void Update(GameTime gameTime);

        public virtual void Draw()
        {
            //Size /2 sets the orgin to the middle of the sprite
            GlobalVariables._spriteBatch.Draw(sprite, Position, spriteBounds, color, Rotation, Orgin, Scale, 0, 0);
        }
    }
}
