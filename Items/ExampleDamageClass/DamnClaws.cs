using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
using RothurMod.Items;

namespace RothurMod.Items.ExampleDamageClass
{
	public class DamnClaws : ExampleDamageItem
	{

		public override void SafeSetDefaults() 
		{
			item.damage = 17;
			item.width = 28;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 12000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.noMelee = false;
			item.shoot = mod.ProjectileType ("SparklingBallA");
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			// It is hard to hook into every place checking item's crit and fake item.ranged = true
			// Instead, we can mimick regular ranged crit assignment
			crit = Main.LocalPlayer.rangedCrit - Main.LocalPlayer.inventory[Main.LocalPlayer.selectedItem].crit + Main.HoverItem.crit;
			base.GetWeaponCrit(player, ref crit);
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<ExampleItem>(), 4);
			recipe.AddIngredient(ItemType<ExampleSoul>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}