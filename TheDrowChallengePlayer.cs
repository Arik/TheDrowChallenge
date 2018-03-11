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

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (damageSource.SourceOtherIndex == 8 && player.HasBuff(mod.BuffType<Decay>()) && !pvp)
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " decayed from being on the surface too long");
            }
            return true;
        }
    }
}
