using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge.Buffs {
	class Decay : ModBuff {
		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = false;
			Main.buffNoTimeDisplay[Type] = true;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			TheDrowChallengePlayer modplayer = player.GetModPlayer<TheDrowChallengePlayer>();
			if ((player.position.Y + player.height) / 16f <= Main.worldSurface && !player.HasBuff(ModContent.BuffType<Sustainability>())) {
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				modplayer.decay_accleration = Math.Clamp(++modplayer.decay_accleration, 0, 120);
				player.lifeRegen -= (int)(256 * modplayer.decay_accleration / 120.0);
				int dustnumber = Dust.NewDust(new Vector2(player.position.X, player.position.Y), 16, 16, DustID.Wraith, player.velocity.X, player.velocity.Y, 100, default, 2.5f);
				Main.dust[dustnumber].noGravity = true;
			} else {
				modplayer.decay_accleration = 0;
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
