using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ShadowShard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Shard"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневой осколок");
		}

		public override void SetDefaults() 
		{
			
			item.width = 18;
			item.height = 13;
			item.maxStack = 99;
			item.value = 4000;
			item.rare = 1;
		}
            
		
	}
} 