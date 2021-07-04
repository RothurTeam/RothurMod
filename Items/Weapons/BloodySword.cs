using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Projectiles;

namespace RothurMod.Items.Weapons
{
	public class BloodySword: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Sword");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавый меч");
		}

		public override void SetDefaults() 
		{
			item.damage = 22;
			item.melee = true;
			item.width = 42;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 20000;
			item.rare = ItemRarityID.Red;
			item.shoot = ModContent.ProjectileType<BloodThornProjectile>();
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 8f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BloodyScale", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}

	}
} 