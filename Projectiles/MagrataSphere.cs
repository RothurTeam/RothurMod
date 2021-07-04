using RothurMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Projectiles
{
		
	public class MagrataSphere : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
		}
		
		public override void SetStaticDefaults() {
			DisplayName.AddTranslation(GameCulture.Russian, "Сфера Маграта");
		}

		public override void AI() {
			projectile.velocity.Y += projectile.ai[0];
			if (Main.rand.NextBool(13)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<CorFlame>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		
		if (projectile.localAI[0] == 0f) {
				Main.PlaySound(SoundID.Item20, projectile.position);
				projectile.localAI[0] = 1f;
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
				projectile.velocity *= 1f;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}
		

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 5; k++) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<CorFlame>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			//Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
			
			if (Main.rand.NextBool(2)) {
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextBool(2)) {
			}
		}
	}
}