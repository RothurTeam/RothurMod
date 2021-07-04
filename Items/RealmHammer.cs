using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items           
{
    public class RealmHammer : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Realmite Hammer"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый молот");
		}

		public override void SetDefaults() 
		{
            item.damage = 7;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 23;
            item.useAnimation = 23;
            item.hammer = 35;    
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
            recipe.AddIngredient(null, "RealmShard", 6);   
            recipe.AddTile(TileID.WorkBenches);   
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}