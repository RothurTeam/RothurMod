using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using RothurMod.Projectiles;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class RottenWorm : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("A Rotten Worm");
			DisplayName.AddTranslation(GameCulture.Russian, "Гнилой Червь");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.LaserRifle);
			item.damage = 20;
			item.width = 50;
			item.height = 36;
			item.useTime = 17;
			item.useAnimation = 17;
			item.rare = 2;
            item.mana = 2;
			item.shoot = 11;
			item.shootSpeed = 9; 
			item.knockBack = 2;
			item.value = 15000;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType ("RottenBall");  
		}
	}
} 