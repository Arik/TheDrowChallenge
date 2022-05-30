using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge.Items {
	public class SuperSustainabilityPotion : BaseSustainabilityPotion {
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Super Sustainability Potion");
		}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 8000;
			Item.rare = ItemRarityID.Lime;
			Item.buffTime = 10 * 60 * 60;
		}

		public override void AddRecipes() {
			CreateRecipe().
				AddIngredient(ModContent.ItemType<GreaterSustainabilityPotion>()).
				AddIngredient(ItemID.Ectoplasm, 1).
				AddIngredient(ItemID.SoulofFright, 1).
				AddIngredient(ItemID.SoulofMight, 1).
				AddIngredient(ItemID.SoulofSight, 1).
				AddTile(TileID.Bottles).
				Register();
		}
	}
}
