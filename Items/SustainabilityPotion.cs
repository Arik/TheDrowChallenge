using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge.Items {
	public class SustainabilityPotion : BaseSustainabilityPotion {
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Sustainability Potion");
		}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 2000;
			Item.rare = ItemRarityID.Blue;
			Item.buffTime = 3 * 60 * 60;
		}

		public override void AddRecipes() {
			CreateRecipe().
				AddIngredient(ModContent.ItemType<LesserSustainabilityPotion>()).
				AddIngredient(ItemID.BeeWax, 1).
				AddIngredient(ItemID.GlowingMushroom, 1).
				AddIngredient(ItemID.GoldOre, 1).
				AddTile(TileID.Bottles).
				Register();

			CreateRecipe().
				AddIngredient(ModContent.ItemType<LesserSustainabilityPotion>()).
				AddIngredient(ItemID.BeeWax, 1).
				AddIngredient(ItemID.GlowingMushroom, 1).
				AddIngredient(ItemID.PlatinumOre, 1).
				AddTile(TileID.Bottles).
				Register();
		}
	}
}
