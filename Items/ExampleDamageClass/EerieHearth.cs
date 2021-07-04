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
	public class EerieHearth : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Eerie Hearth");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Жуткий очаг");
		}
		// This is a staff that uses the example damage class stuff you've set up before, but uses exampleResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using exampleResource then I'd suggest making a new abstract ModItem class that inherits ExampleDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		

		public override void SafeSetDefaults() {
			item.CloneDefaults(ItemID.EmeraldStaff);
			item.Size = new Vector2(28, 36);
			item.damage = 35;
			item.knockBack = 2;
			item.rare = ItemRarityID.LightPurple;
			item.width = 60;
            item.height = 60;
			item.magic = false;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 12f;
			item.shoot = ModContent.ProjectileType<CorShard>();
			item.autoReuse = true;
			// exampleResourceCost is a field in the base class ExampleDamageItem. This item consumes 10 Example Resource to use.
			
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
          {
              int numberProjectiles = 3 + Main.rand.Next(4); //This defines how many projectiles to shot. 4 + Main.rand.Next(2)= 4 or 5 shots
              for (int i = 0; i < numberProjectiles; i++)
              {
                  Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25)); // This defines the projectiles random spread . 30 degree spread.
                  Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
              }
              return false; 
          }   
		
		
		
	}
}