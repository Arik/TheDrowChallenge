using Terraria;
using Terraria.ID;

namespace TheDrowChallenge.Items {
	public class LesserSustainabilityPotion : BaseSustainabilityPotion {
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
		}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = Item.sellPrice(0, 0, 1);
			Item.buffTime = 60 * 60;
		}

		public override void AddRecipes() {
			CreateRecipe(2).
				AddIngredient(ItemID.BottledWater, 2).
				AddIngredient(ItemID.IronOre).
				AddIngredient(ItemID.ShadowScale).
				AddTile(TileID.Bottles).
				Register();

			CreateRecipe(2).
				AddIngredient(ItemID.BottledWater, 2).
				AddIngredient(ItemID.IronOre).
				AddIngredient(ItemID.TissueSample).
				AddTile(TileID.Bottles).
				Register();

			CreateRecipe(2).
				AddIngredient(ItemID.BottledWater, 2).
				AddIngredient(ItemID.LeadOre).
				AddIngredient(ItemID.ShadowScale).
				AddTile(TileID.Bottles).
				Register();

			CreateRecipe(2).
				AddIngredient(ItemID.BottledWater, 2).
				AddIngredient(ItemID.LeadOre).
				AddIngredient(ItemID.TissueSample).
				AddTile(TileID.Bottles).
				Register();
		}
	}
}
