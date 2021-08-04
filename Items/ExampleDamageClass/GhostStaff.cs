using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items;
using RothurMod.Projectiles;
using Terraria.ModLoader;
using RothurMod.Projectiles.Minions;

namespace RothurMod.Items.ExampleDamageClass
{
	public class GhostStaff : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ghost Staff");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Призрачный посох");
		}
		

		public override void SafeSetDefaults() {
			item.UseSound = SoundID.Item20;
			item.Size = new Vector2(28, 36);
			item.damage = 10;
			item.knockBack = 2;
			item.magic = false;
			item.rare = 0;
			item.useTime = 28;
            item.useAnimation = 28;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shootSpeed = 10f;
			item.autoReuse = false;
			item.shoot = ProjectileType<SparklingBall>();
			// exampleResourceCost is a field in the base class ExampleDamageItem. This item consumes 10 Example Resource to use.
			
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ExampleSoul", 5);
			recipe.AddIngredient(null, "TornFabric", 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		
		
		
	}
}