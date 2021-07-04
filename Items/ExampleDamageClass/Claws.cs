using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.ExampleDamageClass
{
	public class Claws : ExampleDamageItem
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Claws");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Теневые когти");
		}

		public override void SafeSetDefaults() 
		{
			item.damage = 66;
			item.width = 28;
			item.height = 26;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 50000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.noMelee = false;
			item.shoot = mod.ProjectileType ("SparklingBallR");
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			// It is hard to hook into every place checking item's crit and fake item.ranged = true
			// Instead, we can mimick regular ranged crit assignment
			crit = Main.LocalPlayer.rangedCrit - Main.LocalPlayer.inventory[Main.LocalPlayer.selectedItem].crit + Main.HoverItem.crit;
			base.GetWeaponCrit(player, ref crit);
		}
	}
}