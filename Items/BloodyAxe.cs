using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
    public class BloodyAxe : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Pickaxe Axe"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавый киркатопор");
		}

		public override void SetDefaults() 
		{
            item.damage = 11;
            item.melee = true;
            item.width = 40;
            item.height = 42;
            item.useTime = 17;
            item.useAnimation = 17;
            item.axe = 12; 
			item.pick = 75;
            item.axe = 17; 
			item.pick = 100;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 20000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BloodyScale", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
        
}