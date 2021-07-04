using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using RothurMod.Projectiles;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RothurMod.Items.ExampleDamageClass
{
	public class LuciferDaggers : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lucifer's Daggers"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кинжалы Люцифера");
			
		}

		public override void SafeSetDefaults() 
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.damage = 24;
			item.width = 42;
			item.height = 42;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 3;
			item.value = 50000;
			item.rare = 2;
			item.maxStack = 1;
			item.shoot = 17;
			item.shootSpeed = 11; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<LuciferDaggersProjectile>();
			item.autoReuse = true;
			item.consumable = false;
			item.thrown = false;
		}

	
	}
} 