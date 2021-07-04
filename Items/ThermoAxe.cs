using RothurMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ThermoAxe : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Thermo Axe");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо топор");
		}

		public override void SetDefaults() {
			item.damage = 14;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 28;
			item.useAnimation = 28;
			item.axe = 10;          //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThermoBar", 9);  
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}