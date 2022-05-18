using Terraria;
using Terraria.ModLoader;

namespace TheDrowChallenge {
	class TheDrowChallengeSystem : ModSystem {
		const int y_range = 25;
		public override void PostWorldGen() {
			bool found = false;
			int x = Main.maxTilesX / 2;
			while (x != 0 && x != Main.maxTilesX - 1) {
				for (int y = (int)(Main.worldSurface) + 5; y <= (int)(Main.worldSurface) + 5 + y_range; y++) {
					if (WorldGen.EmptyTileCheck(x - 1, x + 1, y - 3, y - 1) && Main.tile[x, y - 1].LiquidAmount == 0) {
						Main.spawnTileX = x;
						Main.spawnTileY = y;
						found = true;
						break;
					}
				}
				if (found) {
					break;
				}
				if (x >= Main.maxTilesX / 2) {
					x++;
				}
				x = Main.maxTilesX - x;
			}
			if (!found && 0 <= (int)(Main.worldSurface) + 5 && (int)(Main.worldSurface) + 5 < Main.maxTilesY) {
				Main.spawnTileX = Main.maxTilesX / 2;
				Main.spawnTileY = (int)(Main.worldSurface) + 5;
				for (int i = -1; i <= 1; i++) {
					for (int j = -3; j <= -1; j++) {
						if (0 <= i && i < Main.maxTilesX && 0 <= j && j < Main.maxTilesY) {
							Main.tile[i, j].TileType = 0;
						}
					}
				}
			}
		}
	}
}
