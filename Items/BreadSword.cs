using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class BreadSword	: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bread Sword");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Хлебный меч");
		}

		public override void SetDefaults() 
		{
			item.damage = 8;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 100;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Hay, 20);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
} 