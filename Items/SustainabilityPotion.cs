using TheDrowChallenge.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge.Items
{
	public class SustainabilityPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sustainability Potion");
			Tooltip.SetDefault("Prevents decay on the surface");
		}

        public override void SetDefaults()
		{
            item.value = 2000;
            item.useStyle = 2;
            item.useAnimation = 17;
            item.useTime = 17;
            item.consumable = true;
            item.useTurn = true;
            item.rare = 1;
            item.maxStack = 30;
            item.width = 14;
            item.height = 24;
            item.UseSound = SoundID.Item3;
            item.buffType = mod.BuffType<Sustainability>();
            item.buffTime = 10800;
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
            recipe.AddIngredient(mod.ItemType<LesserSustainabilityPotion>());
            recipe.AddIngredient(ItemID.GoldOre, 1);
            recipe.AddIngredient(ItemID.GlowingMushroom, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<LesserSustainabilityPotion>());
            recipe.AddIngredient(ItemID.PlatinumOre, 1);
            recipe.AddIngredient(ItemID.GlowingMushroom, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
