using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge {
	class TheDrowChallengeSystem : ModSystem {
		public override void PostWorldGen() {
			const int y_range = 25;
			int y_start = (int)(Main.worldSurface) + 5;
			bool found = false;
			while (!found || y_start > Main.maxTilesY) {
				int x = Main.maxTilesX / 2;
				while (x != 0 && x != Main.maxTilesX - 1) {
					for (int y = y_start; y <= y_start + y_range; y++) {
						DebugPaint(x, y);
						if (WorldGen.ActiveAndWalkableTile(x, y) && WorldGen.EmptyTileCheck(x - 1, x + 1, y - 3, y - 1) && Main.tile[x, y - 1].LiquidAmount == 0) {
							Main.spawnTileX = x;
							Main.spawnTileY = y;
							found = true;
							break;
						}
					}
					if (found) break;
					if (x >= Main.maxTilesX / 2) x++;
					x = Main.maxTilesX - x;
				}
				y_start += 25;
			}
		}

		[ConditionalAttribute("DEBUG")]
		private static void DebugPaint(int x, int y) {
			byte paint = PaintID.DeepPurplePaint;
			if (x == Main.maxTilesX / 2) {
				paint = PaintID.DeepYellowPaint;
			}
			Tile tile = Main.tile[x, y];
			tile.WallType = WallID.Dirt;
			tile.WallColor = paint;
			if (tile.HasTile) {
				tile.TileColor = paint;
			}
		}
	}
}
