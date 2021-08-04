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
	public class SilverKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Silver Knife");
			DisplayName.AddTranslation(GameCulture.Russian, "Серебряный нож");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.ThrowingKnife);
			item.damage = 14;
			item.width = 60;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 0, 0, 40);
			item.rare = 0;
			item.shoot = 14;
			item.shootSpeed = 12; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SilverKnifeProjectile>();
			item.autoReuse = false;
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 1);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}

	
	}
} 