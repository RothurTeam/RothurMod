using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Items
{
	public class WOW : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("???"); 
			Tooltip.SetDefault("???");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.value = 0;
			item.rare = 0;
		}

	}
} 