using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDrowChallenge.Buffs;

namespace TheDrowChallenge.Items {
	public class LesserSustainabilityPotion : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lesser Sustainability Potion");
			Tooltip.SetDefault("Prevents decay on the surface");
		}

		public override void SetDefaults() {
			Item.value = 1000;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.consumable = true;
			Item.useTurn = true;
			Item.maxStack = 30;
			Item.width = 14;
			Item.height = 24;
			Item.UseSound = SoundID.Item3;
			Item.buffType = ModContent.BuffType<Sustainability>();
			Item.buffTime = 3600;
		}

		public override bool CanUseItem(Player player) {
			return !player.HasBuff(ModContent.BuffType<SustainabilitySickness>());
		}

		public override bool? UseItem(Player player) {
			player.AddBuff(ModContent.BuffType<SustainabilitySickness>(), 54000);
			return true;
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
