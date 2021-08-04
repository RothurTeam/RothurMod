using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items           
{
    public class ThermoPickaxe : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thermo Pickaxe"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо кирка");
		}

		public override void SetDefaults() 
		{
            item.damage = 7;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.pick = 45;    
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ThermoBar", 12);  
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}