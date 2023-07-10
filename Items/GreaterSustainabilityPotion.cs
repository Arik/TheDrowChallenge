using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge.Items {
	public class GreaterSustainabilityPotion : BaseSustainabilityPotion {
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
		}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Orange;
			Item.buffTime = 6 * 60 * 60;
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
