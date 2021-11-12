using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

using System;

namespace SkateBoardFight.src.UI
{
    abstract class Button
    {
        protected Texture2D sprite;
        protected Color color = Color.White;
        protected Rectangle spriteBounds = new Rectangle(0,0,16,16);

        public Vector2 Position;
        public float Scale = 1;

        public virtual void Update()
        {
            if (Input.LeftClick()
                && Mouse.GetState().Position.X < Position.X + spriteBounds.Width * Scale
                && Mouse.GetState().Position.X > Position.X
                && Mouse.GetState().Position.Y < Position.Y + spriteBounds.Height * Scale
                && Mouse.GetState().Position.Y > Position.Y)
            {
                OnClick();
            }
    }

        public abstract void OnClick();

        public virtual void Draw()
        {
            //Size /2 sets the orgin to the middle of the sprite
            GlobalVariables._spriteBatch.Draw(sprite, Position, spriteBounds, color, 0, new Vector2(0,0), Scale, 0, 0);
        }
    }
}
