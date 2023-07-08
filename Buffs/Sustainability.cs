using Terraria;
using Terraria.ModLoader;

namespace TheDrowChallenge.Buffs {
	class Sustainability : ModBuff {
		public override void SetStaticDefaults() {
			Main.buffNoSave[Type] = false;
		}
	}
}
