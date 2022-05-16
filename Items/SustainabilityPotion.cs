using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDrowChallenge.Buffs;

namespace TheDrowChallenge.Items {
	public class SustainabilityPotion : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sustainability Potion");
			Tooltip.SetDefault("Prevents decay on the surface");
		}

		public override void SetDefaults() {
			Item.value = 2000;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.consumable = true;
			Item.useTurn = true;
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 30;
			Item.width = 14;
			Item.height = 24;
			Item.UseSound = SoundID.Item3;
			Item.buffType = ModContent.BuffType<Sustainability>();
			Item.buffTime = 10800;
		}

		public override bool CanUseItem(Player player) {
			return !player.HasBuff(ModContent.BuffType<SustainabilitySickness>());
		}

		public override bool? UseItem(Player player) {
			player.AddBuff(ModContent.BuffType<SustainabilitySickness>(), 54000);
			return true;
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
