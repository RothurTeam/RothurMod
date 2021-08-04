using System;
using Microsoft.Xna.Framework;
using RothurMod.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles   
{
    public class RottenBall : ModProjectile {
        Random rand = new Random();


        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rotten Ball");
        }
        public override void SetDefaults() {
            projectile.width = 16;
            projectile.height = 16;
            projectile.magic = true;
            projectile.friendly = true;
			projectile.timeLeft = 190;
        }

        public override void AI() {
			
            Vector2 vel = projectile.velocity;

            float angle = (float)Math.Atan2(vel.X, vel.Y);

            if (rand.Next(0,2) == 1) {
                angle += 0.1f;
            } else {angle -= 0.1f;}

            projectile.velocity = new Vector2((float)Math.Sin(angle)*5, (float)Math.Cos(angle)*5);
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Rotten>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			if (Main.rand.NextBool(4)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Rotten>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
    }
}
