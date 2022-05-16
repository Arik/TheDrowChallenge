using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheDrowChallenge.Buffs;

namespace TheDrowChallenge {
	class TheDrowChallengePlayer : ModPlayer {
		public override List<Item> AddStartingItems(bool mediumCoreDeath) {
			return new List<Item> { new Item(ItemID.Torch) };
		}

		public override void PreUpdateBuffs() {
			if ((Player.position.Y + Player.height) / 16f <= Main.worldSurface && !Player.HasBuff(ModContent.BuffType<Sustainability>())) {
				Player.AddBuff(ModContent.BuffType<Decay>(), 60);
			}
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
			if (damageSource.SourceOtherIndex == 8 && Player.HasBuff(ModContent.BuffType<Decay>()) && !pvp) {
				damageSource = PlayerDeathReason.ByCustomReason(Player.name + " decayed from being on the surface");
			}
			return true;
		}
	}
}
