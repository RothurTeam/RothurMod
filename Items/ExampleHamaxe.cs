using RothurMod.Dusts;
using RothurMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ExampleHamaxe : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soul blade");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Клинок душ");
		}

		public override void SetDefaults() {
			item.damage = 14;
			item.width = 40;
			item.height = 48;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.melee = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<ExampleSoul>(), 4);;
			recipe.AddTile(TileType<ExampleWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Sparkle>());
			}
		}
	}
}