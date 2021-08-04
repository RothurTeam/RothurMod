using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RothurMod.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles   
{
    public class EnergyShard : ModProjectile {
        Random rand = new Random();


        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Energy Shard");
        }
        public override void SetDefaults() {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = false;
			projectile.timeLeft = 180;
			projectile.hostile = true;
        }
		
		public override Color? GetAlpha(Color lightColor) {
			return new Color(255, 255, 0, 0) * (1f - (float)projectile.alpha / 255f);
		}

        public override void AI() {
			
            Vector2 vel = projectile.velocity;

            float angle = (float)Math.Atan2(vel.X, vel.Y);

            if (rand.Next(0,2) == 1) {
                angle += 0.12f;
            } else {angle -= 0.12f;}

            projectile.velocity = new Vector2((float)Math.Sin(angle)*5, (float)Math.Cos(angle)*5);
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<SparkleE>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			if (Main.rand.NextBool(4)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<SparkleE>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
    }
}
