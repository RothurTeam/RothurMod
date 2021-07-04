using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using System;

namespace RothurMod.Projectiles
{
	public class LuciferDaggersProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lucifer's Daggers");
			DisplayName.AddTranslation(GameCulture.Russian, "Кинжалы Люцифера");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.DemonSickle);
			aiType = ProjectileID.DemonSickle;
			projectile.width = 33;
			projectile.height = 29;
			projectile.friendly = true;
			projectile.hostile = false;
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
	}

		//public override bool PreKill(int timeLeft) {
			//projectile.type = ProjectileID.Starfury;
			//return true;
		//}
}
