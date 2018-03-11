using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TheDrowChallenge.Buffs
{
    class Decay : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Decay");
            Description.SetDefault("The surface hurts");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if ((player.position.Y + player.height) / 16f <= Main.worldSurface && !player.HasBuff(mod.BuffType<Sustainability>()))
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 256;
            } else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
