using Terraria;
using Terraria.ModLoader;

namespace TheDrowChallenge.Buffs {
	class Sustainability : ModBuff {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sustainability");
			Description.SetDefault("Prevents decay on the surface");
			Main.buffNoSave[Type] = false;
		}
	}
}
