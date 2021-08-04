using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Special
{
	public class SharpTooth : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sharp Tooth"); 
			Tooltip.SetDefault("This may be interesting for a ninja");
			DisplayName.AddTranslation(GameCulture.Russian, "Острый зуб");
			Tooltip.AddTranslation(GameCulture.Russian, "Это может быть интересно для ниндзя");
		}

		public override void SetDefaults() 
		{
			
			item.width = 18;
			item.height = 18;
			item.maxStack = 99;
			item.value = 0;
			item.rare = ItemRarityID.Quest;
		}
            
		
	}
} 