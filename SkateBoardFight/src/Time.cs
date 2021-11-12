using Microsoft.Xna.Framework;

using System;

namespace SkateBoardFight.src
{
    public static class Time
    {
        public static float DeltaTime_InMS(GameTime gameTime)
        {
            return (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public static float DeltaTime_InSec(GameTime gameTime)
        {
            return (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
