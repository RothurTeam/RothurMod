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
	public class ShadowSickle : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Sickle");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневая коса");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.IceSickle);
			item.damage = 46;
			item.width = 42;
			item.height = 42;
			item.useTime = 21;
			item.rare = ItemRarityID.Purple;
			item.shoot = 12;
			item.shootSpeed = 9; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<ShadowBlade>();
			item.autoReuse = false;
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShadowShard", 8);
			recipe.AddTile(TileID.MythrilAnvil); 
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	
	}
} 