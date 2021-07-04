using RothurMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ThermoSpear : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thermo Spear"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо копье");
		}
		
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 11f;
			item.damage = 18;
			item.knockBack = 6f;
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
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(copper: 50);
			// Look at the javelin projectile for a lot of custom code
			// If you are in an editor like Visual Studio, you can hold CTRL and Click ExampleJavelinProjectile
			item.shoot = ProjectileType<ThermoSpearProjectile>();
		}
		
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThermoBar", 3);
			recipe.AddIngredient(null, "Stick", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}