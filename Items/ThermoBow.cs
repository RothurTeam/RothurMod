using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
    public class ThermoBow : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thermo Bow"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо лук");
		}

		public override void SetDefaults() 
		{
            item.damage = 13;
            item.ranged = true; 
			item.noMelee = true;
            item.width = 22;                   
            item.height = 44;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
			item.shoot = 12;
			item.shootSpeed = 6;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 4;
            item.value = 1000;
            item.rare = 0;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useTurn = true;
	    }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThermoBar", 7);  
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}