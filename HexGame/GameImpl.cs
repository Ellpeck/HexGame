using HexGame.Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Cameras;
using MLEM.Startup;

namespace HexGame {
    public class GameImpl : MlemGame {

        public static SpriteFont Font { get; private set; }
        private Camera camera;
        private Map map;

        public GameImpl() {
            this.IsMouseVisible = true;
        }

        protected override void LoadContent() {
            base.LoadContent();
            Font = LoadContent<SpriteFont>("Font");

            this.map = new Map(14, 6);
            this.camera = new Camera(this.GraphicsDevice) {
                AutoScaleWithScreen = true,
                Scale = 3
            };
        }

        protected override void Update(GameTime gameTime) {
            base.Update(gameTime);
            this.camera.LookingPosition = new Vector2(this.map.Width / 2 + 0.5F, this.map.Height / 2 + 0.5F) * Tile.CellSize;
        }

        protected override void DoDraw(GameTime gameTime) {
            base.DoDraw(gameTime);
            this.map.Draw(this.SpriteBatch, this.camera);
        }

    }
}