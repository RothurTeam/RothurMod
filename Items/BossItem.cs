using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class BossItem : ExampleItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Demon Crystal ");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Демонический кристалл");
		}

		
	}
}