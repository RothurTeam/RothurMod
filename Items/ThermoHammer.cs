using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items           
{
    public class ThermoHammer : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thermo Hammer"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо топор");
		}

		public override void SetDefaults() 
		{
            item.damage = 12;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.hammer = 50;    
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
            recipe.AddIngredient(null, "ThermoBar", 10);  
            recipe.AddTile(TileID.Anvils);  
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}