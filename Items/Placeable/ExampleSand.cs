using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace RothurMod.Items.Placeable 
{
	public class ExampleSand : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crystal Sand");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальный песок");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.ExampleSand>();
			//item.ammo = AmmoID.Sand; Using this Sand in the Sandgun would require PickAmmo code and changes to ExampleSandProjectile or a new ModProjectile.
		}

		
	}
}