using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Projectiles
{
	public class ThermoProj : ModProjectile
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			projectile.damage = 6;
			projectile.width = 11;
			projectile.height = 11;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
		}

		public override void AI() {
			if (projectile.localAI[0] == 0f) {
				Main.PlaySound(SoundID.Item20, projectile.position);
				projectile.localAI[0] = 1f;
			}
			if (Main.rand.NextBool(1)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<ThermoDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			if (Main.rand.NextBool(2)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<ThermoDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextBool(1)) {
				target.AddBuff(BuffType<Buffs.EtherealFlames>(), 90, false);
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate = -1;
			projectile.maxPenetrate = -1;
			projectile.tileCollide = false;
			projectile.position += projectile.velocity;
			projectile.velocity = Vector2.Zero;
			projectile.timeLeft = 180;
			return false;
		}
	}
}