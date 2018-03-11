using TheDrowChallenge.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDrowChallenge.Items
{
	public class SuperSustainabilityPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greater Sustainability Potion");
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
            item.buffTime = 36000;
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
            recipe.AddIngredient(mod.ItemType<GreaterSustainabilityPotion>());
            recipe.AddIngredient(ItemID.LunarTabletFragment, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}