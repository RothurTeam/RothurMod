using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class RealmShard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Realm Shard"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый осколок");
		}

		public override void SetDefaults() 
		{
			
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 0;
		}
            
		
	}
} 