using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace SkateBoardFight.src
{
    public static class GlobalVariables
    {
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;

        public const int Window_Width = 900;
        public const int Window_Height = 550;

        public static float Gravity = 1.5f;
    }
}
