using RothurMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class TornFabric : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Torn Fabric"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Рваная ткань");
		}

		public override void SetDefaults() 
		{
			
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 50;
			item.rare = 0;
		}

	}
} 