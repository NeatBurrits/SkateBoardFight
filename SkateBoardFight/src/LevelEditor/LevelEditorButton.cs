using Microsoft.Xna.Framework;
using SkateBoardFight.src.UI;
using System;

namespace SkateBoardFight.src.LevelEditor
{
    class LevelEditorButton : Button
    {
        public int Tile = 0;

        public LevelEditorButton()
        {
            sprite = Art.SkateParkLevelEditorUI;
            Position = new Vector2(0, 0);

            spriteBounds = new Rectangle(0, 0, 24, 24);
        }

        public override void Update()
        {
            if (LevelEditor.tileIndex != Tile)
            {
                color = Color.White;
            }

            base.Update();
        }

        public override void OnClick()
        {
            LevelEditor.tileIndex = Tile;
            color = new Color(0.7f, 0.7f, 0.7f);
        }

        public override void Draw()
        {
            GlobalVariables._spriteBatch.Draw(sprite, Position, Art.SkateParkLevelEditorUISS.Cells[Tile], color, 0, new Vector2(0, 0), Scale, 0, 0);
        }
    }
}
