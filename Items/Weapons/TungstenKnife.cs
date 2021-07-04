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
	public class TungstenKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tungsten Knife"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Вольфрамовый нож");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.ThrowingKnife);
			item.damage = 15;
			item.width = 60;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 3;
			item.value = 1000;
			item.rare = 0;
			item.shoot = 14;
			item.shootSpeed = 12; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<TungstenKnifeProjectile>();
			item.autoReuse = false;
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenBar, 1);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}

	
	}
} 