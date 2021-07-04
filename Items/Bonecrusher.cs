using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class Bonecrusher : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bonecrusher"); 
			Tooltip.SetDefault("Click on the right mouse button to stab");
			DisplayName.AddTranslation(GameCulture.Russian, "Костолом");
			Tooltip.AddTranslation(GameCulture.Russian, "Нажмите на правую кнопку мыши чтобы пырнуть ");
			
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = 30;
			item.knockBack = 10;
			item.value = 10000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
		
		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.Stabbing;
				item.useTime = 30;
				item.useAnimation = 30;
				item.damage = 40;
				item.knockBack = 10;
			}
			else {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 35;
				item.useAnimation = 55;
				item.damage = 70;
			}
			return base.CanUseItem(player);
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 65);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
} 