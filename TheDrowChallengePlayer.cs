using TheDrowChallenge.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace TheDrowChallenge
{
    class TheDrowChallengePlayer : ModPlayer
    {
        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(ItemID.Torch);
            items.Add(item);
        }

        public override void PreUpdateBuffs()
        {
            if ((player.position.Y + player.height) / 16f <= Main.worldSurface && !player.HasBuff(mod.BuffType<Sustainability>()))
            {
                player.AddBuff(mod.BuffType<Decay>(), 60);
            }
        }
    }
}
