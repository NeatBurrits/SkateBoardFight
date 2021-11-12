using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

using System;

namespace SkateBoardFight.src
{
    static class Art
    {
        //Alan Italian
        public static Texture2D AlanItalian;

        public static Texture2D SkatePark;
        public static Texture2D SkateParkLevelEditorUI;

        public static SpriteSheet AlanItalianSS;
        public static SpriteSheet SkateParkSS;
        public static SpriteSheet SkateParkLevelEditorUISS;

        public static void Load(ContentManager content)
        {
            AlanItalian = content.Load<Texture2D>("Fighters/Alan Italian/Alan Italian");
            SkatePark = content.Load<Texture2D>("Levels/Skate Park Sprites");
            SkateParkLevelEditorUI = content.Load<Texture2D>("Levels/Skate Park Sprites UI");

            AlanItalianSS.Cells = AlanItalianSS.SliceSpriteSheet(39, 6, new Vector2(16, 16));
            SkateParkSS.Cells = SkateParkSS.SliceSpriteSheet(7, 3, new Vector2(16, 16));
            SkateParkLevelEditorUISS.Cells = SkateParkSS.SliceSpriteSheet(7, 3, new Vector2(24, 24));
        }
    }
}
