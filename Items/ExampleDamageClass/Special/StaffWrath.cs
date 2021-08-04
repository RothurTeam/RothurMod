using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items;
using RothurMod.Projectiles;
using Terraria.ModLoader;
using RothurMod.Dusts;

namespace RothurMod.Items.ExampleDamageClass.Special
{
	public class StaffWrath : ExampleDamageItem
	{
		bool charging = false;
        bool charged = false;
        int hold = 0;
        int shootType;
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Staff of Wrath");
			Tooltip.SetDefault(""
				+ "\nBy delaying LCM, you can release"
				+ "\nmuch more anger");
				Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "\nЗадерживая ЛКМ можно выпустить "
				+ "\nнамного больше гнева");
			Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Посох гнева");
		}
		// This is a staff that uses the example damage class stuff you've set up before, but uses exampleResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using exampleResource then I'd suggest making a new abstract ModItem class that inherits ExampleDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		

		public override void SafeSetDefaults() {
			item.CloneDefaults(ItemID.EmeraldStaff);
			item.Size = new Vector2(28, 36);
			item.damage = 15;
			item.knockBack = 2;
			item.rare = 2;
			item.width = 44;
            item.height = 44;
			item.useTime = 30;
            item.useAnimation = 30;
			item.magic = false;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 19f;
			//item.shoot = ModContent.ProjectileType<BloodyShard>();
			item.autoReuse = true;
			
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<SpoiledSoul>(), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return false;
        }

        public override void HoldItem(Player player) {
            if (Main.mouseLeft) {
                charging = true;
                hold++;
                if (hold % 10 == 0) {
                    // Main.NewText((hold).ToString(), 175, 75, 255);
                    var angle = (hold*180/150);
                    Vector2 position = new Vector2(player.Center.X,player.Center.Y) + GetVector(angle)*50;
                    Projectile.NewProjectile(position,Vector2.Zero, ModContent.ProjectileType<HoldWeaponProjectile>(), 0, 0f,player.whoAmI);
                }
                if (hold > 30) {
                    hold = 30;
                    charged = true;
                }

                //File.WriteAllText("/home/martos/.local/share/Terraria/ModLoader/Mod Sources/Examples/Items/Weapons/info.txt", hold.ToString());       
            } else if (charging) {
                for (int i = 0;i < Main.projectile.Length;i++) {
                    var proj = Main.projectile[i];
                    if (proj.type == ModContent.ProjectileType<HoldWeaponProjectile>()) {
                        proj.active = false;
                    }
                }
                Shot(player,charged,hold);
                charging = false;
                charged = false;
                hold = 0;
            }
        }

        public void Shot(Player player, bool charged, int damage) {
            var angle = -(float)Math.Atan2(Main.MouseWorld.Y-player.position.Y,Main.MouseWorld.X-player.position.X)+MathHelper.ToRadians(90);
            var pos = player.position;

            Vector2 direction = GetVector(angle);
            if (charged) {
                int numberProjectiles = 4 + Main.rand.Next(2); 
                for (int i = 0; i < numberProjectiles; i++) {
                    Vector2 perturbedSpeed = direction.RotatedByRandom(MathHelper.ToRadians(20));
                    Projectile.NewProjectile(pos.X,pos.Y, perturbedSpeed.X,perturbedSpeed.Y,ModContent.ProjectileType<HoldBullet>(),damage,0f,player.whoAmI);
                }   
            } else {
                Projectile.NewProjectile(pos.X,pos.Y, direction.X*1,direction.Y*1,ModContent.ProjectileType<HoldBullet>(),damage,0f,player.whoAmI);
            }
            // Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
        }

        public Vector2 GetVector(float angle) {
            return new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }
		
    }
		
		
		public class HoldWeaponProjectile : ModProjectile {
        bool spawned = true;
        Vector2 direction;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hold Weapon");
        }
        public override void SetDefaults() {
            projectile.width = 8;
            projectile.height = 8;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (spawned) {
                direction = new Vector2(projectile.position.X-player.position.X,projectile.position.Y-player.position.Y);
                spawned = false;
            }

            projectile.position = player.position + direction;
        }
    }

    public class HoldBullet : ModProjectile {
        bool spawned = true;
        Vector2 direction;
		public const int strikeTime = 20;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hold bullet");
        }
        public override void SetDefaults() {
            projectile.width = 24;
            projectile.height = 24;
            projectile.scale=0.125f;
            projectile.ranged = true;
            projectile.friendly = true;
			projectile.timeLeft = 240;
        }
		
		public override void AI() {
			projectile.velocity.Y += projectile.ai[0];
			if (Main.rand.NextBool(5)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Dark>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Dark>(), projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f);
			}
			if (Main.rand.NextBool(2)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Dark>(), projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f);
			}
			if (Main.rand.NextBool(1)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Dark>(), projectile.velocity.X * 0.8f, projectile.velocity.Y * 0.7f);
			}
		}
    }
		
}
