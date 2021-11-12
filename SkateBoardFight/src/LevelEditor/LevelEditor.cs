using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;
using System;

namespace SkateBoardFight.src.LevelEditor
{
    class LevelEditor
    {
        Texture2D PixelTexture = new Texture2D(GlobalVariables._graphics.GraphicsDevice, 1, 1);

        Point MousePos = Mouse.GetState().Position;

        List<Tile> tiles = new List<Tile>();
        public static int tileIndex;

        //Grid vars
        int GridStart = 6;

        int GridColums;
        int GridRows;
        int GridDimensions = 16;

        LevelEditorButton[] ItemSelectButtons = new LevelEditorButton[Art.SkateParkLevelEditorUISS.Cells.Length];
        float ButtonX_Offset = 3.5f;

        public LevelEditor()
        {
            GridRows = GlobalVariables.Window_Width / 16 + 1;
            GridColums = GlobalVariables.Window_Height / 16 + 1;
            PixelTexture.SetData(new Color[] { Color.White });

            for (float i = ButtonX_Offset; i < Art.SkateParkLevelEditorUISS.Cells.Length + ButtonX_Offset; i++)
            {
                ItemSelectButtons[(int)Math.Floor(i - ButtonX_Offset)] = new LevelEditorButton {Scale = 2, Position = new Vector2(32 * i * 2, GridStart * GridStart / 2 * 1.25f), Tile = (int)Math.Floor(i - ButtonX_Offset)};
            }
        }

        void PlaceGridOBJ()
        {
            foreach (Tile tile in tiles)
            {
                if (tile.Position == new Vector2(MousePos.X - MousePos.X % 16 + 8, MousePos.Y - MousePos.Y % 16 + 8))
                {
                    return;
                }
            }

            tiles.Add(new Tile() { Position = new Vector2(MousePos.X - MousePos.X % 16 + 8, MousePos.Y - MousePos.Y % 16 + 8) });
            tiles[tiles.Count - 1].tile = tileIndex;
        }

        void EraseGridOBJ()
        {
            List<Tile> tilesToErase = new List<Tile>();

            foreach (Tile tile in tiles)
            {
                if (tile.Position == new Vector2(MousePos.X - MousePos.X % 16 + 8, MousePos.Y - MousePos.Y % 16 + 8))
                {
                    tilesToErase.Add(tile);
                }
            }

            foreach (Tile tile in tilesToErase)
            {
                tiles.Remove(tile);
            }
        }

        void DrawGrid()
        {
            for (int y = GridStart; y < GridColums; y++)
            {
                for (int x = 0; x < GridRows; x++)
                {
                    Rectangle rect = new Rectangle((x * GridDimensions), (y * GridDimensions), 1, GridDimensions);
                    GlobalVariables._spriteBatch.Draw(PixelTexture, rect, Color.Black);

                    rect = new Rectangle((x * GridDimensions), (y * GridDimensions), GridDimensions, 1);
                    GlobalVariables._spriteBatch.Draw(PixelTexture, rect, Color.Black);
                }
            }
        }

        void DrawUI()
        {
            foreach (LevelEditorButton editorButton in ItemSelectButtons)
            {
                editorButton.Draw();
            }
        }

        public void Update(GameTime gameTime)
        {
            MousePos = Mouse.GetState().Position;

            foreach (LevelEditorButton editorButton in ItemSelectButtons)
            {
                editorButton.Update();
            }

            if (Input.LeftClick())
            {
                if (Mouse.GetState().Y >= GridStart * 16)
                {
                    PlaceGridOBJ();
                }
            }

            if (Input.RightClick())
            {
                if (Mouse.GetState().Y >= GridStart * 16)
                {
                    EraseGridOBJ();
                }
            }
        }

        public void Draw()
        {
            DrawGrid();
            DrawUI();

            foreach (Tile tile in tiles)
            {
                tile.Draw();
            }
        }
    }
}
