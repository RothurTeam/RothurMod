using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Special
{
	public class LargeGel : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Large Gel"); 
			Tooltip.SetDefault("This may be interesting for a ninja");
			DisplayName.AddTranslation(GameCulture.Russian, "Большой гель");
			Tooltip.AddTranslation(GameCulture.Russian, "Это может быть интересно для ниндзя");
		}

		public override void SetDefaults() 
		{
			
			item.width = 16;
			item.height = 13;
			item.maxStack = 99;
			item.value = 0;
			item.rare = ItemRarityID.Quest;
		}
            
		
	}
} 