using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheDrowChallenge.Buffs;

namespace TheDrowChallenge.Items {
	public abstract class BaseSustainabilityPotion : ModItem {
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}

		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.consumable = true;
			Item.useTurn = true;
			Item.maxStack = Item.CommonMaxStack;
			Item.width = 14;
			Item.height = 24;
			Item.UseSound = SoundID.Item3;
			Item.buffType = ModContent.BuffType<Sustainability>();
		}

		public override bool CanUseItem(Player player) {
			return !player.HasBuff(ModContent.BuffType<SustainabilitySickness>());
		}

		public override void OnConsumeItem(Player player) {
			player.AddBuff(ModContent.BuffType<SustainabilitySickness>(), Item.buffTime + 60 * 60);
		}
	}
}