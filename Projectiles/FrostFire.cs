using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles
{
	public class FrostFire : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 24;
			projectile.height = 24;
			projectile.friendly = true;
			projectile.magic = false;
			projectile.penetrate = 1;
			projectile.timeLeft = 90;
		}

		public override void AI() {
			//projectile.velocity.Y += projectile.ai[0];
			//if (Main.rand.NextBool(3)) {
				//Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<HellFlame>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			//}
		
		if (projectile.localAI[0] == 0f) {
				Main.PlaySound(SoundID.Item20, projectile.position);
				projectile.localAI[0] = 1f;
			}
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 205, default(Color), 1.7f);
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
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}
		

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
			
			if (Main.rand.NextBool(2)) {
				target.AddBuff(BuffID.Frostburn, 180, false);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextBool(2)) {
				target.AddBuff(BuffID.Frostburn, 180, false);
			}
		}
	}
}