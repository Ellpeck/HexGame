using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Cameras;

namespace HexGame.Maps {
    public class Map {

        public readonly int Width;
        public readonly int Height;
        private readonly Tile[,] tiles;

        public Map(int width, int height) {
            this.Width = width;
            this.Height = height;
            this.tiles = new Tile[width, height];

            for (var x = 0; x < this.Width; x++) {
                for (var y = 0; y < this.Height; y++) {
                    this.tiles[x, y] = new Tile(Tile.Textures[0, 0], new Point(x, y));
                }
            }
        }

        public void Draw(SpriteBatch batch, Camera camera) {
            batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: camera.ViewMatrix);
            for (var y = 0; y < this.Height; y++) {
                for (var x = 0; x < this.Width; x += 2)
                    this.DrawTile(batch, x, y);
                for (var x = 1; x < this.Width; x += 2)
                    this.DrawTile(batch, x, y);
            }
            batch.End();
        }

        private void DrawTile(SpriteBatch batch, int x, int y) {
            var tile = this.tiles[x, y];
            if (tile != null)
                tile.Draw(batch);
        }

    }
}