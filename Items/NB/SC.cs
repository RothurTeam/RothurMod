using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items.NB
{
	public class SC	: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("SC");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Каменная клешня");
		}

		public override void SetDefaults() 
		{
			item.damage = 8;
			item.melee = true;
			item.width = 22;
			item.height = 22;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 5000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

	}
} 