using RothurMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ExampleCloneItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Conqueror of the sky");
			DisplayName.AddTranslation(GameCulture.Russian, "Покоритель неба");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Starfury);
			item.shootSpeed *= 0.75f;
			//item.damage = (int)(item.damage * 1.5);
			item.damage = 47; 
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			type = ProjectileType<ExampleCloneProjectile>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Starfury);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}