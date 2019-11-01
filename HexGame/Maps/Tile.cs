using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Extensions;
using MLEM.Startup;
using MLEM.Textures;
using MonoGame.Extended.TextureAtlases;

namespace HexGame.Maps {
    public class Tile {

        public static readonly UniformTextureAtlas Textures = new UniformTextureAtlas(MlemGame.LoadContent<Texture2D>("Textures/Tiles"), 8, 9);
        public static readonly Vector2 CellSize = new Vector2(32 * 0.75F, 28);

        private readonly TextureRegion texture;
        private readonly Point position;

        public Tile(TextureRegion texture, Point position) {
            this.texture = texture;
            this.position = position;
        }

        public void Draw(SpriteBatch batch) {
            var dest = new Rectangle(GetDrawPoint(this.position), this.texture.Size);
            batch.Draw(this.texture, dest, Color.White);
            //batch.DrawCenteredString(GameImpl.Font, this.position.ToString(), dest.Location.ToVector2() + dest.Size.ToVector2() / 2, 0.1F, Color.White);
        }

        public static Point GetDrawPoint(Point position) {
            var x = position.X * CellSize.X;
            var y = position.Y * CellSize.Y;
            if (position.X % 2 == 1)
                y += CellSize.Y / 2;
            return new Point(x.Floor(), y.Floor());
        }

    }
}