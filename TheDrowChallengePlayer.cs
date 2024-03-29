﻿using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TheDrowChallenge.Buffs;

namespace TheDrowChallenge {
	class TheDrowChallengePlayer : ModPlayer {
		public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath) {
			if (Player.difficulty == PlayerDifficultyID.Creative) {
				return Enumerable.Empty<Item>();
			}
			return new[] { new Item(ItemID.Torch) };
		}

		internal int decay_accleration = 0;
		public override void PreUpdateBuffs() {
			if ((Player.position.Y + Player.height) / 16f <= Main.worldSurface && !Player.HasBuff(ModContent.BuffType<Sustainability>())) {
				Player.AddBuff(ModContent.BuffType<Decay>(), 2);  // Needs to be longer than a tick to show up as a debuff.
			} else {
				Player.ClearBuff(ModContent.BuffType<Decay>());
				decay_accleration = 0;
			}
		}

		public override void UpdateBadLifeRegen() {
			if (Player.HasBuff(ModContent.BuffType<Decay>())) {
				if (Player.lifeRegen > 0) {
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				decay_accleration = Math.Clamp(++decay_accleration, 0, 120);
				Player.lifeRegen -= (int)(256 * decay_accleration / 120.0);
			}
		}

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
