using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace RothurMod.Projectiles
{
	public class SparklingBall : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.magic = false;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.tileCollide = true;
            projectile.ignoreWater = true;
		}

		public override void AI() {
			projectile.velocity.Y += projectile.ai[0];
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
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Sparkle>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			if (Main.rand.NextBool(2)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Sparkle>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
		
		private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 5f) {
                vector *= 10f / magnitude;
            }
        }

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 5; k++) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Sparkle>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}