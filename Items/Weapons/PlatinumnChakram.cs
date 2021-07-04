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
	public class PlatinumnChakram : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Platinumn Chakram"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Платиновый чакрам");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.ThornChakram);
			item.damage = 17;
			item.width = 25;
			item.height = 25;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 4;
			item.value = 50000;
			item.rare = 0;
			item.shoot = 14;
			item.shootSpeed = 12; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<PlatinumnChakramProjectile>();
			item.autoReuse = false;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 6);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	
	}
} 