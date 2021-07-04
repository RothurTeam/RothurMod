using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items;
using RothurMod.Projectiles;
using Terraria.ModLoader;

namespace RothurMod.Items.ExampleDamageClass
{
	public class bookofbloodlust : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The book of bloodlust");
			Tooltip.SetDefault("Absorbs the life of enemies");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Книга кровожадности");
			Tooltip.AddTranslation(GameCulture.Russian, "Поглощает жизнь врагов");
			item.shoot = ModContent.ProjectileType<ShadowArm>();
		}
		// This is a staff that uses the example damage class stuff you've set up before, but uses exampleResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using exampleResource then I'd suggest making a new abstract ModItem class that inherits ExampleDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		

		public override void SafeSetDefaults() {
			item.CloneDefaults(ItemID.EmeraldStaff);
			item.Size = new Vector2(28, 36);
			item.damage = 36;
			item.magic = false;
			item.knockBack = 0;
			item.rare = 1;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shoot = ModContent.ProjectileType<ShadowArm>();
			// exampleResourceCost is a field in the base class ExampleDamageItem. This item consumes 10 Example Resource to use.
			
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            int vampirism = 1; // сколько хп ворует
            target.life -= vampirism;
            player.statLife += vampirism;
            player.HealEffect(vampirism, true); // эффектос
        }
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BossItem>(), 12);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
}