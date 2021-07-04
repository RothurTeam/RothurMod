using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace RothurMod.Items
{
	public class RealmSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Realmite Sword"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый меч");
		}

		public override void SetDefaults() 
		{
			item.damage = 12;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RealmShard", 9);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
} 