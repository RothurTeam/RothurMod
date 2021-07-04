using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class SDemon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Core Of The Demon"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Ядро демона");
		}

		public override void SetDefaults() 
		{
			
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 2000;
			item.rare = 1;
		}

	}
} 