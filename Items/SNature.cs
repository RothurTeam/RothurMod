using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class SNature : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Core Of The Nature"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Ядро природы");
		}

		public override void SetDefaults() 
		{
			
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 1;
		}

	}
} 