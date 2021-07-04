using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Projectiles;

namespace RothurMod.Items.Weapons
{
	public class SwordBalance : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Balance Sword");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Меч баланса");
		}

		public override void SetDefaults() 
		{
			item.damage = 16;
			item.melee = true;
			item.width = 42;
			item.height = 40;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<BalanceProj>();
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 11f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Balance", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}

	}
} 