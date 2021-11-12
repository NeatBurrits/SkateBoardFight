using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using SkateBoardFight.src.UI;
using SkateBoardFight.src.LevelEditor;
using SkateBoardFight.src;

namespace SkateBoardFight
{
    public class Game1 : Game
    {
        LevelEditor Editor;
        Fighter fighter;

        public Game1()
        {
            GlobalVariables._graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            GlobalVariables._graphics.PreferredBackBufferWidth = GlobalVariables.Window_Width;
            GlobalVariables._graphics.PreferredBackBufferHeight = GlobalVariables.Window_Height;
            GlobalVariables._graphics.ApplyChanges();

            Editor = new LevelEditor();
            fighter = new Fighter();
        }

        protected override void LoadContent()
        {
            GlobalVariables._spriteBatch = new SpriteBatch(GraphicsDevice);
            Art.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Input.GetKeyState();

            Editor.Update(gameTime);

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            GlobalVariables._spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            Editor.Draw();

            GlobalVariables._spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}