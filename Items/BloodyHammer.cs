using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items           
{
    public class BloodyHammer : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Hammer"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавый молот");
		}

		public override void SetDefaults() 
		{
            item.damage = 12;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 28;
            item.useAnimation = 28;
            item.hammer = 70;    
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
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
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}