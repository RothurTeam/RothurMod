using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ThermoSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thermo Sword"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо меч");
		}

		public override void SetDefaults() 
		{
			item.damage = 16;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThermoBar", 8);  
            recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
} 