using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ExampleBuffPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("<>");
            Tooltip.SetDefault("Grants protection of nature");
			Tooltip.AddTranslation(GameCulture.Russian, "Дарует защиту природы");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item4;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(silver: 2);
            item.buffType = BuffType<Buffs.ExampleDefenseBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 7200; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ExampleItem", 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}