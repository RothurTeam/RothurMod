using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace RothurMod.Projectiles
{
	public class ObserverBall : ModProjectile
	{
		Vector2 direction;
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 240;
			projectile.rotation -= MathHelper.ToRadians(90f);
		}

		public override void AI()
        {
            Vector2 move = Vector2.Zero;
            float distance = 450f;
            bool target = false;
            for (int k = 0; k < 250; k++) {
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
			if (Main.rand.NextBool(1)) {
				//Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<BloodyFlame>(), projectile.velocity.X * 0.65f, projectile.velocity.Y * 0.65f);
			}
			if (Main.rand.NextBool(3)) {
				//Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<BloodyFlame>(), projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.75f);
			}
        }

        private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f) {
                vector *= 10f / magnitude;
            }
        }

		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 5; k++) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<BloodyFlame>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
		
	}
}