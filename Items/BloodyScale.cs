using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class BloodyScale : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Scales"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавая чешуя");
		}

		public override void SetDefaults() 
		{
			
			item.width = 18;
			item.height = 13;
			item.maxStack = 99;
			item.value = 3000;
			item.rare = 1;
		}
            
		
	}
} 