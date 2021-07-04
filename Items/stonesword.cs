using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class stonesword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stone Sword");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Каменный меч");
		}

		public override void SetDefaults() 
		{
			item.damage = 12;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 200;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
} 