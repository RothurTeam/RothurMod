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
	public class BoneStaff : ExampleDamageItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bone rain staff");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Посох костяного дождя");
		}
		// This is a staff that uses the example damage class stuff you've set up before, but uses exampleResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using exampleResource then I'd suggest making a new abstract ModItem class that inherits ExampleDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		

		public override void SafeSetDefaults() {
			item.Size = new Vector2(28, 36);
			item.damage = 18;
			item.knockBack = 1;
			item.rare = 0;
			item.useTime = 32;
            item.useAnimation = 32;
			item.width = 40;
            item.height = 40;
			item.magic = false;
			item.useStyle = 5; 
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			//item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 17f;
			item.shoot = ModContent.ProjectileType<Bone>();
			item.autoReuse = true;
			item.noMelee = true;
			// exampleResourceCost is a field in the base class ExampleDamageItem. This item consumes 10 Example Resource to use.
			
		}
		
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4 + Main.rand.Next(2);  //This defines how many projectiles to shot
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-40, 41) * 0.02f;  //this defines the projectile X position speed and randomnes
                float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.02f;  //this defines the projectile Y position speed and randomnes
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
            return false;
        }  
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 40);
			recipe.AddIngredient(ItemType<ExampleSoul>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
}