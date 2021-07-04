using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles
{
	public class SparklingBallRB : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 60;
			projectile.height = 60;
			projectile.friendly = false;
			projectile.penetrate = 3;
			projectile.timeLeft = 620;
			projectile.damage = 20;
			projectile.hostile = true;
			//projectile.noGravity = false;
		}

		public override void AI() {
			//projectile.velocity.Y += projectile.ai[0];
			      
            Main.player[projectile.owner].direction = projectile.direction;    

                projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.25f;
                projectile.velocity.X = projectile.velocity.X + 0.05f;
                projectile.rotation -= MathHelper.ToRadians(-20);
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
			Main.PlaySound(SoundID.Item10, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}