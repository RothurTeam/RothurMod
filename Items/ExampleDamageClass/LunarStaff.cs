using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items;
using RothurMod.Projectiles;
using Terraria.ModLoader;
using RothurMod.Projectiles.Minions;

namespace RothurMod.Items.ExampleDamageClass
{
	public class LunarStaff : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Lunar staff");
			Tooltip.SetDefault("<right> to summon a minion");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Лунный посох");
			Tooltip.AddTranslation(GameCulture.Russian, "<right>, чтобы вызвать приспешника");
		}
		// This is a staff that uses the example damage class stuff you've set up before, but uses exampleResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using exampleResource then I'd suggest making a new abstract ModItem class that inherits ExampleDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		

		public override void SafeSetDefaults() {
			item.CloneDefaults(ItemID.EmeraldStaff);
			item.Size = new Vector2(28, 36);
			item.damage = 42;
			item.knockBack = 2;
			item.magic = false;
			item.rare = ItemRarityID.Blue;
			item.useTime = 28;
            item.useAnimation = 28;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.magic = false; 
			item.shootSpeed = 12f;
			// exampleResourceCost is a field in the base class ExampleDamageItem. This item consumes 10 Example Resource to use.
			
		}
		
		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 30;
				item.useAnimation = 30;
				item.damage = 42;
				item.shoot = ProjectileType<LunarLamp>();
			    item.buffType = BuffType<Buffs.LunarLampBuff>();
				item.magic = false; 
				item.summon = false; 
				item.rare = ItemRarityID.Blue;
			}
			else {
				item.CloneDefaults(ItemID.EmeraldStaff);
				item.useTime = 28;
				item.useAnimation = 28;
				item.damage = 42;
				item.knockBack = 2;
				item.mana = 0;
				item.shoot = ProjectileType<LunarProjectile>();
				item.magic = false; 
				item.rare = ItemRarityID.Blue;	
				item.shootSpeed = 12f;
			}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(null, "LunarCrystal", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		
		
		
	}
}