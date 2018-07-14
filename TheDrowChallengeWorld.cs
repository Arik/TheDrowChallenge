using Terraria;
using Terraria.ModLoader;

namespace TheDrowChallenge
{
	class TheDrowChallengeWorld : ModWorld
	{
		private bool spawnEye = false;
		private int spawnHardBoss = 0;

		public override void PreUpdate()
		{
			if (spawnEye && Main.netMode != 1 && Main.time > 4860.0)
			{
				for (int k = 0; k < 255; k++)
				{
					if (Main.player[k].active && !Main.player[k].dead && (double)Main.player[k].position.Y >= Main.worldSurface * 16.0)
					{
						NPC.SpawnOnPlayer(k, 4);
						WorldGen.spawnEye = false;
						break;
					}
				}
			}
			if (spawnHardBoss > 0 && Main.netMode != 1 && Main.time > 4860.0)
			{
				bool flag2 = false;
				for (int l = 0; l < 200; l++)
				{
					if (Main.npc[l].active && Main.npc[l].boss)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					int m = 0;
					while (m < 255)
					{
						if (Main.player[m].active && !Main.player[m].dead && (double)Main.player[m].position.Y >= Main.worldSurface * 16.0)
						{
							if (spawnHardBoss == 1)
							{
								NPC.SpawnOnPlayer(m, 134);
								break;
							}
							if (spawnHardBoss == 2)
							{
								NPC.SpawnOnPlayer(m, 125);
								NPC.SpawnOnPlayer(m, 126);
								break;
							}
							if (spawnHardBoss == 3)
							{
								NPC.SpawnOnPlayer(m, 127);
								break;
							}
							break;
						}
						else
						{
							m++;
						}
					}
				}
				WorldGen.spawnHardBoss = 0;
			}
			spawnEye = WorldGen.spawnEye;
			spawnHardBoss = WorldGen.spawnHardBoss;
		}

		public override void PostWorldGen()
		{
			bool found = false;
			int y_range = 25;
			int x = Main.maxTilesX / 2;
			while (x != 0 && x != Main.maxTilesX - 1)
			{
				for (int y = (int)(Main.worldSurface) + 5; y <= (int)(Main.worldSurface) + 5 + y_range; y++)
				{
					if (Main.tile[x, y].active())
					{
						if (WorldGen.EmptyTileCheck(x - 1, x + 1, y - 3, y - 1) && Main.tile[x, y - 1].liquid == 0)
						{
							Main.spawnTileX = x;
							Main.spawnTileY = y;
							found = true;
							break;
						}
					}
				}
				if (found)
				{
					break;
				}
				if (x >= Main.maxTilesX / 2)
				{
					x++;
				}
				x = Main.maxTilesX - x;
			}
			if (!found && 0 <= (int)(Main.worldSurface) + 5 && (int)(Main.worldSurface) + 5 < Main.maxTilesY)
			{
				Main.spawnTileX = Main.maxTilesX / 2;
				Main.spawnTileY = (int)(Main.worldSurface) + 5;
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -3; j <= -1; j++)
					{
						if (0 <= i && i < Main.maxTilesX && 0 <= j && j < Main.maxTilesY)
						{
							Main.tile[i, j].type = 0;
						}
					}
				}
			}
		}
	}
}
