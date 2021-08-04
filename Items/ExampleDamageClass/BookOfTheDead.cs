using System;
using RothurMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RothurMod.Dusts;

namespace RothurMod.Items.ExampleDamageClass
{
    public class BookOfTheDead : ExampleDamageItem {
	
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Book of The Dead");
            Tooltip.SetDefault(""
				+ "\nBy clicking on the right mouse button, you can"
				+ "\nturn the souls of enemies into buffs");
				Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "\nНажав на правую кнопку мыши, вы можете"
				+ "\nпревратить души врагов в баффы");
			DisplayName.AddTranslation(GameCulture.Russian, "Книга смерти");
        }
        public override void SafeSetDefaults() {
            item.damage = 15;
            item.knockBack = 6f;
            item.useStyle = 4;  
            item.useAnimation = 27;
            item.useTime = 27;
			item.UseSound = SoundID.Item20;
            item.width = 30;
            item.height = 30;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = 25000;
            item.rare = 2;
            item.shootSpeed = 10f;
            item.shoot = ModContent.ProjectileType<DeadBolt>();
        }
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Book, 1);
			recipe.AddIngredient(null, "SpoiledSoul", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
    public class DeadBolt : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dead Bolt");
        }
        public override void SetDefaults() {
            projectile.width = 16;
            projectile.height = 16;
            //projectile.ranged = true;
            projectile.friendly = true;
        }
		
		public override void AI() {
			if (Main.rand.NextBool(2)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Dark>(), projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f);
			}
			if (Main.rand.NextBool(1)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Dark>(), projectile.velocity.X * 0.8f, projectile.velocity.Y * 0.7f);
			}
		}
		
        public override void OnHitNPC(NPC target,int damage,float kB,bool crit) {
            if (!target.active) {
                SpawnBuffs();
            }
        }
        public void SpawnBuffs() {
            Player player = Main.player[projectile.owner];
            var angle = MathHelper.ToRadians(Main.rand.Next(0,360));
            var direction = GetVector(angle);
            direction *= Main.rand.Next(100,150);
            Projectile.NewProjectile(player.Center.X+direction.X,player.Center.Y+direction.Y,0f,0f,ModContent.ProjectileType<DeadBookBooster>(),0,0f,player.whoAmI);
            projectile.active = false;
        }
        public Vector2 GetVector(float angle) {
            return new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }
    }
    public class DeadBookBooster : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dead Book Booster");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults() {
            projectile.width = 14;
            projectile.height = 23;
            projectile.friendly = true;
            projectile.hostile = true;
            projectile.timeLeft = 300;
        }
        public override void AI() {
            Player player = Main.player[projectile.owner];
            if (Main.mouseRight) {
                var buffTypes = Main.rand.Next(0,2);
                projectile.active = false;
                var buffs = player.buffType;
                var hasBuff = 0;
                var index = 0;
                for (int i = 0;i < buffs.Length;i++) {
                    var buff = buffs[i];
                    if (buffTypes==0) {
                        if (buff==ModContent.BuffType<DamageBoostS1>()) {
                            hasBuff = 1;
                            index = i;
                            // Main.NewText(hasBuff.ToString(), 175, 75, 255);
                        }
                        if (buff==ModContent.BuffType<DamageBoostS2>()) {
                            hasBuff = 2;
                            index = i;
                        }
                        if (buff==ModContent.BuffType<DamageBoostS3>()) {
                            hasBuff = 3;
                            index = i;
                        }
                    } else {
                        if (buff==ModContent.BuffType<RegenBoostS1>()) {
                            hasBuff = 4;
                            index = i;
                            // Main.NewText(hasBuff.ToString(), 175, 75, 255);
                        }
                        if (buff==ModContent.BuffType<RegenBoostS2>()) {
                            hasBuff = 5;
                            index = i;
                        }
                        if (buff==ModContent.BuffType<RegenBoostS3>()) {
                            hasBuff = 6;
                            index = i;
                        }                  
                    }
                }
                switch(hasBuff) {
                    case 0:
                        if (buffTypes==0) {
                            player.AddBuff(ModContent.BuffType<DamageBoostS1>(),450);
                        } else {
                            player.AddBuff(ModContent.BuffType<RegenBoostS1>(),450);
                        }
                        // Main.NewText("zolupa".ToString(), 175, 75, 255);
                        break;
                    case 1:
                        player.DelBuff(index);
                        player.AddBuff(ModContent.BuffType<DamageBoostS2>(),450);
                        break;
                    case 2:
                        player.DelBuff(index);
                        player.AddBuff(ModContent.BuffType<DamageBoostS3>(),450);
                        break;
                    case 3:
                        if (player.buffTime[index] < 20*60) {
                            player.buffTime[index] += 300;
                        }
                        break;
                    case 4:
                        player.DelBuff(index);
                        player.AddBuff(ModContent.BuffType<RegenBoostS2>(),450);
                        break;
                    case 5:
                        player.DelBuff(index);
                        player.AddBuff(ModContent.BuffType<RegenBoostS3>(),450);
                        break;
                    case 6:
                        if (player.buffTime[index] < 20*60) {
                            player.buffTime[index] += 300;
                        }
                        break;
                }
            }
            AnimateProjectile();
        }
        public void AnimateProjectile()
        {
            projectile.frameCounter++;
            if(projectile.frameCounter >= 8)
            {
                projectile.frame++;
                projectile.frame %= 4;
                projectile.frameCounter = 0;
            }
        }
    }
    public class DamageBoostS1 : ModBuff {
		public override void SetDefaults() {
			DisplayName.SetDefault("Shadow Force Stage 1");
			Description.SetDefault("Increases damage by 5%");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневая сила стадия 1");
			Description.AddTranslation(GameCulture.Russian, "Увеличивает урон на 5%");
			Main.buffNoSave[Type] = true;
		}
        public override void Update(Player player, ref int buffIndex) {
            var increase = 0.05f;
            player.magicDamage += increase;
            player.meleeDamage += increase;
            player.rangedDamage += increase;
            player.minionDamage += increase;
        }
    }
    public class DamageBoostS2 : ModBuff {
		public override void SetDefaults() {
			DisplayName.SetDefault("Shadow Force Stage 2");
			Description.SetDefault("Increases damage by 10%");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневая сила стадия 2");
			Description.AddTranslation(GameCulture.Russian, "Увеличивает урон на 10%");
			Main.buffNoSave[Type] = true;
		}
        public override void Update(Player player, ref int buffIndex) {
            var increase = 0.1f;
            player.magicDamage += increase;
            player.meleeDamage += increase;
            player.rangedDamage += increase;
            player.minionDamage += increase;
        }
    }
    public class DamageBoostS3 : ModBuff {
		public override void SetDefaults() {
			DisplayName.SetDefault("Shadow Force Stage 3");
			Description.SetDefault("Increases damage by 15%");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневая сила стадия 3");
			Description.AddTranslation(GameCulture.Russian, "Увеличивает урон на 15%");
			Main.buffNoSave[Type] = true;
		}
        public override void Update(Player player, ref int buffIndex) {
            var increase = 0.15f;
            player.magicDamage += increase;
            player.meleeDamage += increase;
            player.rangedDamage += increase;
            player.minionDamage += increase;
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += increase;
        }
    }


    public class RegenBoostS1 : ModBuff {
		public override void SetDefaults() {
			DisplayName.SetDefault("Shadow Blessing Stage 1");
			Description.SetDefault("Increases health regeniration by 5%");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневое благословение стадия 1");
			Description.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию здоровья на 5%");
			Main.buffNoSave[Type] = true;
		}
        public override void Update(Player player, ref int buffIndex) {
            var increase = 5;
            player.lifeRegen += increase;
        }
    }
    public class RegenBoostS2 : ModBuff {
		public override void SetDefaults() {
			DisplayName.SetDefault("Shadow Blessing Stage 2");
			Description.SetDefault("Increases health regeniration by 10%");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневое благословение стадия 2");
			Description.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию здоровья на 10%");
			Main.buffNoSave[Type] = true;
		}
        public override void Update(Player player, ref int buffIndex) {
            var increase = 10;
            player.lifeRegen += increase;
        }
    }
    public class RegenBoostS3 : ModBuff {
		public override void SetDefaults() {
			DisplayName.SetDefault("Shadow Blessing Stage 3");
			Description.SetDefault("Increases health regeniration by 15%");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневое благословение стадия 3");
			Description.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию здоровья на 15%");
			Main.buffNoSave[Type] = true;
		}
        public override void Update(Player player, ref int buffIndex) {
            var increase = 15;
            player.lifeRegen += increase;
        }
    }
}