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
	public class GoldenChakram : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Golden Chakram"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Золотой чакрам");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.WoodenBoomerang);
			item.damage = 17;
			item.width = 25;
			item.height = 25;
			item.useTime = 25;
			item.useAnimation = 25;
			item.knockBack = 4;
			item.value = 50000;
			item.rare = 0;
			item.shoot = 14;
			item.shootSpeed = 12; 
			item.maxStack = 1;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<GoldenChakramProjectile>();
			item.autoReuse = false;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 6);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	
	}
} 