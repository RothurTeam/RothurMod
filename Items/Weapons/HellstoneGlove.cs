using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Projectiles;

namespace RothurMod.Items.Weapons
{
    public class HellstoneGlove : ModItem
    {
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hellstone Glove");
			DisplayName.AddTranslation(GameCulture.Russian, "Литая перчатка");
			
		}
		
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.NebulaBlaze);
			item.summon = true;
			item.magic = false;
			item.useAnimation = 18;
			item.useTime = 18;
			item.damage = 18;
			item.mana = -1;
			item.rare = 3;
			item.shoot = ModContent.ProjectileType<DemonSoulProj>();
			item.shootSpeed = 8f;
			item.value = Item.buyPrice(0, 0, 20, 0);
			item.noUseGraphic = true;
			item.autoReuse = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 17);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}   
		
    }
}
