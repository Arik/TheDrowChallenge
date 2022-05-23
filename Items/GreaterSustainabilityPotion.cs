using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDrowChallenge.Buffs;

namespace TheDrowChallenge.Items {
	public class GreaterSustainabilityPotion : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Greater Sustainability Potion");
			Tooltip.SetDefault("Prevents decay on the surface");
		}

		public override void SetDefaults() {
			Item.value = 4000;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.consumable = true;
			Item.useTurn = true;
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 30;
			Item.width = 14;
			Item.height = 24;
			Item.UseSound = SoundID.Item3;
			Item.buffType = ModContent.BuffType<Sustainability>();
			Item.buffTime = 6 * 60 * 60;
		}

		public override bool CanUseItem(Player player) {
			return !player.HasBuff(ModContent.BuffType<SustainabilitySickness>());
		}

		public override bool? UseItem(Player player) {
			player.AddBuff(ModContent.BuffType<SustainabilitySickness>(), Item.buffTime + 60 * 60);
			return true;
		}

		public override void AddRecipes() {
			CreateRecipe().
				AddIngredient(ModContent.ItemType<SustainabilityPotion>(), 2).
				AddIngredient(ItemID.Blinkroot, 1).
				AddIngredient(ItemID.Fireblossom, 1).
				AddIngredient(ItemID.Moonglow, 1).
				AddTile(TileID.Bottles).
				Register();
		}
	}
}
