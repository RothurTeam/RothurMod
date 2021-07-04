using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
    public class RealmBow : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Realmite Bow"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый лук");
		}

		public override void SetDefaults() 
		{
            item.damage = 9;
            item.ranged = true;
			item.noMelee = true;
            item.width = 22;                   
            item.height = 44;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 5;
			item.shoot = 10;
			item.shootSpeed = 5;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 4;
            item.value = 1000;
            item.rare = 0;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.useTurn = true;
	    }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RealmShard", 7);  
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
