using RothurMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class PlatinumSpear : ModItem
	{
		public override void SetStaticDefaults() 
		{ 
			DisplayName.SetDefault("Platinum Spear");
			DisplayName.AddTranslation(GameCulture.Russian, "Платиновое копье");
			
		}
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 10f;
			item.damage = 18;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.rare = 0;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = false;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(copper: 1000);
			// Look at the javelin projectile for a lot of custom code
			// If you are in an editor like Visual Studio, you can hold CTRL and Click ExampleJavelinProjectile
			item.shoot = ProjectileType<PlatinumSpearProjectile>();
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 1);
			recipe.AddIngredient(null, "Stick", 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}