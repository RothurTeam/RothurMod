using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace RothurMod.Projectiles
{
	public class BloodyShard : ModProjectile
	{
		public override void SetStaticDefaults() {
			//ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.width = 11;
			projectile.height = 11;
			projectile.alpha = 255;
			projectile.penetrate = 2;
			projectile.friendly = true;
			projectile.ignoreWater = true;
		}

		public override void AI() {
			Vector2 move = Vector2.Zero;
            float distance = 400f;
            bool target = false;
            for (int k = 0; k < 200; k++) {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5) {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance) {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target) {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, 0f, 0f, 100, new Color(255, 0, 0), 1.5f);
			Main.dust[dust].velocity *= 0.2f;
			if (projectile.velocity == Vector2.Zero) {
				Main.dust[dust].velocity.Y -= 1.1f;
				Main.dust[dust].scale = 1.4f;
			}
			else {
				Main.dust[dust].velocity += projectile.velocity * 0.37f;
			}
			Main.dust[dust].position.X = projectile.Center.X + 4.2f + (float)Main.rand.Next(-3, 3);
			Main.dust[dust].position.Y = projectile.Center.Y + (float)Main.rand.Next(-2, 4);
			Main.dust[dust].noGravity = true;
		}
		
		private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f) {
                vector *= 10f / magnitude;
            }
        }

		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate = -1;
			projectile.maxPenetrate = -1;
			projectile.tileCollide = false;
			projectile.position += projectile.velocity;
			projectile.velocity = Vector2.Zero;
			projectile.timeLeft = 120;
			return false;
		}
	}
}