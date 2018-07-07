using TheDrowChallenge.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge.Items
{
	public class LesserSustainabilityPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Sustainability Potion");
			Tooltip.SetDefault("Prevents decay on the surface");
		}

        public override void SetDefaults()
		{
            item.value = 1000;
            item.useStyle = 2;
            item.useAnimation = 17;
            item.useTime = 17;
            item.consumable = true;
            item.useTurn = true;
            item.maxStack = 30;
            item.width = 14;
            item.height = 24;
            item.UseSound = SoundID.Item3;
            item.buffType = mod.BuffType<Sustainability>();
            item.buffTime = 3600;
		}

        public override bool CanUseItem(Player player)
        {
            return !player.HasBuff(mod.BuffType<SustainabilitySickness>());
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType<SustainabilitySickness>(), 54000);
            return true;
        }

        public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddIngredient(ItemID.ShadowScale);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddIngredient(ItemID.TissueSample);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ItemID.LeadOre);
            recipe.AddIngredient(ItemID.ShadowScale);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ItemID.LeadOre);
            recipe.AddIngredient(ItemID.TissueSample);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
	}
}
