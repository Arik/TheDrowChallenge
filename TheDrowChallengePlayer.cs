using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
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

		internal int decay_accleration = 0;
		public override void SaveData(TagCompound tag) {
			tag.Add("decay_acceleration", decay_accleration);
		}

		public override void LoadData(TagCompound tag) {
			decay_accleration = tag.GetAsInt("decay_acceleration");
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
			if (damageSource.SourceOtherIndex == 8 && Player.HasBuff(ModContent.BuffType<Decay>()) && !pvp) {
				damageSource = PlayerDeathReason.ByCustomReason(Player.name + " decayed from being on the surface");
			}
			decay_accleration = 0;
			return true;
		}
	}
}
