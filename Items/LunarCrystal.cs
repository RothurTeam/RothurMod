using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class LunarCrystal : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lunar Crystal ");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Лунный кристалл");
		}
		
		public override void SetDefaults() 
		{
			
			item.width = 16;
			item.height = 18;
			item.maxStack = 99;
			item.value = 10000;
			item.rare = 0;
		}

		
	}
}