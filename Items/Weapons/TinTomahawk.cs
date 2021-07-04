using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using RothurMod.Projectiles;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class TinTomahawk : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tin Tomahawk");
			DisplayName.AddTranslation(GameCulture.Russian, "Оловянный Томагавк");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.damage = 11;
			item.width = 42;
			item.height = 42;
			item.useTime = 21;
			item.rare = 0;
			item.shoot = 12;
			item.shootSpeed = 9; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<TinTomahawkProjectile>();
			item.autoReuse = false;
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinBar, 1);
			recipe.AddIngredient(null, "Stick", 1);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}

	
	}
} 