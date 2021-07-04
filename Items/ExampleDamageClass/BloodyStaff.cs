using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items;
using RothurMod.Projectiles;
using Terraria.ModLoader;

namespace RothurMod.Items.ExampleDamageClass
{
	public class BloodyStaff : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Staff");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавый посох");
		}
		// This is a staff that uses the example damage class stuff you've set up before, but uses exampleResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using exampleResource then I'd suggest making a new abstract ModItem class that inherits ExampleDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		

		public override void SafeSetDefaults() {
			item.CloneDefaults(ItemID.EmeraldStaff);
			item.Size = new Vector2(28, 36);
			item.damage = 20;
			item.knockBack = 2;
			item.rare = ItemRarityID.Red;
			item.width = 44;
            item.height = 44;
			item.magic = false;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 15f;
			item.shoot = ModContent.ProjectileType<BloodyShard>();
			item.autoReuse = true;
			// exampleResourceCost is a field in the base class ExampleDamageItem. This item consumes 10 Example Resource to use.
			
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2; // This defines how many projectiles to shot
            float rotation = MathHelper.ToRadians(10);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 2f; //this defines the distance of the projectiles form the player when the projectile spawns
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))); // This defines the projectile roatation and speed. .4f == projectile speed
                Projectile.NewProjectile(position.X - 2f, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
		
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BloodyScale>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
}