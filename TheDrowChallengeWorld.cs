using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TheDrowChallenge
{
    class TheDrowChallengeWorld : ModWorld
    {
        public override void PostWorldGen()
        {
            bool found = false;
            int x_range = 5;
            int y_range = 50;
            while (!found)
            {
                int x = Main.maxTilesX / 2 + WorldGen.genRand.Next(-x_range, x_range + 1);
                for (int y = (int)(Main.worldSurface) + 5; y <= (int)(Main.worldSurface) + 5 + y_range; y++)
                {
                    if (Main.tile[x, y].active())
                    {
                        Main.spawnTileX = x;
                        Main.spawnTileY = y;
                        if (WorldGen.EmptyTileCheck(Main.spawnTileX - 1, Main.spawnTileX + 1, Main.spawnTileY - 3, Main.spawnTileY - 1) && Main.tile[Main.spawnTileX, Main.spawnTileY - 1].liquid == 0)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                x_range++;
            }
        }
    }
}
