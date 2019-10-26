using HexGame.Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Startup;

namespace HexGame {
    public class GameImpl : MlemGame {

        public static SpriteFont Font { get; private set; }
        private Map map;

        protected override void LoadContent() {
            base.LoadContent();
            Font = LoadContent<SpriteFont>("Font");

            this.map = new Map(10, 10);
        }

        protected override void DoDraw(GameTime gameTime) {
            base.DoDraw(gameTime);
            this.map.Draw(this.SpriteBatch);
        }

    }
}