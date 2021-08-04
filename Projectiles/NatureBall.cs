using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;

namespace RothurMod.Projectiles
{
	public class NatureBall : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 240;
			//projectile.hostile = true;
		}

		public override void AI() {
			Main.player[projectile.owner].direction = projectile.direction;    

                projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.25f;
                projectile.velocity.X = projectile.velocity.X + 0.05f;
                projectile.rotation -= MathHelper.ToRadians(-20);
            }
			if (Main.rand.NextBool(1)) {
				var index = Dust.NewDust(projectile.position -projectile.velocity, projectile.width, projectile.height, 61, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].noGravity = true;
				Main.dust[index].velocity *= 0.15f;
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
				projectile.velocity *= 0.7f;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 5; k++) {
				var index = Dust.NewDust(projectile.position -projectile.velocity, projectile.width, projectile.height, 61, 0.0f, 0.0f, 0, new Color(), 1f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}