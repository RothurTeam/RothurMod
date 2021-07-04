using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class BuffPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("<>");
            Tooltip.SetDefault("Grants demon protection");
			Tooltip.AddTranslation(GameCulture.Russian, "Дарует защиту демона");
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
            item.rare = ItemRarityID.Red;
            item.value = Item.buyPrice(silver: 2);
            item.buffType = BuffType<Buffs.DefenseBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 10800; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossItem", 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}