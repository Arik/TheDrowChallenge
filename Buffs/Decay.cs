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
			int dustnumber = Dust.NewDust(new Vector2(player.position.X, player.position.Y), 16, 16, DustID.Wraith, player.velocity.X, player.velocity.Y, 100, default, 2.5f);
			Main.dust[dustnumber].noGravity = true;
		}
	}
}
