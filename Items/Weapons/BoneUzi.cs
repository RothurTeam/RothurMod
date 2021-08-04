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
	public class BoneUzi : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bone Uzi");
			DisplayName.AddTranslation(GameCulture.Russian, "Костяное узи");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Uzi);
			item.damage = 14;
			item.width = 31;
			item.height = 36;
			item.useTime = 9;
			item.useAnimation = 9;
			item.rare = 0;
			item.shoot = 11;
			item.shootSpeed = 9; 
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}
		
		public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
	
	}
} 