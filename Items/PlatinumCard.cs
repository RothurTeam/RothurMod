using RothurMod.Tiles;
using RothurMod.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 
using Terraria.Localization;

namespace RothurMod.Items
{
	public class PlatinumCard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Platinum Card"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Платиновая карта");
		}

		public override void SetDefaults() 
		{
			
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 50000000;
			item.rare = 0;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumCoin, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
} 