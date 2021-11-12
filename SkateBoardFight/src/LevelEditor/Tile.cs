using System;
using Microsoft.Xna.Framework;

namespace SkateBoardFight.src
{
    class Tile : GameObject
    {
        public int tile = 0;

        public Tile()
        {
            sprite = Art.SkatePark;

            Orgin = new Vector2(8, 8);
            Position = new Vector2(8 * 3, 8 * 3);

            Size = new Vector2(16, 16);
            Scale = 1;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw()
        {

            GlobalVariables._spriteBatch.Draw(sprite, Position, Art.SkateParkSS.Cells[tile], color, Rotation, Orgin, Scale, 0, 0);
        }
    }
}
