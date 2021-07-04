using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items           
{
    public class RealmPickaxe : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Realmite Pickaxe"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовая кирка");
		}

		public override void SetDefaults() 
		{
            item.damage = 6;
            item.melee = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 23;
            item.useAnimation = 23;
            item.pick = 35;    
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 1000;
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