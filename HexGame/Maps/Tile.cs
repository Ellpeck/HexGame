using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Extensions;
using MLEM.Startup;
using MLEM.Textures;
using MonoGame.Extended.TextureAtlases;

namespace HexGame.Maps {
    public class Tile {

        public static readonly UniformTextureAtlas Textures = new UniformTextureAtlas(MlemGame.LoadContent<Texture2D>("Textures/Tiles"), 8, 6);
        public static readonly Point Size = new Point(32, 28);

        private readonly TextureRegion texture;
        private readonly Point position;

        public Tile(TextureRegion texture, Point position) {
            this.texture = texture;
            this.position = position;
        }

        public void Draw(SpriteBatch batch) {
            var dest = new Rectangle(this.GetDrawPoint(), this.texture.Size);
            batch.Draw(this.texture, dest, Color.White);
            batch.DrawCenteredString(GameImpl.Font, this.position.ToString(), dest.Location.ToVector2() + dest.Size.ToVector2() / 2, 0.1F, Color.White);
        }

        private Point GetDrawPoint() {
            var x = this.position.X * (Size.X * 0.75F).Floor();
            var y = this.position.Y * Size.Y;
            if (this.position.X % 2 == 1)
                y += Size.Y / 2;
            return new Point(x, y);
        }

    }
}