using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Items.Placeable
{
	public class ExampleWall : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = WallType<Walls.ExampleWall>();
		}

	}
}