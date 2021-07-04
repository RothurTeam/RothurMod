using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles
{
	public class BalanceBall : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = false;
			projectile.penetrate = 3;
			projectile.timeLeft = 420;
			projectile.rotation -= MathHelper.ToRadians(90f);
		}

		public override void AI() {
			 {      
            Main.player[projectile.owner].direction = projectile.direction;    

                projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.25f;
                projectile.velocity.X = projectile.velocity.X + 0.05f;
                projectile.rotation -= MathHelper.ToRadians(-50);
            }

            if (projectile.ai[0] <= 10)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0f;
                projectile.velocity.X = projectile.velocity.X + 0f;
                projectile.rotation -= MathHelper.ToRadians(-30);
            } 
        }
		
		if (projectile.localAI[0] == 0f) {
				Main.PlaySound(SoundID.Item20, projectile.position);
				projectile.localAI[0] = 1f;
			}
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, 0f, 0f, 100, new Color(255, 69, 0), 1.5f);
			Main.dust[dust].velocity *= 0.1f;
			if (projectile.velocity == Vector2.Zero) {
				Main.dust[dust].velocity.Y -= 1f;
				Main.dust[dust].scale = 1.2f;
			}
			else {
				Main.dust[dust].velocity += projectile.velocity * 0.3f;
			}
			Main.dust[dust].position.X = projectile.Center.X + 4f + (float)Main.rand.Next(-2, 3);
			Main.dust[dust].position.Y = projectile.Center.Y + (float)Main.rand.Next(-2, 3);
			Main.dust[dust].noGravity = true;
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
					projectile.rotation = projectile.velocity.ToRotation() + 0.85f;
					projectile.rotation += MathHelper.ToRadians(16);
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.70f;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 2; k++) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<SparkleG>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			//Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.70f;
			
		}
		
		public override bool PreKill(int timeLeft) {
			//projectile.type = ProjectileType;
			return true;
		}

		

	}
}