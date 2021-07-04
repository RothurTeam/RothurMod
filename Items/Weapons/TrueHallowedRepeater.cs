using RothurMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;


namespace RothurMod.Items.Weapons
{
	public class TrueHallowedRepeater : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("True Hallowed Repeater");
			DisplayName.AddTranslation(GameCulture.Russian, "Истинный святой арбалет");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.HallowedRepeater);
			//item.shootSpeed *= 0.75f;
			//item.damage = (int)(item.damage * 1.5);
			item.damage = 54; 
			item.rare = ItemRarityID.Yellow;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{ 
            if (type == ProjectileID.WoodenArrowFriendly) //if you use wooden arrow
            {
			    type = ProjectileID.JestersArrow;  
            }
            return true;
        }

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedRepeater);
			recipe.AddIngredient(null, "BrokenHeroBow", 1);	
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}