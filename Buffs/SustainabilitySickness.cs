using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge.Buffs {
	class SustainabilitySickness : ModBuff {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sustainability Sickness");
			Description.SetDefault("Cannot consume anymore sustainability items");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
		}
	}
}
