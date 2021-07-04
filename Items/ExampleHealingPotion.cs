using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ExampleHealingPotion : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Realmite potion");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовое зелье");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 30;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 30;
			item.consumable = true;
			item.rare = 0;
			item.healLife = 60; 
			item.potion = true; 
			item.value = Item.buyPrice(silver: 1);
		}

		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RealmShard", 2);
			recipe.AddIngredient(ItemID.LesserHealingPotion, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}