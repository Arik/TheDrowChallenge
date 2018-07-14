using Terraria;
using Terraria.ModLoader;

namespace TheDrowChallenge.Buffs
{
	class SustainabilitySickness : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sustainability Sickness");
			Description.SetDefault("Cannot consume anymore sustainability items");
			Main.debuff[Type] = true;
			canBeCleared = false;
		}
	}
}
